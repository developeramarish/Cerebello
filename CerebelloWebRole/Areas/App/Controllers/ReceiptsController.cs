﻿using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Cerebello.Model;
using CerebelloWebRole.Areas.App.Models;
using CerebelloWebRole.Code;
using CerebelloWebRole.Code.iText;
using CerebelloWebRole.Code.Mvc;
using CerebelloWebRole.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace CerebelloWebRole.Areas.App.Controllers
{
    public class ReceiptsController : DoctorController
    {
        private ReceiptViewModel GetViewModel(Receipt receipt)
        {
            return new ReceiptViewModel()
            {
                Id = receipt.Id,
                PatientId = receipt.PatientId, // expected to be null here
                ReceiptMedicines = (from rm in receipt.ReceiptMedicines
                                    select new ReceiptMedicineViewModel()
                                    {
                                        Id = rm.Id,
                                        MedicineId = rm.Medicine.Id,
                                        MedicineText = rm.Medicine.Name,
                                        Observations = rm.Observations,
                                        Prescription = rm.Prescription,
                                        Quantity = rm.Quantity
                                    }).ToList()
            };
        }

        public ActionResult Details(int id)
        {
            var receipt = db.Receipts.Where(r => r.Id == id).First();
            return this.View(this.GetViewModel(receipt));
        }

        [HttpGet]
        public ActionResult Create(int patientId, string newKey)
        {
            return this.Edit(null, patientId);
        }

        [HttpPost]
        public ActionResult Create(ReceiptViewModel viewModel)
        {
            return this.Edit(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id, int? patientId)
        {
            ReceiptViewModel viewModel = null;

            if (id != null)
                viewModel = this.GetViewModel((from r in db.Receipts where r.Id == id select r).First());
            else
                viewModel = new ReceiptViewModel()
                {
                    Id = id,
                    PatientId = patientId
                };

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ReceiptViewModel formModel)
        {
            Receipt receipt = null;

            if (formModel.ReceiptMedicines == null)
                this.ModelState.AddModelError("Medicines", "A receita deve ter pelo menos um medicamento");

            // we cannot trust that the autocomplete has removed incorrect
            // value from the client. 
            for (var i = 0; i < formModel.ReceiptMedicines.Count; i++)
            {
                var medication = formModel.ReceiptMedicines[i];
                if (medication.MedicineId != null)
                    continue;
                // it's necessary to remove this value from the ModelState to
                // prevent it from "reappearing"
                // http://stackoverflow.com/questions/9163445/my-html-editors-are-ignoring-any-value-i-set-and-are-always-taking-their-values
                this.ModelState.Remove(string.Format("ReceiptMedicines[{0}].MedicineId", i));
                medication.MedicineText = string.Empty;
            }

            if (formModel.Id == null)
            {
                receipt = new Receipt()
                {
                    CreatedOn = this.GetUtcNow(),
                    PatientId = formModel.PatientId.Value
                };
                this.db.Receipts.AddObject(receipt);
            }
            else
                receipt = db.Receipts.Where(r => r.Id == formModel.Id).FirstOrDefault();

            if (formModel.ReceiptMedicines.Count == 0)
            {
                this.ModelState.AddModelError(
                    () => formModel.ReceiptMedicines,
                    "Não é possível criar uma receita sem medicamentos.");
            }

            if (this.ModelState.IsValid)
            {
                // Updating receipt medicines. This is only possible when view-model is valid,
                // otherwise this is going to throw exceptions.
                receipt.ReceiptMedicines.Update(
                        formModel.ReceiptMedicines,
                        (vm, m) => vm.Id == m.Id,
                        (vm, m) =>
                        {
                            m.MedicineId = vm.MedicineId.Value;
                            m.Quantity = vm.Quantity;
                            m.Observations = vm.Observations;
                            m.Prescription = vm.Prescription;
                        },
                        (m) => this.db.ReceiptMedicines.DeleteObject(m)
                    );

                db.SaveChanges();

                return View("details", this.GetViewModel(receipt));
            }
            return View("edit", formModel);
        }

        public ActionResult ReceiptMedicineEditor(ReceiptMedicineViewModel formModel)
        {
            return View(formModel);
        }

        public ActionResult ReceiptMedicineDetails(ReceiptMedicineViewModel formModel)
        {
            return View(formModel);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var receipt = db.Receipts.Where(m => m.Id == id).First();
            try
            {
                this.db.Receipts.DeleteObject(receipt);
                this.db.SaveChanges();
                return this.Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return this.Json(new { success = false, text = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public FileStreamResult ViewPDF(int id)
        {
            var documentSize = PageSize.A4;
            var document = new Document(PageSize.A4, 36, 36, 80, 80);
            var art = new Rectangle(50, 50, 545, 792);
            var documentStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, documentStream);
            writer.SetBoxSize("art", art);
            writer.PageEvent = new PdfHeaderFooter(this.Doctor.CFG_Documents);

            writer.CloseStream = false;

            document.Open();

            var receipt = this.db.Receipts.Include("ReceiptMedicines").Where(r => r.Id == id).First();

            var medicinesPerUsage = from rm in receipt.ReceiptMedicines group rm by rm.Medicine.Usage;
            foreach (var medicinesGrouped in medicinesPerUsage)
            {
                var usage = EnumHelper.GetText(medicinesGrouped.Key, typeof(TypeUsage));
                document.Add(new Paragraph("USO: " + usage, new Font(Font.FontFamily.HELVETICA, 12, Font.UNDERLINE, BaseColor.BLACK)));

                document.Add(Chunk.NEWLINE);

                List list = new List(List.UNORDERED);
                foreach (var receiptMedicine in medicinesGrouped)
                {
                    var li = new ListItem();
                    li.Add(new Phrase(receiptMedicine.Medicine.Name));
                    li.Add(new Chunk(new DottedLineSeparator()));
                    li.Add(new Phrase(receiptMedicine.Quantity));
                    li.Add(Chunk.NEWLINE);
                    li.Add(new Phrase(receiptMedicine.Prescription, new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.GRAY)));
                    li.Add(Chunk.NEWLINE);
                    li.Add(Chunk.NEWLINE);
                    list.Add(li);
                }
                document.Add(list);
            }

            document.Close();
            documentStream.Position = 0;
            return File(documentStream, "application/pdf");
        }
    }
}

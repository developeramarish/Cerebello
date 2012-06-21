﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CerebelloWebRole.Areas.App.Models;
using Cerebello.Model;
using CerebelloWebRole.Code.Controllers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.pdf.draw;
using CerebelloWebRole.Code.iText;
using CerebelloWebRole.Models;
using CerebelloWebRole.Code;
using CerebelloWebRole.Code.Mvc;

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

            if (this.ModelState.IsValid)
            {
                if (formModel.Id == null)
                {
                    receipt = new Receipt()
                    {
                        CreatedOn = DateTime.UtcNow,
                        PatientId = formModel.PatientId.Value
                    };
                    this.db.Receipts.AddObject(receipt);
                }
                else
                    receipt = db.Receipts.Where(r => r.Id == formModel.Id).FirstOrDefault();

                receipt.ReceiptMedicines.Update(
                        formModel.ReceiptMedicines,
                        (vm, m) => vm.Id == m.Id,
                        (vm, m) =>
                        {
                            m.MedicineId = vm.MedicineId;
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
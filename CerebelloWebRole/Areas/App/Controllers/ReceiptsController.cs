﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Cerebello.Model;
using CerebelloWebRole.Areas.App.Models;
using CerebelloWebRole.Code;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace CerebelloWebRole.Areas.App.Controllers
{
    public class ReceiptsController : DoctorController
    {
        public static ReceiptViewModel GetViewModel(Receipt receipt, Func<DateTime, DateTime> toLocal)
        {
            if (receipt == null)
                return new ReceiptViewModel();

            return new ReceiptViewModel
                {
                    Id = receipt.Id,
                    PatientId = receipt.PatientId, // expected to be null here
                    IssuanceDate = toLocal(receipt.IssuanceDate),
                    PrescriptionMedicines = (from rm in receipt.ReceiptMedicines
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
            var receipt = this.db.Receipts.First(r => r.Id == id);
            return this.View(GetViewModel(receipt, this.GetToLocalDateTimeConverter()));
        }

        [HttpGet]
        public ActionResult Create(int patientId, string newKey, int? y, int? m, int? d)
        {
            return this.Edit(null, patientId, y, m, d);
        }

        [HttpPost]
        public ActionResult Create(ReceiptViewModel[] receipts)
        {
            return this.Edit(receipts);
        }

        [HttpGet]
        public ActionResult Edit(int? id, int? patientId, int? y, int? m, int? d)
        {
            ReceiptViewModel viewModel;

            if (id != null)
                viewModel = GetViewModel(
                    (from r in this.db.Receipts where r.Id == id select r).First(),
                    this.GetToLocalDateTimeConverter());
            else
                viewModel = new ReceiptViewModel()
                {
                    Id = null,
                    PatientId = patientId,
                    IssuanceDate = DateTimeHelper.CreateDate(y, m, d) ?? this.GetPracticeLocalNow(),
                };

            return this.View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ReceiptViewModel[] receipts)
        {
            var formModel = receipts.Single();

            Receipt receipt;

            if (formModel.PrescriptionMedicines == null)
                this.ModelState.AddModelError("Medicines", "A receita deve ter pelo menos um medicamento");

            // we cannot trust that the autocomplete has removed incorrect
            // value from the client. 
            for (var i = 0; i < formModel.PrescriptionMedicines.Count; i++)
            {
                var medication = formModel.PrescriptionMedicines[i];
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
                Debug.Assert(formModel.PatientId != null, "formModel.PatientId != null");
                receipt = new Receipt()
                {
                    CreatedOn = this.GetUtcNow(),
                    PatientId = formModel.PatientId.Value,
                    PracticeId = this.DbUser.PracticeId,
                };
                this.db.Receipts.AddObject(receipt);
            }
            else
                receipt = this.db.Receipts.FirstOrDefault(r => r.Id == formModel.Id);

            if (formModel.PrescriptionMedicines.Count == 0)
            {
                this.ModelState.AddModelError(
                    () => formModel.PrescriptionMedicines,
                    "Não é possível criar uma receita sem medicamentos.");
            }

            if (this.ModelState.IsValid)
            {
                // Updating receipt medicines. This is only possible when view-model is valid,
                // otherwise this is going to throw exceptions.
                Debug.Assert(receipt != null, "receipt != null");
                receipt.ReceiptMedicines.Update(
                        formModel.PrescriptionMedicines,
                        (vm, m) => vm.Id == m.Id,
                        (vm, m) =>
                        {
                            m.PracticeId = this.DbPractice.Id;
                            m.MedicineId = vm.MedicineId.Value;
                            m.Quantity = vm.Quantity;
                            m.Observations = vm.Observations;
                            m.Prescription = vm.Prescription;
                        },
                        m => this.db.ReceiptMedicines.DeleteObject(m)
                    );

                receipt.Patient.IsBackedUp = false;
                receipt.IssuanceDate = this.ConvertToUtcDateTime(formModel.IssuanceDate.Value);
                this.db.SaveChanges();

                return this.View("Details", GetViewModel(receipt, this.GetToLocalDateTimeConverter()));
            }

            return this.View("Edit", formModel);
        }

        public ActionResult ReceiptMedicineEditor(ReceiptMedicineViewModel formModel)
        {
            return this.View(formModel);
        }

        public ActionResult ReceiptMedicineDetails(ReceiptMedicineViewModel formModel)
        {
            return this.View(formModel);
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            var receipt = this.db.Receipts.First(m => m.Id == id);
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
            var document = new Document(PageSize.A4, 36, 36, 80, 80);
            var art = new Rectangle(50, 50, 545, 792);
            var documentStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, documentStream);
            writer.SetBoxSize("art", art);
            writer.PageEvent = new PdfHeaderFooter(this.Doctor.CFG_Documents);

            writer.CloseStream = false;

            document.Open();

            var receipt = this.db.Receipts.Include("ReceiptMedicines").First(r => r.Id == id);

            var medicinesPerUsage = from rm in receipt.ReceiptMedicines group rm by rm.Medicine.Usage;
            foreach (var medicinesGrouped in medicinesPerUsage)
            {
                var usage = EnumHelper.GetText(medicinesGrouped.Key, typeof(TypeUsage));
                document.Add(new Paragraph("USO: " + usage, new Font(Font.FontFamily.HELVETICA, 12, Font.UNDERLINE, BaseColor.BLACK)));

                document.Add(Chunk.NEWLINE);

                var list = new List(List.UNORDERED);
                foreach (var li in medicinesGrouped.Select(receiptMedicine => new ListItem
                    {
                        new Phrase(receiptMedicine.Medicine.Name),
                        new Chunk(new DottedLineSeparator()),
                        new Phrase(receiptMedicine.Quantity),
                        Chunk.NEWLINE,
                        new Phrase(receiptMedicine.Prescription, new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.GRAY)),
                        Chunk.NEWLINE,
                        Chunk.NEWLINE
                    }))
                {
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

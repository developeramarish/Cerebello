﻿using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using Cerebello.Model;
using JetBrains.Annotations;

namespace CerebelloWebRole.Code
{
    /// <summary>
    /// ObjectContext wrapper with global rules of access to objects stored in the database.
    /// These rules are the most relaxed access rules.
    /// Most of them will only check for objects being of the same practice.
    /// Some may restrict a little more.
    /// </summary>
    public class CerebelloEntitiesAccessFilterWrapper : IDisposable
    {
        public CerebelloEntities innerDb { get; private set; }
        private User user;
        private Practice practice;

        public CerebelloEntitiesAccessFilterWrapper([NotNull] CerebelloEntities innerDb)
        {
            if (innerDb == null) throw new ArgumentNullException("innerDb");
            this.innerDb = innerDb;
        }

        public User SetCurrentUserById(int userId)
        {
            this.user = this.innerDb.Users.Include("Practice").SingleOrDefault(u => u.Id == userId);

            if (this.user != null)
                this.practice = this.user.Practice;

            this.AccountDisabled = this.practice == null || this.practice.AccountDisabled;

            return this.user;
        }

        private static readonly ConcurrentDictionary<Type, bool> hasPracticeId = new ConcurrentDictionary<Type, bool>();

        public int SaveChanges()
        {
            // checking changed elements to see if there is something wrong
            foreach (var objectStateEntry in this.innerDb.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                var obj = objectStateEntry.Entity;
                if (obj != null)
                {
                    // checking the PracticeId property
                    var type = obj.GetType();
                    if (hasPracticeId.GetOrAdd(
                        type,
                        t => t.GetProperty("PracticeId") != null && t.GetProperty("PracticeId").PropertyType == typeof(int)))
                    {
                        dynamic dyn = obj;
                        if ((int)dyn.PracticeId != this.practice.Id)
                            throw new Exception("Invalid value for 'PracticeId' property.");
                    }
                }
            }

            return this.innerDb.SaveChanges();
        }

        public DbConnection Connection { get { return this.innerDb.Connection; } }

        public bool AccountDisabled { get; set; }

        public FilteredObjectSetWrapper<AccountContract> AccountContracts
        {
            get { return new FilteredObjectSetWrapper<AccountContract>(this.innerDb.AccountContracts, s => s.Where(ac => ac.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicineActiveIngredient> ActiveIngredients
        {
            get { return new FilteredObjectSetWrapper<MedicineActiveIngredient>(this.innerDb.MedicineActiveIngredients, s => s.Where(ai => ai.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Address> Addresses
        {
            get { return new FilteredObjectSetWrapper<Address>(this.innerDb.Addresses, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Administrator> Administrators
        {
            get { return new FilteredObjectSetWrapper<Administrator>(this.innerDb.Administrators, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        // todo: rename table to Anamnesis, and plural is Anamneses (like Diagnosis and Diagnoses)
        public FilteredObjectSetWrapper<Anamnese> Anamnese
        {
            get { return new FilteredObjectSetWrapper<Anamnese>(this.innerDb.Anamnese, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<PhysicalExamination> PhysicalExaminations
        {
            get { return new FilteredObjectSetWrapper<PhysicalExamination>(this.innerDb.PhysicalExaminations, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Appointment> Appointments
        {
            get { return new FilteredObjectSetWrapper<Appointment>(this.innerDb.Appointments, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<CFG_DayOff> CFG_DayOff
        {
            get { return new FilteredObjectSetWrapper<CFG_DayOff>(this.innerDb.CFG_DayOff, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<CFG_Documents> CFG_Documents
        {
            get { return new FilteredObjectSetWrapper<CFG_Documents>(this.innerDb.CFG_Documents, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<CFG_Schedule> CFG_Schedule
        {
            get { return new FilteredObjectSetWrapper<CFG_Schedule>(this.innerDb.CFG_Schedule, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Cerebello.Model.ChatMessage> ChatMessages
        {
            get { return new FilteredObjectSetWrapper<Cerebello.Model.ChatMessage>(this.innerDb.ChatMessages, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Diagnosis> Diagnoses
        {
            get { return new FilteredObjectSetWrapper<Diagnosis>(this.innerDb.Diagnoses, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<FileMetadata> FileMetadatas
        {
            get { return new FilteredObjectSetWrapper<FileMetadata>(this.innerDb.FileMetadatas, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<PatientFile> PatientFiles
        {
            get { return new FilteredObjectSetWrapper<PatientFile>(this.innerDb.PatientFiles, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<PatientFileGroup> PatientFileGroups
        {
            get { return new FilteredObjectSetWrapper<PatientFileGroup>(this.innerDb.PatientFileGroups, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Doctor> Doctors
        {
            get { return new FilteredObjectSetWrapper<Doctor>(this.innerDb.Doctors, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<ExaminationRequest> ExaminationRequests
        {
            get { return new FilteredObjectSetWrapper<ExaminationRequest>(this.innerDb.ExaminationRequests, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<ExaminationResult> ExaminationResults
        {
            get { return new FilteredObjectSetWrapper<ExaminationResult>(this.innerDb.ExaminationResults, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public ObjectSet<GLB_Token> GLB_Token
        {
            get { return this.innerDb.GLB_Token; }
        }

        public FilteredObjectSetWrapper<HealthInsurance> HealthInsurances
        {
            get { return new FilteredObjectSetWrapper<HealthInsurance>(this.innerDb.HealthInsurances, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public ObjectSet<Holiday> Holidays
        {
            get { return this.innerDb.Holidays; }
        }

        public FilteredObjectSetWrapper<Laboratory> Laboratories
        {
            get { return new FilteredObjectSetWrapper<Laboratory>(this.innerDb.Laboratories, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Leaflet> Leaflets
        {
            get { return new FilteredObjectSetWrapper<Leaflet>(this.innerDb.Leaflets, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicalCertificate> MedicalCertificates
        {
            get { return new FilteredObjectSetWrapper<MedicalCertificate>(this.innerDb.MedicalCertificates, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicalCertificateField> MedicalCertificateFields
        {
            get { return new FilteredObjectSetWrapper<MedicalCertificateField>(this.innerDb.MedicalCertificateFields, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Medicine> Medicines
        {
            get { return new FilteredObjectSetWrapper<Medicine>(this.innerDb.Medicines, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<ModelMedicalCertificate> ModelMedicalCertificates
        {
            get { return new FilteredObjectSetWrapper<ModelMedicalCertificate>(this.innerDb.ModelMedicalCertificates, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<ModelMedicalCertificateField> ModelMedicalCertificateFields
        {
            get { return new FilteredObjectSetWrapper<ModelMedicalCertificateField>(this.innerDb.ModelMedicalCertificateFields, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Patient> Patients
        {
            get { return new FilteredObjectSetWrapper<Patient>(this.innerDb.Patients, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Person> Persons
        {
            get { return new FilteredObjectSetWrapper<Person>(this.innerDb.People, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public ObjectSet<Practice> Practices
        {
            get { return this.innerDb.Practices; }
        }

        public FilteredObjectSetWrapper<Receipt> Receipts
        {
            get { return new FilteredObjectSetWrapper<Receipt>(this.innerDb.Receipts, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<ReceiptMedicine> ReceiptMedicines
        {
            get { return new FilteredObjectSetWrapper<ReceiptMedicine>(this.innerDb.ReceiptMedicines, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<Secretary> Secretaries
        {
            get { return new FilteredObjectSetWrapper<Secretary>(this.innerDb.Secretaries, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<DiagnosticHypothesis> DiagnosticHypotheses
        {
            get { return new FilteredObjectSetWrapper<DiagnosticHypothesis>(this.innerDb.DiagnosticHypotheses, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicalRecord> MedicalRecords
        {
            get { return new FilteredObjectSetWrapper<MedicalRecord>(this.innerDb.MedicalRecords, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicalRecordField> MedicalRecordFields
        {
            get { return new FilteredObjectSetWrapper<MedicalRecordField>(this.innerDb.MedicalRecordFields, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<MedicalRecordFieldValue> MedicalRecordFieldValues
        {
            get { return new FilteredObjectSetWrapper<MedicalRecordFieldValue>(this.innerDb.MedicalRecordFieldValues, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        /// <summary>
        /// Gets the users of the current account, but only if the account is enabled.
        /// When disabled, none will be returned. This kills app usage when account is disabled.
        /// </summary>
        public FilteredObjectSetWrapper<User> Users
        {
            get { return new FilteredObjectSetWrapper<User>(this.innerDb.Users, s => s.Where(a => a.PracticeId == this.user.PracticeId && !this.AccountDisabled)); }
        }

        public FilteredObjectSetWrapper<Notification> Notifications
        {
            get { return new FilteredObjectSetWrapper<Notification>(this.innerDb.Notifications, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<GoogleUserAccoutInfo> GoogleUserAccountInfo
        {
            get { return new FilteredObjectSetWrapper<GoogleUserAccoutInfo>(this.innerDb.GoogleUserAccoutInfoes, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<GoogleDrivePracticeInfo> GoogleDrivePracticeInfo
        {
            get { return new FilteredObjectSetWrapper<GoogleDrivePracticeInfo>(this.innerDb.GoogleDrivePracticeInfoes, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public FilteredObjectSetWrapper<GoogleDrivePatientInfo> GoogleDrivePatientInfo
        {
            get { return new FilteredObjectSetWrapper<GoogleDrivePatientInfo>(this.innerDb.GoogleDrivePatientInfoes, s => s.Where(a => a.PracticeId == this.user.PracticeId)); }
        }

        public ObjectSet<SYS_ActiveIngredient> SYS_ActiveIngredient
        {
            get { return this.innerDb.SYS_ActiveIngredient; }
        }

        public ObjectSet<SYS_Cid10> SYS_Cid10
        {
            get { return this.innerDb.SYS_Cid10; }
        }

        public ObjectSet<SYS_ContractType> SYS_ContractType
        {
            get { return this.innerDb.SYS_ContractType; }
        }

        public ObjectSet<SYS_Holiday> SYS_Holiday
        {
            get { return this.innerDb.SYS_Holiday; }
        }

        public ObjectSet<SYS_Laboratory> SYS_Laboratory
        {
            get { return this.innerDb.SYS_Laboratory; }
        }

        public ObjectSet<SYS_Leaflet> SYS_Leaflet
        {
            get { return this.innerDb.SYS_Leaflet; }
        }

        public ObjectSet<SYS_MedicalEntity> SYS_MedicalEntity
        {
            get { return this.innerDb.SYS_MedicalEntity; }
        }

        public ObjectSet<SYS_MedicalProcedure> SYS_MedicalProcedure
        {
            get { return this.innerDb.SYS_MedicalProcedure; }
        }

        public ObjectSet<SYS_MedicalSpecialty> SYS_MedicalSpecialty
        {
            get { return this.innerDb.SYS_MedicalSpecialty; }
        }

        public ObjectSet<SYS_Medicine> SYS_Medicine
        {
            get { return this.innerDb.SYS_Medicine; }
        }

        

        public void Dispose()
        {
            this.innerDb.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patient_Record.Areas.Patient_Settings.ViewModel;
using Patient_Record.Models;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public class SQLPatientRepository : IPatientRepository
    {
        private readonly AppDBContext context;
        public SQLPatientRepository(AppDBContext context)
        {
            this.context = context;
        }

        public Patient Add(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient_Records Add(Patient_Records patient_Records)
        {
            context.GetPatient_Records.Add(patient_Records);
            context.SaveChanges();
            return patient_Records;
        }

        public Patient Delete(int id)
        {
            Patient patient = context.Patients.Find(id);
            if(patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        public Patient_Records DeleteRecord(int id)
        {
            Patient_Records patient = context.GetPatient_Records.Find(id);
            if (patient != null)
            {
                context.GetPatient_Records.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        public IEnumerable<Patient> GetAllPatient()
        {
            return context.Patients;
        }

        public IEnumerable<Patient_Records> GetAllRecoeds()
        {
            return context.GetPatient_Records;
        }

        public Patient GetPatient(int id)
        {
            return context.Patients.Find(id);
        }

        public Patient_Records GetPatientRecord(int id)
        {
            return context.GetPatient_Records.Find(id);
        }

        public Patient Update(Patient patientUpdate)
        {
            var patient = context.Patients.Attach(patientUpdate);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return patientUpdate;
        }

        public Patient_Records Update(Patient_Records updateRecord)
        {
            var patient = context.GetPatient_Records.Attach(updateRecord);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateRecord;
        }

        public List<PatientList> PatientList()
        {
            var result = from patient in context.Patients
                         join records in context.GetPatient_Records on patient.Patient_Id equals records.Patient_Id
                         select new
                         {
                             Patient_Id = patient.Patient_Id,
                             Patient_Name = patient.Patient_Name,
                             Patient_DOB = patient.Patient_DOB,
                             Patient_Record_Id = records.Patient_Record_Id
                         };
            List<PatientList> patientLists = new List<PatientList>();
            foreach (var res in result)
            {
                PatientList patient = new PatientList();
                patient.Patient_Id = res.Patient_Id;
                patient.Patient_Name = res.Patient_Name;
                patient.Patient_DOB = res.Patient_DOB;
                patient.Patient_Record_Id = res.Patient_Record_Id;
                patientLists.Add(patient);
            }
            return patientLists;
        }

        public List<PatientStatistics> PatientStatistics()
        {
            var result = from patient in context.Patients
                         join records in context.GetPatient_Records on patient.Patient_Id equals records.Patient_Id
                         select new
                         {
                             Patient_Id = patient.Patient_Id,
                             Patient_Name = patient.Patient_Name,
                             Patient_DOB = patient.Patient_DOB,
                             Patient_Bills = records.Bill
                         };
            List<PatientStatistics> patientStatistics = new List<PatientStatistics>();

            return patientStatistics;
        }
    }
}

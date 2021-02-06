using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<Patient> GetAllPatient()
        {
            return context.Patients;
        }

        public Patient GetPatient(int id)
        {
            return context.Patients.Find(id);
        }

        public Patient Update(Patient patientUpdate)
        {
            var patient = context.Patients.Attach(patientUpdate);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return patientUpdate;
        }
    }
}

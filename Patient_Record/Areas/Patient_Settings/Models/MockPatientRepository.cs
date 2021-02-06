/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public class MockPatientRepository : IPatientRepository
    {
        private List<Patient> _patientList;
        public MockPatientRepository()
        {
            _patientList = new List<Patient>()
            {
                new Patient(){ Patient_Name="Mohammad", Patient_Official_ID = 142548, Patient_Email = "m@m.com" }
            };
        }

        public Patient Add(Patient patient)
        {
            _patientList.Add(patient);
            return patient;
        }

        public Patient Delete(int id)
        {
            Patient patient = _patientList.FirstOrDefault(e => e.Patient_Id == id);
            if (patient != null)
            {
                _patientList.Remove(patient);
            }
            return patient;
        }

        public IEnumerable<Patient> GetAllPatient()
        {
            return _patientList;
        }

        public Patient GetPatient(int id)
        {
            
            return _patientList.FirstOrDefault(e => e.Patient_Id == id);
        }

        public Patient Update(Patient patientUpdate)
        {
            Patient patient = _patientList.FirstOrDefault(e => e.Patient_Id == patientUpdate.Patient_Id);
            if (patient != null)
            {
                patient.Patient_Name = patientUpdate.Patient_Name;
                patient.Patient_Email = patientUpdate.Patient_Email;
                patient.Patient_Official_ID = patientUpdate.Patient_Official_ID;
                patient.Patient_DOB = patientUpdate.Patient_DOB;
            }
            return patient;
        }
    }
}
*/
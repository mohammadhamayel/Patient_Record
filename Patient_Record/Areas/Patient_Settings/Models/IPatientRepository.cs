using Patient_Record.Areas.Patient_Settings.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);
        IEnumerable<Patient> GetAllPatient();
        Patient Add(Patient patient);
        Patient Update(Patient patient);
        Patient Delete(int id);

        List<PatientList> PatientList();
        List<PatientStatistics> PatientStatistics();

        IEnumerable<Patient_Records> GetAllRecoeds();
        Patient_Records GetPatientRecord(int id);
        Patient_Records Add(Patient_Records patient_Records);
        Patient_Records Update(Patient_Records patient);
        Patient_Records DeleteRecord(int id);


    }
}

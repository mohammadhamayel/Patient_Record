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
    }
}

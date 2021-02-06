using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.ViewModel
{
    public class PatientList
    {
        [DisplayName("Patient Id")]
        public int Patient_Id { get; set; }
        [DisplayName("Patient Name")]
        public String Patient_Name { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime? Patient_DOB { get; set; }
        [DisplayName("Last Patient Record")]
        public int Patient_Record_Id { get; set; }
    }
}

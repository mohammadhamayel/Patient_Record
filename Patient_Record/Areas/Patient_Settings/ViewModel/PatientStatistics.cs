using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.ViewModel
{
    public class PatientStatistics
    {
        public int Patient_Id { get; set; }
        public string Patient_Name { get; set; }
        public string Patient_Age { get; set; }
        public float Patient_Avg_Bills { get; set; }
        public float Patient_Avg_Bills_Outlier { get; set; }
        public int Patient_5th_Record { get; set; }
        public string Patient_Similars { get; set; }
        public string Months_Visit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public class Patient
    {
        [Key]
        public int Patient_Id { get; set; }
        [Required]
        public string Patient_Name { get; set; }
        [Required]
        ///unique
        public int Patient_Official_ID { get; set; }

        public DateTime Patient_DOB { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9-]+\.[a-zA-Z]", ErrorMessage = "Please enter a valid email which ends with @mit.edu")]
        public string Patient_Email { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Range(100000000,999999999)]
        public int Patient_Official_ID { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        [Column(TypeName = "date")]
        public DateTime? Patient_DOB { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Patient_Email { get; set; }

    }
}

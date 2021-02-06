using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public class Patient_Records
    {
        [Key]
        public int Patient_Record_Id { get; set; }
        [Required]
        [ForeignKey("Patient_Id")]
        public int Patient_Id { get; set; }
        [Required]
        public string Disease_Name { get; set; }
        [Timestamp]
        [DisplayName("Time od Entry")]
        public byte[] Time_Of_Entry { get; set; }

        public string Description  { get; set; }
        public float Bill  { get; set; }

    }
}

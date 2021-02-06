using Microsoft.EntityFrameworkCore;
using Patient_Record.Areas.Patient_Settings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient_Record.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Patient_Records> GetPatient_Records { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Patient>()
                .HasIndex(u => u.Patient_Official_ID)
                .IsUnique();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Patient_Record.Areas.Patient_Settings.ViewModel;
using Patient_Record.Models;

namespace Patient_Record.Areas.Patient_Settings.Models
{
    public class SQLPatientRepository : IPatientRepository
    {
        private readonly AppDBContext context;
        private readonly IConfiguration configuration;
        string conString = "";
        SqlConnection connection;
        public SQLPatientRepository(AppDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
            conString = configuration.GetConnectionString("PatientDbConnection");
            connection = new SqlConnection(conString);
        }

        public Patient Add(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        public Patient_Records Add(Patient_Records patient_Records)
        {
            context.GetPatient_Records.Add(patient_Records);
            context.SaveChanges();
            return patient_Records;
        }

        public Patient Delete(int id)
        {
            Patient patient = context.Patients.Find(id);
            if (patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        public Patient_Records DeleteRecord(int id)
        {
            Patient_Records patient = context.GetPatient_Records.Find(id);
            if (patient != null)
            {
                context.GetPatient_Records.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        public IEnumerable<Patient> GetAllPatient()
        {
            return context.Patients;
        }

        public IEnumerable<Patient_Records> GetAllRecoeds()
        {
            return context.GetPatient_Records;
        }

        public Patient GetPatient(int id)
        {
            return context.Patients.Find(id);
        }

        public Patient_Records GetPatientRecord(int id)
        {
            return context.GetPatient_Records.Find(id);
        }

        public Patient Update(Patient patientUpdate)
        {
            var patient = context.Patients.Attach(patientUpdate);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return patientUpdate;
        }

        public Patient_Records Update(Patient_Records updateRecord)
        {
            var patient = context.GetPatient_Records.Attach(updateRecord);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateRecord;
        }

        public List<PatientList> PatientList()
        {
            var result = from patient in context.Patients
                         join records in context.GetPatient_Records on patient.Patient_Id equals records.Patient_Id
                         select new
                         {
                             Patient_Id = patient.Patient_Id,
                             Patient_Name = patient.Patient_Name,
                             Patient_DOB = patient.Patient_DOB,
                             Patient_Record_Id = records.Patient_Record_Id
                         };
            List<PatientList> patientLists = new List<PatientList>();
            foreach (var res in result)
            {
                PatientList patient = new PatientList();
                patient.Patient_Id = res.Patient_Id;
                patient.Patient_Name = res.Patient_Name;
                patient.Patient_DOB = res.Patient_DOB;
                patient.Patient_Record_Id = res.Patient_Record_Id;
                patientLists.Add(patient);
            }
            return patientLists;
        }

        public List<PatientStatistics> PatientStatistics()
        {
            connection.Open();

            SqlCommand command = new SqlCommand("select Patients.Patient_Name,Patients.Patient_Id, Patients.Patient_DOB, AVG(GetPatient_Records.Bill) from Patients join GetPatient_Records on Patients.Patient_Id = GetPatient_Records.Patient_Id "
                +"group by Patients.Patient_Name, Patients.Patient_DOB, Patients.Patient_Id", connection);
            var reader = command.ExecuteReader();

            List<PatientStatistics> patientStatistics = new List<PatientStatistics>();

            while (reader.Read())
            {
                PatientStatistics patient = new PatientStatistics();
                patient.Patient_Name = reader.GetValue(0).ToString();
                patient.Patient_Id = Int32.Parse(reader.GetValue(1).ToString());
                var Age = CalculateAge(Convert.ToDateTime(reader.GetValue(2).ToString()));
                patient.Patient_Age = Age.ToString();
                patient.Patient_Avg_Bills = float.Parse(reader.GetValue(3).ToString());
                patient.Patient_Avg_Bills_Outlier = float.Parse(reader.GetValue(3).ToString());
                SqlCommand command1 = new SqlCommand("SELECT Patient_Record_Id FROM("+
                                    "SELECT Patient_Record_Id, ROW_NUMBER() OVER(ORDER BY Patient_Record_Id) AS RowNum"+
                                    " FROM GetPatient_Records join Patients on Patients.Patient_Id = GetPatient_Records.Patient_Id"+
                                    " where GetPatient_Records.Patient_Id = "+ Int32.Parse(reader.GetValue(1).ToString())+  
                                " ) AS MyDerivedTable" +
                                " WHERE MyDerivedTable.RowNum = 5", connection);
                var reader2 = command1.ExecuteReader();
                if (reader2.Read())
                {
                    patient.Patient_5th_Record = Int32.Parse(reader2.GetValue(0).ToString());
                }
                else
                {
                    patient.Patient_5th_Record = 0;
                }
                SqlCommand command2 = new SqlCommand("select Patient_Id from ("+
                                                " select distinct t1.Patient_Id, "+
                                                  " STUFF((SELECT distinct '' + t2.Disease_Name "+
                                                       "  from GetPatient_Records t2 "+
                                                       "  where t1.Patient_Id = t2.Patient_Id "+
                                                           " FOR XML PATH(''), TYPE "+
                                                          "  ).value('.', 'NVARCHAR(MAX)') "+
                                                     "   , 1, 0, '') data"+
                                                 "  from GetPatient_Records t1) as diseaseTb "+
                                               " where diseaseTb.data = (select data from( "+
                                                                                   " select distinct t1.Patient_Id,"+
                                                                                    "  STUFF((SELECT distinct '' + t2.Disease_Name"+
                                                                                            " from GetPatient_Records t2"+
                                                                                            " where t1.Patient_Id = t2.Patient_Id"+
                                                                                             "   FOR XML PATH(''), TYPE"+
                                                                                             "   ).value('.', 'NVARCHAR(MAX)')"+
                                                                                            ",1,0,'') data"+
                                   " from GetPatient_Records t1)AS tempTb where tempTb.Patient_Id = 3) And Patient_Id != 3", connection);
                var reader3 = command2.ExecuteReader();
                if (reader3.Read())
                {
                    patient.Patient_Similars = reader3.GetValue(0).ToString();
                }
                else
                {
                    patient.Patient_Similars = "";
                }
                SqlCommand command3 = new SqlCommand("select (pMonth) from( "+
                                    "select Count(Patient_Id) as Cnt, MONTH(Patient_DOB) as pMonth, Patient_Id, row_number() over(order by Patient_Id desc) as roworder "+
                                    " from Patients " +
                                    " where Patient_Id = 3"+
                                    " group by MONTH(Patient_DOB), Patient_Id"+
                                    " ) as mCnt "+
                                    " where mCnt.roworder = 1", connection);
                var reader4 = command3.ExecuteReader();
                if (reader4.Read())
                {
                    patient.Months_Visit = getMonthName(Int32.Parse(reader4.GetValue(0).ToString()));
                }
                else
                {
                    patient.Months_Visit = "";
                }
                patientStatistics.Add(patient);
            }
            connection.Close();
            return patientStatistics;
        }

        private string getMonthName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMMM");
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear && age > 0)
                age = age - 1;

            return age;
        }
    }
}
/*
 var result = from patient in context.Patients
                 join records in context.GetPatient_Records on patient.Patient_Id equals records.Patient_Id                         
                 group new { patient, records } by new { patient.Patient_Name,patient.Patient_Id,patient.Patient_DOB } into pg
                 let patientGroup = pg.FirstOrDefault()
                 let pati = patientGroup.patient
                 let rec = patientGroup.records
                 let avg = pg.Average(m => m.records.Bill)
                 select new 
                 {
                     Patient_Id = pati.Patient_Id,
                     Patient_Name = pati.Patient_Name,
                     Patient_DOB = pati.Patient_DOB,
                     Patient_Bills = avg
                 };
foreach (var res in result)
    {
        PatientStatistics patient = new PatientStatistics();
        patient.Patient_Name = res.Patient_Name;
        patient.Patient_Id = res.Patient_Id;
        patient.Patient_Age = res.Patient_DOB.ToString();

        var pati = context.Patients.FromSqlRaw("SELECT Patient_Record_Id FROM("+
        "SELECT Patient_Record_Id, ROW_NUMBER() OVER(ORDER BY Patient_Record_Id) AS RowNum"+
        "FROM GetPatient_Records join Patients on Patients.Patient_Id = GetPatient_Records.Patient_Id"+
        "where GetPatient_Records.Patient_Id = "+ res.Patient_Id +
        ") AS MyDerivedTable WHERE MyDerivedTable.RowNum = 5 ")
                        .ToList();
        patient.Patient_Avg_Bills = 50;
        patient.Patient_Avg_Bills_Outlier = 52;
        patient.Patient_5th_Record = 0;
        patient.Months_Visit = "March";
        patientStatistics.Add(patient);


    }
 */
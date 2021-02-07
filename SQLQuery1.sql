select Patient_Id, Patient_DOB from Patients

SELECT DATEDIFF(yy,GETDATE(),Patient_DOB) from Patients;

SELECT DATEDIFF(year, CAST(GETDATE() AS DATE), (select CAST(Patient_DOB AS DATE) as pdate from Patients where Patient_Id = 3)) ;

SELECT DATEDIFF(year, (select CAST(Patient_DOB AS DATE) from Patients where Patient_Id = 3), CAST(GETDATE() AS DATE)) AS DateDiff;

select Patients.Patient_Name,Patients.Patient_Id, Patients.Patient_DOB, AVG(GetPatient_Records.Bill) from Patients join GetPatient_Records on Patients.Patient_Id = GetPatient_Records.Patient_Id 
group by Patients.Patient_Name,Patients.Patient_DOB,Patients.Patient_Id

  SELECT Patient_Record_Id 
FROM (
    SELECT Patient_Record_Id ,ROW_NUMBER() OVER (ORDER BY Patient_Record_Id) AS RowNum
    FROM GetPatient_Records join Patients on Patients.Patient_Id = GetPatient_Records.Patient_Id
    where GetPatient_Records.Patient_Id = 3
) AS MyDerivedTable
WHERE MyDerivedTable.RowNum = 5 ;


select Patient_Id from (
select distinct t1.Patient_Id,
  STUFF((SELECT distinct '' + t2.Disease_Name
         from GetPatient_Records t2
         where t1.Patient_Id = t2.Patient_Id
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,0,'') data
from GetPatient_Records t1) as diseaseTb
where diseaseTb.data = (select data from(
                                    select distinct t1.Patient_Id,
                                      STUFF((SELECT distinct '' + t2.Disease_Name
                                             from GetPatient_Records t2
                                             where t1.Patient_Id = t2.Patient_Id
                                                FOR XML PATH(''), TYPE
                                                ).value('.', 'NVARCHAR(MAX)') 
                                            ,1,0,'') data
                                    from GetPatient_Records t1)AS tempTb where tempTb.Patient_Id = 3) And Patient_Id != 3


select (pMonth) from(
select Count(Patient_Id) as Cnt, MONTH(Patient_DOB) as pMonth, Patient_Id,row_number() over( order by Patient_Id desc) as roworder
from Patients
where Patient_Id = 3
group by MONTH(Patient_DOB),Patient_Id
) as mCnt
where mCnt.roworder = 1

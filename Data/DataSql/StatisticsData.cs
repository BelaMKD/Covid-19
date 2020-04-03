using BusinessLayer;
using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class StatisticsData : IStatisticsService
    {
        private readonly AppDbContext dbContext;

        public StatisticsData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Diagnosis> Deaths()
        {
            return dbContext.Diagnoses
               .Where(x => x.IsPositive == true && x.Death == true)
               .Include(x => x.Patient)
               .ThenInclude(p => p.Hospital)
               .Include(x => x.DiagnosisViruses)
               .ThenInclude(z => z.Virus)
               .ToList();
        }

        public IEnumerable<Diagnosis> GetDiagnosesWithCorona()
        {
            return dbContext.Diagnoses
                .Where(x => x.IsPositive == true)
                .Include(x => x.Patient)
                .ThenInclude(p => p.Hospital)
                .Include(x => x.DiagnosisViruses)
                .ThenInclude(z => z.Virus)
                .ToList();
        }

        public IEnumerable<Diagnosis> Recovered()
        {
            return dbContext.Diagnoses
               .Where(x => x.IsPositive == true && x.Recovered == true)
               .ToList();
        }
        public IEnumerable<Patient> GetPatiens()
        {
            return dbContext.Patients
                .Include(p => p.Diagnosis)
                .Include(p => p.Hospital)
                .ToList();
        }
        
        public IEnumerable<PatientInfo> GetPatientsInfo()
        {
            return dbContext.Patients
                .Include(p => p.Diagnosis)
                .Select(p => new PatientInfo {Id = p.Id, PatinetName = p.Name, Gender = p.Gender.ToString(), Birthday = p.BirthDate
                , Hospital = new Hospital {Id = p.Hospital.Id, Name = p.Hospital.Name, City = p.Hospital.City}, Diagnoses = p.Diagnosis })
                .ToList();


        }

    }
}

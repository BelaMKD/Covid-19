using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class DiagnosisData : IDiagnosisService
    {
        private readonly AppDbContext dbContext;

        public DiagnosisData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Diagnosis CreateDiagnosis(Diagnosis diagnosis)
        {
            var temp = dbContext.Diagnoses.Add(diagnosis);
            return temp.Entity;
        }

        public Diagnosis DeleteDiagnosis(int id)
        {
            var temp = dbContext.Diagnoses.SingleOrDefault(d => d.Id == id);
            if(temp != null)
            {
                dbContext.Diagnoses.Remove(temp);
            }
            return temp;
        }

        public IEnumerable<Diagnosis> GetDiagnoses()
        {
            return dbContext.Diagnoses
                .ToList();
        }

        public Diagnosis GetDiagnosisById(int id)
        {
            return dbContext.Diagnoses
                .Include(d => d.Patient)
                .Include(d => d.DiagnosisViruses)
                .SingleOrDefault(x => x.Id == id);
        }

        public Diagnosis UpdateDiagnosis(Diagnosis diagnosis)
        {
            dbContext.Diagnoses.Update(diagnosis);
            return diagnosis;
        }
        public IEnumerable<Diagnosis> GetDiagnosesWithCorona()
        {
            return dbContext.Diagnoses
                .Where(x => x.IsPositive == true)
                .Include(x => x.Patient)
                .Include(x => x.DiagnosisViruses)
                .ThenInclude(z => z.Virus)
                .ToList();
        }
    }
}

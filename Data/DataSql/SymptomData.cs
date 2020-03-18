using Data.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class SymptomData : ISymptomService
    {
        private readonly AppDbContext dbContext;

        public SymptomData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Symptom GetSymptomById(int id)
        {
            return dbContext.Symptoms
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Symptom> GetSymptoms()
        {
            return dbContext.Symptoms
                .ToList();
        }
    }
}

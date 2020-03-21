using Data.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataSql
{
    public class DiagnosisVirusData : IDiagnosesVirusesService
    {
        private readonly AppDbContext dbContext;

        public DiagnosisVirusData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddToBase(DiagnosisVirus diagnosisVirus)
        {
            dbContext.DiagnosisViruses.Add(diagnosisVirus);
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

       
    }
}

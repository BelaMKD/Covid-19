using Data.IServices;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataSql
{
    public class PatientData : IPatientService
    {
        private readonly AppDbContext dbContext;

        public PatientData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Patient CreatePatient(Patient patient)
        {
            var temp = dbContext.Patients.Add(patient);
            return temp.Entity;
        }
    }
}

using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Patient DeletePatient(int id)
        {
            var temp = dbContext.Patients
                //.Include(x=>x.Diagnosis)
                //.ThenInclude(w=>w.Viruses)
                .SingleOrDefault(p => p.Id == id);
            if(temp != null)
            {
                dbContext.Patients.Remove(temp);
            }
            return temp;
        }

        public Patient EditPatient(Patient patient)
        {
            dbContext.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return patient;
        }

        public Patient GetPatientById(int id)
        {
            return dbContext.Patients
                .Include(x=>x.Diagnosis)
                .ThenInclude(w=>w.Viruses)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}

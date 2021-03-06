﻿using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class HospitalData :IHospitalService
    {
        private readonly AppDbContext dbContext;

        public HospitalData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Hospital CreateHospital(Hospital hospital)
        {
            var temp = dbContext.Hospitals.Add(hospital);
            return temp.Entity;
        }

        public Hospital DeleteHospital(int id)
        {
            var temp = dbContext.Hospitals.SingleOrDefault(h => h.Id == id);
            if(temp != null)
            {
                dbContext.Hospitals.Remove(temp);
            }
            return temp;
        }

        public Hospital GetHospitalById(int id)
        {
            return dbContext.Hospitals
                .Include(h => h.Patients)
                .SingleOrDefault(h => h.Id == id);
        }

        public IEnumerable<Hospital> GetHospitals()
        {
            return dbContext.Hospitals
                .OrderBy(h => h.Id)
                .ToList();
        }

        public Hospital UpdateHospital(Hospital hospital)
        {
            dbContext.Entry(hospital).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return hospital;
        }
    }
}

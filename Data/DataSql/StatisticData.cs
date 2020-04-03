using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class StatisticData : IStatisticService
    {
        private readonly AppDbContext dbContext;
        private readonly IHospitalService hospitalService;

        public StatisticData(AppDbContext dbContext, IHospitalService hospitalService)
        {
            this.dbContext = dbContext;
            this.hospitalService = hospitalService;
        }


        public IEnumerable<PatientInfo> GetPatients()
        {
            return dbContext.Patients
                .Select(x => new PatientInfo
                { 
                    Id=x.Id,
                    Name = x.Name,
                    Gender = Convert.ToInt32(x.Gender),
                    BirthDate = x.BirthDate,
                    City = x.City,
                    Hospital = new Hospital
                    {
                        Id = x.Hospital.Id,
                        Name = x.Hospital.Name,
                        City = x.Hospital.City
                    },
                    Diagnoses = x.Diagnosis
                    
                })
                .ToList();
        }
        public class PatientInfo
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string City { get; set; }
            public Hospital Hospital { get; set; }
            public List<Diagnosis> Diagnoses { get; set; }
            public PatientInfo()
            {
                Diagnoses = new List<Diagnosis>();     
            }
        }
    }
}

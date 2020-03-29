using Data.IServices;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DataSql
{
    public class VirusData : IVirusService
    {
        private readonly AppDbContext dbContext;

        public VirusData(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Virus CreateVirus(Virus virus)
        {
            dbContext.Viruses.Add(virus);
            return virus;
        }

        public Virus GetVirusById(int id)
        {
            return dbContext.Viruses
                .Include(x=>x.VirusSymptoms)
                .ThenInclude(z=>z.Symptom)
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Virus> GetViruses()
        {
            return dbContext.Viruses
                .Include(x=>x.VirusSymptoms)
                .ThenInclude(z=>z.Symptom)
                .ToList();
        }

        public Virus UpdateVirus(Virus virus)
        {
            dbContext.Update(virus);
            return virus;
        }
        public Virus RemoveVirus(int id)
        {
            var tempVirus = dbContext.Viruses.SingleOrDefault(x => x.Id == id);
            if (tempVirus!=null)
            {
                dbContext.Viruses.Remove(tempVirus);
            }
            return tempVirus;
        }
    }
}

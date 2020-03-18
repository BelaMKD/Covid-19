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
            return dbContext.Viruses.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Virus> GetViruses()
        {
            return dbContext.Viruses
                .ToList();
        }

        public Virus UpdateVirus(Virus virus)
        {
            dbContext.Entry(virus).State = EntityState.Modified;
            return virus;
        }
    }
}

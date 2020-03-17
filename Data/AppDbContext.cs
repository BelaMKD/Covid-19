﻿using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Virus> Viruses { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<PatientVirus> PatientViruses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientVirus>().HasKey(pl => new { pl.PatientId, pl.VirusId });
            base.OnModelCreating(modelBuilder);
        }

    }
}
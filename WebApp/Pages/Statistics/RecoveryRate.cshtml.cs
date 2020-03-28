﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Statistics
{
    public class RecoveryRateModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public List<StatisticsCore> RecoveryRate { get; private set; }
        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }
        public RecoveryRateModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            RecoveryRate = new List<StatisticsCore>();
        }
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }

        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var newDiagnosis = Diagnoses.GroupBy(d => d.Recovered);
            foreach (var item in newDiagnosis)
            {
                RecoveryRate.Add(new StatisticsCore
                {
                    Recovered = item.Key==true ? 
                    "Deaths " + String.Format("{0:0.00}", ((double)item.Count() / Diagnoses.Count()) * 100) + "%" 
                    : "Recovered " + String.Format("{0:0.00}", ((double)item.Count()/Diagnoses.Count())*100) + "%",
                    TotalPatients = item.Count()
                });
            }
        }
    }
}
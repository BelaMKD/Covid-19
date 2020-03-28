using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }
        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }
        public List<StatisticsCore> RegionPatients { get; set; }
        public List<StatisticsCore> PatientDeath { get; set; }

        public StatisticModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            RegionPatients = new List<StatisticsCore>();
            PatientDeath = new List<StatisticsCore>();
        }
        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var Ddiagnoses = Diagnoses.GroupBy(x => x.Patient.City);
            foreach (var item in Ddiagnoses)
            {

                RegionPatients.Add(new StatisticsCore
                {
                    Region = item.Key,
                    TotalPatients = item.Count()
                });
            }
            var patientDeath = Deaths.GroupBy(x => x.Patient.City);
            foreach (var item in patientDeath)
            {
                PatientDeath.Add(new StatisticsCore
                {
                    Region = item.Key,
                    TotalPatients = item.Count()
                });
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Data.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Statistics
{
    public class GroupByAgeModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }
        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }
        public List<StatisticsCore> AgeGroup { get; set; }
        public List<StatisticsCore> PatientDeath { get; set; }

        public GroupByAgeModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            AgeGroup = new List<StatisticsCore>();
            PatientDeath = new List<StatisticsCore>();
        }
        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var Ddiagnoses = Diagnoses.GroupBy(x => 10 * ((DateTime.Now.Year - x.Patient.BirthDate.Year) / 10));
            foreach (var item in Ddiagnoses.OrderBy( i => i.Key))
            {

                AgeGroup.Add(new StatisticsCore
                {
                    Age = item.Key.ToString() + "-" + $"{item.Key + 9}",
                    TotalPatients = item.Count()
                }); ;
            }
            var patientDeath = Deaths.GroupBy(x => 10 * ((DateTime.Now.Year - x.Patient.BirthDate.Year) / 10));
            foreach (var item in patientDeath)
            {
                PatientDeath.Add(new StatisticsCore
                {
                    Age = item.Key.ToString() + "-" + $"{item.Key + 9}",
                    TotalPatients = item.Count()
                });
            }
        }
    }
}
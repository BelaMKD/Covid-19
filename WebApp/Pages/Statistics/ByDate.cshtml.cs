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
    public class ByDateModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }
        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }

        public List<StatisticsCore> ByDate { get; set; }
        public ByDateModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            ByDate = new List<StatisticsCore>();
        }
        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var Ddiagnoses = Diagnoses.GroupBy(x => x.DateOfTest);
            foreach (var item in Ddiagnoses)
            {

                ByDate.Add(new StatisticsCore
                {
                    DateTime = item.Key,
                    TotalPatients = item.Count()
                });
            }
        }
    }
}
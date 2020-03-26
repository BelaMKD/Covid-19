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
        public List<RegionPatient> RegionPatients { get; set; }
        public StatisticModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            RegionPatients = new List<RegionPatient>();
        }
        public void OnGet()
        {
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var Ddiagnoses = Diagnoses.GroupBy(x => x.Patient.City);
            var x = 0;
            foreach (var item in Ddiagnoses)
            {

                RegionPatients.Add(new RegionPatient
                {
                    Region = item.Key,
                    PatientNumber = item.Count()
                });
            }
        }
    }
}
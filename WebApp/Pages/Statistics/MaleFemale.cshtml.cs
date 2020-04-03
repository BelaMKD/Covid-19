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
    public class PieModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public List<StatisticsCore> MaleFemale { get; private set; }
        public List<StatisticsCore> PatientDeath { get; set; }

        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }
        public PieModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            MaleFemale = new List<StatisticsCore>();
            PatientDeath = new List<StatisticsCore>();
        }
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }

        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var newDiagnosis = Diagnoses.GroupBy(d => d.Patient.Gender.ToString());
            foreach(var item in newDiagnosis)
            {
                MaleFemale.Add(new StatisticsCore
                {
                    Gender = item.Key,
                    TotalPatients = item.Count()
                });
            }
            var patientDeath = Deaths.GroupBy(d => d.Patient.Gender.ToString());
            foreach (var item in patientDeath)
            {
                PatientDeath.Add(new StatisticsCore
                {
                    Gender = item.Key,
                    TotalPatients = item.GroupBy(x => x.Patient.Name).Count()
                });
            }
        }
    }
}
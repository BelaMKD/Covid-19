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
    public class InHospitalModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        public List<StatisticsCore> HospitalPatients { get; private set; }
        public List<StatisticsCore> PatientDeath { get; set; }

        public IEnumerable<Domain.Diagnosis> Deaths { get; set; }
        public IEnumerable<Domain.Diagnosis> Recovered { get; set; }
        public InHospitalModel(IDiagnosisService diagnosisService)
        {
            this.diagnosisService = diagnosisService;
            HospitalPatients = new List<StatisticsCore>();
            PatientDeath = new List<StatisticsCore>();
        }
        public IEnumerable<Domain.Diagnosis> Diagnoses { get; set; }

        public void OnGet()
        {
            Deaths = diagnosisService.Deaths();
            Recovered = diagnosisService.Recovered();
            Diagnoses = diagnosisService.GetDiagnosesWithCorona();
            var newDiagnosis = Diagnoses.GroupBy(d => d.Patient.Hospital.Name);
            foreach (var item in newDiagnosis)
            {
                HospitalPatients.Add(new StatisticsCore
                {
                    Hospital = item.Key,
                    TotalPatients = item.Count()
                });
            }
            var patientDeath = Deaths.GroupBy(d => d.Patient.Hospital.Name);
            foreach (var item in patientDeath)
            {
                PatientDeath.Add(new StatisticsCore
                {
                    Hospital = item.Key,
                    TotalPatients = item.GroupBy(x => x.Patient.Name).Count()
                });
            }
        }
    }
}
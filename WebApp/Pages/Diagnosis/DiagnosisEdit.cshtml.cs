using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp
{
    public class DiagnosisEditModel : PageModel
    {
        private readonly IDiagnosisService diagnosisService;
        private readonly IVirusService virusService;
        private readonly IPatientService patientService;

        [BindProperty]
        public Diagnosis Diagnosis { get; set; }
        [BindProperty]
        public List<Virus> Viruses { get; set; }
        public DiagnosisEditModel(IDiagnosisService diagnosisService, IVirusService virusService, IPatientService patientService)
        {
            this.diagnosisService = diagnosisService;
            this.virusService = virusService;
            this.patientService = patientService;
        }
        public IActionResult OnGet(int? id, int patientId)
        {
            if (id.HasValue)
            {
                Diagnosis = diagnosisService.GetDiagnosisById(id.Value);
                return RedirectToPage("/Hospital/HospitalList");
            }
            else
            {
                Diagnosis = new Diagnosis();
                var patient = patientService.GetPatientById(patientId);
                Diagnosis.Patient = patient;
            }
            Viruses = virusService.GetViruses();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var patient = patientService.GetPatientById(Diagnosis.Patient.Id);
                Diagnosis.Patient = patient;
                Diagnosis.DateOfTest = DateTime.Now;
                foreach (var virus in Viruses)
                {
                    if (virus.IsSelected)
                    {
                        Diagnosis.Viruses.Add(virusService.GetVirusById(virus.Id));
                    }
                
                }
                if (Diagnosis.Id == 0)
                {
                    diagnosisService.CreateDiagnosis(Diagnosis);
                }
                else
                {
                    diagnosisService.UpdateDiagnosis(Diagnosis);
                }
                diagnosisService.Commit();
                return RedirectToPage("./DiagnosisList", new { id = Diagnosis.PatientId });
            }
            return Page();
        }
    }
}
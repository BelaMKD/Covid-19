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
        private readonly IDiagnosesVirusesService diagnosesVirusesService;

        public DiagnosisEditModel(IDiagnosisService diagnosisService, IVirusService virusService, IPatientService patientService,IDiagnosesVirusesService diagnosesVirusesService )
        {
            this.diagnosisService = diagnosisService;
            this.virusService = virusService;
            this.patientService = patientService;
            this.diagnosesVirusesService = diagnosesVirusesService;
        }

        [BindProperty]
        public Diagnosis Diagnosis { get; set; }
        [BindProperty]
        public List<Virus> Viruses { get; set; }
        [BindProperty]
        public DiagnosisVirus DiagnosisVirus { get; set; }
        [BindProperty]
        public Patient Patient { get; set; }
        public IEnumerable<DiagnosisVirus> ListOfSelectedVirusis { get; set; }
        public IActionResult OnGet(int? id, int patientId)
        {
            if (id.HasValue)
            {
                Diagnosis = diagnosisService.GetDiagnosisById(id.Value);
                Patient = patientService.GetPatientById(patientId);
                
                if (Diagnosis == null)
                {
                    return RedirectToPage("NotFound");
                }
            }
            else
            {
                Diagnosis = new Diagnosis();
                Patient = patientService.GetPatientById(patientId);
            }
            Viruses = virusService.GetViruses();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                foreach (var virus in Viruses)
                {
                    if (virus.IsSelected == true)
                    {
                        var diagnosisVirus = new DiagnosisVirus();
                        diagnosisVirus.Virus = virusService.GetVirusById(virus.Id);
                        Diagnosis.DiagnosisViruses.Add(diagnosisVirus);
                    }
                }
                if (Diagnosis.Id == 0)
                {
                    Diagnosis.PatientId = Patient.Id;
                    Diagnosis = diagnosisService.CreateDiagnosis(Diagnosis);
                }
                else
                {
                    Patient = patientService.GetPatientById(Patient.Id);
                    var diagnose = diagnosisService.GetDiagnosisById(Diagnosis.Id);
                    Patient.Diagnosis.Remove(diagnose);
                    Patient.Diagnosis.Add(Diagnosis);
                }
                diagnosisService.Commit();
                return RedirectToPage("./DiagnosisList", new { id = Diagnosis.PatientId });
            }
            return Page();
        }
    }
}
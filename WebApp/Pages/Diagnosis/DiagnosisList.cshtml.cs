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
    public class DiagnosisListModel : PageModel
    {
        private readonly IPatientService patientService;
        private readonly IDiagnosisService diagnosesService;

        public Patient Patient { get; set; }
        [BindProperty]
        public Diagnosis Diagnosis { get; set; }
        [TempData]
        public string Message { get; set; }
        public DiagnosisListModel(IPatientService patientService, IDiagnosisService diagnosesService)
        {
            this.patientService = patientService;
            this.diagnosesService = diagnosesService;
        }
        public IActionResult OnGet(int id)
        {
            Patient = patientService.GetPatientById(id);

            if (Patient==null)
            {
                return RedirectToPage("/Hospitals/HospitalList");
            }
            return Page();
        }
        public IActionResult OnPostDeleteDiagnosis(int id)
        {
            var temp = diagnosesService.DeleteDiagnosis(id);
            if(temp == null)
            {
                return RedirectToPage("NotFound");
            }

            diagnosesService.Commit();

            return RedirectToPage("/Diagnosis/DiagnosisList", new { id = temp.PatientId });
        }
    }
}
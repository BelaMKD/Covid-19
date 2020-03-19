using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Hospitals
{
    public class PatientsInHospitalModel : PageModel
    {
        private readonly IHospitalService hospitalService;
        private readonly IPatientService patientService;

        public PatientsInHospitalModel(IHospitalService hospitalService, IPatientService patientService)
        {
            this.hospitalService = hospitalService;
            this.patientService = patientService;
        }

        public Hospital Hospital { get; set; }
        public IActionResult OnGet(int id)
        {
            Hospital = hospitalService.GetHospitalById(id);
            if(Hospital == null)
            {
                return RedirectToPage("NotFound");
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var patient = patientService.DeletePatient(id);
            if(patient == null)
            {
                return NotFound();
            }
            patientService.Commit();

            return RedirectToPage("/Hospitals/HospitalList");

        }
    }
}
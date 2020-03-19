using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Patients
{
    public class AddPatientModel : PageModel
    {
        private readonly IPatientService patientService;
        private readonly IHospitalService hospitalService;
        private readonly IHtmlHelper htmlHelper;

        public AddPatientModel(IPatientService patientService, IHospitalService hospitalService, IHtmlHelper htmlHelper)
        {
            this.patientService = patientService;
            this.hospitalService = hospitalService;
            this.htmlHelper = htmlHelper;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        [BindProperty]
        public Hospital Hospital { get; set; }

        public IEnumerable<SelectListItem> SelectGender { get; set; }
        public IActionResult OnGet(int id)
        {
            Hospital = hospitalService.GetHospitalById(id);
            Patient = new Patient();
            SelectGender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Patient = patientService.CreatePatient(Patient);
                Patient.HospitalId = Hospital.Id;
               
                Hospital.Patients.Add(Patient);

                patientService.Commit();
                TempData["Message"] = "Patient Added in Hospital!";

                return RedirectToPage("/Hospitals/PatientsInHospital", new { id = Hospital.Id });
            }

            return Page();
        }
    }
}
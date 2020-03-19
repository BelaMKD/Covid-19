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
    public class EditPatientModel : PageModel
    {
        private readonly IPatientService patientServices;
        private readonly IHtmlHelper htmlHelper;
        private readonly IHospitalService hospitalService;

        public EditPatientModel(IPatientService patientServices, IHtmlHelper htmlHelper, IHospitalService hospitalService)
        {
            this.patientServices = patientServices;
            this.htmlHelper = htmlHelper;
            this.hospitalService = hospitalService;
        }
        [BindProperty]
        public Patient Patient { get; set; }
        [BindProperty]
        public Hospital Hospital { get; set; }
        public IEnumerable<SelectListItem> SelectGender { get; set; }

        public IActionResult OnGet(int id)
        {
            Patient = patientServices.GetPatientById(id);
            if(Patient == null)
            {
                return RedirectToPage("NotFound");
            }
            SelectGender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Patient = patientServices.EditPatient(Patient);

                patientServices.Commit();

                Hospital = hospitalService.GetHospitalById(Patient.HospitalId);

                return RedirectToPage("/Hospitals/PatientsInHospital", new { id = Hospital.Id });
            }

            SelectGender = htmlHelper.GetEnumSelectList<Gender>();
            return Page();
        }
    }
}
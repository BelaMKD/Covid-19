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

        public PatientsInHospitalModel(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
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
    }
}
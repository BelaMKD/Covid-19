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
    public class HospitalDeleteModel : PageModel
    {
        private readonly IHospitalService hospitalService;

        public HospitalDeleteModel(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }
        [BindProperty]
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
        public IActionResult OnPost()
        {
            var temp = hospitalService.DeleteHospital(Hospital.Id);
            if(temp == null)
            {
                return RedirectToPage("NotFound");
            }

            hospitalService.Commit();
            TempData["Message"] = "Hospital Deleted!";
            return RedirectToPage("HospitalList");
        }
    }
}
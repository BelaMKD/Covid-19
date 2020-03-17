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
    public class HospitalEditModel : PageModel
    {
        private readonly IHospitalService hospitalService;

        public HospitalEditModel(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }
        [BindProperty]
        public Hospital Hospital { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Hospital = hospitalService.GetHospitalById(id.Value);
                if(Hospital == null)
                {
                    return RedirectToPage("NotFound");
                }
            }
            else
            {
                Hospital = new Hospital();
            }

            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Hospital.Id == 0)
                {
                    Hospital = hospitalService.CreateHospital(Hospital);
                }
                else
                {
                    Hospital = hospitalService.UpdateHospital(Hospital);
                }

                hospitalService.Commit();
                TempData["Message"] = "New Hospital Created!";
                return RedirectToPage("HospitalList");
            }

            return Page();
        }
    }
}
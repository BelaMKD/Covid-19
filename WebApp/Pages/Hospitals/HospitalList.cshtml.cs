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
    public class HospitalListModel : PageModel
    {
        private readonly IHospitalService hospitalService;

        public HospitalListModel(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }
        public IEnumerable<Hospital> Hospitals { get; set; }
        public void OnGet()
        {
            Hospitals = hospitalService.GetHospitals();
        }
    }
};
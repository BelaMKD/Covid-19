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
    public class VirusListModel : PageModel
    {
        private readonly IVirusService virusService;
        public IEnumerable<Virus> Viruses { get; set; }
        public VirusListModel(IVirusService virusService)
        {
            this.virusService = virusService;
        }
        [TempData]
        public string Message { get; set; }
        public IActionResult OnGet()
        {
            Viruses = virusService.GetViruses();
            if(Viruses.Any(v => v.Name == "Covid-19"))
            {
                return Page();
            }
            else
            {
                TempData["Message"] = "For Statistics purposes, please create a Virus with name: Covid-19 ! Thank you.";
                return Page();
            }
        }

    }
}
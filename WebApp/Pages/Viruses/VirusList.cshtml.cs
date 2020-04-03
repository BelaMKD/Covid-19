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
        public void OnGet()
        {
            Viruses = virusService.GetViruses();
        }

    }
}
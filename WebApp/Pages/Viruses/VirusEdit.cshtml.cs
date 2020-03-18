using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp
{
    public class VirusEditModel : PageModel
    {
        private readonly IVirusService virusService;
        [BindProperty]
        public Virus Virus { get; set; }
        public VirusEditModel(IVirusService virusService)
        {
            this.virusService = virusService;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Virus = virusService.GetVirusById(id.Value);
                if (Virus == null)
                {
                    return RedirectToPage("./List");
                }
            }
            else
            {
                Virus = new Virus();
            }
           
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
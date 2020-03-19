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
        private readonly ISymptomService symptomService;

        [BindProperty]
        public Virus Virus { get; set; }
        [BindProperty]
        public IEnumerable<Symptom> Symptoms { get; set; }
        public VirusEditModel(IVirusService virusService, ISymptomService symptomService)
        {
            this.virusService = virusService;
            this.symptomService = symptomService;
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
            Symptoms = symptomService.GetSymptoms();
            return Page();
        } 
        public IActionResult OnPost()
        {
            Symptoms = Symptoms;
            return Page();
        }
    }
}
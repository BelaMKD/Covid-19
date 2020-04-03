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
        public List<Symptom> Symptoms { get; set; }
        public VirusEditModel(IVirusService virusService, ISymptomService symptomService)
        {
            this.virusService = virusService;
            this.symptomService = symptomService;
        }
        public IActionResult OnGet(int? id)
        {
            Symptoms = symptomService.GetSymptoms();
            if (id.HasValue)
            {
                Virus = virusService.GetVirusById(id.Value);
                if (Virus == null)
                {
                    return RedirectToPage("./List");
                }
                foreach (var item in Symptoms)
                {
                    foreach (var sv in Virus.VirusSymptoms)
                    {
                        if (item.Id==sv.SymptomId)
                        {
                            item.IsSelected = true;
                        }
                    }
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
            if (ModelState.IsValid)
            {
                foreach (var symptom in Symptoms)
                {
                    if (symptom.IsSelected)
                    {
                        Virus.VirusSymptoms.Add(new VirusSymptom { Symptom=symptomService.GetSymptomById(symptom.Id)});
                    }

                }
                if (Virus.Id == 0)
                {
                    virusService.CreateVirus(Virus);
                }
                else
                {
                    var virus = virusService.GetVirusById(Virus.Id);
                    virusService.RemoveVirus(virus.Id);
                    virusService.CreateVirus(Virus);
                }
                virusService.Commit();
                return RedirectToPage("./VirusList");
            }
            Symptoms = symptomService.GetSymptoms();
            return Page();
        }
        public IActionResult OnPostDeleteVirus(int id)
        {
            var virus = virusService.RemoveVirus(id);
            if (virus == null)
            {
                return RedirectToPage("./VirusList");
            }
            virusService.Commit();
            return RedirectToPage("./VirusList");
        }
    }
}
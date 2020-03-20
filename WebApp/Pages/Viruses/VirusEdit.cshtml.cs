﻿using System;
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
            if (id.HasValue)
            {
                Virus = virusService.GetVirusById(id.Value);
                if (Virus.Symptoms != null)
                {
                    Virus.Symptoms.Clear();
                    virusService.Commit();
                }

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
            if (ModelState.IsValid)
            {
             
                foreach (var symptom in Symptoms)
                {
                    if (symptom.IsSelected)
                    {
                        Virus.Symptoms.Add(symptomService.GetSymptomById(symptom.Id));
                    }
                    else
                    {
                        Virus.Symptoms.Remove(symptomService.GetSymptomById(symptom.Id));
                    }
                }
                if (Virus.Id == 0)
                {
                    virusService.CreateVirus(Virus);
                }
                else
                {
                    virusService.UpdateVirus(Virus);
                }
                virusService.Commit();
                return RedirectToPage("./VirusList");
            }
            Symptoms = symptomService.GetSymptoms();
            return Page();
        }
    }
}
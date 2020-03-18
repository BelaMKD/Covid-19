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
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Virus Virus { get; set; }
        [BindProperty]
        public List<SelectListItem> Symptomss { get; set; }
        public VirusEditModel(IVirusService virusService, IHtmlHelper htmlHelper)
        {
            this.virusService = virusService;
            this.htmlHelper = htmlHelper;
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
            Symptomss = htmlHelper.GetEnumSelectList<Symptoms>().ToList();
           
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                foreach (var symptom in Symptomss)
                {
                    if (symptom.Selected)
                    {
                        Virus.Symptoms.Add((Symptoms)Enum.Parse(typeof(Symptoms), symptom.Text));
                    }
                }
                if (Virus.Id==0)
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
            Symptomss = htmlHelper.GetEnumSelectList<Symptoms>().ToList();
            return Page();
        }
    }
}
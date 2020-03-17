using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Virus
    {
        public Virus()
        {
            Symptoms = new List<Symptoms>();
            PatientViruses = new List<PatientVirus>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VirusDescription { get; set; }
        [NotMapped]
        public List<Symptoms> Symptoms { get; set; }

        public List<PatientVirus> PatientViruses { get; set; }
    }
}

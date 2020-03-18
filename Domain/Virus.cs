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
            Symptoms = new List<Symptom>();
            PatientViruses = new List<PatientVirus>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VirusDescription { get; set; }
        public List<Symptom> Symptoms { get; set; }

        public List<PatientVirus> PatientViruses { get; set; }
    }
}

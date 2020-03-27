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
            VirusSymptoms = new List<VirusSymptom>();
            DiagnosisViruses = new List<DiagnosisVirus>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string VirusDescription { get; set; }
        public bool IsSelected { get; set; }
        public List<VirusSymptom> VirusSymptoms { get; set; }
        public List<DiagnosisVirus> DiagnosisViruses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Symptom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public List<VirusSymptom> VirusSymptoms { get; set; }
        public Symptom()
        {
            VirusSymptoms = new List<VirusSymptom>();
        }
    }
}

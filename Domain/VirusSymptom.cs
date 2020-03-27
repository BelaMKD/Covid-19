using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class VirusSymptom
    {
        public int VirusId { get; set; }
        public Virus Virus { get; set; }
        public int SymptomId { get; set; }
        public Symptom Symptom { get; set; }
    }
}

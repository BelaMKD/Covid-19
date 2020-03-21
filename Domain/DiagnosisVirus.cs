using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DiagnosisVirus
    {
        public Diagnosis Diagnosis { get; set; }
        public int DiagnosisId { get; set; }
        public Virus Virus { get; set; }
        public int VirusId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class PatientVirus
    {
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Virus Virus { get; set; }
        public int VirusId { get; set; }

    }
}

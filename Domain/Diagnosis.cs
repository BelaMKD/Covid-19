using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public DateTime DateOfTest { get; set; }
        public DateTime? DateRecover { get; set; }
        public bool Recovered { get; set; }

    }
}

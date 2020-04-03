using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class PatientInfo
    {
        public int Id { get; set; }
        public string PatinetName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Hospital Hospital { get; set; }
        public List<Diagnosis> Diagnoses { get; set; }

    }
}

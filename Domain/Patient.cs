using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Patient
    {
        public Patient()
        {
            PatientViruses = new List<PatientVirus>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public bool NotRecovered { get; set; }

        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }

        public List<PatientVirus> PatientViruses { get; set; }

        public Diagnosis Diagnosis { get; set; }

    }
}

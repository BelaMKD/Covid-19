using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Hospital
    {
        public Hospital()
        {
            Patients = new List<Patient>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public List<Patient> Patients { get; set; }

    }
}

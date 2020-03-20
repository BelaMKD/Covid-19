using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Patient
    {
        public Patient()
        {
            Diagnosis = new List<Diagnosis>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public Hospital Hospital { get; set; }
        public int HospitalId { get; set; }


        public List<Diagnosis> Diagnosis { get; set; }

    }
}

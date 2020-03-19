using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Diagnosis
    {
        public Diagnosis()
        {
            Viruses = new List<Virus>();
        }
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        public DateTime DateOfTest { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRecover { get; set; }
        public bool Recovered { get; set; }
        public List<Virus> Viruses { get; set; }
    }
}

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
            DiagnosisViruses = new List<DiagnosisVirus>();
        }
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfTest { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateRecover { get; set; }
        public List<DiagnosisVirus> DiagnosisViruses { get; set; }
        public bool IsPositive { get; set; }
        public bool Recovered { get; set; }
        public bool Death { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Death")]
        public DateTime? DateOfDeath { get; set; }
    }
}

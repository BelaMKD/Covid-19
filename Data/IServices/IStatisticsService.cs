using BusinessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IStatisticsService
    {
        public IEnumerable<Diagnosis> GetDiagnosesWithCorona();
        public IEnumerable<Diagnosis> Deaths();
        public IEnumerable<Diagnosis> Recovered();
        IEnumerable<Patient> GetPatiens();
        IEnumerable<PatientInfo> GetPatientsInfo();
    }
}

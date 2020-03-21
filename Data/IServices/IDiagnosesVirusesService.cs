using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IDiagnosesVirusesService
    {
        int Commit();
        void AddToBase(DiagnosisVirus diagnosisVirus);
    }
}

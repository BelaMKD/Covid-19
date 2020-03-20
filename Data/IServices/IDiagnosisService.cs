using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IDiagnosisService
    {
        Diagnosis CreateDiagnosis(Diagnosis diagnosis);
        Diagnosis UpdateDiagnosis(Diagnosis diagnosis);
        Diagnosis GetDiagnosisById(int id);
        IEnumerable<Diagnosis> GetDiagnoses();
        int Commit();
    }
}

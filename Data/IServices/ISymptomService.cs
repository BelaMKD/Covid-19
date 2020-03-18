using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface ISymptomService
    {
        Symptom GetSymptomById(int id);
        IEnumerable<Symptom> GetSymptoms();

    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IPatientService
    {
        int Commit();
        Patient CreatePatient(Patient patient);
        Patient GetPatientById(int id);
        Patient EditPatient(Patient patient);
        Patient DeletePatient(int id);
    }
}

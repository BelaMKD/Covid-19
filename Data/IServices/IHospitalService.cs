using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IHospitalService
    {
        IEnumerable<Hospital> GetHospitals();
        int Commit();
        Hospital GetHospitalById(int id);
        Hospital CreateHospital(Hospital hospital);
        Hospital UpdateHospital(Hospital hospital);
        Hospital DeleteHospital(int id);
    }
}

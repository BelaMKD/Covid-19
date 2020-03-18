using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.IServices
{
    public interface IVirusService
    {
        Virus GetVirusById(int id);
        Virus CreateVirus(Virus virus);
        Virus UpdateVirus(Virus virus);
        IEnumerable<Virus> GetViruses();
        int Commit();
    }
}

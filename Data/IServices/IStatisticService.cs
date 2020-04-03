using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using static Data.DataSql.StatisticData;

namespace Data.IServices
{
    public interface IStatisticService
    {
        IEnumerable<PatientInfo> GetPatients();
    }
}

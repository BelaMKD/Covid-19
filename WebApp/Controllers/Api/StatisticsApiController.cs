using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Data.IServices;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Api
{
    [Route("api/Statistics")]
    [ApiController]
    public class StatisticsApiController : Controller
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsApiController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }
        
        [HttpGet("Patients")]
        public IActionResult GetPatients()
        {
            var data = statisticsService.GetPatientsInfo();
            return Ok(data);
        }
        [HttpGet("Patients/{id}")]
        public IActionResult GetSinglePatient(int id)
        {
            return Ok(statisticsService.GetSinglePatient(id));
        }
        [HttpGet("Hospitals")]
        public IActionResult GetHospitals()
        {
            var data = statisticsService.GetHospitalInfo();
            return Ok(data);
        }
        [HttpGet("Hospitals/{hospitalId}")]
        public IActionResult GetSingleHospital(int hospitalId)
        {
            return Ok(statisticsService.GetSingleHospital(hospitalId));
        }
    }
}
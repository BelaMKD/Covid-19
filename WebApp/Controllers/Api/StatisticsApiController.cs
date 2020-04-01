using System;
using System.Collections.Generic;
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
        
        [HttpGet]
        public IActionResult GetPatients()
        {
            var data = statisticsService.GetPatiens();
            return Ok(data);

        }
    }
}
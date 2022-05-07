using AuditBenchmarkMicroservice.Models;
using AuditBenchmarkMicroservice.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditBenchmarkMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class AuditBenchmarkController : ControllerBase
    {
        private readonly log4net.ILog _log4net;
        private readonly IAuditBenchmarkService _Service;
        public AuditBenchmarkController(IAuditBenchmarkService Service)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(AuditBenchmarkController));
            _Service = Service;
        }
      
        [HttpGet]
        public IActionResult GetBenchmarksList()
        {
            _log4net.Info(" Http GET request:"+nameof(AuditBenchmarkController));
            List<AuditBenchmark> listOfService = new List<AuditBenchmark>();
            try
            {
                listOfService = _Service.GetBenchmarksList();
                return Ok(listOfService);
            }
            catch (Exception e)
            {
                _log4net.Error(" Exception here" + e.Message + " " + nameof(AuditBenchmarkController));
                return StatusCode(500);
            }
        }
    }
}

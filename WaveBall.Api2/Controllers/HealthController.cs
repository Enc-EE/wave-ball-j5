using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WaveBall.Data;

namespace WaveBall.Api2.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "I'm fine :)";
        }

        [HttpGet]
        [Route("db")]
        public string GetDb()
        {
            using (var dbCtx = new WaveBallContext())
            return "I'm fine :) and there is something more: " + dbCtx.Apps.Any();
        }
    }
}

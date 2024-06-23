using HealthCheck.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCheck.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(int applicationId)
        {
            //BackgroundJob.Enqueue(() => HealthCheckService.Check());
            return Ok("hangfire çalıştı...");
        }


    }
}

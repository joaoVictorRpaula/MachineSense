using MachineSense_Webhook.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MachineSense_Webhook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineSenseWebhookController : ControllerBase
    {
        private readonly ILogger<MachineSenseWebhookController> _ILogger;
        public MachineSenseWebhookController(ILogger<MachineSenseWebhookController> ILogger)
        {
            _ILogger = ILogger;
        }

        [HttpPost("DataGeneratorTopic")]
        public IActionResult NewDataResponseDataGenerator([FromBody] DataResponse dataResponse)
        {
            if (!ModelState.IsValid)
            {
                _ILogger.LogError("An error occurred receiving result, invalid model");
                return BadRequest(ModelState);         
            }

            _ILogger.LogInformation("Result Received: " + dataResponse);
            return Ok(dataResponse);
        }
    }
}

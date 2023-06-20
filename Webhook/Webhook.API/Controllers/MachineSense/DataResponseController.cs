using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Webhook.Application.Interfaces.MachineSense;
using Webhook.Entities.Entities.MachineSense;

namespace Webhook.API.Controllers.MachineSense
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataResponseController : ControllerBase
    {
        private readonly ILogger<DataResponseController> _ILogger;
        private readonly IApplicationDataResponse _IApplicationDataResponse;

        public DataResponseController(ILogger<DataResponseController> iLogger, IApplicationDataResponse applicationDataResponse)
        {
            _ILogger = iLogger;
            _IApplicationDataResponse = applicationDataResponse;
        }

        [HttpPost("DataGeneratorTopic")]
        public async Task<IActionResult> NewDataResponseDataGenerator([FromBody] DataResponse dataResponse)
        {
            if (!ModelState.IsValid)
            {
                _ILogger.LogError("An error occurred receiving result, invalid model");
                return BadRequest(ModelState);
            }

            try
            {
                _ILogger.LogInformation("Result Received: " + dataResponse);
                await _IApplicationDataResponse.SendDataResponseToAdjustmentAPI(dataResponse);
                return Ok("Result received and sended to Adjustment API");
            }
            catch(Exception ex)
            {
                _ILogger.LogError("An error occurred sending result to adjustment API" + ex);
                return BadRequest(ex);
            }

        }
    }
}

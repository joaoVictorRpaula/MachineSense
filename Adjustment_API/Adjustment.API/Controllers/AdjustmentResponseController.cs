using Adjustment.Application.Interfaces;
using Adjustment.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Adjustment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjustmentResponseController : ControllerBase
    {
        private readonly IApplicationAdjustmentResponse _IApplicationAdjustmentResponse;
        private readonly ILogger<AdjustmentResponseController> _ILogger;

        public AdjustmentResponseController(IApplicationAdjustmentResponse iApplicationAdjustmentResponse, ILogger<AdjustmentResponseController> iLogger)
        {
            _IApplicationAdjustmentResponse = iApplicationAdjustmentResponse;
            _ILogger = iLogger;
        }

        [HttpPost("CalculateAdjustment")]
        public async Task<IActionResult> SendNewDataResponseToCalculate([FromBody] DataResponse dataResponse)
        {
            if (!ModelState.IsValid)
            {
                _ILogger.LogError("An error occurred while calculate adjustment, Invalid Model");
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _IApplicationAdjustmentResponse.CalculateAdjustment(dataResponse));
                
            }
            catch(Exception ex)
            {
                _ILogger.LogError("An error occurred while calculate adjustment, "+ex);
                return BadRequest(ex);
            }

        }

    }
}

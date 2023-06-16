using Adjustment_Component.Application.Interfaces;
using Adjustment_Component.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Adjustment_Component.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyAdjustmentResponseController : ControllerBase
    {
        private readonly ILogger<ApplyAdjustmentResponseController> _ILogger;
        private readonly IApplicationApplyAdjustmentResponse _IApplicationApplyAdjustmentResponse;

        public ApplyAdjustmentResponseController(ILogger<ApplyAdjustmentResponseController> logger, IApplicationApplyAdjustmentResponse iApplicationApplyAdjustmentResponse)
        {
            _ILogger = logger;
            _IApplicationApplyAdjustmentResponse = iApplicationApplyAdjustmentResponse;
        }

        [HttpPost]
        public async Task<IActionResult> ApplyAdjustment(AdjustmentResponse adjustmentResponse)
        {
            if (!ModelState.IsValid)
            {
                _ILogger.LogError("An error occurred applying the adjustment, INVALID MODEL PASSED");
                return BadRequest(ModelState);
            }
            try
            {
                await _IApplicationApplyAdjustmentResponse.ApplyAdjustment(adjustmentResponse);
                return Ok();
            }
            catch(Exception ex)
            {
                _ILogger.LogError("An error occurred applying the adjustment " + ex);
                return BadRequest(ex);
            }
        }
    }
}

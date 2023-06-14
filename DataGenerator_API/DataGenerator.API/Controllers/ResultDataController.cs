using DataGenerator.Application.Interfaces;
using DataGenerator.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace DataGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultDataController : ControllerBase
    {
        private readonly IApplicationResultData _IApplicationResultData;
        private readonly IApplicationDataResponse _IApplicationDataResponse;
        private readonly ILogger<ResultDataController> _ILogger;

        public ResultDataController(IApplicationResultData ApplicationResultData, IApplicationDataResponse iApplicationDataResponse, ILogger<ResultDataController> Logger)
        {
            _IApplicationResultData = ApplicationResultData;
            _IApplicationDataResponse = iApplicationDataResponse;
            _ILogger = Logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ResultData resultData)
        {
            if (!ModelState.IsValid)
            {
                _ILogger.LogError("An error occurred while adding result to database, Invalid Model");
                return BadRequest(ModelState);
            }
            try
            {
                ResultData newResultData = new ResultData
                {
                    ResultDate = resultData.ResultDate,
                    MachineName = resultData.MachineName,
                    AngleResult = resultData.AngleResult,
                    AngleUpperTol = resultData.AngleUpperTol,
                    AngleLowerTol = resultData.AngleLowerTol,
                    DiameterResult = resultData.DiameterResult,
                    DiameterUpperTol = resultData.DiameterUpperTol,
                    DiameterLowerTol = resultData.DiameterLowerTol
                };

                try
                {
                    await _IApplicationResultData.Add(newResultData);
                    _ILogger.LogInformation("Added result to database");
                }
                catch (DbException ex)
                {
                    _ILogger.LogError("An error occurred while adding result to database " + ex.ToString());
                    return StatusCode(500, "An error occurred while adding result to database");
                }

                DataResponse newDataResponse = new DataResponse
                {
                    resultData = newResultData
                };

                try
                {
                    await _IApplicationDataResponse.NotifyNewDataResponse(newDataResponse);
                    _ILogger.LogInformation("Notified the result to WebHook");
                }
                //Call Webhook endpoint to notify a new result.
                catch (Exception ex)
                {
                    _ILogger.LogError("An error occurred while notifying the webhook. " + ex.ToString());
                }
                return Ok();
            }
            catch(Exception ex)
            {
                _ILogger.LogError(ex.ToString());
                return StatusCode(500, "An error occurred." + ex);
            }

        }
    }
}

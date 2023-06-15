using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Domain.Interfaces.MachineSense;
using Webhook.Entities.Entities.MachineSense;
using Webhook.Infraestructure.Interfaces;

namespace Webhook.Infraestructure.Services.MachineSense
{
    public class DataResponseInfraService : IDataResponse
    {
        private readonly IHttpService _IHttpService;
        private readonly ILogger<DataResponseInfraService> _Logger;

        public DataResponseInfraService(IHttpService iHttpService, ILogger<DataResponseInfraService> logger)
        {
            _IHttpService = iHttpService;
            _Logger = logger;
        }
        public async Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse)
        {
          
            var success = await _IHttpService.PostAsync("https://localhost:44310/api/AdjustmentResponse/CalculateAdjustment", dataResponse);
            if (!success)
            {
                _Logger.LogError("An error occurred while sending result to Adjustment API");
                throw new Exception("An error occurred while sending result to Adjustment API");
            }
        }
    }
}

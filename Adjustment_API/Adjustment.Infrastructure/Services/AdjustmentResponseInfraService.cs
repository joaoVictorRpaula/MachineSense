using Adjustment.Domain.Interfaces;
using Adjustment.Entities.Entities;
using Adjustment.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Infrastructure.Services
{
    public class AdjustmentResponseInfraService : IAdjustmentSendToComponentService
    {
        private readonly IHttpService _httpService;

        public AdjustmentResponseInfraService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task SendToAdjustmentComponent(AdjustmentResponse adjustmentResponse)
        {
            var success = await _httpService.PostAsync("https://localhost:44395/api/ApplyAdjustmentResponse", adjustmentResponse);
            if (!success)
            {
                throw new Exception("Error sending adjustmentResponse to adjustment component");
            }
        }
    }
}

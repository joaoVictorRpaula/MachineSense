using Adjustment.Domain.Interfaces;
using Adjustment.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Infrastructure.Services
{
    public class AdjustmentResponseInfraService : IAdjustmentResponseService
    {
        private readonly HttpService _httpService;

        public AdjustmentResponseInfraService(HttpService httpService)
        {
            _httpService = httpService;
        }

        public Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdjustmentResponse>> CalculateAdjustment(DataResponse dataResponse)
        {
            throw new NotImplementedException();
        }

        public async Task SendToAdjustmentComponent(AdjustmentResponse adjustmentResponse)
        {
            var success = await _httpService.PostAsync("", adjustmentResponse);
            if (!success)
            {
                throw new Exception("Error sending adjustment to adjustment component");
            }
        }
    }
}

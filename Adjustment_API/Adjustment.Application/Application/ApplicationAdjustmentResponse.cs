using Adjustment.Application.Interfaces;
using Adjustment.Domain.Interfaces;
using Adjustment.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Application.Application
{
    public class ApplicationAdjustmentResponse : IApplicationAdjustmentResponse
    {
        private readonly IAdjustmentCalculateResponseService _IAdjustmentResponseService;

        public ApplicationAdjustmentResponse(IAdjustmentCalculateResponseService iAdjustmentResponseService)
        {
            _IAdjustmentResponseService = iAdjustmentResponseService;
        }


        public async Task<List<AdjustmentResponse>> CalculateAdjustment(DataResponse dataResponse)
        {
            return await _IAdjustmentResponseService.CalculateAdjustment(dataResponse);
        }

        public Task SendToAdjustmentComponent(AdjustmentResponse adjustmentResponse)
        {
            throw new NotImplementedException();
        }
        public Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse)
        {
            throw new NotImplementedException();
        }
    }
}

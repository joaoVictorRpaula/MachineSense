using Adjustment_Component.Application.Interfaces;
using Adjustment_Component.Domain.Interfaces;
using Adjustment_Component.Entities.Entities;
using Adjustment_Component.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Application.Applications
{
    public class ApplicationApplyAdjustmentResponse : IApplicationApplyAdjustmentResponse
    {
        private readonly IApplyAdjustmentResponse _IApplyAdjustmentResponse;

        public ApplicationApplyAdjustmentResponse(IApplyAdjustmentResponse iApplyAdjustmentResponse)
        {
            _IApplyAdjustmentResponse = iApplyAdjustmentResponse;
        }

        public async Task ApplyAdjustment(AdjustmentResponse adjustmentResponse)
        {
            await _IApplyAdjustmentResponse.ApplyAdjustment(adjustmentResponse);
        }

    }
}

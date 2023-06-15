using Adjustment.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Application.Interfaces
{
    public interface IApplicationAdjustmentResponse
    {
        Task<List<AdjustmentResponse>> CalculateAdjustment(DataResponse dataResponse);
        Task SendToAdjustmentComponent(AdjustmentResponse adjustmentResponse);
        Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse);
    }
}

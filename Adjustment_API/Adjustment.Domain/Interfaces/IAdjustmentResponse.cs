using Adjustment.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Domain.Interfaces
{
    public interface IAdjustmentResponse
    {
        Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse);
    }
}

using Adjustment_Component.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Application.Interfaces
{
    public interface IApplicationApplyAdjustmentResponse
    {
        Task ApplyAdjustment(AdjustmentResponse adjustmentResponse);
    }
}

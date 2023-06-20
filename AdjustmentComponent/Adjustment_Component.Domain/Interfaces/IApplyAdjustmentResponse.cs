using Adjustment_Component.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Domain.Interfaces
{
    public interface IApplyAdjustmentResponse
    {
        Task ApplyAdjustment(AdjustmentResponse adjustmentResponse);
    }
}

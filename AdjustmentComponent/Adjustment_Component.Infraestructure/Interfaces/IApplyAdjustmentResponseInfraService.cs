using Adjustment_Component.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Infrastructure.Interfaces
{
    public interface IApplyAdjustmentResponseInfraService
    {
        Task ApplyAdjustment(AdjustmentResponse adjustmentResponse);
    }
}

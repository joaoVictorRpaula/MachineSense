using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Entities.Entities
{
    public class AdjustmentResponse
    {
        public int AdjustmentResponseId { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public string AdjustmentMachine { get; set; }
        public CalculedAdjustment CalculedAdjustments { get; set; }
        
    }
}

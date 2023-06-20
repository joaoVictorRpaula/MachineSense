using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhook.Entities.Entities.MachineSense
{
    public class DataResponse
    {
        public DateTime GeneratedDate { get; set; }
        public ResultData resultData { get; set; }
    }
}

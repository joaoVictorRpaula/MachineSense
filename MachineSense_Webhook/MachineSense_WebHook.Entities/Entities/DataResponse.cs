using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSense_WebHook.Entities.Entities
{
    public class DataResponse
    {
        public DateTime GeneratedDate { get; set; }
        public ResultData resultData { get; set; }
    }
}

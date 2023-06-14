using System;

namespace MachineSense_Webhook.API.Model
{
    public class DataResponse
    {
        public DateTime GeneratedDate { get; set; }
        public ResultData resultData { get; set; }
    }
}

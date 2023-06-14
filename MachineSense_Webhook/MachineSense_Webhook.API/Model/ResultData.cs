using System;

namespace MachineSense_Webhook.API.Model
{
    public class ResultData
    {
        public int IdResult { get; set; }
        public DateTime ResultDate { get; set; }
        public string MachineName { get; set; }
        public int AngleResult { get; set; }
        public int AngleUpperTol { get; set; }
        public int AngleLowerTol { get; set; }
        public int DiameterResult { get; set; }
        public int DiameterUpperTol { get; set; }
        public int DiameterLowerTol { get; set; }
    }
}

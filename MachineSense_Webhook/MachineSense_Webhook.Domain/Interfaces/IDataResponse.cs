using MachineSense_WebHook.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineSense_Webhook.Domain.Interfaces
{
    public interface IDataResponse
    {
        Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse);
    }
}

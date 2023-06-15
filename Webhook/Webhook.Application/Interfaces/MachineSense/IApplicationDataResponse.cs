using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Entities.Entities.MachineSense;

namespace Webhook.Application.Interfaces.MachineSense
{
    public interface IApplicationDataResponse
    {
        Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse);
    }
}

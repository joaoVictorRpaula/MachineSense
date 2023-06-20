using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Entities.Entities.MachineSense;

namespace Webhook.Domain.Interfaces.MachineSense
{
    public interface IDataResponse
    {
        Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webhook.Application.Interfaces.MachineSense;
using Webhook.Domain.Interfaces.MachineSense;
using Webhook.Entities.Entities.MachineSense;

namespace Webhook.Application.Application.MachineSense
{
    public class ApplicationDataResponse : IApplicationDataResponse
    {
        private readonly IDataResponse _IDataResponse;

        public ApplicationDataResponse(IDataResponse iDataResponse)
        {
            _IDataResponse = iDataResponse;
        }

        public async Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse)
        {
            await _IDataResponse.SendDataResponseToAdjustmentAPI(dataResponse);
        }
    }
}

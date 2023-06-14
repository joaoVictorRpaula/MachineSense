using DataGenerator.Application.Interfaces;
using DataGenerator.Domain.InterfacesServices;
using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Application.Application
{
    public class ApplicationDataResponse : IApplicationDataResponse
    {
        private readonly IDataResponseService _IDataResponseService;
        public ApplicationDataResponse(IDataResponseService iDataResponseService)
        {
            _IDataResponseService = iDataResponseService;
        }

        public async Task NotifyNewDataResponse(DataResponse dataResponse)
        {
            await _IDataResponseService.NotifyNewDataResponse(dataResponse);
        }
    }
}

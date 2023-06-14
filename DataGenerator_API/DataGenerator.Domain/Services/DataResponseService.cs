using DataGenerator.Domain.Interfaces;
using DataGenerator.Domain.InterfacesServices;
using DataGenerator.Entities.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataGenerator.Domain.Services
{
    public class DataResponseService : IDataResponseService
    {
        private readonly IDataResponse _response;
        private readonly ILogger<DataResponseService> _Logger;

        public DataResponseService(IDataResponse response, ILogger<DataResponseService> Logger)
        {
            _response = response;
            _Logger = Logger;
        }
        public async Task NotifyNewDataResponse(DataResponse dataResponse)
        {
            dataResponse.GeneratedDate = DateTime.Now;
            await _response.NotifyNewDataResponse(dataResponse);

        }


    }
}

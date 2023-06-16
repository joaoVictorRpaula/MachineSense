using DataGenerator.Domain.Interfaces;
using DataGenerator.Entities.Entities;
using DataGenerator.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Infrastructure.Services
{
    public class DataResponseInfraService : IDataResponse
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<DataResponseInfraService> _Logger;
        public DataResponseInfraService(IHttpService httpService, ILogger<DataResponseInfraService> Logger)
        {
            _httpService = httpService;
            _Logger = Logger;
        }

        public async Task NotifyNewDataResponse(DataResponse dataResponse)
        {

            var success = await _httpService.PostAsync("https://localhost:44321/api/DataResponse/DataGeneratorTopic", dataResponse);
            if (!success)
            {
                _Logger.LogError("Success to enter result on DATABASE --- Error sending result to Webhook");
                throw new Exception("Success to enter result on DATABASE --- Error sending result to Webhook");
            }

        }
    }
}

using DataGenerator.Domain.Interfaces;
using DataGenerator.Entities.Entities;
using DataGenerator.Infrastructure.Interfaces;
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

        public DataResponseInfraService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task NotifyNewDataResponse(DataResponse dataResponse)
        {

            var success = await _httpService.PostAsync("https://localhost:44318/api/MachineSenseWebhook/DataGeneratorTopic", dataResponse);
            if (!success)
            {
                throw new Exception("Success to enter result on DATABASE --- Error sending result to Webhook");
            }

        }
    }
}

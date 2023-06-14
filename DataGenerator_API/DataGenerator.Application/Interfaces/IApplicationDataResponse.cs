using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Application.Interfaces
{
    public interface IApplicationDataResponse
    {
        public Task NotifyNewDataResponse(DataResponse dataResponse);
    }
}

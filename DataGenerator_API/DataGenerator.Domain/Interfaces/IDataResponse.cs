using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Domain.Interfaces
{
    public interface IDataResponse
    {
        Task NotifyNewDataResponse(DataResponse dataResponse);
    }
}

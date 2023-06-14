using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Domain.InterfacesServices
{
    public interface IDataResponseService
    {
        Task NotifyNewDataResponse(DataResponse dataResponse);
    }
}

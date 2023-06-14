using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Application.Interfaces
{
    public interface IApplicationResultData
    {
        Task Add(ResultData resultData);
    }
}

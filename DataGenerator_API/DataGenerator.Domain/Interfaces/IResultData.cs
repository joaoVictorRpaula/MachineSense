using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Domain.Interfaces
{
    public interface IResultData
    {
        Task Add(ResultData resultData);
    }
}

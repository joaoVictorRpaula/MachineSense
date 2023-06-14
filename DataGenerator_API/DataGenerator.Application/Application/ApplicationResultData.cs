using DataGenerator.Application.Interfaces;
using DataGenerator.Domain.Interfaces;
using DataGenerator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Application.Application
{
    public class ApplicationResultData : IApplicationResultData
    {
        private readonly IResultData _IResultData;  
        public ApplicationResultData(IResultData IResultData)
        {
            _IResultData = IResultData;
        }
        public async Task Add(ResultData resultData)
        {
            await _IResultData.Add(resultData);
        }
    }
}

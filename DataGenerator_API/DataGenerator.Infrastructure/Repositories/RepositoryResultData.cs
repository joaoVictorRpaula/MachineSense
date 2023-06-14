using DataGenerator.Domain.Interfaces;
using DataGenerator.Entities.Entities;
using DataGenerator.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Infrastructure.Repositories
{
    public class RepositoryResultData : IResultData
    {
        private readonly Context _db;

        public RepositoryResultData(Context db)
        {
            _db = db;
        }
        public async Task Add(ResultData resultData)
        {
            await _db.ResultData.AddAsync(resultData);
            await _db.SaveChangesAsync();
        }
    }
}

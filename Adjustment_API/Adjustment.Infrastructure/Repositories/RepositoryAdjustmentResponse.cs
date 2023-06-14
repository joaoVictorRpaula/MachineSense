using Adjustment.Domain.Interfaces;
using Adjustment.Entities.Entities;
using Adjustment.Infrastructure.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Infrastructure.Repositories
{
    public class RepositoryAdjustmentResponse : IAdjustmentResponse
    {
        private readonly Context _db;

        public RepositoryAdjustmentResponse(Context db)
        {
            _db = db;
        }
        public async Task AddAdjustmentResponse(AdjustmentResponse adjustmentResponse)
        {
            await _db.AdjustmentResponse.AddAsync(adjustmentResponse);
            await _db.SaveChangesAsync();
        }

    }
}

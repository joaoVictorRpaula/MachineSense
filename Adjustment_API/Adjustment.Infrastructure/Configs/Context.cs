using Adjustment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment.Infrastructure.Configs
{
    public class Context :DbContext
    {
        public Context(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<AdjustmentResponse> AdjustmentResponse { get; set; }
    }
}

using Adjustment_Component.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Infrastructure.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadContent(string ContentPath);
        Task<bool> WriteContent(string ContentPath, string FileContent);
        string GenerateFilePath(AdjustmentResponse adjustmentResponse);
        string GetAdjustLocal(AdjustmentResponse adjustmentResponse);
    }
}

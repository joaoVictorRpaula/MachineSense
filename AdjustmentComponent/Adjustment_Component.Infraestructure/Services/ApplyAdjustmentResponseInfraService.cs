using Adjustment_Component.Domain.Interfaces;
using Adjustment_Component.Entities.Entities;
using Adjustment_Component.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Infrastructure.Services
{
    public class ApplyAdjustmentResponseInfraService : IApplyAdjustmentResponse
    {     
        private readonly IFileService _FileService;
        private readonly ILogger<ApplyAdjustmentResponseInfraService> _Logger;
        public ApplyAdjustmentResponseInfraService(IFileService fileService, ILogger<ApplyAdjustmentResponseInfraService> logger)
        {
            _FileService = fileService;
            _Logger = logger;
        }


        public async Task ApplyAdjustment(AdjustmentResponse adjustmentResponse)
        {
            string calculedAdjustFileContent = await GetCalculedAdjustFileContentAsync(adjustmentResponse);
            string destinyFilePath = _FileService.GenerateFilePath(adjustmentResponse); 
            
            await _FileService.WriteContent(destinyFilePath,calculedAdjustFileContent);
            _Logger.LogInformation("Adjustment Applyed on: "+ destinyFilePath);
            _Logger.LogInformation("New file content" + calculedAdjustFileContent);

        }
        private async Task<string> GetCalculedAdjustFileContentAsync(AdjustmentResponse adjustmentResponse)
        {

            string filePath = _FileService.GenerateFilePath(adjustmentResponse);
            string fileContentText = await _FileService.ReadContent(filePath);
            string adjustLocal = _FileService.GetAdjustLocal(adjustmentResponse);

            //Manipulating string with file content to get actual parameter quantity
            int actualQuantityIndexLocal = fileContentText.IndexOf(adjustLocal) + adjustLocal.Length;
            decimal actualQuantity = decimal.Parse(fileContentText.Substring(actualQuantityIndexLocal, 2));
            
            int newCalculedAdjustedQuantity = (int)(actualQuantity + adjustmentResponse.AdjustmentQuantity);

            return fileContentText.Substring(0, actualQuantityIndexLocal) + newCalculedAdjustedQuantity.ToString() + " " + fileContentText.Substring(actualQuantityIndexLocal + 2);
        }

    }
}

using Adjustment_Component.Entities.Entities;
using Adjustment_Component.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adjustment_Component.Infrastructure.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _Ilogger;
        private readonly IConfiguration _configuration;

        public FileService(ILogger<FileService> ilogger, IConfiguration configuration)
        {
            _Ilogger = ilogger;
            _configuration = configuration;
        }

        public async Task<string> ReadContent(string ContentPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(ContentPath))
                {
                    return await sr.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                _Ilogger.LogError("An error ocurred while reading file: " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _Ilogger.LogError("An error ocurred while reading file: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> WriteContent(string ContentPath, string FileContent)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(ContentPath))
                {
                    await sw.WriteAsync(FileContent);
                    return true;
                }
            }
            catch(FileNotFoundException ex)
            {
                _Ilogger.LogError("An error ocurred while writing file: " + ex.Message);
                throw;
            }
            catch (IOException ex)
            {
                _Ilogger.LogError("An error ocurred while writing file: " + ex.Message);
                throw;
            }
        }
        public string GenerateFilePath(AdjustmentResponse adjustmentResponse)
        {
            return _configuration.GetSection("FileConfiguration")["BaseDirectory"] + adjustmentResponse.AdjustmentMachine + _configuration.GetSection("FileConfiguration")["FileName"];
        }
        public string GetAdjustLocal(AdjustmentResponse adjustmentResponse)
        {
            return adjustmentResponse.AdjustmentCharacteristic + _configuration.GetSection("FileConfiguration")["LocalToAdjust"];
        }
        
    }
}

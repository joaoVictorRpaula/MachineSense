using DataGenerator.Interfaces;
using DataGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataGenerator.Services
{
    public class ResultService : IResultService
    {
        public async Task StartGenerateResult(int timeToGenerateResult)
        {
            while (true)
            {
                var result = ResultGenerate();
                

                await SendToAPIAsync(result);
                Console.WriteLine(result);

                await Task.Delay(TimeSpan.FromSeconds(timeToGenerateResult));
            }
            
        }

        private static async Task SendToAPIAsync(ResultData resultData)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44393");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var json = JsonSerializer.Serialize(resultData);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/ResultData", content);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error sending result to API: " + ex.Message);
            }
        }

        private ResultData ResultGenerate()
        {
            Random random = new Random();
            ResultData resultData = new ResultData();


            string randomMachineName = DataVariables.MachineNames[random.Next(3)];
            int randomAngleResult = random.Next(DataVariables.AngleResultRandomMinimo, DataVariables.AngleResultRandomMaximo);
            int randomDiameterResult = random.Next(DataVariables.DiameterRandomMinimo, DataVariables.DiameterRandomMaximo);


            resultData.ResultDate = DateTime.Now;
            resultData.MachineName = randomMachineName;
            resultData.AngleResult = randomAngleResult;
            resultData.AngleUpperTol = DataVariables.AngleUpperTols;
            resultData.AngleLowerTol = DataVariables.AngleLowerTols;
            resultData.DiameterResult = randomDiameterResult;
            resultData.DiameterUpperTol = DataVariables.DiameterUpperTols;
            resultData.DiameterLowerTol = DataVariables.DiameterLowerTols;

            return resultData;
        }
    }
}

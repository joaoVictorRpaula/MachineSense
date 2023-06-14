using DataGenerator.Interfaces;
using DataGenerator.Model;
using DataGenerator.Services;
using System;
using System.Threading.Tasks;

namespace DataGenerator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IResultService resultService = new ResultService();

            try{
                await resultService.StartGenerateResult();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

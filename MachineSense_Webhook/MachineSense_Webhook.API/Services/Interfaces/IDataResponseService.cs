using MachineSense_Webhook.API.Model;
using System.Threading.Tasks;

namespace MachineSense_Webhook.API.Services.Interfaces
{
    public interface IDataResponseService
    {
        Task SendDataResponseToAdjustmentAPI(DataResponse dataResponse);
    }
}

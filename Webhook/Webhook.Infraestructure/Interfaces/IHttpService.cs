using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhook.Infrastructure.Interfaces
{
    public interface IHttpService
    {
        Task<bool> PostAsync<T>(string url, T data);
    }
}

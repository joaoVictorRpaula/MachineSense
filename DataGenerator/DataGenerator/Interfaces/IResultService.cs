using DataGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Interfaces
{
    public interface IResultService
    {
        public Task StartGenerateResult();
    }
}

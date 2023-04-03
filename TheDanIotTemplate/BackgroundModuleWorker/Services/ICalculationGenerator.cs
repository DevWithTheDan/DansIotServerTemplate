using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundModuleWorker.Services
{
    public interface ICalculationGenerator
    {
        Task GenerateCalculations(CancellationToken cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundModuleWorker.ScopedServices
{
    public interface IScopedService
    {
        Task DoScopedWork(CancellationToken cancellationToken);
    }
}

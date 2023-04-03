using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CalculationDataRepositories
{
    public interface ICalculationDataRepository
    {
        List<CalculationData> GetCalculations(int referenceId, DateTime from, DateTime to);
        CalculationData? GetLatest();
        void InsertCalculationData(CalculationData data);
    }
}

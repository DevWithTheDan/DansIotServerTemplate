using SeededDatabase.Models;

namespace Repositories.CalculationDataRepositories
{
    public interface ICalculationDataRepository
    {
        List<CalculationData> GetCalculations(int referenceId, DateTime from, DateTime to);
        List<CalculationData> GetAllData();
        CalculationData? GetLatest();
        void InsertCalculationData(CalculationData data);
    }
}

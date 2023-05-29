using SeededDatabase.Models;
using ViewModels;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public interface ICalculationService
    {
        List<CalculationReference> GetAllReferences();
        List<CalculationData> GetCalculationData(int referenceId, DateTime from, DateTime to);
        List<CalculationView> GetCalculationView();
    }
}

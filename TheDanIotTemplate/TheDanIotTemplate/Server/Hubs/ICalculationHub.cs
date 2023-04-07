using SeededDatabase.Models;
using ViewModels;

namespace TheDanIotTemplate.Server.Hubs
{
    public interface ICalculationHub
    {
        Task AllReferences(List<CalculationReference> references);
        Task CalculationData(List<CalculationData> data);
        Task CalculationViewList(List<CalculationView> viewList);
    }
}

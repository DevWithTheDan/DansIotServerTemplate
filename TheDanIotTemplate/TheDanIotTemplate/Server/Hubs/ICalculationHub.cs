using SeededDatabase.Models;

namespace TheDanIotTemplate.Server.Hubs
{
    public interface ICalculationHub
    {
        Task AllReferences(List<CalculationReference> references);
        Task CalculationData(List<CalculationData> data);
    }
}

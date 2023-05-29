using SeededDatabase.Models;

namespace Repositories.CalulationReferenceRepositories
{
    public interface ICalculationReferenceRepository
    {
        List<CalculationReference> GetAllCalculationReferences();
        CalculationReference? GetCalculationReference(int id);
    }
}

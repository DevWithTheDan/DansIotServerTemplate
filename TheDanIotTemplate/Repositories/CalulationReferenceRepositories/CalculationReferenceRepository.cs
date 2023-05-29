using SeededDatabase.Context;
using SeededDatabase.Models;

namespace Repositories.CalulationReferenceRepositories
{
    public class CalculationReferenceRepository : ICalculationReferenceRepository
    {
        private readonly SeededDatabaseContext _context;
        public CalculationReferenceRepository(SeededDatabaseContext context)
        {
            _context = context;
        }

        public List<CalculationReference> GetAllCalculationReferences()
        {
            return _context.CalculationReferences.ToList();
        }

        public CalculationReference? GetCalculationReference(int id)
        {
            return _context.CalculationReferences.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}

using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.CalulationReferenceRepositories
{
    public interface ICalculationReferenceRepository
    {
        List<CalculationReference> GetAllCalculationReferences();
        CalculationReference? GetCalculationReference(int id);
    }
}

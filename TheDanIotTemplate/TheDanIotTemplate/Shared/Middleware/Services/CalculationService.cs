using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculationDataRepository _dataRepository;
        private readonly ICalculationReferenceRepository _referenceRepository;

        public CalculationService(ICalculationDataRepository dataRepository, ICalculationReferenceRepository referenceRepository)
        {
            _dataRepository = dataRepository;
            _referenceRepository = referenceRepository;
        }

        public List<CalculationReference> GetAllReferences()
        {
            return _referenceRepository.GetAllCalculationReferences();
        }

        public List<CalculationData> GetCalculationData(int referenceId, DateTime from, DateTime to)
        {
            return _dataRepository.GetCalculations(referenceId, from, to);
        }
    }
}

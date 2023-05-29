using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using SeededDatabase.Models;
using ViewModels;

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

        public List<CalculationView> GetCalculationView()
        {
            var references = _referenceRepository.GetAllCalculationReferences();
            var dataList = _dataRepository.GetAllData();
            var now = DateTime.Now;
            var from = now.AddDays(-7);

            var views = new List<CalculationView>();
            foreach (var reference in references)
            {
                var thisDataList = dataList.Where(x => x.ReferenceId.Equals(reference.Id));
                foreach (var item in thisDataList)
                {
                    views.Add(new CalculationView
                    {
                        CalculationData = item,
                        CalculationReference = reference
                    });
                }
            }
            return views;
        }
    }
}

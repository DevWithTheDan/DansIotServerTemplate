using BackgroundModuleWorker.Services;
using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using SeededDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundModuleWorker.ScopedServices
{
    public class ScopedService : IScopedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private ICalculationGenerator _calculationGenerator;

        public ScopedService(IServiceScopeFactory serviceScopeFactory, ICalculationGenerator calculationGenerator)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _calculationGenerator = calculationGenerator;
        }

        public async Task DoScopedWork(CancellationToken cancellationToken)
        {
            using var mainScope = _serviceScopeFactory.CreateScope();
            var context = mainScope.ServiceProvider.GetService<SeededDatabaseContext>();
            _calculationGenerator = GetCalculationGenerator(context);
            await _calculationGenerator.GenerateCalculations(cancellationToken);
            return;
        }

        private CalculationGenerator GetCalculationGenerator(SeededDatabaseContext context)
        {
            var dataRepo = new CalculationDataRepository(context);
            var reference = new CalculationReferenceRepository(context);
            return new CalculationGenerator(dataRepo, reference);
        }
    }
}

using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundModuleWorker.Services
{
    public class CalculationGenerator : ICalculationGenerator
    {
        private readonly ICalculationDataRepository _calculationDataRepository;
        private readonly ICalculationReferenceRepository _calculationReferenceRepository;

        public CalculationGenerator(ICalculationDataRepository calculationDataRepository, ICalculationReferenceRepository calculationReferenceRepository)
        {
            _calculationDataRepository = calculationDataRepository;
            _calculationReferenceRepository = calculationReferenceRepository;
        }

        public async Task GenerateCalculations(CancellationToken cancellationToken)
        {
            try
            {
                var references = _calculationReferenceRepository.GetAllCalculationReferences();
                foreach (var reference in references)
                {
                    Random random = new();

                    int randomNumberOne = random.Next(reference.Min, reference.Max);
                    int randomNumberTwo = random.Next(reference.Min, reference.Max);

                    int result = randomNumberOne * randomNumberTwo;
                    if (reference.CalculationName.ToLower().Equals("plus"))
                    {
                        result = randomNumberOne + randomNumberTwo;
                    }
                    else if (reference.CalculationName.ToLower().Equals("minus"))
                    {
                        result = randomNumberOne - randomNumberTwo;
                    }
                    else if (reference.CalculationName.ToLower().Equals("divide"))
                    {
                        result = randomNumberOne / randomNumberTwo;
                    }

                    if (reference.IsPositiveOnly)
                    {
                        if (result < 0)
                        {
                            result = +result;
                        }
                    }
                    if (reference.IsNegativeOnly)
                    {
                        if (result > 0)
                        {
                            result = -result;
                        }
                    }

                    var newData = new CalculationData
                    {
                        ReferenceId = reference.Id,
                        Data = result,
                        Timestamp = DateTime.Now,
                    };

                    _calculationDataRepository.InsertCalculationData(newData);
                }
            }
            catch (OperationCanceledException)
            {
                return;
            }
        }
    }
}
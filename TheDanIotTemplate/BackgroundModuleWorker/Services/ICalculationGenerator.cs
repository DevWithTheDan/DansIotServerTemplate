namespace BackgroundModuleWorker.Services
{
    public interface ICalculationGenerator
    {
        Task GenerateCalculations(CancellationToken cancellationToken);
    }
}

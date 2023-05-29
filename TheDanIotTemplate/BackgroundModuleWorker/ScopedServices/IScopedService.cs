namespace BackgroundModuleWorker.ScopedServices
{
    public interface IScopedService
    {
        Task DoScopedWork(CancellationToken cancellationToken);
    }
}

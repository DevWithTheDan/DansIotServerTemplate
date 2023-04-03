using BackgroundModuleWorker;
using BackgroundModuleWorker.ScopedServices;
using BackgroundModuleWorker.Services;
using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using SeededDatabase.Context;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<SeededDatabaseContext>(ServiceLifetime.Transient);
        services.AddTransient<IScopedService, ScopedService>();
        services.AddTransient<ICalculationGenerator, CalculationGenerator>();
        services.AddTransient<ICalculationDataRepository, CalculationDataRepository>();
        services.AddTransient<ICalculationReferenceRepository, CalculationReferenceRepository>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();

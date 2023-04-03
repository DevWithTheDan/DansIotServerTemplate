using Microsoft.AspNetCore.ResponseCompression;
using Repositories.CalculationDataRepositories;
using Repositories.CalulationReferenceRepositories;
using Repositories.SettingsRepositories;
using SeededDatabase.Context;
using TheDanIotTemplate.Server.Hubs;
using TheDanIotTemplate.Shared.Middleware.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SeededDatabaseContext>(ServiceLifetime.Transient);
builder.Services.AddTransient<ICalculationDataRepository, CalculationDataRepository>();
builder.Services.AddTransient<ICalculationReferenceRepository, CalculationReferenceRepository>();
builder.Services.AddTransient<ICalculationService, CalculationService>();

builder.Services.AddTransient<ISettingsRepository, SettingsRepository>();
builder.Services.AddTransient<ISettingsService, SettingsService>();

builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.MapHub<CalculationHub>("/CalculationHub");
app.MapHub<SettingsHub>("/SettingsHub");
app.Run();

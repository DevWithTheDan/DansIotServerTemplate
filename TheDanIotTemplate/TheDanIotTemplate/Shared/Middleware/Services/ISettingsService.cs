using SeededDatabase.Models;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public interface ISettingsService
    {
        FrontendGauge? GetArcGauge();
        FrontendGauge? GetRadialGauge();
        void AddSetting(FrontendGauge frontendGauge);
        void UpdateSetting(FrontendGauge frontendGauge);
        void DeleteSetting(FrontendGauge frontendGauge);
        void UpsertSetting(FrontendGauge frontendGauge);

    }
}

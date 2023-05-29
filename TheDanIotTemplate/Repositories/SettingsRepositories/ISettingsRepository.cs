using SeededDatabase.Models;

namespace Repositories.SettingsRepositories
{
    public interface ISettingsRepository
    {
        FrontendGauge? GetArcGaugeSetting();
        FrontendGauge? GetRadialGaugeSetting();
        void AddSetting(FrontendGauge frontendGauge);
        void UpdateSeting(FrontendGauge frontendGauge);
        void DeleteSetting(FrontendGauge frontendGauge);
    }
}

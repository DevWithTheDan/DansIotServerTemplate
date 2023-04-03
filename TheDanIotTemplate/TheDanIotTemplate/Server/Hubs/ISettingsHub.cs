using SeededDatabase.Models;

namespace TheDanIotTemplate.Server.Hubs
{
    public interface ISettingsHub
    {
        Task ArcGaugeSetting(FrontendGauge frontendGauge);
        Task RadialGaugeSetting(FrontendGauge frontendGauge);

    }
}

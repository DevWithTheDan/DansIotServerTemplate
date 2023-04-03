using Microsoft.AspNetCore.SignalR;
using SeededDatabase.Models;
using TheDanIotTemplate.Shared.Middleware.Services;

namespace TheDanIotTemplate.Server.Hubs
{
    public class SettingsHub : Hub<ISettingsHub>
    {
        private ISettingsService _settingsService;
        public SettingsHub(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public void GetArcGaugeSetting()
        {
            var arcGauge = _settingsService.GetArcGauge();
            Clients.Caller.ArcGaugeSetting(arcGauge);
        }

        public void GetRadialGaugeSetting()
        {
            var arcGauge = _settingsService.GetRadialGauge();
            Clients.Caller.RadialGaugeSetting(arcGauge);
        }

        public void AddGaugeSetting(FrontendGauge frontendGauge)
        {
            _settingsService.AddSetting(frontendGauge);
        }

        public void UpdateGaugeSetting(FrontendGauge frontendGauge)
        {
            _settingsService.UpdateSetting(frontendGauge);
        }

        public void DeleteGaugeSetting(FrontendGauge frontendGauge)
        {
            _settingsService.DeleteSetting(frontendGauge);
        }

        public void UpdateOrAddSetting(FrontendGauge frontendGauge)
        {
            _settingsService.UpsertSetting(frontendGauge);
        }
    }
}

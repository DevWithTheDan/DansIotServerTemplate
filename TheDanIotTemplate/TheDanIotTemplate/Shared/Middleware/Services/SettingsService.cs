using Repositories.SettingsRepositories;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;
        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public FrontendGauge? GetArcGauge()
        {
            return _settingsRepository.GetArcGaugeSetting();
        }

        public FrontendGauge? GetRadialGauge()
        {
            return _settingsRepository.GetRadialGaugeSetting();
        }

        public void AddSetting(FrontendGauge frontendGauge)
        {
            _settingsRepository.AddSetting(frontendGauge);
        }

        public void UpdateSetting(FrontendGauge frontendGauge)
        {
            _settingsRepository.UpdateSeting(frontendGauge);
        }

        public void DeleteSetting(FrontendGauge frontendGauge)
        {
            _settingsRepository.DeleteSetting(frontendGauge);
        }

        public void UpsertSetting(FrontendGauge frontendGauge)
        {
            FrontendGauge? foundSetting = null;
            if (frontendGauge.Type.ToLower().Equals("arc"))
            {
                foundSetting = _settingsRepository.GetArcGaugeSetting();
            }
            else if (frontendGauge.Type.ToLower().Equals("radial"))
            {
                foundSetting = _settingsRepository.GetRadialGaugeSetting();
            }

            if (foundSetting == null)
            {
                AddSetting(frontendGauge);
            }
            else
            {
                UpdateSetting(frontendGauge);
            }
        }
    }
}

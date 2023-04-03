using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

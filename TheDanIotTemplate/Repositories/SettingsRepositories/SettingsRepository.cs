using SeededDatabase.Context;
using SeededDatabase.Models;

namespace Repositories.SettingsRepositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private SeededDatabaseContext _context { get; set; }
        public SettingsRepository(SeededDatabaseContext context)
        {
            _context = context;
        }

        public FrontendGauge? GetArcGaugeSetting()
        {
            return _context.FrontendGauges.FirstOrDefault(x => x.Type.ToLower().Equals("arc"));
        }

        public FrontendGauge? GetRadialGaugeSetting()
        {
            return _context.FrontendGauges.FirstOrDefault(x => x.Type.ToLower().Equals("radial"));
        }

        public void AddSetting(FrontendGauge frontendGauge)
        {
            _context.FrontendGauges.Add(frontendGauge);
            _context.SaveChanges();
        }

        public void UpdateSeting(FrontendGauge frontendGauge)
        {
            var dbSetting = _context.FrontendGauges.FirstOrDefault(x => x.Id.Equals(frontendGauge.Id));
            if (dbSetting != null)
            {
                dbSetting.StartAngle = frontendGauge.StartAngle;
                dbSetting.EndAngle = frontendGauge.EndAngle;
                dbSetting.HeightPx = frontendGauge.HeightPx;
                dbSetting.WidthPx = frontendGauge.WidthPx;
                dbSetting.Min = frontendGauge.Min;
                dbSetting.Max = frontendGauge.Max;
                dbSetting.GaugeTickPosition = frontendGauge.GaugeTickPosition;
                dbSetting.Step = frontendGauge.Step;
                dbSetting.Suffix = frontendGauge.Suffix;
            }
            _context.FrontendGauges.Update(dbSetting);
            _context.SaveChanges();
        }

        public void DeleteSetting(FrontendGauge frontendGauge)
        {
            _context.FrontendGauges.Remove(frontendGauge);
            _context.SaveChanges();
        }


    }
}

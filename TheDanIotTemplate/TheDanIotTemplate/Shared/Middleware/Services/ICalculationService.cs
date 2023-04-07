using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public interface ICalculationService
    {
        List<CalculationReference> GetAllReferences();
        List<CalculationData> GetCalculationData(int referenceId, DateTime from, DateTime to);
        List<CalculationView> GetCalculationView();
    }
}

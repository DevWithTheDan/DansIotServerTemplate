using Microsoft.AspNetCore.SignalR;
using TheDanIotTemplate.Shared.Middleware.Services;

namespace TheDanIotTemplate.Server.Hubs
{
    public class CalculationHub : Hub<ICalculationHub>
    {
        private readonly ICalculationService _calculationService;

        public CalculationHub(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public void GetAllReferences()
        {
            var references = _calculationService.GetAllReferences();
            Clients.Caller.AllReferences(references);
        }

        public void GetData(int referenceId, DateTime from, DateTime to)
        {
            var data = _calculationService.GetCalculationData(referenceId, from, to);
            Clients.Caller.CalculationData(data);
        }
    }
}

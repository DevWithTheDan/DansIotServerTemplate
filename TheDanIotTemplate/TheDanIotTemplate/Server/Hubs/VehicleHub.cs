using Microsoft.AspNetCore.SignalR;
using TheDanIotTemplate.Shared.Middleware.Services;

namespace TheDanIotTemplate.Server.Hubs
{
    public class VehicleHub : Hub<IVehicleHub>
    {
        private IVehicleService _vehicleService;

        public VehicleHub(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        public void GetVehicleManufacturers()
        {
            var manufacturers = _vehicleService.GetVehicleManufacturers();
            Clients.Caller.VehicleManufacturers(manufacturers);
        }

        public void GetManufacturerModels(int modelId)
        {
            var models = _vehicleService.GetVehicleModels(modelId);
            Clients.Caller.VehicleModels(models);
        }

        public void GetVehicleDetailsByModel(int modelId)
        {
            var details = _vehicleService.GetVehicleDetailsByModel(modelId);
            Clients.Caller.VehicleDetails(details);
        }
    }
}

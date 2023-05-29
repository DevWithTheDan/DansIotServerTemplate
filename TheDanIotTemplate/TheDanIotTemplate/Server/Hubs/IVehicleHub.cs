using SeededDatabase.Models;

namespace TheDanIotTemplate.Server.Hubs
{
    public interface IVehicleHub
    {
        Task VehicleManufacturers(List<VehicleManufacturer> manufacturers);
        Task VehicleModels(List<VehicleModel> models);
        Task VehicleDetails(List<VehicleDetail> details);
    }
}

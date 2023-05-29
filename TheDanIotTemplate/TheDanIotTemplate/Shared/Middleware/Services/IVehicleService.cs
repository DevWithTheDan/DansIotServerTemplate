using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public interface IVehicleService
    {
        List<VehicleManufacturer> GetVehicleManufacturers();
        List<VehicleModel> GetVehicleModels(int manufacturerId);
        List<VehicleOwner> GetVehicleOwners();
        List<VehicleDetail> GetVehicleDetailsByModel(int modelId);
        List<VehicleDetail> GetVehicleDetailsByOwner(int ownerId);

    }
}

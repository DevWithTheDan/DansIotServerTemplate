using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.VehicleRepositories
{
    public interface IVehicleRepository
    {
        List<VehicleManufacturer> GetVehicleManufacturers();
        List<VehicleModel> GetVehicleModels(int manufacturerId);
        List<VehicleOwner> GetVehicleOwners();
        List<VehicleDetail> GetOwnerVehicleDetails(int ownerId);
        List<VehicleDetail> GetVehicleDetailsByModel(int modelId);
    }
}

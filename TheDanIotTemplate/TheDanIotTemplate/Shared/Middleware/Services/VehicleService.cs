using Repositories.VehicleRepositories;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDanIotTemplate.Shared.Middleware.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public List<VehicleManufacturer> GetVehicleManufacturers()
        {
            return _vehicleRepository.GetVehicleManufacturers();
        }

        public List<VehicleModel> GetVehicleModels(int manufacturerId)
        {
            return _vehicleRepository.GetVehicleModels(manufacturerId);
        }

        public List<VehicleOwner> GetVehicleOwners()
        {
            return _vehicleRepository.GetVehicleOwners();
        }

        public List<VehicleDetail> GetVehicleDetailsByModel(int modelId)
        {
            return _vehicleRepository.GetVehicleDetailsByModel(modelId);
        }

        public List<VehicleDetail> GetVehicleDetailsByOwner(int ownerId)
        {
            return _vehicleRepository.GetOwnerVehicleDetails(ownerId);
        }
    }
}

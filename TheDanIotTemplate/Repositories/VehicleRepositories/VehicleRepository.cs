using SeededDatabase.Context;
using SeededDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.VehicleRepositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly SeededDatabaseContext _context;
        public VehicleRepository(SeededDatabaseContext context)
        {
            _context = context;
        }

        public List<VehicleManufacturer> GetVehicleManufacturers()
        {
            return _context.VehicleManufacturers.ToList();
        }

        public List<VehicleModel> GetVehicleModels(int manufacturerId)
        {
            return _context.VehicleModels.Where(x => x.ManufacturerId.Equals(manufacturerId)).ToList();
        }

        public List<VehicleOwner> GetVehicleOwners()
        {
            return _context.VechicleOwners.ToList();
        }

        public List<VehicleDetail> GetOwnerVehicleDetails(int ownerId)
        {
            return _context.VehicleDetails.Where(x => x.OwnerId.Equals(ownerId)).ToList();
        }

        public List<VehicleDetail> GetVehicleDetailsByModel(int modelId)
        {
            return _context.VehicleDetails.Where(x=>x.ModelId.Equals(modelId)).ToList();
        }
    }
}

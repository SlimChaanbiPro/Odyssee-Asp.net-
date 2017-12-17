using Odyssey.Data.Infrastructure;
using Odyssey.Data.Interfaces;
using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public class LocationServices : ILocationServices
    {
        IUnitOfWork utOfWork;
        DatabaseFactory dbFactory;

        public LocationServices()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }

        public void CreateLocation(Location location)
        {
            utOfWork.LocationRepository.Add(location);
            utOfWork.Commit();
        }

        public Location GetLocationById(string id)
        {
            return utOfWork.LocationRepository.GetById(id);
        }

        public ICollection<Location> GetAllLocations()
        {
            return utOfWork.LocationRepository.GetAll().ToList();
        }

        public void EditLocation(Location location)
        {
            utOfWork.LocationRepository.Update(location);
            utOfWork.Commit();
        }

        public void DeleteLocation(string id)
        {
            utOfWork.LocationRepository.Delete(l => l.LocationCode == id);
            utOfWork.Commit();
        }

        public void Dispose()
        {
            utOfWork.Dispose();
        }
    }
}

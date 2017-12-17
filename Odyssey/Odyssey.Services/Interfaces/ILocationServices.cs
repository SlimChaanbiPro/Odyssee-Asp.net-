using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public interface ILocationServices : IDisposable
    {
        void CreateLocation(Location location);
        Location GetLocationById(string id);
        ICollection<Location> GetAllLocations();
        void EditLocation(Location location);
        void DeleteLocation(string id);
    }
}

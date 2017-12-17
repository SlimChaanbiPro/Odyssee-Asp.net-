using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public interface IJourneyServices : IDisposable
    {
        ICollection<Journey> GetComingJourneys();
        ICollection<Journey> GetJourneysByCustomer(int idCustomer);

        void CreateJourney(Journey journey);
        Journey GetJourneyById(int id);
        ICollection<Journey> GetAllJourneys();
        void EditJourney(Journey journey);
        void DeleteJourney(int id);
    }
}

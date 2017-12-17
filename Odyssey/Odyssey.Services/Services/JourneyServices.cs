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
    public class JourneysServices : IJourneyServices
    {
        IUnitOfWork utOfWork;
        DatabaseFactory dbFactory;

        public JourneysServices()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }

        public void Dispose()
        {
            utOfWork.Dispose();
        }


        public void CreateJourney(Journey journey)
        {
            utOfWork.JourneyRepository.Add(journey);
            utOfWork.Commit();
        }

        public Journey GetJourneyById(int id)
        {
            return utOfWork.JourneyRepository.GetById(id);
        }

        public ICollection<Journey> GetAllJourneys()
        {
            return utOfWork.JourneyRepository.GetAll().ToList();
        }

        public void EditJourney(Journey journey)
        {
            utOfWork.JourneyRepository.Update(journey);
            utOfWork.Commit();
        }

        public void DeleteJourney(int id)
        {
            utOfWork.JourneyRepository.Delete(j => j.JourneyId == id);
            utOfWork.Commit();
        }
    }
}

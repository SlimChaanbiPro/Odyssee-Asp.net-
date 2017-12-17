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
    public class AnalyticsServices : IAnalyticsServices
    {
        IUnitOfWork utOfWork;
        DatabaseFactory dbFactory;

        public AnalyticsServices()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }

        public void Dispose()
        {
            utOfWork.Dispose();
        }
    }
}

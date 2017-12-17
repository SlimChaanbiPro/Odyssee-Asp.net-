using Odyssey.Data.Interfaces;
using Odyssey.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private OdysseyContext dataContext;
        protected OdysseyContext DataContext
        {
            get
            {
                return dataContext = dbFactory.DataContext;
            }
        }

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public void Commit()
        {
            DataContext.SaveChanges();
        }
        private ICustomerRepository customerRepository;
        public ICustomerRepository CustomerRepository
        {
            get { return customerRepository = new CustomerRepository(dbFactory); }
        }

        private IJourneyRepository journeyRepository;
        public IJourneyRepository JourneyRepository
        {
            get { return journeyRepository = new JourneyRepository(dbFactory); }
        }

        private ILocationRepository locationRepository;
        public ILocationRepository LocationRepository
        {
            get { return locationRepository = new LocationRepository(dbFactory); ; }
        }

        private IOperatingCompanyRepository operatingCompanyRepository;
        public IOperatingCompanyRepository OperatingCompanyRepository
        {
            get { return operatingCompanyRepository = new OperatingCompanyRepository(dbFactory); }
        }

        public void Dispose()
        {
            dbFactory.Dispose();
        }
    }
}

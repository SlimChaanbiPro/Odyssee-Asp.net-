using Odyssey.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        ICustomerRepository CustomerRepository { get; }
        IJourneyRepository JourneyRepository { get; }
        ILocationRepository LocationRepository { get; }
        IOperatingCompanyRepository OperatingCompanyRepository { get; }
    }
}

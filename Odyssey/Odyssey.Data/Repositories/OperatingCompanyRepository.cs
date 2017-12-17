using Odyssey.Data.Infrastructure;
using Odyssey.Data.Interfaces;
using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Data.Repositories
{
    public class OperatingCompanyRepository : RepositoryBase<OperatingCompany>, IOperatingCompanyRepository
    {
        public OperatingCompanyRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IOperatingCompanyRepository : IRepository<OperatingCompany>
    {

    }
}

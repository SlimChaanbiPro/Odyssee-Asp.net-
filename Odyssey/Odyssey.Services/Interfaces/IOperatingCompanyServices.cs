using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public interface IOperatingCompanyServices : IDisposable
    {
        void CreateOperatingCompany(OperatingCompany operatingCompany);
        OperatingCompany GetOperatingCompanyById(int id);
        ICollection<OperatingCompany> GetAllOperatingCompanies();
        void EditOperatingCompany(OperatingCompany operatingCompany);
        void DeleteOperatingCompany(int id);
    }
}

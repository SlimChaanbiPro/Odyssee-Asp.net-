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
    public class OperatingCompanyServices : IOperatingCompanyServices
    {
        IUnitOfWork utOfWork;
        DatabaseFactory dbFactory;

        public OperatingCompanyServices()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }

        public void CreateOperatingCompany(OperatingCompany operatingCompany)
        {
            utOfWork.OperatingCompanyRepository.Add(operatingCompany);
            utOfWork.Commit();
        }

        public OperatingCompany GetOperatingCompanyById(int id)
        {
            return utOfWork.OperatingCompanyRepository.GetById(id);
        }

        public ICollection<OperatingCompany> GetAllOperatingCompanies()
        {
            return utOfWork.OperatingCompanyRepository.GetAll().ToList();
        }

        public void EditOperatingCompany(OperatingCompany operatingCompany)
        {
            utOfWork.OperatingCompanyRepository.Update(operatingCompany);
            utOfWork.Commit();
        }

        public void DeleteOperatingCompany(int id)
        {
            utOfWork.OperatingCompanyRepository.Delete(oc => oc.OperatingCompanyId == id);
            utOfWork.Commit();
        }

        public void Dispose()
        {
            utOfWork.Dispose();
        }
    }
}

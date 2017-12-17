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
    public class CustomerServices : ICustomerServices
    {
        IUnitOfWork utOfWork;
        DatabaseFactory dbFactory;

        public CustomerServices()
        {
            dbFactory = new DatabaseFactory();
            utOfWork = new UnitOfWork(dbFactory);
        }

        public void CreateCustomer(Customer customer)
        {
            utOfWork.CustomerRepository.Add(customer);
            utOfWork.Commit();
        }

        public Customer GetCustomerById(int id)
        {
            return utOfWork.CustomerRepository.GetById(id);
        }

        public ICollection<Customer> GetAllCustomers()
        {
            return utOfWork.CustomerRepository.GetAll().ToList();
        }

        public void EditCustomer(Customer customer)
        {
            utOfWork.CustomerRepository.Update(customer);
            utOfWork.Commit();
        }

        public void DeleteCustomer(int id)
        {
            utOfWork.CustomerRepository.Delete(c => c.CustomerId == id);
            utOfWork.Commit();
        }

        public void Dispose()
        {
            utOfWork.Dispose();
        }
    }
}

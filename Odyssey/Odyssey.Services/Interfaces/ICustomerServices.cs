using Odyssey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odyssey.Services
{
    public interface ICustomerServices : IDisposable
    {
        void CreateCustomer(Customer customer);
        Customer GetCustomerById(int id);
        ICollection<Customer> GetAllCustomers();
        void EditCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}

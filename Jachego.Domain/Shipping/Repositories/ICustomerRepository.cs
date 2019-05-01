using Jachego.Domain.Shipping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Repositories
{
    interface ICustomerRepository
    {
        Customer GetById(Guid id);
        void Save(Customer customer);
        IEnumerable<Customer> GetCustomers();
    }
}

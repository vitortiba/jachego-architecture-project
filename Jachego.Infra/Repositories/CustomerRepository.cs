using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Jachego.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;

        public CustomerRepository (StoreDataContext context)
        {
            _context = context;
        }

        Customer ICustomerRepository.GetById(Guid id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

    }
}

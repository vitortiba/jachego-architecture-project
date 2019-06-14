using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Jachego.Infra.Contexts;

namespace Jachego.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDataContext _context;

        public CustomerRepository(StoreDataContext context)
        {
            _context = context;
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void Delete(Guid id)
        {
            var customer = _context.Customers.Find(id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }



    }
}

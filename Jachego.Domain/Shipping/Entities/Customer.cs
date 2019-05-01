using Jachego.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Entities
{
    public class Customer : Entity
    {
        public Customer(
           string name,
           string document,
           string email,
           string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

    }
}


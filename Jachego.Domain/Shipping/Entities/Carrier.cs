using Jachego.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Entities
{
    public class Carrier : Entity
    {
        public Carrier(
           string name,
           string document,
           string email
           )
        {
            Name = name;
            Document = document;
            Email = email;
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
    }
}

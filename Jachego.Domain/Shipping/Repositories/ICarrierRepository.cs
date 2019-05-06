using Jachego.Domain.Shipping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Repositories
{
    public interface ICarrierRepository
    {
        Carrier GetById(Guid id);
        void Save(Carrier carrier);
        IEnumerable<Carrier> GetCarriers();
    }
}

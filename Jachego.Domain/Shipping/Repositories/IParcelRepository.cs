using Jachego.Domain.Shipping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Repositories
{
    public interface IParcelRepository
    {
        void Save(Parcel parcel);
        IEnumerable<Parcel> GetParcels();
        Parcel GetParcelByCode(string code);
        void Delete(string code);
    }
}

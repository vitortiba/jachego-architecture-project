using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Jachego.Infra.Contexts;

namespace Jachego.Infra.Repositories
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly StoreDataContext _context;

        public ParcelRepository(StoreDataContext context)
        {
            _context = context;
        }

        public Parcel GetParcelByCode(string code)
        {
            return _context.Parcel.Find(code);
        }

        public void Save(Parcel parcel)
        {
            _context.Parcel.Add(parcel);
            _context.SaveChanges();
        }

        public IEnumerable<Parcel> GetParcels()
        {
            return _context.Parcel.ToList();
        }
        public void Delete(string code)
        {
            var parcel = _context.Parcel.Find(code);

            _context.Parcel.Remove(parcel);
            _context.SaveChanges();
        }


    }
}

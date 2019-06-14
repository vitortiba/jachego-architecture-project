using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Jachego.Infra.Contexts;

namespace Jachego.Infra.Repositories
{
    public class CarrierRepository : ICarrierRepository
    {
        private readonly StoreDataContext _context;

        public CarrierRepository(StoreDataContext context)
        {
            _context = context;
        }

        public Carrier GetById(Guid id)
        {
            return _context.Carriers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Save(Carrier carrier)
        {
            _context.Carriers.Add(carrier);
            _context.SaveChanges();
        }

        public IEnumerable<Carrier> GetCarriers()
        {
            return _context.Carriers.ToList();
        }

        public void Delete(Guid id)
        {
            var carrier = _context.Carriers.Find(id);

            _context.Carriers.Remove(carrier);
            _context.SaveChanges();
        }

        /**
        public void UpdateCarrier(Carrier carrier)
        {
            var existingCarrier = _context.Carriers.Where(s => s.Id == carrier.Id).FirstOrDefault<Carrier>();

            if (existingCarrier != null)
            {
                existingCarrier.Name = carrier.Name;
                existingCarrier.Document = carrier.Document;
                existingCarrier.Document = carrier.Email;

                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
        }
        **/



    }
}

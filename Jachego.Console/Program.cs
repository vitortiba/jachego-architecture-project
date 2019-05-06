using Jachego.Domain.Shipping.Entities;
using Jachego.Domain.Shipping.Repositories;
using Jachego.Domain.Shipping.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fakeCustomerRepository = new FakeCustomerRepository();
            var fakeCarrierRepository = new FakeCarrierRepository();
            GenerateParcel(fakeCustomerRepository, fakeCarrierRepository);
        }
        public static void GenerateParcel(
            ICustomerRepository customerRepository,
            ICarrierRepository carrierRepository
            )
        {
            var customer = customerRepository.GetById(Guid.NewGuid());
            var carrier = carrierRepository.GetById(Guid.NewGuid());
            var parcel = new Parcel(
                new DeliveryInterval(new DateTime(20180202), new DateTime(20180205)),
                new TrackingCode("123", carrier),   
                carrier,
                customer,
                "12341"
                );
        }
        public class FakeCustomerRepository : ICustomerRepository
        {
            public Customer GetById(Guid id)
            {
                var customerFake = new Customer
                (
                    "João",
                    "11111111111",
                    "email@teste.com",
                    "14999999999"
                );
                return customerFake;
            }
            public IEnumerable<Customer> GetCustomers()
            {
                throw new NotImplementedException();
            }

            public void Save(Customer customer)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeCarrierRepository : ICarrierRepository
        {

            public Carrier GetById(Guid id)
            {
                var carrierFake = new Carrier
                (
                    "João",
                    "11111111111",
                    "email@teste.com"
                );
                return carrierFake;
            }

            public IEnumerable<Carrier> GetCarriers()
            {
                throw new NotImplementedException();
            }

            public void Save(Carrier carrier)
            {
                throw new NotImplementedException();
            }
        }

        public class FakeParcelRepository : IParcelRepository
        {
            public Parcel GetParcelByCode(string code)
            {
                var customerRepository = new FakeCustomerRepository();
                var carrierRepository = new FakeCarrierRepository();
                var customer = customerRepository.GetById(Guid.NewGuid());
                var carrier = carrierRepository.GetById(Guid.NewGuid());
                var parcelFake = new Parcel(
                    new DeliveryInterval(new DateTime(20180202), new DateTime(20180205)),
                    new TrackingCode("123", carrier),
                    carrier,
                    customer,
                    "12341"
                    );
                return parcelFake;
            }

            public IEnumerable<Parcel> GetParcels()
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Parcel> GetParcelsByCarrier(Guid id)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Parcel> GetParcelsByCustomer(Guid id)
            {
                throw new NotImplementedException();
            }

            public void Save(Parcel parcel)
            {
                throw new NotImplementedException();
            }
        }
    }
}

using Jachego.Domain.Shipping.ValueObjects;
using Jachego.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.Entities
{
    public class Parcel : Entity
    {
        public Parcel(
           DeliveryInterval deliveryInterval,
           TrackingCode trackingCode,
           Carrier carrier,
           Customer customer,
           string code
           )
        {
            DeliveryInterval = deliveryInterval;
            TrackingCode = trackingCode;
            Carrier = carrier;
            Customer = customer;
            Code = code;
        }

        public DeliveryInterval DeliveryInterval { get; private set; }
        public TrackingCode TrackingCode { get; private set; }
        public Carrier Carrier { get; private set; }
        public Customer Customer { get; private set; }
        public string Code { get; private set; }
    }
}

using Jachego.Domain.Shipping.Entities;
using Jachego.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.ValueObjects
{
    public class TrackingCode : ValueObject
    {
        public TrackingCode(string code, Carrier carrier)
        {
            Code = code;
            Carrier = carrier;

            if (String.IsNullOrEmpty(code))
            {
                AddNotification("code", "É necessário que tenha um código de rastreio");
            }
            if (carrier.Equals(null))
            {
                AddNotification("carrier", "A transportadora está vazia");
            }
        }

        public string Code { get; private set; }
        public Carrier Carrier { get; private set; }

        public string BuildCode ()
        {
            return Carrier.Name + '-' + Code;
        }
    }
}

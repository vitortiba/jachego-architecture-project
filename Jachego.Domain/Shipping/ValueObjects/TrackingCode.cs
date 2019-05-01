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
                AddNotification("code", "endereço do e-mail vazio");
        }

        public string Code { get; private set; }
        public Carrier Carrier { get; private set; }

        public string FormatCode ()
        {
            return Carrier.Name + '-' + Code;
        }
    }
}

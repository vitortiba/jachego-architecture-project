using Jachego.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jachego.Domain.Shipping.ValueObjects
{
    public class DeliveryInterval : ValueObject
    {
        public DeliveryInterval (DateTime startDeliveryDate, DateTime expectedDeliveryDate)
        {
            StartDeliveryDate = startDeliveryDate;
            ExpectedDeliveryDate = expectedDeliveryDate;
        }

        public DateTime StartDeliveryDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public double IntervalOfDays()
        {
            return ExpectedDeliveryDate.Subtract(StartDeliveryDate).TotalDays;
        }
    }
}

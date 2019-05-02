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

            if (expectedDeliveryDate.Equals(null))
            {
                AddNotification("expectedDeliveryDate", "A data esperada está vazia");
            }
            if (startDeliveryDate.Equals(null))
            {
                AddNotification("startDeliveryDate", "A data de início está vazia");
            }
            if (expectedDeliveryDate.CompareTo(startDeliveryDate) < 0)
            {
                AddNotification("expectedDeliveryDate", "A data esperada para a entrega é anterior à data de início.");
            }
        }

        public DateTime StartDeliveryDate { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public double IntervalOfDays()
        {
            return ExpectedDeliveryDate.Subtract(StartDeliveryDate).TotalDays;
        }

        public string StringfyInterval()
        {
            return StartDeliveryDate.ToString() + " até " + ExpectedDeliveryDate.ToString();
        }
    }
}

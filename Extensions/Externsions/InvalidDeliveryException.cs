using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Externsions
{
    internal class InvalidDeliveryException : Exception
    {
        public Delivery.DeliveryStatus Status { get; set; } 
        public InvalidDeliveryException(Delivery.DeliveryStatus status , string message) : base(message) 
        {
            this.Status = (Delivery.DeliveryStatus) ((int)status + 1);
        }
    }
}

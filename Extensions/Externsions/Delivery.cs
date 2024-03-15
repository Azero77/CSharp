using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Externsions
{
    internal partial class Delivery
    {
        public int Id { get; set; }
        public string CostumerName { get; set; }

        public DeliveryStatus Status { get; set; }

        

        public event EventHandler Delivered;

        public virtual void OnDelivered()
        {
            Delivered?.Invoke(this, EventArgs.Empty);
        }
    }
}

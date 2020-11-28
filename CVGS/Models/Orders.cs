using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public string Id { get; set; }
        public string UserId { get; set; }
        public Guid? ShippingId { get; set; }
        public Guid? MailingId { get; set; }
        public bool IsShipped { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AddressMailing Mailing { get; set; }
        public virtual AddressShipping Shipping { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}

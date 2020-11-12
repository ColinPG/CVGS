using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class AddressShipping
    {
        public int ShippingId { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ApartmentNumber { get; set; }
        public string Province { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastModified { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}

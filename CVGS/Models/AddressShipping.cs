﻿using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class AddressShipping
    {
        public AddressShipping()
        {
            Order = new HashSet<Order>();
        }

        public Guid ShippingId { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string ApartmentNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public DateTime? LastModified { get; set; }
        public string UserId { get; set; }
        public string ProvinceCode { get; set; }
        public bool? Archived { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}

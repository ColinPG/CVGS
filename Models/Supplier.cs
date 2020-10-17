using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            SupplierContact = new HashSet<SupplierContact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string LocalPhone { get; set; }
        public string Fax { get; set; }
        public string TollFreePhone { get; set; }
        public string WebSite { get; set; }
        public string UserName { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual ICollection<SupplierContact> SupplierContact { get; set; }
    }
}

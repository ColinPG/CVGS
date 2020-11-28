using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Province
    {
        public Province()
        {
            AddressMailing = new HashSet<AddressMailing>();
            AddressShipping = new HashSet<AddressShipping>();
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public string Code { get; set; }
        public string CountryCode { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
        public double? FederalTax { get; set; }
        public string FederalTaxAcronym { get; set; }
        public double? ProvincialTax { get; set; }
        public string ProvincialTaxAcronym { get; set; }
        public bool? PstOnGst { get; set; }

        public virtual ICollection<AddressMailing> AddressMailing { get; set; }
        public virtual ICollection<AddressShipping> AddressShipping { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}

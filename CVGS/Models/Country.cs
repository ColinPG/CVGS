using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Country
    {
        public Country()
        {
            AddressMailing = new HashSet<AddressMailing>();
            AddressShipping = new HashSet<AddressShipping>();
            AspNetUsers = new HashSet<AspNetUsers>();
        }

        public string Code { get; set; }
        public string Alpha2Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<AddressMailing> AddressMailing { get; set; }
        public virtual ICollection<AddressShipping> AddressShipping { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}

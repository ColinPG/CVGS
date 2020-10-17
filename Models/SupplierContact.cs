using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class SupplierContact
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string LandLine { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}

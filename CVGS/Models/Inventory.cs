using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Inventory
    {
        public Guid ProductGuid { get; set; }
        public string LocationGln { get; set; }
        public short NewOnHand { get; set; }
        public short NewOnOrder { get; set; }
        public short UsedOnHand { get; set; }
        public string UserName { get; set; }

        public virtual Location LocationGlnNavigation { get; set; }
        public virtual Product ProductGu { get; set; }
    }
}

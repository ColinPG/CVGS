using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
        }

        public Guid Guid { get; set; }
        public string Gtin { get; set; }
        public string NewSku { get; set; }
        public string UsedSku { get; set; }
        public string GameCompanyPartNumber { get; set; }
        public Guid GameGuid { get; set; }
        public int PublisherId { get; set; }
        public int DeveloperId { get; set; }
        public string PlatformCode { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal Msrp { get; set; }
        public decimal NewStorePrice { get; set; }
        public decimal NewWebPrice { get; set; }
        public bool? AcceptUsed { get; set; }
        public decimal? UsedCustomerCredit { get; set; }
        public decimal? UsedStorePrice { get; set; }
        public decimal? UsedWebPrice { get; set; }
        public string UserName { get; set; }

        public virtual GameCompany Developer { get; set; }
        public virtual Game GameGu { get; set; }
        public virtual Platform PlatformCodeNavigation { get; set; }
        public virtual GameCompany Publisher { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class OrderItem
    {
        public Guid OrderId { get; set; }
        public Guid GameId { get; set; }
        public string GameFormatCode { get; set; }
        public int Quantity { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Game Game { get; set; }
        public virtual GameFormat GameFormatCodeNavigation { get; set; }
        public virtual Order Order { get; set; }
    }
}

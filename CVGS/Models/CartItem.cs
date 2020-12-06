using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class CartItem
    {
        public string UserId { get; set; }
        public Guid GameId { get; set; }
        public string GameFormatCode { get; set; }
        public int Quantity { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Game Game { get; set; }
        public virtual GameFormat GameFormatCodeNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

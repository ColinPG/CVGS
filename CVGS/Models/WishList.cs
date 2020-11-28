using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class WishList
    {
        public string UserId { get; set; }
        public Guid GameId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Game Game { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

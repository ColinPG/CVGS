using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class UserGameLibraryItem
    {
        public string UserId { get; set; }
        public Guid GameId { get; set; }
        public DateTime? DatePurchased { get; set; }

        public virtual Game Game { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

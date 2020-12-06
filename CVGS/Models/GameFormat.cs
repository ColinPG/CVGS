using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameFormat
    {
        public GameFormat()
        {
            CartItem = new HashSet<CartItem>();
            Game = new HashSet<Game>();
            OrderItem = new HashSet<OrderItem>();
        }

        public string Code { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<Game> Game { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameFormat
    {
        public GameFormat()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}

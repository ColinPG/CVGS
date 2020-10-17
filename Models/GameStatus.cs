using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameStatus
    {
        public GameStatus()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GamePerspective
    {
        public GamePerspective()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishPerspectiveName { get; set; }
        public string FrenchPerspectiveName { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}

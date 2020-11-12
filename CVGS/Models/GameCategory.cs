using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameCategory
    {
        public GameCategory()
        {
            CategoryPreference = new HashSet<CategoryPreference>();
            Game = new HashSet<Game>();
        }

        public int Id { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<CategoryPreference> CategoryPreference { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}

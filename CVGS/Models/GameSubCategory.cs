using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameSubCategory
    {
        public GameSubCategory()
        {
            Game = new HashSet<Game>();
            SubCategoryPreference = new HashSet<SubCategoryPreference>();
        }

        public int Id { get; set; }
        public int GameCategoryId { get; set; }
        public string EnglishCategory { get; set; }
        public string FrenchCategory { get; set; }

        public virtual ICollection<Game> Game { get; set; }
        public virtual ICollection<SubCategoryPreference> SubCategoryPreference { get; set; }
    }
}

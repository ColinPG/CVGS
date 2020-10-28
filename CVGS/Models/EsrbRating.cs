using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class EsrbRating
    {
        public EsrbRating()
        {
            Game = new HashSet<Game>();
        }

        public string Code { get; set; }
        public string EnglishRating { get; set; }
        public string FrenchRating { get; set; }

        public virtual ICollection<Game> Game { get; set; }
    }
}

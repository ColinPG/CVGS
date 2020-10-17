using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Region
    {
        public Region()
        {
            Location = new HashSet<Location>();
        }

        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}

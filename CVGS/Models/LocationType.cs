using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            Location = new HashSet<Location>();
        }

        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Location> Location { get; set; }
    }
}

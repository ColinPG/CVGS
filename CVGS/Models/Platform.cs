using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Platform
    {
        public Platform()
        {
            PlatformPreference = new HashSet<PlatformPreference>();
        }

        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<PlatformPreference> PlatformPreference { get; set; }
    }
}

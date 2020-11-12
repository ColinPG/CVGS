using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class PlatformPreference
    {
        public string UserId { get; set; }
        public string PlatformCode { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual Platform PlatformCodeNavigation { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

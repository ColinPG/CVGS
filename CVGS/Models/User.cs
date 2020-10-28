using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVGS.Models
{
    public class User : IdentityUser
    {
        public string Bio { get; set; }
        public string GamerTag { get; set; }
        public bool PromoEmailEnabled { get; set; }
    }
}

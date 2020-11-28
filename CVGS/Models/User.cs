using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVGS.Models
{
    public class User : IdentityUser
    {
        public bool PromoEmailEnabled { get; set; }
        public string Bio { get; set; }
        public string GamerTag { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string City { get; set; }
    }
}

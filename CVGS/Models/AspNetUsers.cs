using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AddressMailing = new HashSet<AddressMailing>();
            AddressShipping = new HashSet<AddressShipping>();
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            AspNetUserTokens = new HashSet<AspNetUserTokens>();
            CategoryPreference = new HashSet<CategoryPreference>();
            PlatformPreference = new HashSet<PlatformPreference>();
            SubCategoryPreference = new HashSet<SubCategoryPreference>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public bool? PromoEmailEnabled { get; set; }
        public string Bio { get; set; }
        public string GamerTag { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string ProvinceState { get; set; }
        public string City { get; set; }

        public virtual ICollection<AddressMailing> AddressMailing { get; set; }
        public virtual ICollection<AddressShipping> AddressShipping { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<CategoryPreference> CategoryPreference { get; set; }
        public virtual ICollection<PlatformPreference> PlatformPreference { get; set; }
        public virtual ICollection<SubCategoryPreference> SubCategoryPreference { get; set; }
    }
}

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
            CartItem = new HashSet<CartItem>();
            CategoryPreference = new HashSet<CategoryPreference>();
            Orders = new HashSet<Orders>();
            PlatformPreference = new HashSet<PlatformPreference>();
            SubCategoryPreference = new HashSet<SubCategoryPreference>();
            UserGameLibrary = new HashSet<UserGameLibrary>();
            WishList = new HashSet<WishList>();
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
        public string City { get; set; }
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual ICollection<AddressMailing> AddressMailing { get; set; }
        public virtual ICollection<AddressShipping> AddressShipping { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<CategoryPreference> CategoryPreference { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<PlatformPreference> PlatformPreference { get; set; }
        public virtual ICollection<SubCategoryPreference> SubCategoryPreference { get; set; }
        public virtual ICollection<UserGameLibrary> UserGameLibrary { get; set; }
        public virtual ICollection<WishList> WishList { get; set; }
    }
}

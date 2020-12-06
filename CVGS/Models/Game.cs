using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Game
    {
        public Game()
        {
            CartItem = new HashSet<CartItem>();
            OrderItem = new HashSet<OrderItem>();
            UserGameLibraryItem = new HashSet<UserGameLibraryItem>();
            WishListItem = new HashSet<WishListItem>();
        }

        public Guid Guid { get; set; }
        public string GameFormatCode { get; set; }
        public int GameCategoryId { get; set; }
        public int? GameSubCategoryId { get; set; }
        public string EsrbRatingCode { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
        public bool FrenchVersion { get; set; }
        public string EnglishPlayerCount { get; set; }
        public string FrenchPlayerCount { get; set; }
        public string GamePerspectiveCode { get; set; }
        public string EnglishTrailer { get; set; }
        public string FrenchTrailer { get; set; }
        public string EnglishDescription { get; set; }
        public string FrenchDescription { get; set; }
        public string EnglishDetail { get; set; }
        public string FrenchDetail { get; set; }
        public string UserName { get; set; }
        public DateTime? LastModified { get; set; }
        public double? Price { get; set; }

        public virtual EsrbRating EsrbRatingCodeNavigation { get; set; }
        public virtual GameCategory GameCategory { get; set; }
        public virtual GameFormat GameFormatCodeNavigation { get; set; }
        public virtual GamePerspective GamePerspectiveCodeNavigation { get; set; }
        public virtual GameSubCategory GameSubCategory { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual ICollection<UserGameLibraryItem> UserGameLibraryItem { get; set; }
        public virtual ICollection<WishListItem> WishListItem { get; set; }
    }
}

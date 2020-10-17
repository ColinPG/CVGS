using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class GameCompany
    {
        public GameCompany()
        {
            ProductDeveloper = new HashSet<Product>();
            ProductPublisher = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Product> ProductDeveloper { get; set; }
        public virtual ICollection<Product> ProductPublisher { get; set; }
    }
}

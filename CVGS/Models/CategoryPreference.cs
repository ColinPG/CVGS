using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class CategoryPreference
    {
        public string UserId { get; set; }
        public int GamecategoryId { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual GameCategory Gamecategory { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

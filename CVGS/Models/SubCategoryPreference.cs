using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class SubCategoryPreference
    {
        public string UserId { get; set; }
        public int GameSubcategoryId { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual GameSubCategory GameSubcategory { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}

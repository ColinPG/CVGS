using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class PopulationClassification
    {
        public PopulationClassification()
        {
            Population = new HashSet<Population>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Population> Population { get; set; }
    }
}

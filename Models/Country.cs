using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Country
    {
        public Country()
        {
            Location = new HashSet<Location>();
            Person = new HashSet<Person>();
            Population = new HashSet<Population>();
            Supplier = new HashSet<Supplier>();
        }

        public string Code { get; set; }
        public string Alpha2Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }

        public virtual ICollection<Location> Location { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Population> Population { get; set; }
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Country
    {
        public Country()
        {
        }

        public string Code { get; set; }
        public string Alpha2Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
    }
}

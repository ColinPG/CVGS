using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class CreditCard
    {
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string FrenchName { get; set; }
        public byte CardNumberLength { get; set; }
        public string CardNumberPrefixList { get; set; }
    }
}

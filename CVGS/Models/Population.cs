using System;
using System.Collections.Generic;

namespace CVGS.Models
{
    public partial class Population
    {
        public Guid Guid { get; set; }
        public int Sequence { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string PopulationClassificationCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string LandLine { get; set; }
        public string Extension { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Sin { get; set; }
        public string Hin { get; set; }
        public string FinancialInstitution { get; set; }
        public string BranchAddress { get; set; }
        public string TransitNumber { get; set; }
        public string BankCode { get; set; }
        public string AccountNumber { get; set; }
        public string Visa { get; set; }
        public string MasterCard { get; set; }
        public string Amex { get; set; }
        public bool Allocated { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual PopulationClassification PopulationClassificationCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
    }
}

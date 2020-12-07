using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVGS.Models
{
    public partial class AddressMailing
    {
        public string Summary()
        {
            string result;
            string province = "";
            if (!String.IsNullOrEmpty(ProvinceCode))
                province = "<br/> <b>Province</b> <br/> " + ModelValidations.Capitilize(ProvinceCodeNavigation.EnglishName);
            result = "<b> Street </b> <br/>" + Street + "<br/> <b>City</b> <br/>" + City
                 + " <br/> <b>Postal Code</b> <br/>" +PostalCode + " <br/> <b>Country</b> <br/>" + ModelValidations.Capitilize(CountryCodeNavigation.EnglishName) + " " +province;          
            //<b> + street etc
            return result;
        }

        public string ShortSummary()
        {
            string result;
            string province = "";
            if (!String.IsNullOrEmpty(ProvinceCode))
                province =  ModelValidations.Capitilize(ProvinceCodeNavigation.EnglishName);
            result = Street + ", "+ PostalCode + ", " + ModelValidations.Capitilize(CountryCodeNavigation.EnglishName) + ", " + province;
            //<b> + street etc
            return result;
          
        }
    }

    public partial class AddressShipping
    {
        public string Summary()
        {
            string result;
            string province = "";
            if (!String.IsNullOrEmpty(ProvinceCode))
                province = "<br/> <b>Province</b> <br/> " + ModelValidations.Capitilize(ProvinceCodeNavigation.EnglishName);
            result = "<b> Street </b> <br/>" + Street + "<br/> <b>City</b> <br/>" + City
                 + " <br/> <b>Postal Code</b> <br/>" + PostalCode + " <br/> <b>Country</b> <br/>" + ModelValidations.Capitilize(CountryCodeNavigation.EnglishName) + " " + province;

            return result;
        }

        public string ShortSummary()
        {
            string result;
            string province = "";
            if (!String.IsNullOrEmpty(ProvinceCode))
                province = ModelValidations.Capitilize(ProvinceCodeNavigation.EnglishName);
            result = Street + ", " + PostalCode + ", " + ModelValidations.Capitilize(CountryCodeNavigation.EnglishName) + ", " + province;
            //<b> + street etc
            return result;
        }
    }
}

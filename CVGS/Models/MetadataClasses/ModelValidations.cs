using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CVGS.Models
{
    public static class ModelValidations
    {
        public static string Capitilize(string input)
        {
            if (input == null)
                return string.Empty;
            string output = input.ToLower();
            output = output.Trim(' ');
            string[] words = output.Split(' ');
            output = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(words[i]))
                    output += words[i].First().ToString().ToUpper() + words[i].Substring(1);
                if (i != (words.Length - 1))
                    output += " ";
            }
            return output;
        }

        public static bool IsStringNumeric(string input)
        {
            input = input.Trim();
            char[] letters = input.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (!char.IsDigit(letters[i]))
                    return false;
            }
            return true;
        }
        public static bool PostalCodeValidation(string postalCode)
        {
            Regex pattern = new Regex(@"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$",
                RegexOptions.IgnoreCase);
            if (postalCode == null || postalCode == "" || pattern.IsMatch(postalCode.ToString()))
                return true;
            else
                return false;
        }

        // Accepts 000-000-0000, (000) 000-0000, 000 000 0000, 000.000.0000, +00 000 000 000
        public static bool ValidPhoneNumber(string phoneNumber)
        {
            Regex pattern = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
                RegexOptions.IgnoreCase);
            if (phoneNumber == null || phoneNumber == "" || pattern.IsMatch(phoneNumber.ToString()))
                return true;
            else
                return false;
        }

        public static bool ValidEmail(string email)
        {
            Regex pattern = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Z0-9.-]+\.[A-Za-z]{2,4}$",
                RegexOptions.IgnoreCase);
            if (email == null || email == "" || pattern.IsMatch(email.ToString()))
                return true;
            else
                return false;
        }
    }
}

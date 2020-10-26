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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GENX.Files
{
   public static class StringExtensions
    {
        public static string ReplaceWithDash(this string input)
        {
            string output = AddSpacesBetweenWords(input);
            output = output.Replace(" ", "-");
            return output;
        }

        public static string ReplaceWithDash(this StringBuilder input)
        {
            string output = ReplaceWithCamelCase(input.ToString());
            output = output.Replace(" ", "-");
            return output;
        }

        public static string AddSpacesBetweenWords(this string input)
        {
            string output = Regex.Replace(input, "([a-z])_?([A-Z])", "$1 $2");
            return output;
        }

        public static string ReplaceWithCamelCase(this string input)
        {
            
            string camelCase = input.Substring(0, 1).ToLower() + input.Substring(1);
            return camelCase;
        }

        public static string ReplaceWithCamelCase(this StringBuilder input)
        {
            string output = Regex.Replace(input.ToString(), "([a-z])_?([A-Z])", "$1 $2");
            string camelCase = output.Substring(0, 1).ToLower() + output.Substring(1);
            return camelCase;
        }

        public static string GetFileExtention(this string fileName)
        {
            try
            {
                string extention = fileName.Substring(fileName.LastIndexOf(".") + 1);
                return extention;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

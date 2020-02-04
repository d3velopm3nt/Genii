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
            string output = Regex.Replace(input, "([a-z])_?([A-Z])", "$1 $2");
            output = output.Replace(" ", "-");
            return output;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Extensions
{
   public  class ExtensionHelper
    {
        public static string[] GetAllExtensionsFromFileText(string text)
        {
            string[] extensions = text.Split(new[] { ExtensionConstants.ExtensionDelimiter }, StringSplitOptions.RemoveEmptyEntries);
           
            return extensions;
        }
    }
}

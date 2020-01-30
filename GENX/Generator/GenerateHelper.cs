using GENX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator
{
  public static  class GenerateHelper
    {

        public static string ReplaceEntityTag(this string text,string table)
        {
            text.Replace(CoreConstants.Entity, table);

            //This will check any [entity] keywords in the text file.
            text.Replace(CoreConstants.Entity.ToLower(), table.ToLower());

            return text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALX.Core.Sql
{
   internal static class DBFormatHelper
    {
        internal static string FixSingleQuotesInText(string text)
        {
            if (text.Contains("'"))
                text.Replace("'", "''");

            return text;
        }
    }
}

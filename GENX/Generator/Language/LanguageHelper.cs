using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Language
{
    public static class LanguageHelper
    {
        public static LanguageList GetProgrammingLangauage(string extension)
        {
            LanguageList language  = LanguageList.CShaprp;
            switch (extension)
            {
                case "js":
                    language = LanguageList.JavaScript;
                    break;
                case "cs":
                    language = LanguageList.CShaprp;
                    break;
                case "cshtml":
                    language = LanguageList.csHtml;
                    break; 
                case "css":
                    language = LanguageList.Css;
                    break;
            }

            return language;
        }
    }
}

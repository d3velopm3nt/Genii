using GENX.Files;
using GENX.Generator.Template;
using GENX.Interfaces;
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
            LanguageList language  = LanguageList.CSHARP;
            switch (extension)
            {
                case "js":
                    language = LanguageList.JAVASCRIPT;
                    break;
                case "cs":
                    language = LanguageList.CSHARP;
                    break;
                case "cshtml":
                    language = LanguageList.CSHTML;
                    break; 
                case "css":
                    language = LanguageList.CSS;
                    break;
                case "ts":
                    language = LanguageList.TYPESCRIPT;
                    break;
                case "html":
                language = LanguageList.HTML;
                break;
            }
            return language;
        }

        public static IXFile GetFileFromExtention(string ext,IXFile projectFile = null)
        {
            
            switch(GetProgrammingLangauage(ext))
            {
                case LanguageList.CSHARP:
                  return  new CSharpFile(projectFile);
                case LanguageList.TYPESCRIPT:
                   return  new TypescriptFile(projectFile);
                case LanguageList.HTML:
                return new HtmlFile(projectFile);
                default:
                    return new TemplateFile(projectFile);
            }
        }
    }
}

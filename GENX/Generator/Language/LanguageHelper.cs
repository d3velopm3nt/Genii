using GENX.Files;
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
            }
            return language;
        }

        public static IXFile GetFileFromExtention(IXFile file)
        {
            switch(GetProgrammingLangauage(file.FileExtension))
            {
                case LanguageList.CSHARP:
                    file = (CSharpFile)file;
                    break;
                    
                case LanguageList.TYPESCRIPT:
                    file = (TypescriptFile)file;
                    break;
            }

            return file;
        }
    }
}

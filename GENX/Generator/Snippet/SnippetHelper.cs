using DALX.Core;
using GENX.Generator.Language;
using GENX.Generator.Library;
using GENX.Generator.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Snippet
{
   public static class SnippetHelper
    {
        #region Properties
        internal static string GetFullPath
        {
            get
            {
                var path = LibraryHelper.GetFullPath("\\Snippets\\");
                FileHelper.CreateFolderPathExist(path);
                return path;
            }
        }
        #endregion
        public static SnippetFile BuildSnippetFile(IXFile file)
        {
            var snippet = new SnippetFile();
                snippet.BuildFileX(file);

            //Check the languag by file extension
            snippet.ProgramingLanguage = LanguageHelper.GetProgrammingLangauage(file.FileExtension);

            //Check For GenTags in File Text
            snippet.GenTagList = TagHelper.GetTagsInText(file.FileText);

            return snippet;
        }

       

    }
}

using GENX.Generator.Snippet;
using GENX.Generator.Tag;
using GENX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Generator.Solution;
using GENX.Interfaces;

namespace GENX.Generator.Library
{
   public static class LibraryManager
    {
        
        public static void Load()
        {
            CreateLibraryBase();
        }

        public static void CreateLibraryBase()
        {
            string solution = SolutionHelper.GetFullPath;
        }

        private static List<IXFile> snippetList;
        public static List<IXFile> LoadSnippetFileList()
        {
                if(snippetList == null)
                {
                    snippetList = LibraryHelper.GetFileXList(XType.Snippet,"");
                }
                return snippetList;
        }

        private static List<IXFile> codeList;
        public static List<IXFile> LoadTemplateFileList()
        {
                if (codeList == null)
                    codeList = LibraryHelper.GetFileXList(XType.Template,"");
                else
                    codeList = new List<IXFile>();
                return codeList;
            
        }

        private static List<IXFile> gentags;

        public static List<IXFile> LoadGenTagList()
        {
                if (gentags == null)
                    gentags = TagHelper.BuildTagList();

                return gentags;
        }




    }
}

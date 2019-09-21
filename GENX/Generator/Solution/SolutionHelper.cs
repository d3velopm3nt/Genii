using DALX.Core;
using GENX.Generator.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Solution
{
    public static class SolutionHelper
    {
        #region Properties
        public static string GetFullPath
        {
            get
            {
                var path = LibraryHelper.GetFullPath("Solutions\\");
                FileHelper.CreateFolderPathExist(path);
                return path;
            }
        }
        #endregion

        #region Methods
        public static void CreateSolutionFolder(string Folder)
        {
            FileHelper.CreateFolderPathExist(GetFullPath + Folder + "\\");
        }

        #endregion
    }
}

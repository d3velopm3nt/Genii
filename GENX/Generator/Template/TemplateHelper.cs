using DALX.Core;
using GENX.Generator.Library;
using GENX.Interfaces;

namespace GENX.Generator.Template
{
   public static class TemplateHelper 
    {
        #region Properties
        internal static string GetFullPath
        {
            get
            {
                var path = LibraryHelper.GetFullPath("\\Template\\");
                FileHelper.CreateFolderPathExist(path);
                return path;
            }
        }
        #endregion

        #region Methods
        internal static TemplateFile BuildXFile(IXFile file)
        {
            TemplateFile Gexfile = new TemplateFile();
            Gexfile.BuildFileX(file);

            return Gexfile;
        }
        #endregion


    }
}

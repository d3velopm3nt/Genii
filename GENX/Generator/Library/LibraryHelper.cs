using DALX.Core;
using GENX.Core;
using GENX.Generator.Template;
using GENX.Generator.Snippet;
using GENX.Generator.Tag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Library
{
    public static class LibraryHelper
    {
        #region Properties
        public static string LibraryPath
        {
            get
            {
                var libPath = GetDocumentsPath() + "\\GenX Source";
                FileHelper.CreateFolderPathExist(libPath);
                return libPath;
            }
        }

        public static void CreateFolder(XType xType)
        {
            try
            {
                if (xType == XType.Snippet)
                    FileHelper.CreateFolderPathExist(SnippetHelper.GetFullPath);
                else if (xType == XType.Template)
                    FileHelper.CreateFolderPathExist(TemplateHelper.GetFullPath);
                else if (xType == XType.Tag)
                    FileHelper.CreateFolderPathExist(TagHelper.GetFullPath);

            }
            catch (Exception ex)
            {
               
            }

        }
        #endregion
       
        #region Methods
        public static string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static string GetFullPath(string FolderName)
        {
            return LibraryPath + "\\" + FolderName;
        }

        public static string GetXTypeFolderName(XType type)
        {
            string folderName = "";
            switch (type)
            {
                case XType.Snippet:
                    folderName = SnippetHelper.GetFullPath;
                    break;
                case XType.Tag:
                    folderName = TagHelper.GetFullPath;
                    break;
                case XType.Template:
                    folderName = TemplateHelper.GetFullPath;
                    break;
            }
            return folderName;
        }


        public static List<IXFile> GetFileXList(XType typeFile,string path)
        {
            List<FileInfo> files = FileHelper.GetFilesFromPath(path);
            var xfiles = new List<IXFile>();

            foreach (FileInfo f in files)
            {
                FileX file = new FileX(FileHelper.ReadFile(f.FullName), f.Name, f.OpenText().ReadToEnd(), f.Extension);
                if (typeFile == XType.Snippet)
                    xfiles.Add(new SnippetFile(file));
                else if (typeFile == XType.Template)
                    xfiles.Add(new TemplateFile(file));
             

            }
            return xfiles.ToList();
        }

        #endregion

    }
}

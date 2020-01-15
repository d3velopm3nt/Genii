using DALX.Core;
using GENX.Interfaces;
using GENX.Generator.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator
{
   public class FileX : IXFile
    {
        #region Properties
        public string SolutionName { get; set; }
        public string ProjectName { get; set; }
        public string FullPath { get; set; }
        public string FileName { get; set; } = "";

        public string TargetPath { get; set; }

        public string FriendlyName
        {
            get
            {
                
                return FileName.Remove(FileName.LastIndexOf("."));
            }
        }

        public string Description { get; set; }
        public string FileText { get; set; }
        public string FileExtension { get; set; }
        public List<GenTag> GenTagList { get; set; }
        public List<Snippet.SnippetFile> Snippets { get; set; }
        #endregion

        #region Constructors
        public FileX()
        {
            
        }

        public FileX(string fullPath, string fileName, string fileText, string fileExtenstion,string soltuion,string project = null)
        {

        }

        public FileX(string fullPath,string fileName,string fileText,string fileExtenstion)
        {
            this.FullPath = fullPath;
            this.FileName = fileName.Substring(0,fileName.IndexOf("."));
            this.FileText = fileText;
            this.FileExtension = fileExtenstion;
        }

        public FileX(IXFile file)
        {
           Build(file);
        }

        #endregion
        #region Methods

        public IXFile Build(IXFile file)
        {
            return BuildFileX(file);
        }

        public bool Generate(string fullPath)
        {
            FileHelper.WriteToFile(fullPath, FileText);
            return true;
        }

        public IXFile BuildFileX(IXFile file)
        {
            this.FileName = file.FileName;
            this.FileText = FileText;
            this.FileExtension = FileExtension;
            this.SolutionName = file.SolutionName;
            this.ProjectName = file.ProjectName;
            this.FullPath = file.FullPath;
            return this; 
        }

        public IXFile Load(string path)
        {
            return this;
        }

        public virtual string GetDataType(string dbType)
        {
            return "";
        }

        #endregion
    }
}

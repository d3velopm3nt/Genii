using GENX.Generator.Connection;
using GENX.Generator.Snippet;
using GENX.Generator.Tag;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Interfaces
{
   public interface IXFile
    {
        #region Properties
        string SolutionName { get; set; }
        string ProjectName { get; set; }
        string FullPath { get; set; }
         string FileName { get; set; }
         string Description { get; set; }
         string FileText { get; set; }
         string FileExtension { get; set; }

        string TargetPath { get; set; }
        List<GenTag> GenTagList { get; set; }
        List<SnippetFile> Snippets { get; set; }

        string GetDataType(string dbType);
        #endregion

        #region Methods
        IXFile Build(IXFile xFile);
        bool Generate(string path);
        IXFile Load(string path);
        
        #endregion
    }
}

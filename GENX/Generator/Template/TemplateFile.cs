
using GENX.Generator.Snippet;
using GENX.Generator.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Template
{
    public class TemplateFile : FileX
    {
        #region    Properties
        public List<SnippetFile> SnippetList { get; set; }
        //public string TargetPath { get; set; } = "";
        #endregion

        public TemplateFile(IXFile file) :base(file)
        {

        }
        public TemplateFile()
        {

        }

        #region Methods


        public new void Load()
        {
            
        }
        #endregion
    }
}

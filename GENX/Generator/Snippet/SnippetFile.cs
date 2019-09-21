using DALX.Core;
using GENX.Generator.Template;
using GENX.Generator.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Snippet
{
   public class SnippetFile : FileX
    {
        #region Properties
      
        public LanguageList ProgramingLanguage { get; set; }


        #endregion

        #region Constructors
        public SnippetFile()
        {

        }

        public SnippetFile(IXFile file) :base(file)
        {

        }
        #endregion


        #region Methods

        public new IXFile Build(IXFile xfile)
        {
            return SnippetHelper.BuildSnippetFile(xfile);
        }

     
        #endregion

    }
}

using GENX.Generator;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Files
{
   public class HtmlFile : FileX
    {
        public HtmlFile()
        {

        }

        public HtmlFile(IXFile file) : base(file)
        {

        }

        private string fileName;
        public override string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value.ReplaceWithDash().ToLower();
            }
        }

    
    }
}

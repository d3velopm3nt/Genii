using GENX.Core;
using GENX.Generator;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Extensions
{
   public class ExtensionFile : FileX
    {
        public string FilePath { get; set; }
        public List<ExtensionLine> Extensions { get; set; }

        public ExtensionFile()
        {

        }

        public override IXFile Build(IXFile file)
        {
            file = base.BuildFileX(file);

            GetExtetions(file.FileText);

            return file;
        }

        private void GetExtetions(string text)
        {
            string[] lines = XFileHelper.GetAllLines(text);

            foreach(var line in lines)
            {

                if (!line.Contains(ExtensionConstants.Path))
                {
                    string[] exArr = line.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    ExtensionLine ex = new ExtensionLine()
                    {
                        Name = exArr[0],
                        Snippet = exArr[1],
                        ID = exArr.Length > 1 ? exArr[2] : ""
                    };
                    this.Extensions.Add(ex);
                }
                    else
                    this.FilePath = line.Replace(ExtensionConstants.Path + "::", "").Trim();

            }
        }


    }
}

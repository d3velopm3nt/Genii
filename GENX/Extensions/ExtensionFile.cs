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
   public class ExtensionFile 
    {
        public string FilePath { get; set; }
        public List<ExtensionLine> Extensions { get; set; }

        public ExtensionFile()
        {
            this.Extensions = new List<ExtensionLine>();
        }

        public void BuildExtensions(string text)
        {
            string[] lines = XFileHelper.GetAllLines(text);

            foreach(var line in lines)
            {

                if (!line.Contains(ExtensionConstants.Path))
                {
                    string[] exArr = line.Split("::".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string name = "";
                    bool islink = false;
                    if (exArr[0].Contains("L:"))
                        islink = true;
                    
                        name = exArr[0].Replace("L:", "");
                    
                    ExtensionLine ex = new ExtensionLine()
                    {
                        Name = name,
                        Snippet = exArr[1],
                        ID = exArr.Length > 2 ? exArr[2] : "",
                        IsLink = islink
                    };
                    this.Extensions.Add(ex);
                }
                    else
                    this.FilePath = line.Replace(ExtensionConstants.Path, "").Trim();

            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Extensions
{
   public class ExtensionManager
    {

        public static List<ExtensionFile> LoadExtensions(string path)
        {
            List<ExtensionFile> extensions = new List<ExtensionFile>();
            try
            {

            string text = File.ReadAllText(path);
            string[] exSnippets = ExtensionHelper.GetAllExtensionsFromFileText(text.Trim());

            foreach(var exText in exSnippets)
            {
                ExtensionFile extension = new ExtensionFile();
                extension.BuildExtensions(exText);
                    extensions.Add(extension);
            }
            }
            catch (Exception ex)
            {
             
            }
            return extensions;
        }


    }
}

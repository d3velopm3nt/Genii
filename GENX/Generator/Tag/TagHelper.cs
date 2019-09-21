using DALX.Core;
using GENX.Generator.Library;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Tag
{
    internal static class TagHelper
    {
        #region Properties
        internal static string GetFullPath
        {
            get
            {
                var path = LibraryHelper.GetFullPath("\\Tags\\");
                FileHelper.CreateFolderPathExist(path);
                string filePath = path + "ExampleTags.txt";
                FileHelper.WriteToFile(filePath, "[example This is n Name] Tag Value - This can be anything");
                return filePath;
            }
        }
        #endregion

        #region Methods

        private static TagFile BuildTagFile(string line, IXFile xFile = null)
        {
            TagFile genTagFile = new TagFile();
            if (xFile != null)
                genTagFile.BuildFileX(xFile);
            GenTag tag = new GenTag() {
                Tag = line.Substring(0, line.LastIndexOf("] ") + 2),
            Value = line.Substring(line.LastIndexOf("]") + 2)
        };
            genTagFile.TagList.Add(tag);
            return genTagFile;
        }

        internal static List<IXFile> BuildTagList()
        {
            List<IXFile> tags = new List<IXFile>();
            FileInfo file = new FileInfo(GetFullPath);
            using (StreamReader reader = new StreamReader(GetFullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    tags.Add(BuildTagFile(line));
                }
            }
            return tags;
        }

        public static List<GenTag> GetTagsInText(string fileString)
        {
           
            List<GenTag> tagsFound = new List<GenTag>();
            foreach (GenTag gtag in tagsFound)
            {
                if (fileString.Contains(gtag.Tag))
                    tagsFound.Add(gtag);
            }

            return tagsFound;
        }

        #endregion
    }
}

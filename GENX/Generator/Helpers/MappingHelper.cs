using DALX.Core;
using GENX.Generator.Project;
using GENX.Generator.Snippet;
using GENX.Generator.Table;
using GENX.Generator.Table.Column;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Helpers
{
   public static class MappingHelper
    {
        ///Replace [MapProperies::snippetName] with snippet and mapping object
        ///
        static TableEntity Table { get; set; }
        public static IXFile CheckMappingProperties(IXFile file, TableEntity table)
        {
            try
            {
                Table = table;
                if (file.FileText.Contains("[MapProperties::"))
                {
                    int startIndex = file.FileText.LastIndexOf("::") + 2;
                    string modelPart = file.FileText.Substring(startIndex);

                    string mapp = modelPart.Substring(0, modelPart.IndexOf("]"));
                    string mapObj = mapp.Replace("]","");
                    foreach (SnippetFile snippet in ProjectHelper.Snippets)
                    {
                        string fullPropSnipString = $"[MapProperties::{snippet.FileName}::{mapObj}]";
                        if (file.FileText.Contains(fullPropSnipString))
                        {
                            file.FileText = file.FileText.Replace(fullPropSnipString, MapProperties(snippet, mapObj));
                        }
                    }
                }
                return file;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static string MapProperties(SnippetFile snippet,string mapObject)
        {
            string newText = "";
            string snippetText = snippet.FileText;
            foreach (ColumnPropety column in Table.ColumnList)
            {
                if (!CoreHelper.BasePropertyList().Any(x => x.Contains(column.ColumnName)))
                {
                    newText += snippetText
                        .Replace("[Property]", column.ColumnName)
                       .Replace("[MapObject]", mapObject);
                }
            }
            return newText;
        }


    }
}

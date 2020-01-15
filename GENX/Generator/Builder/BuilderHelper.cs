using DALX.Core;
using DALX.Core.Sql;
using GENX.Generator.Table;
using GENX.Generator.Table.Column;
using GENX.Generator.Tag;
using GENX.Generator.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GENX.Interfaces;
using GENX.Generator.Snippet;
using GENX.Generator.Helpers;
using GENX.Files;

namespace GENX.Generator.Builder
{
    public class BuilderHelper
    {

        static TableEntity Table { get; set; }
        public static IXFile BuildEntityTemplateFile(IXFile template, TableEntity table, string projectName)
        {
            Table = table;
            IXFile file = new TemplateFile();

            file.Build(template);
            file.ProjectName = projectName;
            file.Load(template.FullPath);
            
            file.FileText = ReplaceTagsTextInTemplate(file);

            file = SnippetHelper.CheckSnippetProperties(file, Table);
            file = MappingHelper.CheckMappingProperties(file, Table);
            //    tempText += ReplaceLinkedProperties(table.TableName, temp
            //if (file.FileName.Contains("Linked"))late.FileText);

            //file.FileText = tempText;
            return file;
        }

        public static string CheckFilePostFix(string filename)
        {
            if (filename.StartsWith("I"))
                filename = filename.Substring(1);

            return filename;
        }

        private static string ReplaceTagsTextInTemplate(IXFile file)
        {
            StringBuilder sBuilder = new StringBuilder(file.FileText);
            sBuilder.Replace("[Project]", file.ProjectName);
            sBuilder.Replace("[Entity]", Table.TableName);
            sBuilder.Replace("[DateGenerated]", DateTime.Now.ToString());
            sBuilder.Replace("[IEntity]", $"I{Table.TableName}");       
            return sBuilder.ToString();
        }

        private static string ReplaceLinkedProperties(string _table, string _text)
        {
            string returnText = "";
            foreach (string table in SqlHelper.SelectTableRelationships(_table))
            {
                returnText += _text.Replace("[LinkedProperty]", table) + Environment.NewLine;
            }
            return returnText;
        }


    }
}

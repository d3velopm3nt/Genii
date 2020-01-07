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

namespace GENX.Generator.Builder
{
    public class BuilderHelper
    {
        private static List<GenTag> tagFiles { get; set; }
        private static IXFile IFile { get; set; }
        static TableEntity Table { get; set; }
        public static IXFile BuildEntityTemplateFile(TemplateFile template, TableEntity table, string projectName)
        {
            Table = table;
            IXFile file = new TemplateFile();
            file.Build(template);
            file.ProjectName = projectName;
            file.Load(template.FullPath);
            string tempText = ReplaceTagsTextInTemplate(file, table.TableName);

            if (file.FileName.Contains("Linked"))
                tempText += ReplaceLinkedProperties(table.TableName, template.FileText);

            file.FileText = tempText;
            return file;
        }

        public static string CheckFilePostFix(string filename   )
        {
            if (filename.StartsWith("I"))
                filename = filename.Substring(1);

            return filename;
        }

       //private static string ConvertFileNameToSingleName(string fileName)
       // {
       //     if (fileName.EndsWith("ies"))
       //         return fileName = fileName.Replace("ies", "y");
       //     else if (fileName.EndsWith("s"))
       //         return fileName = fileName.Replace("es", "e"); 
       // }

        private static string ReplaceTagsTextInTemplate(IXFile file, string tableName)
        {
            StringBuilder sBuilder = new StringBuilder(file.FileText);
            sBuilder.Replace("[Project]", file.ProjectName);
            sBuilder.Replace("[Entity]", tableName);
            sBuilder.Replace("[Properties]", AddProperties());
            sBuilder.Replace("[DateGenerated]", DateTime.Now.ToString());
            sBuilder.Replace("[IEntity]", $"I{tableName}");
            
            return sBuilder.ToString();
        }

        private static void CheckSnippetProperties(IXFile file)
        {
            if(file.FileText.Contains("[Properties]"))
            foreach(Snippet.SnippetFile snippet in file.Snippets)
            {
                    if (file.FileText.Contains($"[Properties][{snippet.FileName}]"))
                    {

                    }
            }
        }

        private static string AddProperties()
        {
            string newText = "";
            foreach (ColumnPropety column in Table.ColumnList)
            {
                if (!CoreHelper.BasePropertyList().Any(x => x.Contains(column.ColumnName)))
                    newText += "[DataMapping(true)] public " + column.DataType + " " + column.ColumnName + " {get;set;} " + Environment.NewLine;
            }
            return newText;
        }



        private static string ReplaceLinkedProperties(string _table, string _text)
        {
            string returnText = "";
            foreach (string table in SqlHelper.SelectTableRelationships(_table))
            {
                returnText += _text.Replace("[LinkedEntity]", table) + Environment.NewLine;
            }
            return returnText;
        }


    }
}

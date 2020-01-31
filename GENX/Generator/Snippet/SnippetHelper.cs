﻿using DALX.Core;
using GENX.Generator.Language;
using GENX.Generator.Library;
using GENX.Generator.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using GENX.Interfaces;
using System.IO;
using GENX.Generator.Table.Column;
using GENX.Generator.Table;
using GENX.Generator.Project;
using GENX.Core;

namespace GENX.Generator.Snippet
{
    public static class SnippetHelper
    {
        #region Properties
        static TableEntity Table { get; set; }
        internal static string GetFullPath
        {
            get
            {
                var path = LibraryHelper.GetFullPath("\\Snippets\\");
                FileHelper.CreateFolderPathExist(path);
                return path;
            }
        }
        #endregion
        public static SnippetFile BuildSnippetFile(IXFile file)
        {
            var snippet = new SnippetFile();
            snippet.BuildFileX(file);

            //Check the languag by file extension
            //snippet = (SnippetFile)LanguageHelper.GetFileFromExtention(file);

            //Check For GenTags in File Text
            snippet.GenTagList = TagHelper.GetTagsInText(file.FileText);

            return snippet;
        }


        public static List<SnippetFile> GetProjectSnippets(string path)
        {
            List<SnippetFile> snippets = new List<SnippetFile>();
            var files = Directory.GetFiles(path + "\\Snippets");
            foreach (var file in files)
            {
                SnippetFile snippet = new SnippetFile();
                snippet.FileText = File.ReadAllText(file);
                snippet.FileName = file.Substring(file.LastIndexOf("\\") + 1);
                snippet.FileName = snippet.FileName.Replace(snippet.FileName.Substring(snippet.FileName.LastIndexOf(".")), "");
                snippets.Add(snippet);
            }
            return snippets;
        }

        public static IXFile CheckSnippetProperties(IXFile file, TableEntity table)
        {
            Table = table;
            Table.File = file;
            if (file.FileText.Contains("[Properties::"))
                foreach (SnippetFile snippet in ProjectHelper.Snippets)
                {
                    string fullPropSnipString = $"[Properties::{snippet.FileName}]";
                    if (file.FileText.Contains(fullPropSnipString))
                    {
                        file.FileText = file.FileText.Replace(fullPropSnipString, AddProperties(snippet));
                        break;
                    }
                }

            return file;
        }

        private static string AddProperties(SnippetFile snippet)
        {
            string newText = "";
            string snippetText = snippet.FileText;
            foreach (ColumnProperty column in Table.ColumnList)
            {
                string propertyType = column.IsLinkedProperty ? SnippetContants.LinkedProperty : SnippetContants.Property;
                if (!CoreHelper.BasePropertyList().Any(x => x.Contains(column.ColumnName)))
                {
                        newText += GetSnippetText(snippetText, propertyType)
                            .Replace(CoreConstants.DataType, column.DataType)
                            .Replace(CoreConstants.Property, column.ColumnName)
                            .ReplaceEntityTag(Table.TableName)+ Environment.NewLine;

                    if (column.IsLinkedProperty)
                    {
                        //Generate Extension for linked property

                    }
                }
            }
            return newText;
        }

        public static string GetSnippetText(string snippetText,string snippetName)
        {
            bool snippetStarted = false;
            if (!snippetText.Contains(snippetName))
                return snippetText;
            else
            {
                string[] lines = snippetText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.Contains(SnippetContants.SnippetEnd))
                        return snippetText;
                    else if (snippetStarted)
                        snippetText += line;
                    else if (line.Contains(snippetName + SnippetContants.SnippetStart))
                    {
                        snippetText = line.Replace(snippetName, "");
                        snippetStarted = true;
                    }
                    
                   
                }
                return snippetText;
            }
        }


    }
}

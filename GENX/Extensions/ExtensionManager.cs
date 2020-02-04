using DALX.Core;
using GENX.Generator;
using GENX.Generator.Project;
using GENX.Generator.Snippet;
using GENX.Generator.Table;
using GENX.Interfaces;
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
        private ProjectFile _projectFile;
        public static List<ExtensionFile> Extensions { get; set; }
        public ExtensionManager(ProjectFile projectFile)
        {
            this._projectFile = projectFile;
        }
        public static List<ExtensionFile> LoadExtensions(string path)
        {
            List<ExtensionFile> extensions = new List<ExtensionFile>();
            try
            {

                string text = File.ReadAllText(path);
                string[] exSnippets = ExtensionHelper.GetAllExtensionsFromFileText(text.Trim());

                foreach (var exText in exSnippets)
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

        private static bool GenerateExtensionCode(ExtensionLine line, string tableName,out string allText)
        {
            allText = "";
            bool update = false;
          
                string fullName = $"//[{line.Name}]";
                if (allText.Contains(fullName))
                {
                    string snippetText = ProjectHelper.Snippets.Where(x => x.FileName == line.Snippet).FirstOrDefault()?.FileText;
                    snippetText = SnippetHelper.GetSnippetText(snippetText, line.ID).ReplaceEntityTag(tableName);

                    if (!allText.Contains(snippetText))
                    {
                        snippetText += Environment.NewLine + fullName;
                        allText = allText.Replace(fullName, snippetText);
                        update = true;
                    }
                }
            
            return update;
        }

        public void RunExtensions()
        {
            try
            {
                string path = "";
                foreach (ExtensionFile extension in Extensions)
                    foreach (TableEntity table in _projectFile.TableList)
                    {
                        path = extension.FilePath.Replace("[Entity]", table.TableName);
                        string allText = FileHelper.ReadFile(path);
                        bool update = false;
                        foreach(var line in extension.Extensions)
                       update = GenerateExtensionCode(line, table.TableName, out allText);
                        if (update)
                            FileHelper.WriteToFile(path, allText);
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void RunLinkedExtensions(string linkedTable)
        {
            foreach (ExtensionFile extension in Extensions)
            {
                string allText = FileHelper.ReadFile(extension.FilePath);
                bool update = false;
                foreach(var ext in extension.Extensions)
                    if(ext.IsLink)
                        update = GenerateExtensionCode(ext, linkedTable, out allText);
                              
                    if (update)
                        FileHelper.WriteToFile(extension.FilePath, allText);
            }
        }
    }
}

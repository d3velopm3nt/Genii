using DALX.Core;
using GENX.Generator;
using GENX.Generator.Project;
using GENX.Generator.Snippet;
using GENX.Generator.Table;
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
        public List<ExtensionFile> Extensions { get; set; }
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
                        foreach (ExtensionLine line in extension.Extensions)
                        {
                            string fullName = $"//[{line.Name}]";
                            if (allText.Contains(fullName))
                            {
                                string snippetText = ProjectHelper.Snippets.Where(x => x.FileName == line.Snippet).FirstOrDefault().FileText;
                                snippetText = SnippetHelper.GetSnippetText(snippetText, line.ID).ReplaceEntityTag(table.TableName);

                                if (!allText.Contains(snippetText))
                                {
                                    snippetText += Environment.NewLine + fullName;
                                    allText = allText.Replace(fullName, snippetText);
                                    update = true;
                                }
                            }
                        }
                        if (update)
                            FileHelper.WriteToFile(path, allText);

                    }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}

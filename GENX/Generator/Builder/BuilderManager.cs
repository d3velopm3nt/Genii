
using DALX.Core;
using GENX.Core;
using GENX.Extensions;
using GENX.Generator.Project;
using GENX.Generator.Snippet;
using GENX.Generator.Table;
using GENX.Generator.Template;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Builder
{
    public class BuilderManager
    {
        ProjectFile projectFile { get; set; }
        List<ExtensionFile> Extensions { get; set; }

        public bool Pause { get; set; }
        public BuilderManager(ProjectFile _projectfile, List<ExtensionFile> extensions)
        {
            this.projectFile = _projectfile;
            this.Extensions = extensions;
        }

        public void GenerateTemplateTableFiles(IGenXControl form)
        {
            projectFile = form.ProjectFile;
            try
            {
                foreach (IXFile template in projectFile.TemplateList)
                {
                    foreach (TableEntity table in projectFile.TableList)
                    {
                        //Change path to entity name folder if [Entity] exists in path
                        template.TargetPath.Replace("[Entity]", table.TableName);
                        BuilderHelper.BuildEntityTemplateFile(template, table, projectFile.ProjectName).Generate(template.TargetPath + @"\" + table.TableName + BuilderHelper.CheckFilePostFix(template.FileName));

                        form.GetUpdatedMessageStatus(template.FileName, table.TableName, "File generated successfully");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public void RunExtensions()
        {
            try
            {
                string path = "";
                foreach (ExtensionFile extension in Extensions)
                    foreach (TableEntity table in projectFile.TableList)
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
                                snippetText = SnippetHelper.GetSnippetText(snippetText, line.ID).Replace(CoreConstants.Entity, table.TableName);
                               
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

        public void GenerateTableLinkedList()
        {

        }


    }
}


using DALX.Core;
using GENX.Core;
using GENX.Extensions;
using GENX.Generator.Project;
using GENX.Generator.Snippet;
using GENX.Generator.Table;
using GENX.Generator.Template;
using GENX.Interfaces;
using System;
using GENX.Generator.Helpers;

namespace GENX.Generator.Builder
{
    public class BuilderManager
    {
       public static ProjectFile projectFile { get; set; }
       
        public bool Pause { get; set; }
        public BuilderManager(ProjectFile _projectfile)
        {
            projectFile = _projectfile;
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
                        template.TargetPath =  template.TargetPath.ReplaceEntityTag( table.TableName);

                        template.FileName = template.FileName.ReplaceEntityTag(table.TableName);
                        BuilderHelper.BuildEntityTemplateFile(template, table, projectFile.ProjectName).Generate(template.TargetPath, template.FileName);

                        form.GetUpdatedMessageStatus(template.FileName, table.TableName, "File generated successfully");

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

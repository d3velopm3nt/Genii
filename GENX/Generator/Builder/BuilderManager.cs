
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
using System.Linq;

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
                foreach (IXFile template in projectFile.TemplateList.Where(x=>x.IsActive))
                {
                   
                    foreach (TableEntity table in projectFile.TableList)
                    {
                        var temp = template.Clone();
                        //Change path to entity name folder if [Entity] exists in path
                        temp.TargetPath = temp.TargetPath.ReplaceEntityTag( table.TableName);
                        temp.FileName = temp.FileName.ReplaceEntityTag(table.TableName);
                        BuilderHelper.BuildEntityTemplateFile(temp, table, projectFile.ProjectName).Generate(temp.TargetPath, temp.FileName);

                        form.GetUpdatedMessageStatus(temp.FileName, table.TableName, "File generated successfully");
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

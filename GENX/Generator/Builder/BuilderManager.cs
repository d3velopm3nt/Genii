
using GENX.Generator.Project;
using GENX.Generator.Table;
using GENX.Generator.Template;
using GENX.Interfaces;
using Innotrack.Logger;
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
        public bool Pause { get; set; }
        public BuilderManager(ProjectFile _projectfile)
        {
            this.projectFile = _projectfile;
        }

        public void GenerateTemplateTableFiles(IGenXControl form)
        {
            projectFile = form.ProjectFile;
            try
            {
                foreach (TemplateFile template in projectFile.TemplateList)
                {
                    foreach (TableEntity table in projectFile.TableList)
                    {
                       BuilderHelper.BuildEntityTemplateFile(template, table,projectFile.ProjectName).Generate(template.TargetPath + @"\" + table.TableName + template.FileName);
                       form.GetUpdatedMessageStatus(template.FileName, table.TableName, "File generated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
            }
        }

        public void GenerateTableLinkedProperties()
        {
            try
            {

            }
            catch (Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
            }
        }

        public void GenerateTableLinkedList()
        {

        }


    }
}

using DALX.Core;
using GENX.Generator.Template;
using Innotrack.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX.Generator.Template
{
   public static class TemplateBuilder
    {
        /// <summary>
        /// Check File Text for GenTags -> Replace GanTag value with Tag in file.
        /// Add SnippetCode if SnipTag is found
        ///
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static TemplateFile BuildFile(string FilePath )
        {
            TemplateFile file=null;
            try
            {
               string lines = FileHelper.ReadFile(FilePath);
                file.FileText = lines;
            }
            catch(Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
            }
            return file;
        }

        public static List<TemplateFile> GetTemplatFileeList(List<TemplateFile> templateList)
        {
            
            try
            {
               
            }
            catch(Exception ex)
            {
                LoggerX.WriteErrorLog(ex);
            }

            return templateList;
        }


    }
}

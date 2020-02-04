using GENX.Generator.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Generator.Template;
using GENX.Generator.Table;
using GENX.Interfaces;

namespace GENX.Generator.Project
{
  public class ProjectFile : FileX
    {
        #region Properties
        public string Solution { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public ConnectionFile DefaultConnection { get; set; }
        public List<IXFile> TemplateList { get; set; }
        public List<TableEntity> TableList { get; set; }

        #endregion

        #region Constructors
        public ProjectFile()
        {
            DefaultConnection = new ConnectionFile();
            TemplateList = new List<IXFile>();
            TableList = new List<TableEntity>();
        }
        #endregion
    }
}

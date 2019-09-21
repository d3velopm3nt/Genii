using GENX.Generator.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Interfaces
{
   public interface IGenXControl
    {
        void GetUpdatedMessageStatus(string template,string table,string message);
        string GenerateStatus { get; set; }

        ProjectFile ProjectFile { get; set; }


    }
}

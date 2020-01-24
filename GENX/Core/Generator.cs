using GENX.Generator.Builder;
using GENX.Generator.Library;
using GENX.Generator.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Core
{
    public class Generator
    {
        #region Properties

        #endregion


        #region Constructors

        public Generator()
        {
            this.Load();
        }
        #endregion

        #region Methods
        public void Load()
        {
            ///Load all files from the GenX Library
            LibraryManager.Load();

        }


        #endregion
    }
}

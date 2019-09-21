using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Tag
{
   public class GenTag
    {
        #region Properties
        public string Tag { get; set; }
        public string Value { get; set; }
        #endregion

        #region Constructors
        public GenTag(string tag,string value)
        {
            this.Tag = tag;
            this.Value = value;
        }

        public GenTag()
        {

        }
        #endregion
    }
}

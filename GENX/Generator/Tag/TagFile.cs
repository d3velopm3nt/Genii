using GENX.Generator.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENX.Interfaces;

namespace GENX.Generator.Tag
{
    public class TagFile : FileX
    {
        #region Properties
     public List<GenTag> TagList { get; set; }
        #endregion

        #region Constructors

        public TagFile()
        {
            TagList = new List<GenTag>();
        }


        public TagFile(IXFile file, string tag, string value)
        {
            TagList = new List<GenTag>();
            this.BuildFileX(file);

        }
        #endregion

        #region Methods
        public new IXFile Build(IXFile file)
        {

            return this;
        }
        #endregion
    }
}

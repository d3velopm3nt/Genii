using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Core
{
  public static  class XFileHelper
    {
        public static string[] GetAllLines(string text)
        {
          return text.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

    }
}

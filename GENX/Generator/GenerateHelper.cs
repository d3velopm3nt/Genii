using GENX.Core;
using GENX.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator
{
  public static  class GenerateHelper
    {
        /// <summary>
        /// Replace correct formated tablename with entity keyword.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string ReplaceEntityTag(this string text,string table)
        {
            StringBuilder sBuilder = new StringBuilder(text);
            //No Change
            sBuilder.Replace(CoreConstants.Entity, table);
            //Upper Case
            sBuilder.Replace(CoreConstants.EntityUpper, table);
            //Lower Case
            sBuilder.Replace(CoreConstants.EntityLower, table.ToLower());

            //Add Spaces with between entity words
            sBuilder.AddSpaceInEntity(table);
            // Camel Case
            sBuilder.ReplaceEntityCC(table);
            //Dash and lower case
            sBuilder.ReplaceEntityDash(table);
            return sBuilder.ToString();
        }

        public static string AddSpaceInEntity(this StringBuilder sBuilder,string table)
        {
            sBuilder.Replace(CoreConstants.EntitySpace, table.AddSpacesBetweenWords());
            sBuilder.Replace(CoreConstants.EntityUpper, table.ToUpper().AddSpacesBetweenWords());
            sBuilder.Replace(CoreConstants.EntityLower, table.ToLower().AddSpacesBetweenWords());
            return sBuilder.ToString();
        }

        public static string ReplaceEntityDash(this StringBuilder sBuilder, string table)
        {
            sBuilder.Replace(CoreConstants.EntityDash.ToLower(), table.ReplaceWithDash().ToLower());
            sBuilder.Replace(CoreConstants.EntityDash, table.ReplaceWithDash().ToLower());

            return sBuilder.ToString();
        }

        public static string ReplaceEntityCC(this StringBuilder sBuilder,string table)
        {
            sBuilder.Replace(CoreConstants.EntityCamelCase.ToLower(), table.ReplaceWithCamelCase().ToLower());
            sBuilder.Replace(CoreConstants.EntityCamelCase, table.ReplaceWithCamelCase().ToLower());
            sBuilder.Replace(CoreConstants.EntityCamelCaseSpace, table.ReplaceWithCamelCase().AddSpacesBetweenWords());


            return sBuilder.ToString();
        }

    }
}

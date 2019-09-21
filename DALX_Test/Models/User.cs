using DALX.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX_Test.Models
{
    public partial class CoreUser : BaseEntity<CoreUser>
    {

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password {get;set;}

        #endregion

        #region Constructors
        public CoreUser() : base()
        {

        }

        /// <summary>
        /// The Base Entity to get and populate CoreUser Entity 
        /// </summary>
        /// <param name="ID"></param>
        public CoreUser(Guid ID): base(ID)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}

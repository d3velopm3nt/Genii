using DALX.Core;
using DALX.Core.Sql.Sorters;
using DALX_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALX_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter 1 to create a new user and 2 to view users");
            var result = Console.ReadLine();
                CoreUser user = new CoreUser();
            if (result == "1")
            {
                for (int i = 0; i < 1000; i++)
                {
                    user = new CoreUser();
                    user.FirstName = "Jack" + i;
                    user.LastName = "Bomb";
                    user.Email = "xxx@xxx.com";
                    user.Password = "xxx";
                    user.Create();
                    Console.WriteLine(user.FirstName + " " + user.LastName + " Created"); 
                }
                Console.ReadLine();
                }
            else if(result =="2")
            {
                //SorterCollection sorters = new SorterCollection();
                //sorters.Add(new QuerySorter("FirstName", QuerySortType.ASC));
                //foreach (CoreUser u in)
                //{
                //    Console.WriteLine(u.FirstName + " " + u.LastName + " : " + u.Email);

                //}
                var users = user.Read();
                Console.WriteLine(users.Count.ToString());
                Console.ReadLine();
            }
            else if (result == "3")
            {
                Guid guid = new Guid("8E3F814F-7CAD-4C5A-915F-0001024D8377");

                
                 user = new CoreUser(guid);

                //Console.WriteLine(user.FirstName + " " + user.LastName + " Date: " + user.CreatedDateTime + " Found");
                Console.ReadLine();
            }

        }
    }
}

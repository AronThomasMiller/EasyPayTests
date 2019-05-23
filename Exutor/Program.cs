using DatabaseManagerNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exutor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new DatabaseManager())
            {
                conn.SqlCommand("insert into addresses values (74,true,50,24,1,71,1,1,2)");
            }
        }
    }
}

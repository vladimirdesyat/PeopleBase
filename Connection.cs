using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBase
{
    internal class Connection : Table
    {
        public SqlConnection connect = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
        public Connection() { }
    }
}

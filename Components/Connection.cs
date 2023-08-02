using System;
using System.Data.SqlClient;

namespace PeopleBase.Components
{
    internal class Connection : Queries
    {
        public SqlConnection connect = new();
        public Connection() 
        {
            connect = new SqlConnection(@"Server=localhost;Database=master;Trusted_Connection=True;");
        }
    }
}

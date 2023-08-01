using System.Data.SqlClient;

namespace PeopleBase
{
    internal class Connection : Table
    {
        public SqlConnection connect = new SqlConnection("Server=localhost;Database=master;Trusted_Connection=True;");
        public Connection() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBase
{
    internal class Table : Database
    {
        public string viewTable = "SELECT DISTINCT * FROM PEOPLE ORDER BY Full_Name";
        public string checkTime = "SELECT DISTINCT * FROM PEOPLE WHERE F_M = 'M' AND Full_Name LIKE 'F%'";
        public string clearTable = "DELETE FROM PEOPLE";
        public string createTable = "CREATE TABLE PEOPLE(Full_Name char(50),Birth_Date char(8),F_M char(1))";
        public string query = "INSERT INTO PEOPLE(Full_Name, Birth_Date, F_M)";
        public Table() { }
    }
}

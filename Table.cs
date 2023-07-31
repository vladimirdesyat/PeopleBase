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
        public string checkTime = "SELECT DISTINCT * FROM PEOPLE WHERE GENDER = 'M' AND FULL_NAME LIKE 'F%'";
        public string clearTable = "DELETE FROM PEOPLE";
        public string createTable = "CREATE TABLE PEOPLE(FULL_NAME char(50),BIRTH_DATE char(10),GENDER char(1))";
        public string query = "INSERT INTO PEOPLE(FULL_NAME, BIRTH_DATE, GENDER)";
        public Table() { }
    }
}

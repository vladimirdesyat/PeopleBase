namespace PeopleBase.Components
{
    internal class Queries
    {
        public string createTable;
        public string query;
        public string viewFullAgeTable;

        public string checkTime;
        public string checkFaster;
        
        public string viewAllTable;
        public string clearTable;       
        public string drop;
        public Queries() 
        {
            // 1
            createTable = "CREATE TABLE PEOPLE(FULL_NAME char(50),BIRTH_DATE DATE,GENDER char(1))";

            // 2 
            query = "INSERT INTO PEOPLE(FULL_NAME, BIRTH_DATE, GENDER)";

            // 3
            viewFullAgeTable = "SELECT DISTINCT FULL_NAME,BIRTH_DATE, GENDER, DATEDIFF(YEAR, BIRTH_DATE, GETDATE()) AS 'AGE' FROM PEOPLE ORDER BY FULL_NAME";

            // 5
            checkTime = "SELECT DISTINCT * FROM PEOPLE WHERE GENDER = 'M' AND FULL_NAME LIKE 'F%'";

            // 6
            checkFaster = "SELECT DISTINCT FULL_NAME,BIRTH_DATE, GENDER FROM PEOPLE WHERE GENDER = 'M' AND FULL_NAME LIKE 'F%'";

            // view
            viewAllTable = "SELECT * FROM PEOPLE ORDER BY Full_Name";

            // clear
            clearTable = "DELETE FROM PEOPLE";

            // del
            drop = "DROP TABLE PEOPLE";
        }
    }
}

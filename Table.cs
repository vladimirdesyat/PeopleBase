namespace PeopleBase
{
    internal class Table : Database
    {
        public string viewTable = "SELECT DISTINCT * FROM PEOPLE ORDER BY Full_Name";
        public string viewAllTable = "SELECT * FROM PEOPLE ORDER BY Full_Name";
        public string viewFullAgeTable = "SELECT FULL_NAME,BIRTH_DATE, GENDER, DATEDIFF(YEAR, BIRTH_DATE, GETDATE()) AS 'AGE' FROM PEOPLE ORDER BY FULL_NAME";
        public string checkTime = "SELECT DISTINCT * FROM PEOPLE WHERE GENDER = 'M' AND FULL_NAME LIKE 'F%'";
        public string clearTable = "DELETE FROM PEOPLE";
        public string createTable = "CREATE TABLE PEOPLE(FULL_NAME char(50),BIRTH_DATE DATE,GENDER char(1))";
        public string query = "INSERT INTO PEOPLE(FULL_NAME, BIRTH_DATE, GENDER)";
        public Table() { }
    }
}

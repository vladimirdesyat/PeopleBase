namespace PeopleBase.Components.Data
{
    internal class Database
    {
        public string nameDatabase = "PeopleDatabase";
        public string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        public Database() { }
        public string SaveDataBase()
        {
            var saveDatabase = Path.Combine(systemPath, $"{nameDatabase}_Data.mdf");
            return saveDatabase;
        }
        public string SaveLogOfDataBase()
        {
            var saveLogOfDatabase = Path.Combine(systemPath, $"{nameDatabase}_Log.ldf");
            return saveLogOfDatabase;
        }
        public string CreateDataBase()
        {
            var createDatabase = "CREATE DATABASE MyDatabase ON PRIMARY " +
             $"(NAME = {nameDatabase}_Data, " +
             $"FILENAME = '{SaveDataBase()}', " +
             "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
             $"LOG ON (NAME = {nameDatabase}_Log, " +
             $"FILENAME = '{SaveLogOfDataBase()}', " +
             "SIZE = 1MB, " +
             "MAXSIZE = 5MB, " +
             "FILEGROWTH = 10%)";
            return createDatabase;
        }
    }
}

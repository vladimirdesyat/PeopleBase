namespace PeopleBase.Components
{
    internal class RandomGen
    {
        readonly List<string> output = new List<string>();
        readonly Random rand = Random.Shared;
        readonly DateTime dateStart = new DateTime(1960, 1, 1);
        readonly string[] names = { "Morgan", "Alexis", "River", "Parker", "Charlie", "Jordan", "Riley", "Ryan" };
        readonly string[] lastNames = { "Ford", "Davis", "Adams", "Smith", "Jones", "Nelson", "Miller", "Lee" };
        readonly string[] gender = { "F", "M" };

        public RandomGen()
        {

        }
        public string Birth()
        {
            lock (rand)
            {
                int range = (DateTime.Today - dateStart).Days;
                var birthDate = dateStart.AddDays(rand.Next(range));

                return birthDate.ToString();
            }
        }
        public string FullName()
        {
            lock (rand)
            {
                var output = new List<string>();

                var name = names[rand.Next(0, names.Length)];
                var fullName = "";
                var lastName = lastNames[rand.Next(0, lastNames.Length)];
                fullName += lastName + " " + name;

                return fullName;
            }
        }
        public string Gender()
        {
            lock (rand)
            {
                var gend = gender[rand.Next(0, gender.Length)];
                return gend;
            }
        }
        public List<string> Output()
        {
            output.Add(FullName());
            output.Add(Birth());
            output.Add(Gender());

            return output;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleBase
{
    internal class RandomGen
    {
        List<string> output = new List<string>();
        Random rand = new Random();
        DateTime dateStart = new DateTime(1960, 1, 1);
        string[] maleNames = { "Aaron", "James", "Liam", "Robert", "Abraham", "Jacob", "Ethan", "Noah" };
        string[] femaleNames = { "Abby", "Olivia", "Adele", "Mia", "Emma", "Sophia", "Charlotte", "Isabella" };
        string[] lastNames = { "Ford", "Davis", "Adams", "Smith", "Jones", "Nelson", "Miller", "Lee" };
        string[] gender = { "F", "M" };

        public RandomGen() { }
        public List<string> Output()
        {
            // int i = 0;
            int range = (DateTime.Today - dateStart).Days;
            var fullName = "";
            var name = "";
            var lastName = lastNames[rand.Next(0, lastNames.Length)];
            var birthDate = dateStart.AddDays(rand.Next(range));
            var gend = gender[rand.Next(0, gender.Length)];
            if (gend == "F")
            {
                name = femaleNames[rand.Next(0, femaleNames.Length)];
            }
            else
            {
                name = maleNames[rand.Next(0, maleNames.Length)];
            }
            fullName += lastName + "" + name;
            output.Add(fullName);
            output.Add(birthDate.ToString().Substring(0, 10));
            output.Add(gend);
            // fullName = "";
            return output;
        }
    }
}

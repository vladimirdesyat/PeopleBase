using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PeopleBase
{
    internal class RandomGen
    {
        List<string> output = new List<string>();
        Random rand = Random.Shared;
        DateTime dateStart = new DateTime(1960, 1, 1);
        string[] names = { "Morgan", "Alexis", "River", "Parker", "Charlie", "Jordan", "Riley", "Ryan" };
        string[] lastNames = { "Ford", "Davis", "Adams", "Smith", "Jones", "Nelson", "Miller", "Lee" };
        string[] gender = { "F", "M" };

        public RandomGen() 
        {
            
        }
        public string Birth()
        {
            lock (rand)
            {
                int range = (DateTime.Today - dateStart).Days;
                var birthDate = dateStart.AddDays(rand.Next(range));
                return birthDate.ToString().Substring(0, 10);
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

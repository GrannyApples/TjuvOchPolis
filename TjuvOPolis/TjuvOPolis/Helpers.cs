using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Helpers
    {
        public static List<Person> FillCitizens(int population)
        {
            List<Person> list = new List<Person>();

            
            for(int i = 0; i < population; i++)
            {
                int[] spawn = Person.SpawnLocation();
                Person person = new Person(spawn[0], spawn[1], "tomt");
                list.Add(person);
            }
            return list;
        }



    }
}

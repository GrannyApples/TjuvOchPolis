using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Helpers
    {
        public static void Mover(List<Person> people)
        {
            foreach (Person person in people)
            {
                Random rndX = new Random();
                Random rndY = new Random();
                int moveDirectionX = rndX.Next(-1, 1);   //-1, 0, 1
                int moveDirectionY = rndY.Next(-1, 1);   //-1, 0, 1

                person.MovementX = person.MovementX + moveDirectionX;
                person.MovementY = person.MovementY + moveDirectionY;


                //Om gubben går utanför arrayen, t.ex. uppåt "taket" vid X = 0 raden, då hamnar den nere vid X = 23. osv.
                if (person.MovementX == 0)
                {
                    person.MovementX = 23;
                }
                if (person.MovementX == 24)
                {
                    person.MovementX = 1;
                }
                if (person.MovementY == 0)
                {
                    person.MovementY = 98;
                }
                if (person.MovementY == 99)
                {
                    person.MovementY = 1;
                }
            }
        }
        public static List<Person> FillPeople(int population, int numOfPolice, int numOfCriminals)
        {
            List<Person> list = new List<Person>();

            for (int i = 0; i < population; i++)
            {
                //string[] inv = new string[4] { "Plånbok", "Mobiltelefon", "Nycklar", "Pengar" };
                int[] spawn = Person.SpawnLocation();
                list.Add(new Citizen("", spawn[0], spawn[1]));
            }
            for (int i = 0; i < numOfPolice; i++)
            {
                string[] inv = new string[4];
                int[] spawn = Person.SpawnLocation();
                list.Add(new Police("", spawn[0], spawn[1]));
            }
            for (int i = 0; i < numOfCriminals; i++)
            {
                string[] inv = new string[4];
                int[] spawn = Person.SpawnLocation();
                list.Add(new Thief("", spawn[0], spawn[1]));
            }
            return list;
        }



    }
}

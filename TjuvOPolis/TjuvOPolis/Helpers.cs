using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Helpers
    {
        public static int[] Mover(List<Person> people)
        {
            int[] movementXY = new int[2];

            foreach (Person person in people)
            {
                Random rndX = new Random();
                Random rndY = new Random();
                int moveDirectionX = rndX.Next(-1, 1);   //-1, 0, 1
                int moveDirectionY = rndY.Next(-1, 1);   //-1, 0, 1

                person.MovementX = person.MovementX + moveDirectionX;
                person.MovementY = person.MovementY + moveDirectionY;

                
                movementXY[0] = person.MovementX;
                movementXY[1] = person.MovementY;


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
            return movementXY;
        }
        public static List<Person> FillPeople(int population, int numOfPolice, int numOfCriminals)
        {
            List<Person> list = new List<Person>();
            
            //Inventory item1 = new Inventory("Plånbok", "Mobiltelefon", "Nycklar", "Pengar");
            //inventory.Add(item1);
            //Inventory item2 = new Inventory();

            for (int i = 0; i < population; i++)
            {
                List<string> inventory = Helpers.FillInventory();
                int[] spawn = Person.SpawnLocation();
                list.Add(new Citizen("M", spawn[0], spawn[1], inventory));
            }
            for (int i = 0; i < numOfPolice; i++)
            {
                List<string> policeInventory = new List<string>();
                int[] spawn = Person.SpawnLocation();
                list.Add(new Police("P", spawn[0], spawn[1], policeInventory));
            }
            for (int i = 0; i < numOfCriminals; i++)
            {
                List<string> thiefInventory = new List<string>();
                int[] spawn = Person.SpawnLocation();
                list.Add(new Thief("T", spawn[0], spawn[1], thiefInventory));
            }
            return list;
        }

        public static List<string> FillInventory()
        {
            List<string> inventory = new List<string>();
            inventory.Add("Wallet");
            inventory.Add("Watch");
            inventory.Add("Keys");
            inventory.Add("Phone");

            return inventory;
        }
        public static void krock(List<Person> people, int population)
        {
            
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    if (people[i].MovementX == people[j].MovementX && people[i].MovementY == people[j].MovementY)
                    {
                        Console.WriteLine("Hallå där");
                    }
                }
            }
        }
        


    }
}

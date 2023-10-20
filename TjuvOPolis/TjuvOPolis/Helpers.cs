namespace TjuvOPolis
{
    public class Helpers
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
            inventory.Add("plånbok");
            inventory.Add("klocka");
            inventory.Add("nycklar");
            inventory.Add("telefon");

            return inventory;
        }
        public static string[,] Collision(List<Person> people, int population, string[,] collisions)
        {
            Console.SetCursorPosition(0, 25);
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {
                    if (people[i].MovementX == people[j].MovementX && people[i].MovementY == people[j].MovementY)
                    {
                        if (people[i].Marker == "M" && people[j].Marker == "T")
                        {

                            collisions[people[i].MovementX, people[i].MovementY] = "TM";

                            Console.WriteLine("Tjuv och medborgare kolliderar vid: " + people[i].MovementX + "." + people[i].MovementY);
                            Random rnd = new Random();
                            int stealIndex = rnd.Next(0, ((Citizen)people[i]).Inventory.Count);
                            
                            if (((Citizen)people[i]).Inventory.Count == 0)
                            {
                                Console.WriteLine("Medborgare #" + i + " har inga föremål kvar. Tjuv #" + j + " är väldigt besviken.");
                                
                            }
                            else
                            {
                                //Lägger till föremål från citizens Index till tjuvens inventory
                                //Sedan tar bort föremål från citizens Index från inventory
                                Console.WriteLine("Tjuv #" + j + " har tagit Medborgare #" + i + "'s " + ((Citizen)people[i]).Inventory[stealIndex]);
                                ((Thief)people[j]).ThiefInventory.Add(((Citizen)people[i]).Inventory[stealIndex]);
                                ((Citizen)people[i]).Inventory.RemoveAt(stealIndex);
                            }
                            

                            Console.WriteLine();

                            Thread.Sleep(2000);

                        }
                        if (people[i].Marker == "P" && people[j].Marker == "T")
                        {
                            collisions[people[i].MovementX, people[i].MovementY] = "TP";
                            Console.WriteLine("Tjuv och polis kolliderar vid: " + people[i].MovementX + "." + people[i].MovementY);

                            if (((Thief)people[j]).ThiefInventory.Count > 0)
                            {
                                Console.WriteLine("Polis #" + i + " har haffat Tjuv # " + j + " och har beslagtagit allt stöldgods och skickat tjuven till fängelset.");
                                for (int p = 0; p < ((Thief)people[j]).ThiefInventory.Count; p++)
                                {
                                    ((Police)people[i]).PoliceInventory.Add(((Thief)people[j]).ThiefInventory[p]);
                                    ((Thief)people[j]).ThiefInventory.RemoveAt(p);
                                }
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                
                            }
                            
                        }
                        if (people[i].Marker == "M" && people[j].Marker == "P")
                        {
                            collisions[people[i].MovementX, people[i].MovementY] = "MP";
                            Console.WriteLine("Medborgare och polis kolliderar vid: " + people[i].MovementX + "." + people[i].MovementY);
                        }

                    }

                }
            }

            return collisions;
        }

    }
}

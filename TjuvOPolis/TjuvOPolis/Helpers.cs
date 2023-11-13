using System.Collections.Generic;

namespace TjuvOPolis
{
    public class Helpers
    {
        public static int[] Mover(List<Person> people, List<Person> prisoners, List<Person> poorPeople)
        {
            int[] movementXY = new int[2];

            foreach (Person person in people)
            {
                Random rndX = new Random();
                Random rndY = new Random();
                int moveDirectionX = rndX.Next(-1, 2);   //-1, 0, 1
                int moveDirectionY = rndY.Next(-1, 2);   //-1, 0, 1

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

            foreach (Person prisoner in prisoners)
            {
                Random rndX = new Random();
                Random rndY = new Random();
                int moveDirectionX = rndX.Next(-1, 2);   //-1, 0, 1
                int moveDirectionY = rndY.Next(-1, 2);   //-1, 0, 1

                prisoner.MovementX = prisoner.MovementX + moveDirectionX;
                prisoner.MovementY = prisoner.MovementY + moveDirectionY;

                movementXY[0] = prisoner.MovementX;
                movementXY[1] = prisoner.MovementY;

                //Om gubben går utanför arrayen, t.ex. uppåt "taket" vid X = 0 raden, då hamnar den nere vid X = 23. osv.

                if (prisoner.MovementX == 0)
                {
                    prisoner.MovementX = 8;
                }
                if (prisoner.MovementX == 9)
                {
                    prisoner.MovementX = 1;
                }
                if (prisoner.MovementY == 0)
                {
                    prisoner.MovementY = 18;
                }
                if (prisoner.MovementY == 19)
                {
                    prisoner.MovementY = 1;
                }
                
            }

            foreach (Person poorPerson in poorPeople)
            {

                Random rndX = new Random();
                Random rndY = new Random();
                int moveDirectionX = rndX.Next(-1, 2);   //-1, 0, 1
                int moveDirectionY = rndY.Next(-1, 2);   //-1, 0, 1

                poorPerson.MovementX = poorPerson.MovementX + moveDirectionX;
                poorPerson.MovementY = poorPerson.MovementY + moveDirectionY;

                movementXY[0] = poorPerson.MovementX;
                movementXY[1] = poorPerson.MovementY;
               
                //Om gubben går utanför arrayen, t.ex. uppåt "taket" vid X = 0 raden, då hamnar den nere vid X = 23. osv.

                if (poorPerson.MovementX == 0)
                {
                    poorPerson.MovementX = 13;
                }
                if (poorPerson.MovementX == 14)
                {
                    poorPerson.MovementX = 1;
                }
                if (poorPerson.MovementY == 0)
                {
                    poorPerson.MovementY = 23;
                }
                if (poorPerson.MovementY == 24)
                {
                    poorPerson.MovementY = 1;
                }

            }

            return movementXY;

        }

        public static List<Person> FillPeople(int numOfCitizen, int numOfPolice, int numOfCriminals)
        {
            List<Person> list = new List<Person>();


            for (int i = 0; i < numOfCitizen; i++)
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


        internal static List<string> FillInventory()
        {
            List<string> inventory = new List<string>();
            inventory.Add("wallet");
            inventory.Add("watch");
            inventory.Add("keys");
            inventory.Add("phone");

            return inventory;

        }
        private static void Clear(int x, int y,int width, int height)
        {
            int curTop = Console.CursorTop;
            int curLeft = Console.CursorLeft;
            for (; height > 0;)
            {
                Console.SetCursorPosition(x, y + --height);
                Console.Write(new string(' ', width));
            }
            Console.SetCursorPosition(curLeft, curTop);
        }

        public static string[,] Collision(List<Person> people, string[,] collisions, List<Person> prisoners, List<Person> poorPeople)
        {
           
            int startPosX = 45;
            int startPosY = 25;

            Console.SetCursorPosition(startPosX, startPosY);
            Console.WriteLine("\t\t======Status=====");
            Console.SetCursorPosition(startPosX, 27);

            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i + 1; j < people.Count; j++)
                {

                    if (people[i].MovementX == people[j].MovementX && people[i].MovementY == people[j].MovementY)
                    {

                        Console.SetCursorPosition(startPosX, startPosY++);
                        
                        if (people[i].Marker == "C" && people[j].Marker == "T")
                        {

                            Console.SetCursorPosition(startPosX, startPosY++);
                            collisions[people[i].MovementX, people[i].MovementY] = "TC";

                            Console.WriteLine("Thief and Citizen collides at: " + people[i].MovementX + "." + people[i].MovementY);
                            
                            Random rnd = new Random();
                            int stealIndex = rnd.Next(0, ((Citizen)people[i]).Inventory.Count);

                            if (((Citizen)people[i]).Inventory.Count == 0)
                            {

                                Console.SetCursorPosition(startPosX, startPosY++);
                                Console.WriteLine("Citizen #" + i + " has no items left. Thief #" + j + " is very dissappointed.");
                                
                            }
                            else
                            {

                                Console.SetCursorPosition(startPosX, startPosY++);
                                //Lägger till föremål från citizens Index till tjuvens inventory
                                //Sedan tar bort föremål från citizens Index från inventory
                                Console.WriteLine("Thief #" + j + " has stolen Citizen #" + i + "'s " + ((Citizen)people[i]).Inventory[stealIndex]);   

                                ((Thief)people[j]).ThiefInventory.Add(((Citizen)people[i]).Inventory[stealIndex]);
                                ((Citizen)people[i]).Inventory.RemoveAt(stealIndex);

                            }
                            
                            Thread.Sleep(2000);

                        }
                        
                        if (people[i].Marker == "P" && people[j].Marker == "T")
                        {
                            Console.SetCursorPosition(startPosX, startPosY++);
                            collisions[people[i].MovementX, people[i].MovementY] = "TP";
                            Console.WriteLine("Thief and Police collides at: " + people[i].MovementX + "." + people[i].MovementY); 

                            if (((Thief)people[j]).ThiefInventory.Count > 0)
                            {

                                Console.SetCursorPosition(startPosX, startPosY++);
                                Console.WriteLine("Police #" + i + " has caught Thief # " + j + " and taken their stolen items. The thief has been sent to Jail.");
                               
                                for (int p = 0; p < ((Thief)people[j]).ThiefInventory.Count; p++)
                                {

                                    ((Police)people[i]).PoliceInventory.Add(((Thief)people[j]).ThiefInventory[p]);
                                    ((Thief)people[j]).ThiefInventory.RemoveAt(p);                    

                                }
                               
                                prisoners.Add(new Thief("T", 5, 5, ((Thief)people[j]).ThiefInventory));
                                people.RemoveAt(j);

                                Thread.Sleep(2000);

                            }                            
                        }

                        if (people[i].Marker == "C" && people[j].Marker == "P")
                        {

                            Console.SetCursorPosition(startPosX, startPosY++);
                            collisions[people[i].MovementX, people[i].MovementY] = "CP";
                            Console.WriteLine("Citizen and Police collides at: " + people[i].MovementX + "." + people[i].MovementY);

                            if (((Citizen)people[i]).Inventory.Count <= 0)
                            {
                                Console.SetCursorPosition(startPosX, startPosY++);
                                Console.WriteLine("Police #" + j + " has sent Citizen #" + i + " to the poor house.");
                                
                                poorPeople.Add(new Citizen("C", 5, 5, ((Citizen)people[i]).Inventory));
                                
                                people.RemoveAt(i);

                            }
                            Thread.Sleep(2000);
                        }

                    }

                }
            }
            
            Clear(45,26,100,20);
            return collisions;

        }

    }
}


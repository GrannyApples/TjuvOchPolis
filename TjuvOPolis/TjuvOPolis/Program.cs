using System.Collections.Generic;

namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] city = new string[25, 100];
            string[,] prison = new string[10, 20];
            string[,] collisions = new string[25, 100];
            string[,] poorHouse = new string[15, 25];

            int populationCitizen = 100;
            int populationThief = 100;
            int populationPolice = 100;

            List<Person> people = Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
            List<Person> prisoners = new List<Person>();
            List<Person> poorPeople = new List<Person>();
            Console.CursorVisible = false;


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    int[] spawn = Person.SpawnLocation();

                    switch (key.Key)
                    {
                        case ConsoleKey.C:

                            List<string> inventory = Helpers.FillInventory();

                            people.Add(new Citizen("M", spawn[0], spawn[1], inventory));


                            break;


                        case ConsoleKey.P:

                            List<string> policeInventory = new List<string>();

                            people.Add(new Police("P", spawn[0], spawn[1], policeInventory));


                            break;

                        case ConsoleKey.T:


                            List<string> thiefInventory = new List<string>();


                            people.Add(new Thief("T", spawn[0], spawn[1], thiefInventory));

                            break;

                        default:
                            break;
                    }
                }

                

                Helpers.Mover(people, prisoners, poorPeople);
                
                City.CityDrawer(city, people, collisions, prison);
                City.PrisonDrawer(prison, prisoners, collisions);
                City.PoorHouseDrawer(poorHouse, poorPeople, collisions);

                Array.Clear(collisions, 0, collisions.Length);

                collisions = Helpers.Collision(people, collisions, prisoners, poorPeople);


                Thread.Sleep(200);

                
                Console.SetCursorPosition(0, 0);
                
                //Console.Clear();
            }
            
        }
    }
}
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

            int populationCitizen = 1;
            int populationThief = 2;
            int populationPolice = 2;

            List<Person> people = Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
            List<Person> prisoners = new List<Person>();
            List<Person> poorPeople = new List<Person>();

            while (true)
            {

                //!!!Fungerar ej än!!!

                //if (Console.KeyAvailable)
                //{
                //    ConsoleKeyInfo key = Console.ReadKey(intercept: true);


                //    switch (key.Key)
                //    {
                //        case ConsoleKey.C:
                //            int j = 0;
                //            people.Add(new Citizen("C", 20, 50, ((Citizen)people[j]).Inventory));
                            

                //            break;


                //        case ConsoleKey.P:
                //            int i = 0;
                //            people.Add(new Police("P", 15, 30, ((Police)people[i]).PoliceInventory));

                //            break;

                //        case ConsoleKey.T:
                //            int k = 0;
                //            people.Add(new Thief("T", 25, 75, ((Thief)people[k]).ThiefInventory));

                //            break;

                        
                //    }
                //}
                
                

                Helpers.Mover(people, prisoners, poorPeople);
               
                City.CityDrawer(city, people, collisions, prison);
                City.PrisonDrawer(prison, prisoners, collisions);
                City.PoorHouseDrawer(poorHouse, poorPeople, collisions);  
                
                collisions = Helpers.Collision(people, collisions, prisoners, poorPeople);

                Thread.Sleep(100);
                Array.Clear(collisions, 0, collisions.Length);
                
                
                Console.Clear();
            }
            
        }
    }
}
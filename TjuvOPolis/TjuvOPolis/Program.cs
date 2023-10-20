namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] city = new string[25, 100];
            string[,] collisions = new string[25, 100];
            //string[] backpack = 
            int population = 20;
            int thiefPopulation = 10;
            int policePopulation =30;

            List<Person> people = Helpers.FillPeople(population, policePopulation, thiefPopulation);

            Person.SpawnLocation();

            while (true)
            {
                Helpers.Mover(people);
               
                City.CityDrawer(city, people, collisions);
                collisions = Helpers.Collision(people, population, collisions);
                Thread.Sleep(100);
                Array.Clear(collisions, 0, collisions.Length);
                
                Console.Clear();
            }
        }
    }
}
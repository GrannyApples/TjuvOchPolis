namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {


            string[,] city = new string[25, 100];
            string[,] collisions = new string[25, 100];
            int population = 20;
            int thiefPopulation = 10;
            int policePopulation =10;

            List<Person> people = Helpers.FillPeople(population, thiefPopulation, policePopulation);

            Person.SpawnLocation();

            while (true)
            {
                Helpers.Mover(people);
                collisions = Helpers.Collision(people, population, collisions);
                City.CityDrawer(city, people, collisions);
                Array.Clear(collisions, 0, collisions.Length);
                Thread.Sleep(1100);
                Console.Clear();
            }
        }
    }
}
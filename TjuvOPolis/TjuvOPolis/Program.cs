namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] city = new string[25, 100];
            int population = 10;
            int thiefPopulation = 5;
            int policePopulation = 5;

            List<Person> people = Helpers.FillPeople(population, thiefPopulation, policePopulation);

            Person.SpawnLocation();

            while (true)
            {
                City.CityDrawer(city, people);
                Helpers.Mover(people);
                Thread.Sleep(1000);
                Console.WriteLine("hej");
                Console.Clear();


            }
        }
    }
}
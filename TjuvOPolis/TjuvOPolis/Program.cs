namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string[,] city = new string[25, 100];
            int population = 20;
            int thiefPopulation = 10;
            int policePopulation = 10;

            List<Person> people = Helpers.FillPeople(population, thiefPopulation, policePopulation);

            Person.SpawnLocation();

            while (true)
            {
                
                City.CityDrawer(city, people);
                Helpers.Mover(people);
                Helpers.krock(people, population);
                
                Console.ReadKey();


                Console.Clear();


            }
        }
    }
}
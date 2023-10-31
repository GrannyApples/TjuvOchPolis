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

            int population = 50;
            int thiefPopulation = 50;
            int policePopulation =50;
            

            List<Person> people = Helpers.FillPeople(population, policePopulation, thiefPopulation);
            List<Person> prisoners = new List<Person>();
            List<Person> poorPeople = new List<Person>();
            
           
            while (true)
            {
                Helpers.Mover(people, prisoners);
               
                City.CityDrawer(city, people, collisions, prison);
                City.PrisonDrawer(prison, prisoners, collisions);
                City.PoorHouseDrawer(poorHouse, people);

                
                collisions = Helpers.Collision(people, collisions, prisoners);
                Thread.Sleep(100);
                Array.Clear(collisions, 0, collisions.Length);
                
                
                Console.Clear();
            }
            
        }
    }
}
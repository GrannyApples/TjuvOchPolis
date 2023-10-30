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
            //string[] backpack = 
            int population = 20;
            int thiefPopulation = 10;
            int policePopulation =30;
            int prisonerPopulation = 0;
            int poorHousePopulation = 0;

            List<Person> people = Helpers.FillPeople(population, policePopulation, thiefPopulation);
            //List<Person> prisoners = new List<Person>();
            //List<Person> poorPeople = new List<Person>();
            
           
            while (true)
            {
                Helpers.Mover(people);
               
                City.CityDrawer(city, people, collisions, prison);
                City.PrisonDrawer(prison, people, collisions);
                City.PoorHouseDrawer(poorHouse, people);

                
                collisions = Helpers.Collision(people, collisions);
                Thread.Sleep(0);
                //Array.Clear(collisions, 0, collisions.Length);
                
                
                Console.Clear();
            }
        }
    }
}
namespace TjuvOPolis
{
    public class City
    {
        public static void PoorHouseDrawer(string[,] poorHouse, List<Person> poorPeople, string[,] collisions)
        {


            Console.SetCursorPosition(0, 36);
            Console.WriteLine("       Poor House");

            for (int x = 0; x < poorHouse.GetLength(0); x++)
            {

                for (int y = 0; y < poorHouse.GetLength(1); y++)
                {

                    if (x == 0 || x == poorHouse.GetLength(0) - 1)
                    {
                        poorHouse[x, y] = "=";
                    }
                    else if (y == 0 || y == poorHouse.GetLength(1) - 1)
                    {
                        poorHouse[x, y] = "|";
                    }
                    else
                    {
                        poorHouse[x, y] = " ";
                    }
                }               
            }

            foreach (Person person in poorPeople)
            {

                poorHouse[person.MovementX, person.MovementY] = "C";

            }

            for (int x = 0; x < poorHouse.GetLength(0); x++)
            {
                for (int y = 0; y < poorHouse.GetLength(1); y++)
                {

                    Console.Write(poorHouse[x, y]);

                }

                Console.WriteLine();
            }

        }

        public static void PrisonDrawer(string[,] prison, List<Person> prisoners, string[,] collision)
        {

            Console.SetCursorPosition(0, 25);
            Console.WriteLine("\tPrison");

            for (int x = 0; x < prison.GetLength(0); x++)
            {
                for (int y = 0; y < prison.GetLength(1); y++)
                {

                    if (x == 0 || x == prison.GetLength(0) - 1)
                    {
                        prison[x, y] = "=";
                    }
                    else if (y == 0 || y == prison.GetLength(1) - 1)
                    {
                        prison[x, y] = "|";
                    }
                    else
                    {
                        prison[x, y] = " ";
                    }
                    
                }
                
            }

            foreach (Person person in prisoners)
            {

                prison[person.MovementX, person.MovementY] = "T";

            }

            for (int x = 0; x < prison.GetLength(0); x++)
            {
                for (int y = 0; y < prison.GetLength(1); y++)
                {
                    
                    Console.Write(prison[x, y]);
                    
                }
                Console.WriteLine();
            }
        }

        public static void CityDrawer(string[,] city, List<Person> people, string[,] collisions, string[,] prison)
        {

            for (int x = 0; x < city.GetLength(0); x++)
            {
                for (int y = 0; y < city.GetLength(1); y++)
                {

                    if (x == 0 || x == city.GetLength(0) - 1)
                    {
                        city[x, y] = "=";
                    }
                    else if (y == 0 || y == city.GetLength(1) - 1)
                    {
                        city[x, y] = "|";
                    }
                    else
                    {
                        city[x, y] = " ";
                    }
                }
            }

            foreach (Person person in people)
            {

                if (person is Citizen)
                {
                    city[person.MovementX, person.MovementY] = person.Marker;
                }
                if (person is Police)
                {
                    city[person.MovementX, person.MovementY] = person.Marker;
                }
                if (person is Thief)
                {
                    city[person.MovementX, person.MovementY] = person.Marker;
                }
            }

            for (int x = 0; x < city.GetLength(0); x++)
            {
                for (int y = 0; y < city.GetLength(1); y++)
                {

                    Console.Write(city[x, y]);
                   
                }

                Console.WriteLine();
            }
            
        }
    }
}

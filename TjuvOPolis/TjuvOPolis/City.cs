namespace TjuvOPolis
{
    public class City
    {
        public static void PoorHouseDrawer(string[,] poorHouse, List<Person> people)
        {


            Console.SetCursorPosition(0, 36);
            Console.WriteLine("      Fattighuset");

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

                prison[person.MovementX, person.MovementY] = "X";

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
                    if (collisions[x, y] == "TM")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (collisions[x, y] == "TP")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (collisions[x, y] == "MP")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(city[x, y]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

        }


    }


}

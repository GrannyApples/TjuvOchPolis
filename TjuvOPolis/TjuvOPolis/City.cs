namespace TjuvOPolis
{
    internal class City
    {

        public static void CityDrawer(string[,] city, List<Person> people, string[,] collisions)
        {
            for (int x = 0; x < city.GetLength(0); x++)
            {
                for (int y = 0; y < city.GetLength(1); y++)
                {
                    if (x == 0 || x == 24)
                    {
                        city[x, y] = "-";
                    }
                    else if (y == 0 || y == 99)
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
            Console.SetCursorPosition(0, 0);
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
            //Thread.Sleep(1000);
        }

        //public static void krock(List<Person> people)
        //{
        //    for (int i = 0; i < people.Count; i++)
        //    {
        //        for (int j = i + 1; j < people.Count; j++)
        //        {
        //            if (people[i].MovementX == people[j].MovementX && people[i].MovementY == people[j].MovementY)
        //            {
        //                Console.WriteLine("Hallå där");
        //            }
        //        }
        //    }
        //}
    }
}

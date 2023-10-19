using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class City
    {
        public static void CityDrawer(string[,] city, List<Person> people)
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

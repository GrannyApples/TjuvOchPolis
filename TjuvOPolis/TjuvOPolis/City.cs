using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class City
    {

        public static void CityDrawer(string[,] city) //List<Citizen> citizens)
        {

            for (int x = 0; x < city.GetLength(0); x++)
            {
                for (int y = 0; y < city.GetLength(1); y++)
                {
                    if (x == 0 || x == 24)
                    {
                        Console.Write("-");
                    }
                    else if (y == 0 || y == 99)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }


                }
                Console.WriteLine();

            }
            //foreach (Person person in citizens)
            //{
            //    if (person is Citizen)
            //    {
            //        city[person.MovementX, person.MovementY] = "M";
            //    }
            //    if (person is Police)
            //    {
            //        city[person.MovementX, person.MovementY] = "P";
            //    }
            //    if (person is Criminal)
            //    {
            //        city[person.MovementX, person.MovementY] = "T";
            //    }
            //}
            //for (int x = 0; x < city.GetLength(0); x++)
            //{
            //    for (int y = 0; y < city.GetLength(1); y++)
            //    {
            //        Console.Write(city[x, y]);
            //    }
            //    Console.WriteLine();
            //}

        }
    }
}

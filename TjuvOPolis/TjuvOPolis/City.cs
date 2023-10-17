using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class City
    {

        public static void CityDrawer(string[,] city, Citizen citizen)
        {


            for(int x = 0; x < city.GetLength(0); x++)
            {
                for(int y = 0; y < city.GetLength(1); y++)
                {
                    Console.Write("_");
                }
                Console.WriteLine();
            }
        }

    }
}

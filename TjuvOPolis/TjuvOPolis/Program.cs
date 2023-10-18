using System;

namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] city = new string[25, 100];
            int population = 10;

            List<Citizen> citizens = Helpers.FillCitizens(population);
            
            int[] spawn = Citizen.SpawnLocation();

            City.CityDrawer(city);





            //Random random = new Random();




            //int positionX = random.Next(0, city.GetLength(0));
            //int positionY = random.Next(0, city.GetLength(1));

            //string marker = "M";

            //while (true)
            //{

            //    Console.Clear();

            //    for (int x = 0; x < city.GetLength(0); x++)
            //    {
            //        for (int y = 0; y < city.GetLength(1); y++)
            //        {
            //            if (positionX == x && positionY == y)
            //            {
            //                Console.Write(marker);
            //            }
            //            else
            //            {
            //                Console.Write(" ");
            //            }
            //        }
            //        Console.WriteLine();

            //    }
            //    positionY++;
            //    Console.ReadKey();
            //    Console.Clear();
            //}

        }
    }
}
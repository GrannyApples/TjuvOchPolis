using System;

namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] city = new string[25, 100];
            int population = 10;
            int thiefPopulation = 5;
            int policePopulation = 5;

            List<Citizen> citizens = Helpers.FillCitizens(population);
            List<Thief> thieves = Helpers.FillThieves(thiefPopulation);
            List<Police> police = Helpers.FillPolice(policePopulation);

            //int[] spawn = Citizen.SpawnLocation();


            

            while (true)
            {
                foreach(Citizen person in citizens)
                {
                    City.CityDrawer(city, person);
                    Console.ReadKey();
                    
                }

                
                
            }




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
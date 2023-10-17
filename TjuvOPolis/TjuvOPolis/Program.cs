using System;

namespace TjuvOPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] city = new string[25, 100];
            int population = 3;

            List<Person> citizens = Helpers.FillCitizens(population);
            Person citizen = new Person(0, 0, "Empty"); 
            
            int[] spawn = Person.SpawnLocation();
            
            
            while (true)
            {
                //City.CityDrawer(city, citizen);


                for (int x = 0; x < city.GetLength(0); x++)
                {

                    for (int y = 0; y < city.GetLength(1); y++)
                    {
                        if (spawn[0] == x && spawn[1] == y)
                        {

                            Console.Write("M");


                        }
                        else
                        {
                            Console.Write("_");
                        }
                    }
                    Console.WriteLine();
                }
                citizen.MovementY++;
                Console.ReadKey();
                Console.Clear();


            }


            //Random random = new Random();

            //string[,] city = new string[25, 100];


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
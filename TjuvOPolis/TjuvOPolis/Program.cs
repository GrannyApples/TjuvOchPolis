﻿using System.Collections.Generic;

namespace TjuvOPolis
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[,] city = new string[25, 100];
            string[,] prison = new string[10, 20];
            string[,] collisions = new string[25, 100];
            string[,] poorHouse = new string[15, 25];
            int speed = 50;
            int populationCitizen = 10;
            int populationThief = 10;
            int populationPolice = 10;
            List<Person> people = Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
            List<Person> prisoners = new List<Person>();
            List<Person> poorPeople = new List<Person>();

            Console.CursorVisible = false;
            
            
            while (true)
            {
             
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                    int[] spawn = Person.SpawnLocation();

                    switch (key.Key)
                    {
                        case ConsoleKey.C:

                            List<string> inventory = Helpers.FillInventory();

                            people.Add(new Citizen("C", spawn[0], spawn[1], inventory));
                            populationCitizen+=1;
                            Helpers.FillPeople(populationCitizen, populationPolice, populationThief);

                            break;


                        case ConsoleKey.P:

                            List<string> policeInventory = new List<string>();

                            people.Add(new Police("P", spawn[0], spawn[1], policeInventory));
                            populationPolice+=1;
                            Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
                            break;

                        case ConsoleKey.T:


                            List<string> thiefInventory = new List<string>();


                            people.Add(new Thief("T", spawn[0], spawn[1], thiefInventory));
                            populationThief+=1;
                            Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
                            break;
                        case ConsoleKey.W:
                            Console.Clear();
                            break;
                            case ConsoleKey.D:
                            speed += 50;
                            break;
                            case ConsoleKey.E:
                                speed = 0;
                            break;
                        default:

                            break;
                    }
                }

                Console.SetCursorPosition(101, 5);
                Console.WriteLine("Press P to spawn Police");
                Console.SetCursorPosition(101, 6);
                Console.WriteLine("Police: " + populationPolice + "  ");
                Console.SetCursorPosition(101, 8);
                Console.WriteLine("Press C to spawn Citizens");
                Console.SetCursorPosition(101, 9);
                Console.WriteLine("Citizens: " + (populationCitizen - poorPeople.Count) + "  ");
                Console.SetCursorPosition(101, 11);
                Console.WriteLine("Press T to spawn Thiefs");
                Console.SetCursorPosition(101, 12);
                Console.WriteLine("Thiefs: " + (populationThief - prisoners.Count) + "  ");
                
                Console.SetCursorPosition(0, 0);
                
                Console.SetCursorPosition(20, 27);
                Console.WriteLine("Prisoners: " + (prisoners.Count) + "  ");
                Console.SetCursorPosition(25, 46);
                Console.WriteLine("Poorpeople: " + poorPeople.Count + "  ");
                Console.SetCursorPosition(101, 22);
                Console.WriteLine("D/E");
                Console.SetCursorPosition(101, 23);
                Console.WriteLine("Refresh rate: "+speed+"ms  ");
                Console.SetCursorPosition(0, 0);

                Helpers.FillPeople(populationCitizen, populationPolice, populationThief);
                Helpers.Mover(people, prisoners, poorPeople);
                
                City.CityDrawer(city, people, collisions, prison);
                City.PrisonDrawer(prison, prisoners, collisions);
                City.PoorHouseDrawer(poorHouse, poorPeople, collisions);
                Console.SetCursorPosition(0, 0);
                Array.Clear(collisions, 0, collisions.Length);

                collisions = Helpers.Collision(people, collisions, prisoners, poorPeople);
                
                
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(speed);
                
            }
            
        }
    }
}
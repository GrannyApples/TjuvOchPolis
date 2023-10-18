using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOPolis
{
    internal class Helpers
    {
        
        public static void Mover(Citizen citizen)
        {
            Random rnd = new Random();
            int moveDirection = rnd.Next(1, 9);

            if (moveDirection == 1)
            {
                citizen.MovementX--;
                citizen.MovementY++;

            }
            if (moveDirection == 2)
            {
                citizen.MovementY++;
            }
            if (moveDirection == 3)
            {
                citizen.MovementX++;
                citizen.MovementY++;
            }
            if (moveDirection == 4)
            {
                citizen.MovementX--;
            }
            if (moveDirection == 5)
            {

            }
            if (moveDirection == 6)
            {
                citizen.MovementX++;
            }
            if (moveDirection == 7)
            {
                citizen.MovementX--;
                citizen.MovementY--;
            }
            if (moveDirection == 8)
            {
                citizen.MovementX--;
            }
            if (moveDirection == 9)
            {
                citizen.MovementX++;
                citizen.MovementY--;
            }
            

            Console.WriteLine(moveDirection);
        }
        public static List<Citizen> FillCitizens(int population)
        {
            List<Citizen> list = new List<Citizen>();

            
            for(int i = 0; i < population; i++)
            {
                int[] spawn = Citizen.SpawnLocation();
                Citizen person = new Citizen(" M ", spawn[0], spawn[1]);
                list.Add(person);
            }
            return list;
        }

        public static List<Thief> FillThieves(int thiefPopulation)
        {
            List<Thief> list = new List<Thief>();


            for (int i = 0; i < thiefPopulation; i++)
            {
                int[] spawn = Thief.SpawnLocation();
                Thief person = new Thief(" T ", spawn[0], spawn[1]);
                list.Add(person);
            }
            return list;
        }

        public static List<Police> FillPolice(int policePopulation)
        {
            List<Police> list = new List<Police>();


            for (int i = 0; i < policePopulation; i++)
            {
                int[] spawn = Police.SpawnLocation();
                Police person = new Police(" P ", spawn[0], spawn[1]);
                list.Add(person);
            }
            return list;
        }



    }
}

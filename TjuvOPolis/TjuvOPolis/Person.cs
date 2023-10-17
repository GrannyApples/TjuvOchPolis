namespace TjuvOPolis
{
    public class Person
    {
        public int MovementX { get; set; }
        public int MovementY { get; set; }
        public string Inventory { get; set; }

        public Person(int movementX, int movementY, string inventory)

        {
            MovementX = movementX;
            MovementY = movementY;
            Inventory = inventory;

        }
        public static int[] SpawnLocation()
        {
            Random spawnX = new Random();
            Random spawnY = new Random();
            int movementX = spawnX.Next(0, 26);
            int movementY = spawnY.Next(0, 101);

            int[] movementXY = new int[2];
            movementXY[0] = movementX;
            movementXY[1] = movementY;
            return movementXY;
            

            //return movementXY;


        }
        //public static void SpawnLocation(int movementX, int movementY)
        //{
        //    Random spawnX = new Random();
        //    Random spawnY = new Random();
        //    movementX = spawnX.Next(0, 26);
        //    movementY = spawnY.Next(0, 101);

        //    return;


        //}
    }

    public class Citizen : Person
    {
        public string Marker { get; set; }
        public Citizen(int movementX, int movementY, string inventory, string marker) : base(movementX, movementY, inventory)
        {
            Marker = marker;           
        }

        
    }

    public class Police : Person
    {
        public Police(int movementX,  int movementY, string inventory) : base(movementX, movementY, inventory)
        {

        }
    }

    public class Criminal : Person
    {
        public Criminal(int movementX, int movementY, string inventory) : base(movementX, movementY, inventory)
        {

        }
    }
}

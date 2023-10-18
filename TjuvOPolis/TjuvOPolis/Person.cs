namespace TjuvOPolis
{
    public class Person
    {
        public string Marker { get; set; }
        public int MovementX { get; set; }
        public int MovementY { get; set; }
        

        public Person(string marker, int movementX, int movementY)

        {
            Marker = Marker;
            MovementX = movementX;
            MovementY = movementY;
            

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
        
        
        public Citizen(string marker, int movementX, int movementY) : base(marker, movementX, movementY)
        {
                       
        }

        
    }

    public class Police : Person
    {
        public Police(string marker, int movementX,  int movementY) : base(marker, movementX, movementY)
        {

        }
    }

    public class Criminal : Person
    {
        public Criminal(string marker,int movementX, int movementY) : base(marker, movementX, movementY)
        {

        }
    }
}

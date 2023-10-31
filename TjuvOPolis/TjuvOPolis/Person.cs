namespace TjuvOPolis
{
    public class Person
    {
        public string Marker { get; set; }
        public int MovementX { get; set; }
        public int MovementY { get; set; }


        public Person(string marker, int movementX, int movementY)

        {
            Marker = marker;
            MovementX = movementX;
            MovementY = movementY;

        }
        public static int[] SpawnLocation()
        {
            Random spawnX = new Random();
            Random spawnY = new Random();
            int movementX = spawnX.Next(1, 24);
            int movementY = spawnY.Next(1, 99);

            int[] movementXY = new int[2];
            movementXY[0] = movementX;
            movementXY[1] = movementY;
            return movementXY;
        }

        
    }

    public class Citizen : Person
    {
        public List<string> Inventory { get; set; }

        public Citizen(string marker, int movementX, int movementY, List<string>inventory) : base(marker, movementX, movementY)
        {
            Marker = "M";
            Inventory = inventory;
        }
    }

    public class Police : Person
    {
        
        public List<string> PoliceInventory { get; set; }
        public Police(string marker, int movementX, int movementY, List<string> policeInventory) : base(marker, movementX, movementY)
        {
            Marker = "P";
            PoliceInventory = policeInventory;
        }
    }

    public class Thief : Person
    {
        public List<string> ThiefInventory { get; set; }
        
        public Thief(string marker, int movementX, int movementY, List<string> thiefInventory) : base(marker, movementX, movementY)
        {
            Marker = "T";
            ThiefInventory = thiefInventory;
            
        }
    }

    
}

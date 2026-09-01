namespace Belphagor
{
    public class Gamemap
    {
        public LinkedList<Room> Map {get;set;}

         public Room? Room1 {set; get;}
        public Room? Room2 {set; get;}
        public Room? Room3 {set; get;}
        public Room? Room4 {set; get;}
        public Room? Room5 {set; get;}
        public Room? Room6 {set; get;}
        public Room? Room7 {set; get;}
        public Room? Room8 {set; get;}
        public Room? Room9 {set; get;}
        public Room? Room10 {set; get;}
        public Room? Room11 {set; get;}
        public static Room? Void {set; get;}
        
        
        public Gamemap()
        {
            Map = new LinkedList<Room>();
            
        }

        public void AddRoom(Room room)
        {
            Map.AddLast(room);
            Program.log.Info("Room added");
        }
/// <summary>
/// Crea le stanze, assegna le loro adiacenti e le aggiunge alla lista Map
/// </summary>
        public void CreateGamemap()
        {
            Gamemap gamemap = new Gamemap();
            
            this.Room1 = new Room("Regno",1);
            this.Room2 = new Room("Fondamento",2);
            this.Room3 = new Room("Splendore",3);
            this.Room4 = new Room("Bellezza",4);
            this.Room5 = new Room("Eternità",5);
            this.Room6 = new Room("Forza",6);
            this.Room7 = new Room("Conoscenza",7);
            this.Room8 = new Room("Amore",8);
            this.Room9 = new Room("Intelligenza",9);
            this.Room10 = new Room("Corona",10);
            this.Room11 = new Room("Sapienza",11);
            
            AddRoom(Room1);
            AddRoom(Room2);
            AddRoom(Room3);
            AddRoom(Room4);
            AddRoom(Room5);
            AddRoom(Room6);
            AddRoom(Room7);
            AddRoom(Room8);
            AddRoom(Room9);
            AddRoom(Room10);
            AddRoom(Room11);

            Room1.SetConnectedRooms(Room2.number,null,null,null);
            Room2.SetConnectedRooms(Room4.number,Room1.number,null,null);
            Room3.SetConnectedRooms(Room6.number,null,Room4.number,null);
            Room4.SetConnectedRooms(Room7.number,Room2.number,Room5.number,Room3.number);
            Room5.SetConnectedRooms(Room8.number,null,null,Room4.number);
            Room6.SetConnectedRooms(Room9.number,Room3.number,Room7.number,null);
            Room7.SetConnectedRooms(Room10.number,Room4.number,Room8.number,Room6.number);
            Room8.SetConnectedRooms(Room11.number,Room5.number,null,Room7.number);
            Room9.SetConnectedRooms(null,Room6.number,Room10.number,null);
            Room10.SetConnectedRooms(null,Room7.number,Room11.number,Room9.number);
            Room11.SetConnectedRooms(null,Room8.number,null,Room10.number);
            Program.log.Info("Gamemap generated");           
        }

        public int AddMoneyCorona()
        {
            var random= new Random();

            return random.Next(1, 13);
            Program.log.Info("Money added to Corona");

        }

        
    }

}
/*namespace Belphagor
{
    
    public class Spawner
    {
        public LinkedList<Room> roomList;

        public Spawner(LinkedList<Room> RoomList)
        {
            roomList = RoomList;
        }

        public static void SpawnDemons(Demon demon, Gamemap gamemap)
        {
            int index;
            Random random = new Random();
            LinkedList<Room> spawnRoomList = new LinkedList<Room>();
            if(spawnRoomList.Count == 0)//creo una copia della mappa
            {
                spawnRoomList = gamemap.Map;
            }
            index = random.Next(0, spawnRoomList.Count);//scelgo stanza casuale
            Room spawnRoom = spawnRoomList.ElementAt(index);
            demon.room = spawnRoom;
            foreach(Room room in gamemap.Map)
            {
                if(spawnRoomList.ElementAt(index).number == room.number)//cerco nella mappa la stanza con lo stesso numero
                {
                    room.roomDemons.Add(demon);//assegno la stanza al demone
                    Program.log.Info("Demon spawned");
                }
            }
            spawnRoomList.Remove(spawnRoomList.ElementAt(index));//elimino la stanza dalla copia della mappa evitando più demoni in una sola stanza
        }

        public void SpawnItems()
        {
            
        }
    
    }
}*/
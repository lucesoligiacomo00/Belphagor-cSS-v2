namespace Belphagor
{
 public class Ira : Demon
 {
    public int turn{get;set;}
    public Ira(string Name, int Life, int maxLife, int Attack, Item ItemDrop, Room Room, bool IsAggressive, bool isAlive, int Turn) : base(Name, Life, maxLife, Attack, ItemDrop, Room, IsAggressive, isAlive)
    {
      this.turn = Turn;
      this.room = Room;
    }
/// <summary>
/// Permette ad Ira di spostarsi in una stanza adiacente casuale se non sono presenti demoni
/// </summary>
    public void IraMove()
    {
      Random rnd = new Random();
      bool moved = false;
      int i=0;  

      while(!moved)
      {
        Program.log.Info("Ira finding room");
        int direction = rnd.Next(0,4);
        Room newRoom = room.GetDirection(direction);
        i++;            
        if(newRoom != null && newRoom.roomDemons.Count == 0 && newRoom.number != 1 && newRoom.number != 7)//verifica che sia una direzione valida, la stanza sia vuota e non sia regno o conoscenza
        {
          this.room.containsDemon = false;
          this.room.roomDemons.Clear();//elimina tutti i demoni dalla vecchia stanza
          this.room = newRoom;//assegna ad ira una nuova stanza
          this.room.roomDemons.Add(this);//aggiungo ira alla lista dei demoni nella nuova stanza
          this.room.containsDemon = true;
          moved = true;
          Console.WriteLine("Ira si è spostato nella stanza {1}",room.number,room.name);
        }
        if(i>20)
        {
          Program.log.Info("Ira cant move");
          return;
        }        
      }
    }

    /*public void SpawnDemons(Demon demon, Gamemap gamemap)
    {
      int index;
      Random random = new Random();
      LinkedList<Room> spawnRoomList = new LinkedList<Room>();
      if(spawnRoomList.Count == 0)//creo una copia della mappa una sola volta
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
          }
      }
      spawnRoomList.Remove(spawnRoomList.ElementAt(index));//elimino la stanza dalla copia della mappa evitando più demoni in una sola stanza
    }*/

    


    

 }
}
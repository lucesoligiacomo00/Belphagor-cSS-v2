namespace Belphagor
{
    public class Avidità : Demon
    {
        Random rd= new Random();
        public Avidità(string Name, int Life, int maxLife, int Attack, Item ItemDrop, Room Room, bool IsAggressive, bool isAlive) : base(Name, Life, maxLife, Attack, ItemDrop, Room, IsAggressive, isAlive)
        {
            this.room = Room;
        }

        public void InstanceAvidità(Gamemap gamemap)
        {
            int i= rd.Next(0,11);
            //Avidità avidità = new Avidità("Avidità",30,30,5,item,);

        }

        

    }

}
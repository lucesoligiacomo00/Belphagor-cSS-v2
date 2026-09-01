namespace Belphagor;
public class Entity
{
    public string name{get;set;}
    public int life{get;set;}
    public int maxLife {get;set;}
    public int attack{get;set;}
    public Room room{get;set;}

    public Entity(string Name, int Life,int MaxLife, int Attack,Room Room)
    {
        this.name=Name;
        this.life=Life;
        this.maxLife = MaxLife;
        this.attack=Attack;
        this.room = Room;
    }

    public Entity ()
    {
    }

    public virtual void Talk()
    {
        
    }

    

}
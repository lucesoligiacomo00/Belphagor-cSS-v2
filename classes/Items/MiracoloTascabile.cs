namespace Belphagor;
public class MiracoloTascabile: Item
{
    bool charged =true;
    int turnUsed {set; get;}
    int turnCharge=5; 

    public MiracoloTascabile( ) : base()
    {
        this.name="Miracolo Tascabile";
        this.equippable=false;
        this.equipValue=0;
        this.id=6;
        this.transportable=true;
        this.weight=1;
        this.charged=true;
        this.turnCharge=5;
    }

    public override void Observe (Ronen ronen)
    {
        Program.log.Info("Observing miracle");
        if(charged)
        {
        Console.WriteLine($"Una pergamena con scritte incomprensibili. A detta di quell'angelo è in grado di eliminare ogni male, se usata da una persona di buon cuore.");
        }
        else
        {
            Console.WriteLine("La pergamena è stata usata poco tempo fa, è ancora calda.");
        }
    }
/// <summary>
/// Miracolo Tascabile si può usare ogni 5 turni ed infligge 50 di danno al demone con cui Ronen è in combattimento.
/// </summary>
/// <param name="ronen"></param>
    public override void Effect (Ronen ronen)
    {
        if (ronen.turn>=turnUsed+turnCharge)
        {
            Console.WriteLine("Miracolo Ricaricato!");
            Program.log.Info("Miracle recharged");
            charged=true;

        }

        if (charged)
        {
            if(!ronen.room.containsDemon)
            {
                Console.WriteLine($"Non c'è nessun nemico quì. La pergamena non si attiva.");
            }
            else
            {
                ronen.room.roomDemons.ElementAt(0).life-= 50;
                Console.WriteLine($"Una luce accecante esce dalla pergamena, infliggendo 50 di danno a {ronen.room.roomDemons[0].name}.");
                Program.log.Info("Miracle used");
                charged=false;
                turnUsed=ronen.turn;

            }
            
        }
        else
        {
            Console.WriteLine("Devi Aspettare che il Miracolo si ricarichi");
            Console.WriteLine($"Mancano {turnUsed+turnCharge-ronen.turn} turni");
        }

    }

}

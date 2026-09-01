namespace Belphagor;
public class AcquaSanta : Item
{
    
    public bool full =true; //indica se si può usare o meno
    
    public override void Effect(Ronen ronen) //ti curi la vita e si svuota la bottiglia
    {
        
        if (ronen.maxLife==ronen.life && full)
        {
            ronen.pissFull=true;
            Console.WriteLine("Non ha avuto alcun effetto, ma adesso devi andare in bagno.");
            full=false;

        }
        if (!ronen.pissFull)
        {
            if(full)
            {
                ronen.life=ronen.maxLife;
                weight=1;
                full=false;
                Console.WriteLine("* glub glub * ");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("La bottiglia è vuota.");

            }

        }
        else
        {
            if(full)
            {
                Console.WriteLine("Non puoi bere senza prima andare ad urinare.");
            }
            else
            {
                Console.WriteLine("La bottiglia è vuota.");

            }
            

        }


    }

    public void Refill() //metodo per riempire la bottiglia
    {
        weight=2;
        full=true;
        Program.log.Info("Holy Water refilled");

    }

    public override void Observe (Ronen ronen)
    {
        Program.log.Info("Observing holy water");
        if(full)
        {
            Console.WriteLine($"Un barattolo pieno di un liquido luminoso, a detta di quell'angelo è in grado di guarire ogni ferita o malattia...");

        }
        else
        {
            Console.WriteLine("Un barattolo luminoso, anche se vuoto, chissà quanto potrebbe valere...");
        }
    }

    public AcquaSanta() : base()
    {
        this.name="Acqua Santa";
        this.equippable=false;
        this.equipValue=0;
        this.id=0;
        this.transportable=true;
        this.weight=2;
        this.full =true;
    }

    

}


namespace Belphagor;
public class Demon : Entity
{
    public Item itemDrop{set; get;}
    public bool isAggressive{set; get;}

    public bool isAlive{set; get;}

    public Demon(string Name, int Life, int MaxLife, int Attack, Item ItemDrop, Room Room, bool IsAggressive, bool IsAlive) : base(Name,Life,MaxLife,Attack,Room)
    {
        this.name=Name;
        this.life=Life;
        this.maxLife = MaxLife;
        this.attack=Attack;
        this.room = Room;
        this.isAggressive = IsAggressive;
        this.itemDrop = ItemDrop;
        this.isAlive=IsAlive;
    }

/// <summary>
/// Consente di attaccare il demone passato come parametro, parlarci, fuggire cambiando stanza, visualizzare ed interagire con gli oggetti nella borsa di Ronen o nella stanza in cui si trova.
/// </summary>
/// <param name="ronen"></param>
/// <param name="demon"></param>
    public void CombatMenu(Ronen ronen, Demon demon)
    {
        int i=0;
        
        if (isAlive)
        {
            if (ronen.room.filled>=30)
            {
                Console.WriteLine($" La stanza è così piena di urina santa che {demon.name} è affogato e ha droppato un Materiale Demoniaco");
                ronen.room.roomItems.Add(itemDrop);
                ronen.room.roomDemons.Remove(demon);
                ronen.room.containsDemon = false;
                demon.isAlive=false;                    
                ronen.isFighting = false;

            } 

            Program.log.Info("Combat Menu opened");
            
            while(ronen.life>0 && ronen.isFighting)
            {            
                Console.WriteLine("====================");
                Console.WriteLine(" 1) Attacca");
                if(!ronen.isTutorial)
                {
                    Console.WriteLine(" 2) Fuggi");  
                    Console.WriteLine(" 3) Oggetti stanza");
                    Console.WriteLine(" 4) Borsa");
                }                
                
                if(!this.isAggressive)
                {
                    Console.WriteLine(" 5) Parla");
                }                
                Console.WriteLine("====================");
                ronen.PrintStats();
                
                string input = Console.ReadLine();
                GameManager.PrintSpace();
                if(input == "1")//Attack
                {
                    this.isAggressive = true;
                    Program.log.Info("Ronen attack");
                    ronen.turn++; 
                    if (ronen.weapon==null)
                    {
                        Console.WriteLine("Ronen attacca {0} a mani nude",demon.name);
                    }      
                    else 
                    {
                        Console.WriteLine("Ronen attacca {0} con {1}",demon.name, ronen.weapon.name);
                    }
                    demon.life -= ronen.attack;
                    Console.WriteLine("Il demone ha subito {0} danni",ronen.attack);
                    ronen.life -= demon.attack;
                    Console.WriteLine("Il demone risponde l'attacco");
                    Console.WriteLine("Ronen ha subito {0} danni",demon.attack);
                }
                else if(input == "2" && !ronen.isTutorial)
                {                    
                    ronen.Move(ronen,true,demon);
                    ronen.isFighting = false;
                    break;
                }
                else if(input == "5")
                {
                    if(!this.isAggressive)
                    {
                        Talk();
                    }                    
                }
                else if(input =="3")
                {
                    //Console.Clear();
                    Program.log.Info("Inspecting room");                    
                    Item.DisplayItems(room.roomItems);
                    Item.PrintBagWeight(ronen);
                    if(room.roomItems.Count == 0)
                    {
                        break;
                    }
                    Item? roomItem = new Item();
                    roomItem = Item.SelectItem(room.roomItems,ronen,true);
                    if(roomItem!=null)
                    {
                        roomItem.interactionActive=true;
                        roomItem.RoomInteraction(ronen);
                    } 
                           
                }
                else if(input =="4")
                {
                    Program.log.Info("Bag opened");
                    Item.DisplayItems(ronen.bagItem);
                    Item.PrintBagWeight(ronen);
                    if(ronen.bagItem.Count == 0)
                    {
                        break;
                    }
                    Item? bagItem = new Item();
                    bagItem = Item.SelectItem(ronen.bagItem,ronen,true);
                    if(bagItem!=null)
                    {
                        bagItem.interactionActive=true;
                        bagItem.BagInteraction(ronen);
                    }              
                }
                else if(input =="H" || input =="h")
                {

                    Console.WriteLine($"L'obiettivo del gioco è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.");
                    break;

                }
                    
                else
                {
                    Program.log.Info("Unknown command");
                    Console.WriteLine("Comando inesistente");
                }

                if(demon.life <=0 && i==0)
                {
                    Console.WriteLine("Ronen ha finalmente ucciso {0} che ha lasciato {1}",demon.name,demon.itemDrop.name);
                    Program.log.Info("Demon killed");
                    ronen.room.roomItems.Add(itemDrop);
                    ronen.room.roomDemons.Remove(demon);
                    ronen.room.containsDemon = false;
                    demon.isAlive=false;                    
                    ronen.isFighting = false;
                    i++;
                    break;
                }
            }   
                
        }        
    }

/// <summary>
/// Consente di assegnare il demone passato come parametro ad una stanza casuale ad eccezione delle stanze Regno e Conoscenza.
/// </summary>
/// <param name="demon"></param>
/// <param name="gamemap"></param>
    public void SpawnDemons(Demon demon,Gamemap gamemap)
    {
      int index;
      bool roomAssigned=false;
      Random random = new Random();
      while(!roomAssigned)
      {
        index = random.Next(1, gamemap.Map.Count);//stanza random esclusa regno
        //Console.WriteLine($"Ira spawn range: {gamemap.Map.ElementAt(1).name} - {gamemap.Map.ElementAt(gamemap.Map.Count-1).name}");
        if(!gamemap.Map.ElementAt(index).containsDemon && index != 6)//verifico se la stanza non contiene un demone e non è Conoscenza
        {
            demon.room = gamemap.Map.ElementAt(index);
            gamemap.Map.ElementAt(index).roomDemons.Add(demon);
            gamemap.Map.ElementAt(index).containsDemon = true;
            roomAssigned = true;
            Program.log.Info("Demon randomly spawned");
        }
      }
    }
/// <summary>
/// Instanzia 6 demoni con differenti stanze e statistiche che verranno passati al chiamante tramite una lista.
/// </summary>
/// <param name="gamemap"></param>
/// <returns></returns>
    public static List<Demon> CreateDemons(Gamemap gamemap)
    {
        Item materiale = new Item();
        materiale.MaterialeDemoniaco();
        Demon superbia = new Demon("Superbia",80,80,30,materiale,gamemap.Room9,false,true);
        Demon accidia = new Demon("Accidia",300,300,10,materiale,gamemap.Room5,false,true);
        Demon gola = new Demon("Gola",150,150,20,materiale,gamemap.Room6,false,true);
        Demon avarizia = new Demon("Avarizia",200,200,30,materiale,gamemap.Room10,false,true);
        Demon invidia = new Demon("Invidia",10,10,10,materiale,gamemap.Room7,false,true);
        Demon lussuria = new Demon("Lussuria",70,70,30,materiale,gamemap.Room4,false,true);
        Demon belphagor = new Demon("Belphagor",300,300,35,materiale,gamemap.Room1,false,true);

        gamemap.Room9.roomDemons.Add(superbia);
        gamemap.Room9.containsDemon = true;
        gamemap.Room5.roomDemons.Add(accidia);
        gamemap.Room5.containsDemon = true;
        gamemap.Room6.roomDemons.Add(gola);
        gamemap.Room6.containsDemon = true;
        gamemap.Room10.roomDemons.Add(avarizia);
        gamemap.Room10.containsDemon = true;
        gamemap.Room7.roomDemons.Add(invidia);
        gamemap.Room7.containsDemon = true;
        gamemap.Room4.roomDemons.Add(lussuria);
        gamemap.Room4.containsDemon = true;
        gamemap.Room1.roomDemons.Add(belphagor);
        gamemap.Room1.containsDemon = true;

        List<Demon> gameDemons = new List<Demon>();
        gameDemons.Add(superbia);
        gameDemons.Add(accidia);
        gameDemons.Add(gola);
        gameDemons.Add(avarizia);
        gameDemons.Add(invidia);
        gameDemons.Add(lussuria);
        gameDemons.Add(belphagor);
        Program.log.Info("Demons spawned");
        return gameDemons;
    }


    public void Talk()
    {
        switch(name)
        {           
            case"Superbia":
                Random rnd = new Random();
                string[] dialog = new string[3];

                dialog[0] = "SUPERBIA: <<Tu devi essere Ronen! Poverino, mi spiace per te...>>";

                dialog[1] = "SUPERBIA: <<Noi non abbiamo chissà quale interesse nel combatterti. Ma se ci attacchi risponderemo con tutta la nostra forza.>>";
                dialog[2] = "SUPERBIA: <<Sempre il solito Ronen, eh? Stai qui a parlare con me, invece di perseguire i tuoi veri desideri uh? Dev'essere troppo faticoso per i tuoi gusti.>>";

                int index = rnd.Next(0, dialog.Length);
                Console.WriteLine(dialog[index]);
                break;            
            case"Accidia":
                Console.WriteLine("ACCIDIA: *ronf ronf*");
                break;
            case"Gola":
                Console.WriteLine("GOLA: <<DI PIU', DI PIU'. HO FAME!>>");
                break;
            case"Avarizia":
                Console.WriteLine("AVARIZIA: <<Ronen, Ronen, Ronen... Sei proprio tu l'avidità incarnata, vero? Non riesci a smettere di cercare sempre di più, di accumulare ricchezze senza sosta. Hai tutto il mio rispetto.>>");
                break; 
            case"Invidia":
                Console.WriteLine("INVIDIA: <<Ronen, come osi possedere tutto ciò che desideri? La tua fortuna mi fa infuriare, ma presto tu e tutto ciò che possiedi sarà MIO!!!>>");
                break;
            case"Lussuria":
                Console.WriteLine("LUSSURIA: <<Oh, Ronen, non resistere alla tentazione, lascia che il piacere ti travolga e ti conduca alla tua perdizione.>>");
                break;
            case"Ira":
                Console.WriteLine("IRA: *rawr*");
                break;
            case"Belphagor":
                if (this.life>100)
                {
                Console.WriteLine("BELPHAGOR: <<Vederti qui, impotente e vulnerabile, è un piacere senza pari. Il mio potere è ineguagliabile, e tu non sei altro che un'effimera fiammella destinata a spegnersi. Adesso, concedimi il piacere di spegnere quella luce che ancora arde dentro di te. La tua anima diventerà mia, e il tuo nome verrà dimenticato nel vento dell'oblio...>>");
                }
                else if (this.life<=100)
                {
                Console.WriteLine("BELPHAGOR: <<*unf unf* Ronen, sei più forte di quanto mi aspettassi, ma non riuscirai lo stesso a battermi *unf unf* Che ne diresti di fare un patto? Io ti do potere, fama e donne a volontà e tu mi lasci stare *unf unf* che ne dici?>>");

                }
                break;
            default:
                break;
        }
    }






    

    


}
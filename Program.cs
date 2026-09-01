using System.Reflection;
using log4net;
using log4net.Config;
namespace Belphagor;
class Program
{
    public static Ronen ronen;
    public static Angel gennaro;
    public static Gamemap gamemap = new Gamemap();
    public static Chest chest5 = new Chest();
    public static Chest chest9 = new Chest();

    public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    static void Main(string[] args)
    {

        log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
        log.Info("-----Game inizialization-----");

        gamemap.CreateGamemap();
        gennaro = new Angel("Gennaro",999,999,999,gamemap.Room7);
        List<Item> bagItem = new List<Item>();
        List<Item> armor = new List<Item>();
        ronen = new Ronen("Ronen",100,100,3,gamemap.Room7,50,0,bagItem,0,0,true,null,armor,0,true,false); 
        Program.log.Info("Ronen spawned");

        Item materiale = new Item();
        materiale.MaterialeDemoniaco();

        List<Item> chestItems = new List<Item>();
        chest5=new Chest(chestItems);
        chest9=new Chest(chestItems);  
        gamemap.Room5.roomItems.Add(chest5);
        gamemap.Room9.roomItems.Add(chest9);

        List<Demon> gameDemons= Demon.CreateDemons(gamemap);
        Ira ira = new Ira("Ira",120,120,25,materiale,null,true,true,0);
        gameDemons.Add(ira);


        Console.WriteLine("BELPHAGOR");
        Console.WriteLine(" 1) Nuova Partita");
        Console.WriteLine(" 2) Carica Partita precedente");

        switch (Console.ReadLine())
        {
            case "1": 
                ira.SpawnDemons(ira,gamemap);
                break;
            case "2":
                //gennaro.Load(ronen, gamemap);
                gamemap=gennaro.LoadMap(gamemap);
                ronen=gennaro.LoadRonen(ronen);
                break;
            default:
                gamemap=gennaro.LoadMap(gamemap);
                ronen=gennaro.LoadRonen(ronen);
                break;        
        }
        GameManager.PrintSpace();        
        
        if(ronen.isTutorial)
            {
                foreach(Demon demon in gameDemons)
                {
                    if(demon.name == "Invidia" && demon.life >0)
                    {
                        GameManager.Tutorial(ronen,demon);
                    }
                }                
            }

        Console.WriteLine("Se serve un reminder sull'obiettivo del gioco premi (H).");
        
        while(ronen.life > 0)
        {
            //Console.WriteLine("Ira ora si trova in {0}",ira.room.name);            
            //Console.WriteLine("Ronen ora si trova in {0}",ronen.room.name);
            
            if(!ronen.isFighting)
            {
                ronen.StandardMenu(ronen,gennaro);
            }

            if(ronen.turn%3 == 0)
            {
                Program.log.Info("Third turn");
                bool iraAlive=false;
                foreach(Room room in gamemap.Map)
                {
                    if(room.containsDemon==true && room.roomDemons[0].name=="Ira")
                    {
                        iraAlive=true;
                    }

                }
                if(ira.room != ronen.room && ira.isAlive && iraAlive)
                {
                    ira.IraMove();                    
                }
                               
            }        
        
            foreach(Room room in gamemap.Map)//controlla se nella stanza di ronen è presente un demone
            {
                if(room == ronen.room)
                {
                    if(room.roomDemons.Any() && room == ronen.room && room.roomDemons.ElementAt(0).isAlive)//controlla se è la stessa stanza di ronen e ci sono demoni
                    {
                        Program.log.Info("Ronen encountered demon");
                        //Console.Clear();
                        Console.WriteLine("Il demone {0} è nella stanza",room.roomDemons.ElementAt(0).name);
                        ronen.isFighting=true;
                        room.roomDemons.ElementAt(0).CombatMenu(ronen,room.roomDemons.ElementAt(0));                    
                    }
                    if(room.number == 10)//
                    {
                        int soldi = gamemap.AddMoneyCorona(); 
                        if(!ronen.bagItem.Any(borsaSoldi => borsaSoldi.id==10))
                        {
                            Item moneyBag =new Item();
                            moneyBag.SaccaSoldi();
                            ronen.bagItem.Add(moneyBag);
                        }
                        Program.log.Info("Ronen picked money");
                        ronen.money+=soldi;
                        if(ronen.bagItem.Any(borsaSoldi => borsaSoldi.id==10))
                        {
                            ronen.bagItem.Find(borsaSoldi => borsaSoldi.id==10).weight=ronen.money;
                        }
                        Console.WriteLine("Ho raccolto {0} monete",soldi);
                        soldi = 0;
                    }
                    if(room.number==2 && room.filled>=40)
                    {
                        Console.WriteLine("La tua urina ha completamente riempito la stanza. Nonostante la porta da cui sei venuto stranamente riesce a reggere il peso di tutta questa urina, la porta di marmo rossa con le scritte strane sembra non reggere più. Il portone si sgretola e tutto il piscio invade la stanza finale. Uno tsunami di pipì irrompe nella sala dove un'enorme demone dormiva. Viene letteralmente inondato e la sua pelle, a contatto con la tua urina santificata si dissolve. Dopo pochi minuti, non c'è più traccia di quel demone.");
                        Console.ReadLine();
                        Console.WriteLine("Sei rimasto solo, al centro della stanza. Il tuo obiettivo è stato raggiunto, ma non è successo niente dopo. Provi a tornare dall'angelo, ma non è più nella sua stanza. Cerchi perfino se è rimasto qualche altro demone in giro, ma senza risultato.");
                        Console.WriteLine("Sei Solo");
                        Console.ReadLine();

                        Console.WriteLine("La prima preoccupazione è la possibilità di morire di fame o sete, ma anche dopo settimane ancora non senti necessità di mangiare o bere.");
                        Console.ReadLine();

                        Console.WriteLine("Stranamente anche dopo mesi non sei impazzito");
                        Console.ReadLine();
                        Console.WriteLine("Sono ormai passati anni, ma sei felice. Hai raggiunto la pace interiore, grazie al tuo piscio.");
                        Console.ReadLine();
                        Console.WriteLine("Sono passati una decina di secoli e senti un rumore provenire sia dal piano di sopra che dal piano di sotto. Ma ormai tu sei pronto, questo è il tuo regno e nessuno riuscirà a togliertelo.");
                        Console.ReadLine();
                        Console.WriteLine("Fin");
                        Console.ReadLine();
                        return;
                    }
                    if(room.number == 1)
                    {
                        if(room.containsDemon == false && ronen.forgedItems>0)
                        {
                            Console.WriteLine("Dopo quest'ultimo colpo, il corpo dell'enorme demone cade a terra senza vita. Belphagor è finalmente morto. Hai combattuto i tuoi demoni e li hai sconfitti.");
                            Console.ReadLine();
                            Console.Clear();                            
                            Console.WriteLine("La tua anima è salva.");
                            Console.ReadLine();
                            Console.Clear();   
                            Console.WriteLine("Ora puoi riposare...");
                            Console.ReadLine();
                            return;

                        }
                        else if(room.containsDemon == false && ronen.forgedItems<=0)
                        {
                            Console.WriteLine("BELPHAGOR: <<HAHAHAHA NON ERA MAI SUCCESSA UNA COSA SIMILE... GENNARO, VOLEVI UN'ALTRA ANIMA NEL TUO REGNO CELESTE? INVECE HAI CREATO UN NUOVO DEMONE! AHAHAHAH ABBIAMO UN NUOVO DEMONE! RONEN!>>");
                            Console.ReadLine();  
                            Console.WriteLine("Dopo quest'ultimo colpo, il corpo dell'enorme demone cade a terra senza vita. Belphagor è finalmente morto. Hai combattuto i tuoi demoni e li hai sconfitti.");
                            Console.ReadLine();  
                            
                            Console.WriteLine("Procedi a sederti sul trono di Belphagor e il tuo corpo comincia a cambiare, mutare, crescere. Sei ufficialmente diventato il demone di questo girone...");
                            Console.ReadLine();  
                            Console.WriteLine("FINE");
                            Console.ReadLine();
                            return;
                        }
                    }
                }                        
            }

            if(ronen.life <=0)
            {
                Console.WriteLine("Sei Morto");
                Console.ReadLine();  
            }            
        }
    }
}
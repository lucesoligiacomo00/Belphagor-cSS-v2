using Newtonsoft.Json;

namespace Belphagor;
public class Ronen : Entity
{
    
    public new string name = "Ronen";
    public int bagCapacity {set; get;} //indica il massimo peso che si può portare
    public int bagWeight {set; get;} //peso attuale trasportato
    public int turn{set;get;} //turni trascorsi
    public int money {set; get;} //quantità di soldi in possesso
    public List<Item> bagItem {set; get;} //lista degli oggetti nella borsa
    
    public List<Item> armor {set; get;} //lista oggetti equipaggiati come armatura

    public Item? weapon {set; get;} //oggetto dell'arma
    public bool isFighting{get;set;}
    public  int forgedItems {get;set;}
    public bool isTutorial {get;set;}
    public bool pissFull {get;set;}

    public Ronen ()
    {
        

    }

    [JsonConstructor]
    public Ronen(string Name, int Life,int MaxLife, int Attack,Room Room, int BagCapacity, int BagWeight, List<Item> BagItem,int Money, int Turn,bool IsFighting, Item Weapon, List<Item> Armor, int ForgedItems,bool IsTutorial, bool PissFull) : base(Name, Life, MaxLife, Attack, Room)
    {
        this.name="Ronen";
        this.life= Life;
        this.maxLife= MaxLife;
        this.attack=Attack;
        this.room= Room;
        this.bagItem= BagItem;
        this.armor = Armor;
        this.weapon=Weapon;
        
        this.bagCapacity = BagCapacity;
        this.bagWeight = BagWeight;
        this.bagItem = BagItem;
        this.money = Money;
        this.turn = Turn;
        this.isFighting = IsFighting; 
        this.forgedItems=ForgedItems;
        this.isTutorial=IsTutorial;

        this.pissFull=PissFull;
    }


    

    
    public void Drop(int index) //butta oggetti dalla borsa
    {
        bagItem.Remove(bagItem.ElementAt(index+1));
        Program.log.Info("Item dropped form bag");
    }
    public void Use(int index)//usa oggetti dalla borsa
    {
        bagItem[index].Effect(this);
        Program.log.Info("Item used");
    }
/// <summary>
/// Permette di scegliere se cambiare stanza, aprire la sua borsa o visualizzare gli oggetti presenti nella stanza tramite riga di comando.
/// </summary>
/// <param name="ronen"></param>
/// <param name="gamemap"></param>
/// <param name="chest5"></param>
/// <param name="chest9"></param>
    public void StandardMenu(Ronen ronen,Angel angel)
    {
        bool validInput=false;
        //Console.Clear();
        while(!validInput && ronen.room.roomDemons.Count() == 0)
        {
            Console.WriteLine("====================");
            Console.WriteLine(" 1) Cambia Stanza");
            Console.WriteLine(" 2) Apri Borsa");
            Console.WriteLine(" 3) Oggetti stanza");
            if(ronen.room.number == 9 || ronen.room.number == 5)
            {
                Console.WriteLine(" 4) Cassa");
            }
            if(ronen.room.number== angel.room.number)
            {
                Console.WriteLine(" 5) Angelo");
            }
            Console.WriteLine(" 6) Equipaggiamenti");
            if(ronen.pissFull)
            {
                Console.WriteLine(" 7) Orina");
            }
            Console.WriteLine("====================");
            PrintStats();
            Program.log.Info("Standard menu");
            string input = Console.ReadLine();
            GameManager.PrintSpace();

            switch(input)
            {
                case "1":
                    ronen.Move(ronen,false,null);
                    validInput=true;
                    break;
                case "2":
                    Item.DisplayItems(this.bagItem);
                    Item.PrintBagWeight(ronen);
                    if(ronen.bagItem.Count == 0)
                    {
                        break;
                    }
                    Item? bagItem = new Item();
                    bagItem = Item.SelectItem(ronen.bagItem,ronen,false);
                    if(bagItem!=null)
                    {
                        bagItem.interactionActive=true;
                        bagItem.BagInteraction(ronen);
                    }
                    isFighting = false;
                    validInput=true;
                    break;
                case "3":
                    Item.DisplayItems(room.roomItems);
                    if(room.roomItems.Count == 0)
                    {
                        break;
                    }
                    Item? roomItem = Item.SelectItem(room.roomItems,ronen,false);
                    if(roomItem!=null)
                    {
                        roomItem.interactionActive=true;
                        roomItem.RoomInteraction(ronen);
                    }
                    
                    isFighting = false;
                    validInput=true;
                    break;
                case "4":
                    if(ronen.room.number == 5)
                    {
                        Program.chest5.ChestEffect(ronen);
                    }
                    else if(ronen.room.number == 9)
                    {
                        Program.chest9.ChestEffect(ronen);
                    }
                    break;
                case "5":
                    isFighting = false;
                    Console.WriteLine("Cosa ti serve dall'Angelo?");
                    angel.AngelMenu(ronen);
                    Console.WriteLine("Grazie mille!");
                    break;
                case "H":
                    Console.WriteLine($"L'obiettivo del gioco è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.");
                    break;
                case "h":
                    Console.WriteLine($"L'obiettivo del gioco è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.");
                    break;
                case "6": Armor(ronen);
                    break;
                case "7": Piss(ronen);
                    break;
                default:
                    break;                    
            }
        }
    }

    private void Piss(Ronen ronen)
    {
        ronen.room.filled++;
        ronen.pissFull=false;
        
    }

    public void Armor(Ronen ronen)
    {
        Console.WriteLine("Oggetti Equipaggiati");
        if (ronen.weapon!=null)
        {
            Console.WriteLine($"- {ronen.weapon.name}");

        }
        if (ronen.armor.Any(item => item.equipValue==2))
        {
            Console.WriteLine($"- {ronen.armor.Find(item => item.equipValue==2).name}");

        }
        if (ronen.armor.Any(item => item.equipValue==3))
        {
            Console.WriteLine($"- {ronen.armor.Find(item => item.equipValue==3).name}");

        }
        if (ronen.armor.Any(item => item.equipValue==4))
        {
            Console.WriteLine($"- {ronen.armor.Find(item => item.equipValue==4).name}");

        }
        if (ronen.armor.Any(item => item.equipValue==5))
        {
            Console.WriteLine($"- {ronen.armor.Find(item => item.equipValue==5).name}");

        }
        if (ronen.armor.Any(item => item.equipValue==6))
        {
            Console.WriteLine($"- {ronen.armor.Find(item => item.equipValue==6).name}");

        }
        


    }

/// <summary>
/// Permette di scegliere tramite riga di comando le stanze in cui Ronen può andare
/// </summary>
/// <param name="ronen"></param>
    public void Move(Ronen ronen, bool wasFighting, Demon demon)
    {
        bool nord = false;
        bool sud = false;
        bool est = false;
        bool ovest = false;
        int input=0;
        bool validInput = false;

        while (!validInput)
        {
            //Console.Clear();            
            Console.WriteLine("====================");
            if(ronen.room.GetDirection(0) != null)
            {
                Console.WriteLine("  1. Nord - {0}",ronen.room.GetDirection(0).name);
                nord = true;
            }
            if(ronen.room.GetDirection(1) != null)
            {
                if(ronen.room.GetDirection(1).number == 1)
                {
                    if(this.forgedItems >= 7)
                    {
                        Console.WriteLine("  2. Sud - Regno");
                        sud = true;
                    }
                    else
                    {
                        Console.WriteLine("  Regno - Hai bisogno ancora di {0} Materiali Demoniaci",7-this.forgedItems);
                    }
                    if(this.money>=300)
                    {
                        Console.WriteLine("  2. Sud - Regno");
                        sud = true;
                    }
                }
                else
                {
                    Console.WriteLine("  2. Sud - {0}", ronen.room.GetDirection(1).name);
                    sud = true;
                }
            }
            if(ronen.room.GetDirection(2) != null)
            {
                Console.WriteLine("  3. Est - {0}", ronen.room.GetDirection(2).name);
                est = true;
            }
            if(ronen.room.GetDirection(3) != null)
            {
                Console.WriteLine("  4. Ovest - {0}", ronen.room.GetDirection(3).name);
                ovest = true;
            }
            Console.WriteLine("  5. Annulla");
            Console.WriteLine("====================");
            Program.log.Info("Move menu");

            string? inputString = Console.ReadLine();
            GameManager.PrintSpace();
            int.TryParse(inputString, out input);
            //Console.Clear();
            

            switch (input)
            {
                case 1:
                    if(ronen.room.GetDirection(0) !=  null && nord && ronen.room.number!=1)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("A nord di questa stanza non c'è nulla");
                    }                    
                    break;

                case 2:
                    if(ronen.room.GetDirection(1) !=  null && sud)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("A sud di questa stanza non c'è nulla");
                    }                    
                    break;

                case 3:
                    if(ronen.room.GetDirection(2) !=  null && est)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("A est di questa stanza non c'è nulla");
                    }                    
                    break;
                    
                case 4:
                    if(ronen.room.GetDirection(3) !=  null && ovest)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("A ovest di questa stanza non c'è nulla");
                    }                    
                    break;

                case 5:
                    Console.WriteLine("");//annulla
                    if(wasFighting)
                    {
                        validInput = true;
                        Console.WriteLine($"Il demone {demon.name} è nella stanza");
                        demon.CombatMenu(ronen,demon);
                    }
                    Program.log.Info("Move menu quit");
                    return;                
                    
                default:
                    Console.WriteLine("");//comando errato
                    Program.log.Info("Invalid direction command");
                    break;
            }
        }
        ronen.turn++;
        ronen.room = ronen.room.GetDirection(input-1);
        ronen.room.Description();
        Program.log.Info("Ronen changed room");
        //Console.WriteLine("Ronen si è spostato nella stanza {0} ", ronen.room.name);
    }

    public void PrintStats()
    {    
        Console.WriteLine($"Ronen - HP:{this.life}  ATK:{this.attack}");
        Console.WriteLine("------------------------");
    }

    public void BagWeightUpdate()
    {
        bagWeight=0;
        if(this.bagItem.Any(borsaSoldi => borsaSoldi.id==10))
        {
            this.bagItem.Find(borsaSoldi => borsaSoldi.id==10).weight=this.money;
         }
        foreach(Item item in bagItem)
        {
            bagWeight+=item.weight;
        }
        foreach(Item armorItem in this.armor)
        {
            bagWeight+=armorItem.weight;
        }
            
    }
}
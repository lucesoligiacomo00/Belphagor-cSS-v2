namespace Belphagor;
public class Item
{
    public int weight {set; get;} //peso dell'oggetto
    public string name {set; get;} //nome dell'oggetto
    public bool transportable {set; get;}
    public bool equippable {set; get;}
    public int equipValue {set; get;}
    public bool weapon {set;get;}
    public bool interactionActive {set; get;}//indica se si sta interagendo con un oggetto
    public int id {set;get;}

    public Item()
    {
        switch(this.id)
        {
            case 0: AcquaSanta();
                break;
            case 1: Excalibur();
                break;
            case 2: ElmoSacro();
                break;
            case 3: StivaliAngelici();
                break;
            case 4: BraccialeDiCastita();
                break;
            case 5: ScudoCelestiale();
                break;
            case 6: MiracoloTascabile();
                break;
            case 7: ArmaturaDivina();
                break;
            case 8: Chest();
                break;
            case 9: MaterialeDemoniaco();
                break;
            case 10: SaccaSoldi();
                break;
        }
    }
/// <summary>
/// Stampa a video la lista di Item passata come argomento.
/// </summary>
/// <param name="list"></param>
    public static void DisplayItems(List<Item> list)
    {
        int i=0;
        //Console.Clear();
        if(list.Count() > 0)
        {
            Console.WriteLine("===============");
            foreach(Item item in list)
            {
                i++;                  
                Console.WriteLine("{0}. - {1}",i,item.name);
            }
            //Console.WriteLine("{0}. - Esci",i+1);

            Console.WriteLine("===============");
        }
        else
        {
            //Console.Clear();
            Console.WriteLine("Non c'è nessun oggetto...");
        }
        //Console.WriteLine("0. - Esci");
        Console.WriteLine();

    }
/// <summary>
/// Restituisce l'Item selezionato dalla lista tramite riga di comando
/// </summary>
/// <param name="list"></param>
/// <param name="ronen"></param>
/// <returns></returns>
    public static Item SelectItem(List<Item> list,Ronen ronen,bool wasFighting)
    {
        int i=0;       
        ronen.isFighting = true;
        while(true)
        {
            string input = Console.ReadLine();
            GameManager.PrintSpace();
            foreach(Item item in list)
            {
                i++;
                if(i.ToString() == input && item.transportable)
                {
                    Console.WriteLine("Oggetto '{0}' selezionato",item.name);
                    //Console.Clear();
                    return item;

                }
                else if(i.ToString() == input && !item.transportable)
                {
                    Console.WriteLine("Non puoi raccogliere questo oggetto");
                    if(wasFighting)
                    {
                        ronen.room.roomDemons.ElementAt(0).CombatMenu(ronen,ronen.room.roomDemons.ElementAt(0));
                        return null;
                    }
                    else
                    {
                        ronen.StandardMenu(ronen,Program.gennaro);
                        return null;
                    }
                }
                
            }
            Console.WriteLine("Comando inesistente riprova");
            i=0;
            DisplayItems(list);

        }         
    }

/// <summary>
/// Stampa a video un menù che permette di osservare o raccogliere un oggetto presente in una stanza.
/// </summary>
/// <param name="ronen"></param>
    public void RoomInteraction(Ronen ronen) //menu dell'interazione con l'oggetto
    {
        while (interactionActive==true)
        {
            Console.WriteLine("Cosa faccio? ");
            Console.WriteLine("===============");
            Console.WriteLine("1) Osservo");
            Console.WriteLine("2) Prendo");
            Console.WriteLine("3) Niente");
            Console.WriteLine("===============");
            PrintBagWeight(ronen);

            string input=Console.ReadLine(); //il giocatore inserisce la risposta
            GameManager.PrintSpace();
            switch(input)
            {
                case "1": Observe(ronen); //commento sulle osservazioni sull'oggetto
                    break;

                case "2": Store(ronen,ronen.room.roomItems); //prende l'oggetto e lo mette in borsa
                    interactionActive=false;
                    break;

                default: //torna indietro
                    Console.WriteLine("No niente, non mi interessa.");
                    interactionActive=false;
                    break;
            } 
        }
        ronen.BagWeightUpdate();
    }
/// <summary>
/// Stampa a video un menù che permette di osservare o usare un oggetto presente nalla borsa di Ronen.
/// </summary>
/// <param name="ronen"></param>
    public void BagInteraction(Ronen ronen) //menu dell'interazione con l'oggetto
    {
        while (interactionActive==true)
        {
            Console.WriteLine("Cosa faccio? ");
            Console.WriteLine("===============");
            Console.WriteLine("1) Osservo");
            Console.WriteLine("2) Uso");
            Console.WriteLine("3) Niente");
            Console.WriteLine("===============");
            PrintBagWeight(ronen);

            string input=Console.ReadLine(); //il giocatore inserisce la risposta
            GameManager.PrintSpace();
            switch(input)
            {
                case "1": Observe(ronen); //commento sulle osservazioni sull'oggetto
                    break;

                case "2": Effect(ronen); //prende l'oggetto e lo mette in borsa
                    interactionActive=false;
                    break;

                default: //torna indietro
                    Console.WriteLine("No niente, non mi interessa.");
                    interactionActive=false;
                    break;
            } 
        }
        ronen.BagWeightUpdate();
    }

    public static void PrintBagWeight(Ronen ronen)
    {
        Console.WriteLine($"Peso Borsa : {ronen.bagWeight}/{ronen.bagCapacity}");
        Console.WriteLine("----------------------------");

    }

    public virtual void Effect(Ronen ronen) //effetto dell'oggetto
    {
        switch (id)
        {
            case 0: 
            AcquaSantaEffect(ronen);
                break;
            case 1: 
                ExcaliburEffect(ronen);
                break;
            case 2: 
                ElmoSacroEffect(ronen);
                break;
            case 3: 
                StivaliAngeliciEffect(ronen);
                break;
            case 4: 
                BraccialeDiCastitaEffect(ronen);
                break;
            case 5: 
                ScudoCelestialeEffect(ronen);
                break;
            case 6: 
                MiracoloTascabileEffect(ronen);
                break;
            case 7: 
                ArmaturaDivinaEffect(ronen);
                break;
            case 8: 
                
                break;
            case 9:
                MaterialeDemoniacoEffect();
                break;
            case 10:
                SaccaSoldiEffect(ronen);
                break;
            
            
        }

    }
    public virtual void Observe(Ronen ronen) //metodo di quando si osserva l'oggetto
    {
        switch (id)
        {
            case 0: 
                
                break;
            case 1: 
                ExcaliburObserve();
                break;
            case 2: 
                ElmoSacroObserve();
                break;
            case 3: 
                StivaliAngeliciObserve();
                break;
            case 4: 
                BraccialeDiCastitaObserve();
                break;
            case 5: 
                ScudoCelestialeObserve();
                break;
            case 6: 
                break;
            case 7: 
                ArmaturaDivinaObserve();
                break;
            case 8: 
                
                break;
            case 9:
                MaterialeDemoniacoEffect();
                break;
            case 10:
                SaccaSoldiObserve(ronen);
                break;
            
        }

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ronen"></param>
    public void SwitchItem (Ronen ronen)
    {
    
        int equipedLocation=ronen.armor.Count+1;

        for (int i=0; i<ronen.armor.Count;i++)
        {
            if(ronen.armor[i].equipValue==this.equipValue)
            {
                equipedLocation=i;
            }
            
        }
        
        if (ronen.armor.Contains(this))
        {
            Console.WriteLine($"Vuoi Disequipaggiare {this.name}?");
            Console.WriteLine($"(Y)es / (N)o");
            string a=Console.ReadLine();
            GameManager.PrintSpace();
            switch(a)
            {
                case "Y":
                    Unequip(ronen,this.equipValue);
                    break;
                case "N":
                    break;
            }
        }
        else
        {            
            if (equipedLocation!=ronen.armor.Count+1) 
            {
                ronen.armor[equipedLocation].Unequip(ronen,ronen.armor[equipedLocation].equipValue);
                

            }           
                
            this.Equip(ronen,this.equipValue);
            //Console.Clear();                
            Console.WriteLine($"Hai equipaggiato {this.name}, ora la tua salute massima è {ronen.maxLife} e il tuo Attacco è {ronen.attack}.");
            


        }

    }
/// <summary>
/// Dato l'intero equipValue permette di scegliere quale Item equipaggiare.
/// </summary>
/// <param name="ronen"></param>
/// <param name="equipValue"></param>
    public void Equip(Ronen ronen,int equipValue) //metodo di quando si osserva l'oggetto
    {
        switch (equipValue)
        {
            case 0: 
                break;
            case 1: 
                ExcaliburEquip(ronen);
                break;
            case 2: 
                ElmoSacroEquip(ronen);
                break;
            case 3: 
                StivaliAngeliciEquip(ronen);
                break;
            case 4: 
                BraccialeDiCastitaEquip(ronen);
                break;
            case 5: 
                ScudoCelestialeEquip(ronen);
                break;
            case 6: 
                ArmaturaDivinaEquip(ronen);
                break;
            case 7:                 
                break;
            case 8: 
                break;
            
            
        }

    }

    
/// <summary>
/// Dato l'intero equipValue permette di scegliere quale Item disequipaggiare.
/// </summary>
/// <param name="ronen"></param>
/// <param name="equipValue"></param>
    public void Unequip(Ronen ronen,int equipValue) //metodo di quando si osserva l'oggetto
    {
        switch (equipValue)
        {
            case 0: 
                break;
            case 1: 
                ExcaliburUnequip(ronen);
                break;
            case 2: 
                ElmoSacroUnequip(ronen);
                break;
            case 3: 
                StivaliAngeliciUnequip(ronen);
                break;
            case 4: 
                BraccialeDiCastitaUnequip(ronen);
                break;
            case 5: 
                ScudoCelestialeUnequip(ronen);
                break;
            case 6:
                ArmaturaDivinaUnequip(ronen);
                break;
            case 7: 
                
                break;
            case 8: 
                break;
            
            
        }

    }

    
/// <summary>
/// Permette di aggiungere alla borsa di Ronen un Item se questa non è piena.
/// </summary>
/// <param name="ronen"></param>
    public void Store(Ronen ronen,List<Item> sourceList) //metodo per prendere l'oggetto
    {
        if (ronen.bagWeight+this.weight>ronen.bagCapacity)
        {
            Console.WriteLine("Sto portando troppo peso, se voglio prendere qualcos'altro devo prima lasciare qualcosa.");

        }
        else
        {            
            ronen.bagItem.Add(this);
            sourceList.Remove(this);
            ronen.bagWeight+=this.weight;
            Console.WriteLine($"Hai aggiunto {this.name} alla tua borsa.");
        }

    }

    public void AcquaSanta ()
    {
        this.name="Acqua Santa";
        this.equippable=false;
        this.equipValue=0;
        this.id=0;
        this.transportable=true;
        this.weight=2;
        this.weapon=false;
    }

    public void AcquaSantaEffect(Ronen ronen)
    {
        AcquaSanta acquaSanta = new AcquaSanta();
        //Console.WriteLine("Senti una voce lontana.");
        //Console.WriteLine("ANGEL: <<Nel ricaricare la tua anima ho commesso un'errore, rimedio subito. Riprova ad utililzzare questo oggetto.");

        acquaSanta.Effect(ronen);
        ronen.bagItem.Add(acquaSanta);
        
        ronen.bagItem.Remove(this);



    }
    
    

    public void Excalibur ()
    {
        this.name="Excalibur";
        this.equippable=true;
        this.equipValue=1;
        this.id=1;
        this.transportable=true;
        this.weight=5;
        this.weapon=true;
    }

    public void ExcaliburEffect(Ronen ronen)
    {
        SwitchItem(ronen);
        


    }
    

    private void ExcaliburEquip(Ronen ronen)
    {
        ronen.attack+=20;
        ronen.bagItem.Remove(this);
        ronen.weapon=this;
    }
    
    private void ExcaliburUnequip(Ronen ronen)
    {
        ronen.attack-=20;
        ronen.bagItem.Add(this);
        ronen.weapon=null;;
    }

    
    private void ExcaliburObserve()
    {
        Console.WriteLine("Una spada che distrugge ogni cosa istantaneamente, se usata da un'entità santa...");
    }

    public void ElmoSacro ()
    {
        this.name="Elmo Sacro";
        this.equippable=true;
        this.equipValue=2;
        this.id=2;
        this.transportable=true;
        this.weight=3;
        this.weapon=false;
    }

    public void ElmoSacroEffect(Ronen ronen)
    {
        SwitchItem(ronen);
    }

    private void ElmoSacroEquip(Ronen ronen)
    {
        ronen.maxLife+= 5;
        ronen.bagItem.Remove(this);
        ronen.armor.Add(this);
        /*if(ronen.bagItem.Contains(this))
        {
            ronen.bagWeight-=this.weight;
        }*/
    }

    


    private void ElmoSacroUnequip(Ronen ronen)
    {
        ronen.maxLife-= 5;
        ronen.bagItem.Add(this);
        ronen.armor.Remove(this);
    }



    private void ElmoSacroObserve()
    {
        Console.WriteLine("Un'elmo medievale impenetrabile. A seconda delle emozioni del portatore emana una luce di colore diverso.");
    }



    public void StivaliAngelici ()
    {
        this.name="Stivali Angelici";
        this.equippable=true;
        this.equipValue=3;
        this.id=3;
        this.transportable=true;
        this.weight=4;
        this.weapon=false;
    }

    public void StivaliAngeliciEffect(Ronen ronen)
    {    
        SwitchItem(ronen);

    
    }

    

    private void StivaliAngeliciEquip(Ronen ronen)
    {
        ronen.maxLife+= 2;
        ronen.bagCapacity+=20;
        ronen.bagItem.Remove(this);
        ronen.armor.Add(this);
    }




    private void StivaliAngeliciUnequip(Ronen ronen)
    {
        ronen.maxLife-= 2;
        ronen.bagCapacity-=20;
        ronen.bagItem.Add(this);
        ronen.armor.Remove(this);
    }
    

    private void StivaliAngeliciObserve()
    {
        Console.WriteLine("Degli stivali leggeri, ma estremamente resistenti. Chissà quanto potrebbero valere.");
    }

    public void BraccialeDiCastita ()
    {
        this.name="Bracciale di Castità";
        this.equippable=true;
        this.equipValue=4;
        this.id=4;
        this.transportable=true;
        this.weight=4;
        this.weapon=false;
    }

    public void BraccialeDiCastitaEffect(Ronen ronen)
    {
        SwitchItem(ronen);
    }

    

    private void BraccialeDiCastitaEquip(Ronen ronen)
    {
        ronen.maxLife+= 2;
        ronen.attack+=1;
        ronen.bagItem.Remove(this);
        ronen.armor.Add(this);
    }

    private void BraccialeDiCastitaUnequip(Ronen ronen)
    {
        ronen.maxLife-= 2;
        ronen.attack-=1;
        ronen.bagItem.Add(this);
        ronen.armor.Remove(this);
    }
    

    private void BraccialeDiCastitaObserve()
    {
        Console.WriteLine("Un bracciale che si illumina con un'intensità e calore sempre maggiore più lo avvicini alle parti basse.");
        Console.WriteLine("Se li avvicini troppo potrebbero polverizzarti i gioielli di famiglia.");
    }

    public void ScudoCelestiale ()
    {
        this.name="Scudo Celestiale";
        this.equippable=true;
        this.equipValue=5;
        this.id=5;
        this.transportable=true;
        this.weight=7;
        this.weapon=false;
    }

    public void ScudoCelestialeEffect (Ronen ronen)
    {
       SwitchItem(ronen);


    }

    

    private void ScudoCelestialeEquip(Ronen ronen)
    {
        ronen.maxLife+= 20;
        ronen.attack+=1;
        ronen.bagItem.Remove(this);
        ronen.armor.Add(this);
    }

    

    private void ScudoCelestialeUnequip(Ronen ronen)
    {
        ronen.maxLife-= 20;
        ronen.attack-=1;
        ronen.bagItem.Add(this);
        ronen.armor.Remove(this);
    }
    

    private void ScudoCelestialeObserve()
    {
        Console.WriteLine("Uno scudo enorme e pesantissimo. Sembra indistruttibile.");
    }

    public void MiracoloTascabile ()
    {
        this.name="Miracolo Tascabile";
        this.equippable=false;
        this.equipValue=0;
        this.id=6;
        this.transportable=true;
        this.weight=1;
        this.weapon=true;
        
    }

    public void MiracoloTascabileEffect(Ronen ronen)
    {
        MiracoloTascabile miracoloTascabile = new MiracoloTascabile();
        Console.WriteLine("Senti una voce lontana.");
        Console.WriteLine("ANGEL: <<Nel ricaricare la tua anima ho commesso un'errore, rimedio subito. Riprova ad utililzzare questo oggetto.");


        ronen.bagItem.Add(miracoloTascabile);
        ronen.bagItem.Remove(this);



    }


    public void ArmaturaDivina ()
    {
        this.name="Armatura Divina";
        this.equippable=true;
        this.equipValue=6;
        this.id=7;
        this.transportable=true;
        this.weight=20;
        this.weapon=false;
    }

    public void ArmaturaDivinaEffect (Ronen ronen)
    {
        SwitchItem(ronen);


    }

    private void ArmaturaDivinaEquip(Ronen ronen)
    {
        ronen.maxLife+= 50;
        ronen.attack+=1;
        ronen.bagItem.Remove(this);
        ronen.armor.Add(this);
    }
    private void ArmaturaDivinaUnequip(Ronen ronen)
    {
        ronen.maxLife-= 50;
        ronen.attack-=1;
        ronen.bagItem.Add(this);
        ronen.armor.Remove(this);
    }
    

    private void ArmaturaDivinaObserve()
    {
        Console.WriteLine("Un'armatura forse troppo larga per me, ma non importa fintanto che funziona.");
    }

    public void Chest ()
    {
        this.name="Cassa";
        this.equippable=false;
        this.equipValue=0;
        this.id=8;
        this.transportable=false;
        this.weight=50;
        this.weapon=false;
    }

    public void MaterialeDemoniaco ()
    {
        this.name="Materiale Demoniaco";
        this.equippable=false;
        this.equipValue=0;
        this.id=9;
        this.transportable=true;
        this.weight=5;
        this.weapon=false;
    }

    public void MaterialeDemoniacoEffect()
    {
        Console.WriteLine($"Questo oggetto è apparentemente inutile. Se lo porti dall'angelo potrebbe farci qualcosa.");
    }

    public void SaccaSoldi ()
    {
        this.name="Sacca per Soldi";
        this.equippable=false;
        this.equipValue=0;
        this.id=10;
        this.transportable=true;
        this.weight=0;
        this.weapon=false;
    }

    public void SaccaSoldiEffect(Ronen ronen)
    {
        if(!ronen.room.containsDemon)
            {
                Console.WriteLine($"Non vuoi liberartene, anche se quì non servono a niente.");
            }
            else
            {
                if(ronen.room.roomDemons.Any( Avarizia => Avarizia.name=="Avarizia"))
                {
                    Console.WriteLine($"Hai lanciato {ronen.money} ad {ronen.room.roomDemons.ElementAt(0).name}, curandolo di {ronen.money}");
                    ronen.room.roomDemons.ElementAt(0).life+= ronen.money;
                    
                    

                }
                else
                {
                    Console.WriteLine($"Hai lanciato {ronen.money} a {ronen.room.roomDemons.ElementAt(0).name}, infliggendogli {ronen.money} danni.");
                    ronen.room.roomDemons.ElementAt(0).life-= ronen.money;
                    

                }
                ronen.money=0;
                
                

            }

    }
    public void SaccaSoldiObserve (Ronen ronen)
    {
        if (ronen.money==0)
        {
            Console.WriteLine($"Una sacca per contenere denaro. Sfortunatamente non hai alcun soldo.");
        }
        else 
        {
            Console.WriteLine($"Una sacca per contenere denaro. Attualmente hai {ronen.money}, ma non sono abbastanza per te.");
        }
    }


    

}

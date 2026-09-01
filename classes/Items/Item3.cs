﻿/*namespace Belphagor;
public class Item
{
    public int weight {set; get;} //peso dell'oggetto
    public string name {set; get;} //nome dell'oggetto
    public bool transportable {set; get;}
    public bool equippable {set; get;}
    public int equipValue {set; get;}
    public bool interactionActive; //indica se si sta interagendo con un oggetto
    public int id {set;get;}

    public Item(int Weight, string Name, bool Transportable, bool Equippable, bool InteractionActive, int Id)
    {
        this.weight = Weight;
        this.name = Name;
        this.transportable = Transportable;
        this.equippable = Equippable;
        this.interactionActive = InteractionActive;
        this.id = Id;
    }

    public Item()
    {
        switch(id)
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
        }
    }

    public void Interaction(Ronen ronen) //menu dell'interazione con l'oggetto
    {
        interactionActive = true;
        while (interactionActive)
        {
            Console.WriteLine("Cosa faccio? ");
            Console.WriteLine("===============");
            Console.WriteLine("1) Osservo");
            Console.WriteLine("2) Prendo");
            Console.WriteLine("3) Niente");
            Console.WriteLine("===============");

            string input=Console.ReadLine(); //il giocatore inserisce la risposta
            switch(input)
            {
                case "1": Observe(ronen); //commento sulle osservazioni sull'oggetto
                    interactionActive=false;
                    break;

                case "2": Store(ronen); //prende l'oggetto e lo mette in borsa
                    interactionActive=false;
                    break;

                default: //torna indietro
                    Console.WriteLine("No niente, non mi interessa.");
                    interactionActive=false;
                    break;
            }
        }
    }

    public static void DisplayItems(List<Item> list)
    {
        int i=0;
        Console.Clear();
        if(list.Count() > 0 && list.ElementAt(0).id != 8)
        {
            Console.WriteLine("===============");
            foreach(Item item in list)
            {
                if(item.id != 8)
                {
                    i++;
                    Console.WriteLine("{0}. - {1}",i,item.name);
                } 
            }
            Console.WriteLine("===============");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Non c'è nessun oggetto...");
        }
        //Console.WriteLine("0. - Esci");
        Console.WriteLine();

    }

    public static Item SelectItem(List<Item> list,Ronen ronen)
    {
        int i=0;       
        ronen.isFighting = true;
        while(true)
        {
            string input = Console.ReadLine();
            foreach(Item item in list)
            {
                if(item.id != 8)
                {
                    i++;
                }
                if(i.ToString() == input)
                {
                    Console.WriteLine("Oggetto '{0}' selezionato",item.name);
                    Console.Clear();
                    return item;
                }
            }
            Console.WriteLine("Comando inesistente riprova");

        }         
    }

    public void Effect(Ronen ronen) //effetto dell'oggetto
    {
        switch (id)
        {
            case 0: 
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
                break;
            case 7: 
                ArmaturaDivinaEffect(ronen);
                break;


        }

    }
    public void Observe(Ronen ronen) //metodo di quando si osserva l'oggetto
    {

    }



    public void Store(Ronen ronen) //metodo per prendere l'oggetto
    {
        if (ronen.bagWeight+this.weight>ronen.bagCapacity)
        {
            Console.WriteLine("Sto portando troppo peso, se voglio prendere qualcos'altro devo prima lasciare qualcosa");

        }
        else
        {
            ronen.bagWeight+=this.weight;
            ronen.bagItem.Add(this);
            Console.WriteLine("Ho aggiunto {0} nella mia borsa",this.name);
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
    }

    public void Excalibur ()
    {
        this.name="Excalibur";
        this.equippable=true;
        this.equipValue=1;
        this.id=1;
        this.transportable=true;
        this.weight=5;
    }

    public void ExcaliburEffect(Ronen ronen)
    {
        ronen.attack++;

    }

    public void ElmoSacro ()
    {
        this.name="Elmo Sacro";
        this.equippable=true;
        this.equipValue=2;
        this.id=2;
        this.transportable=true;
        this.weight=3;
    }

    public void ElmoSacroEffect(Ronen ronen)
    {
        ronen.maxLife+= 5;

    }

    public void StivaliAngelici ()
    {
        this.name="Stivali Angelici";
        this.equippable=true;
        this.equipValue=3;
        this.id=3;
        this.transportable=true;
        this.weight=4;
    }

    public void StivaliAngeliciEffect(Ronen ronen)
    {
        ronen.maxLife+= 2;
        ronen.bagCapacity+=10;

    }

    public void BraccialeDiCastita ()
    {
        this.name="Bracciale di Castità";
        this.equippable=true;
        this.equipValue=4;
        this.id=4;
        this.transportable=true;
        this.weight=4;
    }

    public void BraccialeDiCastitaEffect(Ronen ronen)
    {
        ronen.maxLife+= 2;
        ronen.attack+=1;

    }

    public void ScudoCelestiale ()
    {
        this.name="Scudo Celestiale";
        this.equippable=true;
        this.equipValue=5;
        this.id=5;
        this.transportable=true;
        this.weight=7;
    }

    public void ScudoCelestialeEffect (Ronen ronen)
    {
        ronen.maxLife+= 20;
        ronen.attack+=0;

    }

    public void MiracoloTascabile ()
    {
        this.name="Miracolo Tascabile";
        this.equippable=false;
        this.equipValue=0;
        this.id=6;
        this.transportable=true;
        this.weight=1;

    }


    public void ArmaturaDivina ()
    {
        this.name="Armatura Divina";
        this.equippable=true;
        this.equipValue=6;
        this.id=7;
        this.transportable=true;
        this.weight=20;

    }

    public void ArmaturaDivinaEffect (Ronen ronen)
    {
        ronen.maxLife+=50;
        ronen.attack+=0;

    }

}*/
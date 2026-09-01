﻿using System.Text.Json.Serialization;

namespace Belphagor;
public class Chest : Item
{
    List<Item> listItem {set; get;}

    [JsonConstructor]
    public Chest(List<Item> ListItem)
    {
        this.name="Cassa";
        this.equippable=false;
        this.equipValue=0;
        this.id=8;
        this.transportable=false;
        this.weight=50;
        this.listItem=ListItem;
    }

    public Chest()
    {
        this.name="Cassa";
        this.equippable=false;
        this.equipValue=0;
        this.id=8;
        this.transportable=false;
        this.weight=50;
        this.listItem= new List<Item>();
    }

/// <summary>
/// Il menù di interazione della Chest consente di prendere, lasciare o osservare un item.
/// </summary>
/// <param name="ronen"></param>
    public void ChestEffect (Ronen ronen)
    {
        //Console.Clear();
        Program.log.Info("Chest menu");
        Console.WriteLine("==================");
        Console.WriteLine("  1) Prendi Oggetti");
        Console.WriteLine("  2) Lascia Oggetti");
        Console.WriteLine("  3) Osserva");
        Console.WriteLine("  4) Esci");
        Console.WriteLine("==================");
        string a=Console.ReadLine();
        GameManager.PrintSpace();
        switch(a)
        {
            case "1": 
             ItemTakingSelection(ronen);
             break;
            case "2":
             ItemLeavingSelection(ronen);
             break;
            case "3":
             Observe();
             break;
            default: 
             //Console.Clear();
             Console.WriteLine(" Non mi interessa");
             break;
        }
    }

    public void Observe ()
    {
        Program.log.Info("Observing chest");
        //Console.Clear();
        Console.WriteLine("Una cassa, sembra essere senza fine.");
    }
/// <summary>
/// Consente di spostare un Item dalla Chest alla borsa di Ronen.
/// </summary>
/// <param name="ronen"></param>
    public void ItemTakingSelection(Ronen ronen) //prendi l'oggetto dalla chest
    {
        //Console.Clear();
        Console.WriteLine("==================");
        if (listItem.Any())
        {
            for(int i=0;i<listItem.Count;i++) //rappresenta tutti gli oggetti nella chest con un numero da 1 alla dimensione degli ogggetti nella chest
            {
                Console.WriteLine($" {i+1}) {listItem[i].name}");

            }
            Console.WriteLine($"  {listItem.Count+1}) Esci");
            Console.WriteLine("==================");
            Program.log.Info("Chest items displayed");
            string selected=Console.ReadLine(); // inserisci il numero della scelta che vuoi fare
            GameManager.PrintSpace();
            int a;
            if (int.TryParse(selected, out a)) // prova a convertire il numero inserito in int e se riesce
            {
                if (a>0 & a<listItem.Count+1) // controlla se è tra gli oggetti nella chest
                {
                    if(ronen.bagCapacity>=ronen.bagWeight+listItem[a-1].weight) // in caso ci sia controlla se hai spazio in borsa
                    {
                        ronen.bagItem.Add(listItem[a-1]);
                        ronen.bagWeight+=listItem[a-1].weight;
                        listItem.RemoveAt(a-1);
                        Program.log.Info("Item picked from chest");

                    }
                    else
                    {
                        Console.WriteLine($"Stai già portando troppo peso.");
                        Program.log.Info("Maximum weight reached");

                    }
                    
                }
                ChestEffect(ronen);
            }
            else
            {
                ChestEffect(ronen);
            }

        }
        


    }

/// <summary>
/// Consente di lasciare un Item dalla borsa di Ronen alla Chest
/// </summary>
/// <param name="ronen"></param>
    public void ItemLeavingSelection(Ronen ronen) //lasci l'oggetto nella stanza
    {
        //Console.Clear();
        Console.WriteLine("Scegli gli Oggetti da Lasciare");
        Console.WriteLine("==================");
        for(int i=0;i<ronen.bagItem.Count;i++)
        {
            Console.WriteLine($" {i+1}) {ronen.bagItem[i].name}");

        }
        Console.WriteLine($"  {ronen.bagItem.Count+1}) Esci");
        Console.WriteLine("==================");
        Program.log.Info("Bag items displayed");
        string selected=Console.ReadLine();
        GameManager.PrintSpace();
        int a;
        if (int.TryParse(selected, out a))
        {
            if (a>0 & a<ronen.bagItem.Count+1)
            {
                ronen.bagWeight-=ronen.bagItem[a-1].weight;
                       
                this.listItem.Add(ronen.bagItem[a-1]);
                ronen.bagItem.RemoveAt(a-1);
                Program.log.Info("Item dropped from bag");                            
            }
            ChestEffect(ronen);
        }
        else
        {
            ChestEffect(ronen);
        }


    }
}
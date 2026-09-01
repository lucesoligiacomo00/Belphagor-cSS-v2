﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belphagor
{
    public class Room
    {
        public string name {get;set;}
        public int number {get;set;}
        public int?[] connectedRooms {get;set;}
        public List<Demon> roomDemons {get;set;}
        public bool containsDemon {get;set;}
        public List<Item> roomItems {get;set;}
        public int money{get;set;}
        public int filled{get;set;}

        public Room(string Name,int Number)
        {
            name=Name;
            number=Number;
            connectedRooms = new int?[4];
            roomDemons = new List<Demon>(3);
            containsDemon = false;
            roomItems = new List<Item>(10);
            filled=0;
        }
/// <summary>
/// Data una stanza imposta le sue adiacenti passate come parametri.
/// </summary>
/// <param name="n"></param>
/// <param name="s"></param>
/// <param name="e"></param>
/// <param name="w"></param>
        public void SetConnectedRooms(int? n,int? s,int? e,int? w)
        {
            if(n != null)
            {
                connectedRooms[0] = n;
            }
            if(s != null)
            {
                connectedRooms[1] = s;
            }
            if(e != null)
            {
                connectedRooms[2] = e;
            }
            if(w != null)
            {
                connectedRooms[3] = w;
            }
            Program.log.Info("Connected rooms setted");        
        }

        public Room GetDirection(int direction)
        {
            if (direction >= 0 && direction < connectedRooms.Length)
            {
                Program.log.Info("Direction obtained");

                foreach(Room room in Program.gamemap.Map)
                {
                    if (room.number==this.connectedRooms[direction])
                    {
                        return room;

                    }
                }

                
                
            }
            return null;
        }

        public void Description()
        {
            
            if(this.filled<=10)
            {
                switch(this.number)
                {
                    case 1:
                        Console.WriteLine("Ti ritrovi in una stanza buia, un forte odore di marcio invade il tuo olfatto. Senti una voce provenire dall'altro lato della stanza.");
                        Console.ReadLine();  

                        Console.WriteLine("??? <<E' PER CASO ENTRATO QUALCUNO?>>");
                        Console.WriteLine("Poi un rumore netto e colonne di fiamme si accendono su tutte le pareti della stanza. Grazie alla luce emanata dalle fiamme riesci a vedere dove ti trovi. Sul pavimento, sparse in giro, ci sono buste della spazzatura e bottiglie vuote");
                        Console.WriteLine("e in fondo vedi una creatura umanoide gigantesca, con 2 corna e una lunga coda da ratto seduta sul suo trono di porcellana. La vedi strizzare gli occhi guardando nella tua direzione.");
                        Console.ReadLine();  

                        Console.WriteLine("??? <<OOHH FORSE HO CAPITO! TU SEI L'UMANO CHE HANNO FATTO PORTARE QUI! COME FAI AD ESSSERE ANCORA IN VITA? MA INDOSSI UN'ARMATURA SACRA!>>");
                        Console.WriteLine("??? <<DEV'ESSERSI INTROMESSO GENNARO. POCO MALE, TI TERMINERO' IO STESSO, BELPHAGOR!>>");
                        Console.WriteLine("BELPHAGOR <<DAI VIENI E COMBATTI! NON MI VA DI VENIRE LI' DA TE.>>");
                        Console.WriteLine("La porta dietro di te si chiude impedendoti la fuga.>>");
                        Console.ReadLine();  

                        break;
                    case 2:
                        Console.WriteLine("Ti ritrovi in una stanza di cemento completamente vuota, ad eccezione della porta a sud, che sembra essere fatta di un marmo rosso.");
                        Console.WriteLine("Inoltre su di essa ci sono delle scritte incomprensibili:");
                        Console.WriteLine("מי שקורא הוא טיפש");
                        break;
                    case 3:
                        Console.WriteLine("Ti ritrovi in una stanza familiare. Sembra essere un'ufficio con enormi vetrate di un grattacielo altissimo.");
                        Console.WriteLine("Prestando maggiore attenzione ti rendi conto che le vetrate sono solo dipinte sulle pareti.");
                        break;
                    case 4:
                        Console.WriteLine("Ti ritrovi in un luogo familiare. Sembra essere la cima di un colle durante la notte. Si vede il cielo stellato");
                        Console.WriteLine("e una bellissima luna piena. Noti ad un certo punto una stella cadente.");
                        Console.WriteLine("Senti come se ci dovrebbe essere anche qualcun'altro lì con te.");
                        Console.WriteLine("Prestando maggiore attenzione ti rendi conto che è tutto dipinto sulle pareti di cemento della stanza.");
                        Console.WriteLine("Quella stella cadente sarà stata solo la tua immaginazione.");
                        break;
                    case 5:
                        Console.WriteLine("Ti sembra di trovarti nello spazio profondo. Tutto intorno a te è nero, tranne le stelle, i pianeti e le galassie in lontananza.");
                        Console.WriteLine("Senti una forte emozione, che non sentivi da parecchio tempo.");
                        Console.WriteLine("Ti rendi conto però delle porte ai lati della stanza. Sei in una stanza dipinta di nero e cosparsa di lampadine per simulare le stelle.");
                        break;
                    case 6:
                        Console.WriteLine("Ti ritrovi in una palestra, un luogo a te poco familiare. Senti di non voler stare troppo in quel luogo.");
                        break;
                    case 7:
                        Console.WriteLine("Ti ritrovi nel luogo da cui sei partito. L'angelo che ti ha salvato la vita si trova ancora lì dove lo hai lasciato, ferito.");
                        break;
                    case 8:
                        Console.WriteLine("Ti ritrovi in una camera da letto estremamente familiare. Senti un forte senso di nostalgia nel guardare il letto matrimoniale al centro della stanza.");
                        Console.WriteLine("All'improvviso un forte senso di colpa ti pervade. Vuoi uscire di lì il prima possibile.");
                        break;
                    case 9:
                        Console.WriteLine("Ti ritrovi in una stanza piena di libri. Sembra essere una biblioteca. Senti come se fossi stato lì tutta una vita.");
                        break;
                    case 10:
                        Console.WriteLine("Ti ritrovi in una stanza completamente ricoperta di monete dorate. Senti come se ti appartenessero.");
                        break;
                    case 11:
                        Console.WriteLine("Ti ritrovi in una stanza d'ospedale. Vorresti ci fosse qualcun'altro lì con te");
                        break;


                }
                   
            }
            else if(this.filled>10 && this.filled<=20)
            {
                Console.WriteLine("Un'odore acre invade le tue narici, non riesci a notare altro oltre la pozza di un liquido ambrato che lambisce le caviglie.");
            }
            else if(this.filled>20 && this.filled<30)
            {
                Console.WriteLine("Un'intenso odore di urina permea completamente il tuo olfatto. Non riesci a notare nient'altro che il lago tiepido che ti bagna fino al bacino");
            }
            else if(this.filled>=30)
            {
                Console.WriteLine("Stranamente riesci ad entrare nella stanza, sembra quasi che le porte quì non funzionano seguendo le leggi della fisica. Sarebbe strano il contrario dato che la stanza in cui ti trovi è talmente piena di urina che l'unico modo che hai per muoverti nella stanza è nuotando.");

            }
        }
    }
}
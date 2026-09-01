using log4net;
using System.Reflection;
using System.Configuration;
using System.Timers;
using System.Text.Json;

namespace Belphagor;

//parlato con angelo
class GameManager
{
    public static void PrintSpace()
    {
        Console.WriteLine(); 
        Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        Console.WriteLine(); 
    }

    public static void Tutorial(Ronen ronen, Demon invidia)
    {
        Console.WriteLine("Ti trovi in una stanza vuota che non riconosci, le 4 pareti che ti circondano hanno ciascuna una porta di legno parecchio antiquata. Pensandoci meglio non riesci a ricordare molto del tuo passato, solo vaghe sensazioni.");
        Console.WriteLine("Senti un rumore dietro di te. Ti volti ed un'enorme' creatura melmosa ti aggredisce.");
        Console.WriteLine("Però, prima ancora che riesca a colpirti un tremore scuote l'intera stanza, parte del soffitto crolla e dal piano di sopra arriva una luce così accecante da farti perdere i sensi.");
        
        
        Console.ReadLine();   
        Console.WriteLine("??? <<-nen>>");
        
        Console.ReadLine();   
        Console.WriteLine("??? <<Ronen>>");

        Console.ReadLine();   
        Console.WriteLine("??? <<RONEN!>>");

        Console.WriteLine("Ti risvegli e vedi la bestia che ti stava aggredendo combattere una figura angelica apprentemente intenzionata a difenderti.");
        Console.WriteLine("I due combattono per parecchio tempo, fino a quando l'angelo non viene colpito. A quel punto il mostro perde completamente l'attenzione dal suo avversario e si dirige verso di te.");
        Console.WriteLine("ANGELO <<Anche se non sembra, l'ho parecchio indebolito. Potresti sconfiggerlo tu stesso da solo. Combattilo e ti salverai!>>");
        Console.ReadLine();   

        invidia.CombatMenu(ronen,invidia);
        Console.WriteLine("Il corpo melmoso di fronte a te si dissolve, lasciando solo uno strano oggetto dall'aspetto organico, ma dai colori troppo strani per provenire da un'animale.");


        Console.WriteLine("ANGELO <<Sei riuscito a sconfiggerlo, fantastico! Per fuggire da questo luogo dovrai battere il demone che risiede a Sud, nella sala del Regno. Sfortunatamente la ferita che ho ricevuto è troppo grave e non posso aiutarti attivamente ad uscire di quì, ma posso darti i mezzi per riuscire tu stesso. Prima però raccogli da terra quell'oggetto lasciato da Invidia. Se me lo dai posso forgiarlo in un'oggetto sacro che può aiutarti a fronteggiare gli altri demoni quì dentro. Inoltre posso guarirti dalle ferite che riceverai nei tuoi combattimenti dandoti una Bottiglia di Acqua Santa, che riempirò ogni volta che verrai a guarirti se necessario e posso salvare la tua anima, creando quindi una sorta di check point da cui partire ogni volta che verrai sconfitto.>>");

        //Console.WriteLine("fine tutorial");
        Console.ReadLine();
        ronen.isTutorial=false;
    }
}

using System.Text.Json;
using Newtonsoft.Json;

namespace Belphagor
{
    public class Angel : Entity
    {
        
        public bool saving {set; get;}
        public Angel(string Name, int Life,int maxLife, int Attack,Room Room) : base(Name, Life, maxLife, Attack, Room)
        {

        }

        
        public void WaterFill(Ronen ronen)
        {
             Console.WriteLine("ANGELO: <<Ecco a te una boccetta dell'Acqua Santa, bevendola verrai curato da ogni male, quando l'avrai bevuta torna da me e te ne darò un'altra.>>");
            
            ronen.life = Program.ronen.maxLife;
            AcquaSanta acquasanta = new AcquaSanta();
            if (ronen.bagItem.Any(item=> item.id==acquasanta.id))
            {
                
                int acquaCount=0;
                int bagCount=ronen.bagItem.Count;
                for(int count=0; count<bagCount;count++)
                {
                    if (ronen.bagItem[count].id==acquasanta.id)
                    {
                        ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==acquasanta.id));
                        acquaCount++;
                        bagCount=ronen.bagItem.Count;
                        count--;

                    }
                    
                    

                }
                while(acquaCount>0)
                {
                    ronen.bagItem.Add(acquasanta);
                    acquaCount--;
                }
                
                
            }
            else
            {
                ronen.bagItem.Add(acquasanta);
            }
            Program.log.Info("Angel refilled holy water");
        }
/// <summary>
/// Se Ronen ha nella sua borsa un Materiale Demoniaco potrà essere usato per forgiare un item. L'item forgiato dipende da quanti item sono stati forgiati precedentemente e raggiungono un massimo di 7.
/// </summary>
/// <param name="ronen"></param>
        public void Forge(Ronen ronen)
        {
            Item materialeDemoniaco= new Item();
            materialeDemoniaco.MaterialeDemoniaco();
            if (ronen.bagItem.Any(item=> item.id==materialeDemoniaco.id))
            {
                Program.log.Info("Angel forging");
                switch(ronen.forgedItems)
                {
                    case 0: 
                    Console.WriteLine("ANGELO: <<Ecco a te l'Arma Sacra, in grado di tagliare ogni materiale: EXCALIBUR.>>");
                    Console.WriteLine($"Excalibur aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item Excalibur = new Item();
                     Excalibur.Excalibur();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(Excalibur);
                     ronen.forgedItems++;
                     Program.log.Info("Excalibur forged");
                     break;
                    case 1: 
                    Console.WriteLine("ANGELO: <<Ecco a te l'Elmo Sacro, in grado di resistere a colpi letali. Apparteneva ad un certo Sommo che brillava di luce propria.>>");
                    Console.WriteLine($"Elmo Sacro aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item ElmoSacro = new Item();
                     ElmoSacro.ElmoSacro();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(ElmoSacro);
                     ronen.forgedItems++;
                     Program.log.Info("Elmo sacro forged");
                     break;
                    case 2: 
                    Console.WriteLine("ANGELO: <<Ecco a te le scarpe in grado di reggere ogni peso: gli Stivali Angelici, usati da noi angeli per effettuare commissioni per l'altissimo.>>");
                    Console.WriteLine($"Stivali Angelici aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item StivaliAngelici = new Item();
                     StivaliAngelici.StivaliAngelici();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(StivaliAngelici);
                     ronen.forgedItems++;
                     Program.log.Info("Stivali angelici forged");
                     break;
                    case 3: 
                    Console.WriteLine("ANGELO: <<Ecco a te i Bracciali di Castità che ti terranno lontano da ogni peccato.>>");
                    Console.WriteLine($"Breacciali di Castità aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item BraccialeDiCastita = new Item();
                     BraccialeDiCastita.BraccialeDiCastita();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(BraccialeDiCastita);
                     ronen.forgedItems++;
                     Program.log.Info("Bracciale di castità forged");
                     break;
                    case 4: 
                    Console.WriteLine("ANGELO: <<Ecco a te lo Scudo Celestiale, in grado di proteggerti da ogni colpo.>>");
                    Console.WriteLine($"Scudo Celestiale aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item ScudoCelestiale = new Item();
                     ScudoCelestiale.ScudoCelestiale();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(ScudoCelestiale);
                     ronen.forgedItems++;
                     Program.log.Info("Scudo celestiale forged");
                     break;
                    case 5: 
                    Console.WriteLine("ANGELO: <<Ecco a te un regalo dall'altissimo. Un Miracolo Tascabile, utilizzabile più volte, ma limitato ad un uso ogni tanto. Non sarebbe giusto darti un'arma troppo potente.>>");
                    Console.WriteLine($"Miracolo Tascabile aggiunto alla Borsa!");
                     MiracoloTascabile miracoloTascabile = new MiracoloTascabile();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(miracoloTascabile);
                     ronen.forgedItems++;
                     Program.log.Info("Miracle forged");
                     break;
                    case 6: 
                    Console.WriteLine("ANGELO: <<E quindi li hai sconfitti tutti... Bene. Ecco a te il tuo ultimo aiuto. L'Armatura Divina, con questa non solo sarai al sicuro, ma riuscirai ad entrare nell'ultima stanza.>>");
                    Console.WriteLine($"Armatura Sacra aggiunto alla Borsa! Per Equipaggiarlo vai nella borsa e Usalo!");
                     Item ArmaturaDivina = new Item();
                     ArmaturaDivina.ArmaturaDivina();
                     ronen.bagItem.Remove(ronen.bagItem.Find(item => item.id==materialeDemoniaco.id));
                     ronen.bagItem.Add(ArmaturaDivina);
                     ronen.forgedItems++;
                     Program.log.Info("Armatura divina forged");
                     break;
                    case 7: 
                    Console.WriteLine("ANGELO: <<Suppongo tu sia riuscito a sconfiggere Belphagor. Allora che ci fai ancora qui?>>");
                     Program.log.Info("All items already forged");
                     break;
                    default: 
                    Console.WriteLine("ANGELO: <<Come hai fatto? non ci dovrebbero essere altri demoni qui dentro...>>");
                     Program.log.Info("Materiale demoniaco exceeded limit");
                    break;
                        


                }

            }
            

        }

        public override void Talk()
        {
            Random rnd = new Random();
            string[] dialog = new string[3];

            dialog[0] = "ANGELO: <<Il tuo obiettivo è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.>>";

            dialog[1] = "ANGELO: <<Questo sarebbe un luogo veramente triste per terminare la propria esistenza. Perfavore Ronen, salvati!>>";
            dialog[2] = "ANGELO: <<La ferita fa male, ma non preoccuparti per me>>";

            int index = rnd.Next(0, dialog.Length);
            Console.WriteLine(dialog[index]);
            Program.log.Info("Angel talk");
        }
        
/// <summary>
/// Il menu di interazione dell'Angelo permette di curare Ronen, forgiare Items o parlare con l'Angelo
/// </summary>
        public void AngelMenu(Ronen ronen)
        {
            Program.log.Info("Angel menu");
            bool validInput = true;
            while(validInput)
            {
                Console.WriteLine("============");
                Console.WriteLine(" 1) Cura");
                Console.WriteLine(" 2) Forgia");
                Console.WriteLine(" 3) Parla");
                Console.WriteLine(" 4) Salva");
                Console.WriteLine(" 5) Esci");
                Console.WriteLine("============");
                string input = Console.ReadLine();
                GameManager.PrintSpace();

                switch(input)
                {
                case "1": WaterFill(Program.ronen);
                    break;

                case "2": Forge(Program.ronen);
                    break;

                case "3": Talk();
                    break;
                case "4": Save();
                    break;                    
                case "5": 
                    ronen.isFighting = false;
                    validInput = false;
                    break;
                case "H":
                    Console.WriteLine($"L'obiettivo del gioco è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.");
                    break;
                case "h":
                    Console.WriteLine($"L'obiettivo del gioco è escire da questo luogo. Per farlo dovrai sconfiggere il Demone che si trova ad estremo sud, ma per raggiungerlo devi uccidere tutti gli altri demoni minori che si trovano quì dentro, raccogliere i Frammenti Demoniaci che rilasciano quando sconfitti e farli forgiare dall'Angelo. Così facendo potrai accedere alla sala del Regno e salvare la tua anim- ehm volevo dire uscire di quì.");
                    break;

                default: Console.WriteLine("");                    
                    break;
                }

                

            }

        }

        public Ronen LoadRonen(Ronen ronen)
        {
            string ronenFileName = "RonenData.json";
            string ronenGesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{ronenFileName}");
            Console.WriteLine(ronenGesturefile);
            if (File.Exists(ronenGesturefile))
            {
                //RonenData loadData = new RonenData();
                
                //loadData.prot=JsonConvert.DeserializeObject<Ronen>(File.ReadAllText(ronenGesturefile));

                using (StreamReader file = File.OpenText(ronenGesturefile))
                {
                    string jsonString = File.ReadAllText(ronenGesturefile);
                    RonenData loadData = System.Text.Json.JsonSerializer.Deserialize<RonenData>(jsonString)!;
                    Console.WriteLine(loadData.prot.turn);
                    return loadData.prot;
                }
                
                
                
                
            }
            return ronen;

        }

        public Gamemap LoadMap(Gamemap gamemap)
        {
            string fileName = "SaveData.json";
            string gesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{fileName}");
            Console.WriteLine(gesturefile);
            if (File.Exists(gesturefile))
            {
                
                
                
                string jsonString = File.ReadAllText(gesturefile);
                SaveData loadData = System.Text.Json.JsonSerializer.Deserialize<SaveData>(jsonString)!;
                
                return loadData.data;



            }
            return gamemap;

        }

        public void Load(Ronen ronen, Gamemap gamemap)
        {
            string fileName = "SaveData.json";
            string gesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{fileName}");
            Console.WriteLine(gesturefile);
            if (File.Exists(gesturefile))
            {
                
                
                
                string jsonString = File.ReadAllText(gesturefile);
                SaveData loadData = System.Text.Json.JsonSerializer.Deserialize<SaveData>(jsonString)!;
                
                gamemap=loadData.data;



            }

            string ronenFileName = "RonenData.json";
            string ronenGesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{ronenFileName}");
            Console.WriteLine(ronenGesturefile);
            if (File.Exists(ronenGesturefile))
            {
                //RonenData loadData = new RonenData();
                
                //loadData.prot=JsonConvert.DeserializeObject<Ronen>(File.ReadAllText(ronenGesturefile));

                using (StreamReader file = File.OpenText(ronenGesturefile))
                {
                    string jsonString = File.ReadAllText(ronenGesturefile);
                    RonenData loadData = System.Text.Json.JsonSerializer.Deserialize<RonenData>(jsonString)!;
                    
                    ronen=loadData.prot;
                }
                
                
                
                Console.WriteLine(ronen.turn);
            }
        }

        private void Save()
        {
            Console.WriteLine("Procedo a salvare la tua anima...");
            this.saving=true;
            string fileName = "SaveData.json";
            string ronenFileName = "RonenData.json";
            
            Save(fileName,ronenFileName,Program.ronen,Program.gamemap);
            Console.WriteLine("Partita Salvata");
            saving=false;
        }

        public static void Save(string fileName,string ronenFileName, Ronen ronen, Gamemap gamemap)
        {

            SaveData saveData = new SaveData()
            {
                
                data=gamemap

            };

            RonenData ronendata = new RonenData()
            {
                prot=ronen,
            };
            string gesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{fileName}");
            string ronenGesturefile= Path.Combine(Environment.CurrentDirectory + $@"\{ronenFileName}");

            //Console.WriteLine(gesturefile);
            
            if (!File.Exists(gesturefile))
            {
                using (File.Create(gesturefile))
                {
                File.SetAttributes(gesturefile, 
                        (new FileInfo(gesturefile)).Attributes | FileAttributes.Normal);
                

                }
            }

            var option = new JsonSerializerOptions
            {
                WriteIndented =true,
                MaxDepth = 0,
                IncludeFields=true,
                ReferenceHandler=System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            string jsonString = System.Text.Json.JsonSerializer.Serialize(saveData,option);
                               
            
            File.WriteAllText(gesturefile, jsonString);

            //Console.WriteLine(ronenGesturefile);

            if (!File.Exists(ronenGesturefile))
            {
                using (File.Create(ronenGesturefile))
                {
                File.SetAttributes(ronenGesturefile, 
                        (new FileInfo(ronenGesturefile)).Attributes | FileAttributes.Normal);
                

                }
            }

            var ronenOption = new JsonSerializerOptions
            {
                WriteIndented =true,
                MaxDepth = 0,
                IncludeFields=true,
                ReferenceHandler=System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };

            string ronenJsonString = System.Text.Json.JsonSerializer.Serialize(ronendata,ronenOption);
                               
            
            File.WriteAllText(ronenGesturefile, ronenJsonString);

            
        
        

    }
    
    }
    public class SaveData
    {
        
        public Gamemap data {get;set;}

    }

    public class RonenData 
    {
        public Ronen? prot {get;set;}

    }

}

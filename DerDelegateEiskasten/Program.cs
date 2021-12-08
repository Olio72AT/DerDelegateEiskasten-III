using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DerDelegateEiskasten
{
    class Program
    {
        private static bool endThread = false;

        private static Einbaurahmen<Kuehli, Kuehli> Rahmen;
     

        static void Main(string[] args)
        {
            ConsoleKeyInfo input; 
            do
            {
                Console.Clear();
                Extensionmethodes.Ausgabe("**************************************************");
                Extensionmethodes.Ausgabe("*             DerDelegateEiskasten!              *");
                Extensionmethodes.Ausgabe("**************************************************");
                Extensionmethodes.Ausgabe("Choose one of the following options:  ");
                Extensionmethodes.Ausgabe("-->  F3     Testing Mode  ");
                Extensionmethodes.Ausgabe("-->  F4     Operating Mode  ");
                Extensionmethodes.Ausgabe("-->  F5     Modultest Mode  ");
                input = Console.ReadKey();
            } while (input.Key != ConsoleKey.F3 && input.Key != ConsoleKey.F4 && input.Key != ConsoleKey.F5);

            if (input.Key == ConsoleKey.F3)
                MainTest(args);
            else if ((input.Key == ConsoleKey.F4))
                MainOperating(args);
            else
                Modultest(args);

            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("*                  Bye, bye ...                  *");
            Extensionmethodes.Ausgabe("**************************************************");
        }

        private static void Modultest (string[] args)
        {
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");

// Datenbank gefüllt mit Hersteller, Anschrift und Produktgruppen. 

            Datenbank.FillIt();

// A) Bauen Sie 1 Einbauschrank mit 1 Kuehl- und 1 Gefrierschrank                   (5 Punkte)
//          1) Kuehlschrank oben mit dem Namen: "Der Modultest Kühlschrank"         (15 Minuten)
//                  Type: Kuehli
//          2) Microwelle unten mit dem Namen "Der Microwellen Herd mit Kuehlfunktion" 
//                  Type: KuehliKuehliFuerLagerProdukte 
//                  ArtEiskasten.Microwelle
            
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");

            Kuehli kuehli = new Kuehli
                ("Der Modultest Kühlschrank", ArtEiskasten.Kuehltruhe);

            KuehliFuerLagerProdukte gfrieri = new KuehliFuerLagerProdukte
                ("Der Microwellen Herd mit Kuehlfunktion", ArtEiskasten.Microwellenherd);

            Einbaurahmen<Kuehli, KuehliFuerLagerProdukte> ikaeKastel =
                new Einbaurahmen<Kuehli, KuehliFuerLagerProdukte>(kuehli, gfrieri, kuehli.name, gfrieri.name);

            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");

// B) Befüllen Sie jeweils 3 "Produkte" in den Kühlschrank bzw. in den Microwellenherd (5 Punkte)
//                                                                                     (10 Minuten)

            ikaeKastel.Oberschrank.Einschalten();
            ikaeKastel.Unterschrank.Einschalten();

            ikaeKastel.Oberschrank.EtwasReinlegen(new Produkt(1425, "Apfel Rot"));
            ikaeKastel.Oberschrank.EtwasReinlegen(new Produkt(3344, "Apfel Grün"));
            ikaeKastel.Oberschrank.EtwasReinlegen(new Produkt(4644, "Apfel Gelb"));

            ikaeKastel.Unterschrank.EtwasReinlegen(new LagerProdukt(1, 5425, "Stange Salami", 2, 2));
            ikaeKastel.Unterschrank.EtwasReinlegen(new LagerProdukt(2, 5233, "Salzstiegl Bier", 4, 1));
            ikaeKastel.Unterschrank.EtwasReinlegen(new LagerProdukt(3, 5938, "Joghurt", 6, 3));

// C)   Wie konzentrieren uns jetzt auf den KuehliFuerLagerProdukte.
//      Zeigen Sie alle LagerProdukte mit ZeigeAlleProdukte an.
//      Wie sie sehen können, werden Produkte wie folgt angezeigt: 
//      
//      Das Produkt: Code: 5425 - Name: 2 Stange Salami

            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");

            // ikaeKastel.Unterschrank.ZeigeAlleProdukte();


//                                                                              (3 Punkte - 10 Minuten)
//  D)  Erweitern Sie die Ausgabe, dass in der Ausgabe auch der Herstellername angezeigt wird:
//      Das Produkt: Code: 5425 - Name: 2 Stange Salami - Hersteller: Wolf
// 
//      Benutzen Sie dazu die Lambda Expression: 
//      var hersteller = Datenbank.herstellerListe.Where(x => x.Id == this.HerstellerId).FirstOrDefault();
//      Geben Sie nun die LagerProdukte wieder mit ZeigeAlleProdukte aus. 
//      Entfernen Sie anschließend die obere Ausgabe, damit die Produkte nur einmal angezeigt werden. 

            ikaeKastel.Unterschrank.ZeigeAlleProdukte();





            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("*********** Press RETURN to run the devices ******");

            Console.Read();


            while (!Console.KeyAvailable)
            {
                Extensionmethodes.Ausgabe("");
                Extensionmethodes.Ausgabe("OperationLoop: Device is working ...! The temperatures are: ");
                
//  E)      TODO Aufgabenstellung ... 



                Extensionmethodes.Ausgabe(ikaeKastel.Oberschrank.GetActualTemperature());
                Extensionmethodes.Ausgabe(ikaeKastel.Unterschrank.GetActualTemperature());

                Thread.Sleep(1000);
            }

            Extensionmethodes.Ausgabe("Now shutdown all devices. ");
        }



        private static void MainOperating (string[] args)
        {
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");

            Datenbank.FillIt();

            // Lets go live! 

            // Wir wollen: 
            // A) 1 Einbauschrank mit 1 Kuehl- und 1 Gefrierschrank (5 Punkte) 

            KuehliFuerLagerProdukte kuehli = new KuehliFuerLagerProdukte 
                ("Der coole Kühlschrank!", ArtEiskasten.Kuehltruhe);
            
            Kuehli gfrieri = new Kuehli 
                ("Der geniale Gefrierschrank!", ArtEiskasten.Gefrierschrank);

            Einbaurahmen<KuehliFuerLagerProdukte, Kuehli> ikaeKastel = 
                new Einbaurahmen<KuehliFuerLagerProdukte, Kuehli>(kuehli, gfrieri, kuehli.name, gfrieri.name);



            // B) Wir haben eine neue Produktklasse "LagerProdukte", die sich von der Klasse Produkte ableitet: (8 Punkte)
            // Zu den Eigenschaften der Produkte kommen folgende Eigenschaften dazu ->
            //
            //      public int strichCodeNummer { get; } = 9999;                *** Bereits vorhanden 
            //      public string name { get; }          = "Kein Produkt";      *** Bereits vorhanden
            //      public int Id { get; }               = -1;                  *** Neu
            //      public int herstellerId { get; }     = -1;                  *** Neu 
            //      public int Stueck { get; }           = -1;                  *** Neu 

            // C) Legen Sie nun 6 LagerProdukte in den Kuehlschrank, sowie 6 normale Produkte in den Gefrierschrank ( 6 Punkte )
            // Beachten Sie Datenbank.cs und verwenden Sie eine existierende herstellerId. 
            ikaeKastel.Oberschrank.Einschalten();
            ikaeKastel.Unterschrank.Einschalten();

            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(1, 5425, "Stange Salami", 2, 2));
            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(2, 5233, "Salzstiegl Bier", 4, 1));
            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(3, 5938, "Joghurt", 6, 3));
            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(4, 5425, "Stange Salami", 2, 5));
            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(5, 8726, "Käse", 7, 1));
            ikaeKastel.Oberschrank.EtwasReinlegen(new LagerProdukt(6, 1425, "Apfel", 8, 2));

            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(1425, "Apfel Rot" ));
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(3344, "Apfel Grün"));
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(4644, "Apfel Gelb"));
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(3122, "Apfel kaputt"));
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(8726, "Käse"));
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(1425, "Mandarine"));

            ikaeKastel.Oberschrank.ZeigeAlleProdukte();
            ikaeKastel.Unterschrank.ZeigeAlleProdukte();


            // D) Die Id soll unique sein, ändern Sie also die Methode: kuehli -> public bool EtwasReinlegen(Produkt produkt)
            // id = liste.count() + 1; ( 4 Punkte ) 

            // Erledigt.

            // E) Was könnte daraufhin für ein Problem entstehen, wenn wir kuehli -> 
            //     public Produkt EtwasRausnehmen(int strichCode)
            // in Bezug auf Remove() entstehen? (In Zusammenhang mit Punkte D) )  

            // Erledigt.

            // -------

            // Lambda Expressions 



            // LINQ 

            // Geben Sie zusätzlich zu den Produkten in der Methode Kuehli -> ZeigeAlleProdukte()
            // 
            // a) FirmenNamen, GruendungsJahr, sowie den Ort sortiert nach PLZ ( 2 Punkte )  
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("Die Lager-Produkte inkl. Hersteller und Anschrift: ");

            // hier ---> 

            var prodInKuehlschrank = from p in ikaeKastel.Oberschrank.kuehlspeicher
                                     select new { name = p.name, herstellerId = p.HerstellerId };

            foreach (var p in prodInKuehlschrank)
            {

                var hersteller = from h in Datenbank.herstellerListe
                                 where p.herstellerId == h.Id
                                 select new { name = h.FirmenNamen, jahr = h.GruendungsJahr, 
                                     anschriftId = h.AnschriftId };




                foreach (var x in hersteller)
                    Extensionmethodes.Ausgabe(" " + x.name); // .... 

            }

            Extensionmethodes.Ausgabe("**************************************************");
            // b) Darunter die Liste aller Hersteller mit allen verfügbaren Feldern aus, inkl. der kompletten Anschrift. ( 2 Punkte ) 

            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("Liste aller verfügbaren Hersteller und Anschrift: ");

            // hier ---> 

            Extensionmethodes.Ausgabe("**************************************************");

            // c) Darunter alle PLZ einmalig und den Ort sortiert nach PLZ und dann nach Ort. ( 2 Punkte ) 
            
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("Verfügbarkeit aller Hersteller örtlich: ");

            // hier ---> 

            Extensionmethodes.Ausgabe("**************************************************");

            // d) Die Anzahl der Produkte, die sich im Einbauschrank in den jeweiligen Geräten befinden. ( 2 Punkte ) 
            
            Extensionmethodes.Ausgabe(" ");
            Extensionmethodes.Ausgabe("**************************************************");
            Extensionmethodes.Ausgabe("Im Einbauschrank befinden sich: " );

            // hier ---> 

            Extensionmethodes.Ausgabe("**************************************************");


            // Viel Spass



        }



        private static void MainTest (string[] args)
        {
            // Our TestCode so far ... ;) 


            DebugInfo.DebugListe.Add("Der generische Eiskasten Teil 1!");
            DebugInfo.Ausgabe();

            Produkt milki = new Produkt(1111, "Milch");

            Kuehli kuehli = new Kuehli("Der coole Kühlschrank!", ArtEiskasten.Kuehltruhe);
            kuehli.EtwasReinlegen(milki);
            kuehli.Einschalten();
            kuehli.EtwasReinlegen(milki);
            kuehli.EtwasReinlegen(new Produkt(1112, "Butter"));
            kuehli.EtwasReinlegen(new Produkt(1112, "Butter"));
            kuehli.EtwasReinlegen(new Produkt(1113, "Zwettler Bier"));
            kuehli.EtwasReinlegen(new Produkt(1114, "Edelweiss Stammbräu"));
            kuehli.EtwasReinlegen(new Produkt(2200, "Grünen Veltliner"));

            kuehli.ZeigeAlleProdukte();

            // Jetzt kommt die Kiste in den Einbauschrank

            Einbaurahmen<Kuehli> einbaurahmen = new Einbaurahmen<Kuehli>(kuehli, kuehli.name);

            einbaurahmen.Oberschrank.Ausschalten();

            DebugInfo.DebugListe.Add("-----------------------------------------------");
            DebugInfo.DebugListe.Add("Der generische Eiskasten Teil 2!");
            DebugInfo.Ausgabe();

            Kuehli gfrieri = new Kuehli("Der geniale Gefrierschrank!", ArtEiskasten.Gefrierschrank);

            Einbaurahmen<Kuehli, Kuehli> ikaeKastel = new Einbaurahmen<Kuehli, Kuehli>(kuehli, gfrieri,
                kuehli.name, gfrieri.name);

            Rahmen = ikaeKastel;

            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(1112, "Butter"));
            ikaeKastel.Oberschrank.Einschalten();
            ikaeKastel.Unterschrank.Einschalten();
            ikaeKastel.Unterschrank.EtwasReinlegen(new Produkt(1112, "Butter"));
            ikaeKastel.Oberschrank.EtwasRausnehmen(1112);

            ikaeKastel.Unterschrank.EtwasReinlegen(new GefrierProdukt(1300, "Wodka", -70f));

            ikaeKastel.Oberschrank.ZeigeAlleProdukte();
            ikaeKastel.Unterschrank.ZeigeAlleProdukte();

            // Console.ReadKey();
            // _____________________________________________________________________
            Thread t1 = new Thread(OperationLoop)
            {
                Name = "StateEvent Machine"
            };

            t1.Start();

            // Delegates: 

            // Der Delegat wird hier mal deklariert, aber noch nicht instanziert.
            DerDelegierteAuftragserteiler derDelegierteAuftragserteiler;

            // Nun instanzieren wir ihn und fügen die GEWÜNSCHTE Methode (Lambda Expression) hinzu.
            derDelegierteAuftragserteiler =
                new DerDelegierteAuftragserteiler(NachrichtenDienst.InformiereEiskasten);

            // Der Delegate führt nun aus. 
            derDelegierteAuftragserteiler(Auftrag.SagHallo);

            // Füge zusätzliche Methode hinzu 
            derDelegierteAuftragserteiler += NachrichtenDienst.SendeDelegiertenAuftragAnUser;

            // Schicke NOTAUS an alle zu Informierenden.
            derDelegierteAuftragserteiler(Auftrag.DrueckeNotAus);

            // Events:
            Events events = new Events();
            events.MainEventsTesting(events);

            // Register Listeners 
            events.eiskastenSteuerung += kuehli.OnEiskastenSteuerung;
            events.eiskastenSteuerung += gfrieri.OnEiskastenSteuerung;

            // Let's call the event
            events.CallEvent(Auftrag.ErhoeheTemperaturUmEinGrad); ;


            Console.ReadKey();

            // Nehme  Methode heraus 
            derDelegierteAuftragserteiler -= NachrichtenDienst.SendeDelegiertenAuftragAnUser;

            // Schicke NOTAUS an alle zu Informierenden.
            derDelegierteAuftragserteiler(Auftrag.Ausschalten);


            kuehli.Beep(2200);
            endThread = true;

            // Aufruf unserer Extensionmethod Ausgabe 
            kuehli.Ausgabe("This is the end, my friend!");

        }


        private static void OperationLoop(object obj)
        {
            while (!endThread)
            {
                Thread.Sleep(1000);
                DebugInfo.DebugListe.Add("OperationLoop: Device is working ...!");
                DebugInfo.Ausgabe();
            }
            DebugInfo.DebugListe.Add("OperationLoop: Device is shutdown / Stecker wurde gezogen ...!");
            DebugInfo.Ausgabe();

            
        }

        public static void NachrichtEmpfangenFuerEiskasten(Auftrag auftrag)
        {
            DebugInfo.DebugListe.Add("DEVICE has received an Auftrag: " + auftrag.ToString());
            DebugInfo.Ausgabe();

            // Jetzt würd ich gerne die Kuehli.InformMe aufrufen
            if (Rahmen != null)
            {
                Rahmen.Oberschrank.InformMe(auftrag);
                Rahmen.Unterschrank.InformMe(auftrag);
            }
        }

        public static void NachrichtEmpfangenFuerUser(Auftrag auftrag)
        {
            DebugInfo.DebugListe.Add("USER has received an Auftrag: " + auftrag.ToString());
            DebugInfo.Ausgabe();

        }
    }

   
}

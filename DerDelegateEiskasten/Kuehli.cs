using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DerDelegateEiskasten
{
    class Kuehli : IEiskasten<Produkt>
    {
        public ArtEiskasten art { get; }
        public string name { get; }
        private bool _eingeschaltet { get; set; } = false;

        private int temperature { get; set; } = 0;

        private int temperatureShouldHave = -5;
        
        
        public List<Produkt> kuehlspeicher { get; set; } = new List<Produkt>();


        // Wir brauchen einen Konstruktor, der uns sagt, was er zu leben braucht.
        public Kuehli (string name, ArtEiskasten artEiskasten)
        {
            art = artEiskasten;
            this.name = name;

            DebugInfo.DebugListe.Add("Kuehli neu instanziert als " + art.ToString());
            DebugInfo.Ausgabe();

            var randomNumber = new Random();
            temperature = randomNumber.Next(0, 20);
            
        }

        public string GetActualTemperature()
        {
            if (temperature > temperatureShouldHave)
                temperature -= 1;
            else if (temperature < temperatureShouldHave)
                temperature += 1;

            if (temperature < -30)
            {
                var returnstring = name + " **** I am dead ";
                Ausschalten();
                return returnstring;
            }

            return name + " " + temperature + " Celsius   (Soll) " + temperatureShouldHave + " Celcius";
        }

        public void Ausschalten()
        {
            if (_eingeschaltet)
            {
                DebugInfo.DebugListe.Add(art.ToString() + " wurde ausgeschaltet.");
                DebugInfo.Ausgabe();

            }
            else
            {
                DebugInfo.DebugListe.Add(art.ToString() + " wurde bereits ausgeschaltet.");
                DebugInfo.Ausgabe();

            }

            _eingeschaltet = false;
            Extensionmethodes.Beep(this,440);
        }

        public void Einschalten()
        {
            
            DebugInfo.DebugListe.Add(art.ToString() + " wurde eingeschaltet.");
            DebugInfo.Ausgabe();


            _eingeschaltet = true;
            Extensionmethodes.Beep(this, 1000);
        }

        public Produkt EtwasRausnehmen(int strichCode)
        {
            // Lambda Expression - Gib mir aus der Liste das erste Element zurück, dass passt.
            var elemToDelete = kuehlspeicher.Where(x => x.strichCodeNummer == strichCode).FirstOrDefault();
            // var elem2 = Kuehlspeicher.FirstOrDefault(x => x.StrichCodeNummer == strichCode);

            if (elemToDelete != null)
            {
                kuehlspeicher.Remove(elemToDelete);
                DebugInfo.DebugListe.Add(elemToDelete.name + " wurde entnommen.");

            } else
            {
                DebugInfo.DebugListe.Add("Produkt wurde im " + art + " nicht gefunden.");
            }

            DebugInfo.Ausgabe();
            
            return elemToDelete;
        }

        public bool EtwasReinlegen(Produkt produkt)
        {
            if (!_eingeschaltet)
            {
                DebugInfo.DebugListe.Add(produkt.name + " konnte nicht in '" + name.ToString() + 
                    "' gelegt werden, da er ausgeschaltet ist.");
                DebugInfo.Ausgabe();
                return false;
            }   
            kuehlspeicher.Add(produkt);

            DebugInfo.DebugListe.Add(produkt.name + " wurde in '" + name.ToString() + "' gelegt.");
            DebugInfo.Ausgabe();

            return true;
        }

        public void ZeigeAlleProdukte()
        {
            DebugInfo.DebugListe.Add("Inventar: Im " + art + " '" + name + "' befindet sich derzeit:");

            foreach (Produkt p in kuehlspeicher)
            {
                if (p is LagerProdukt l)
                {
                    this.Ausgabe(l.ToString());
                }
                else 
                    DebugInfo.DebugListe.Add("Das Produkt: " + p.name + " (" + p.strichCodeNummer + ")");
            }

            DebugInfo.Ausgabe();
        }

        public bool InformMe(Auftrag auftrag)
        {
            DebugInfo.DebugListe.Add("*****************Delegates***************");
            DebugInfo.DebugListe.Add("Nachricht empfangen an " + name + " Auftrag: " + auftrag);
            DebugInfo.Ausgabe();
            return true;
        }

        public bool OnEiskastenSteuerung (Auftrag auftrag)
        {
            DebugInfo.DebugListe.Add("*****************Events******************");
            DebugInfo.DebugListe.Add("Nachricht empfangen an " + name + " Auftrag: " + auftrag);
            DebugInfo.Ausgabe();

            return true;
        }
    }
}

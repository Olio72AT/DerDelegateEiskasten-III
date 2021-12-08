using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    public class Produkt : IProdukte
    {
        // *** Eigenschaften
        public int strichCodeNummer { get; } = 9999;
        public string name { get; } = "Kein Produkt";

        // *** Methoden
        public string GetName()
        {
            return name;
        }

        public int GetStrichCode()
        {
            return strichCodeNummer;
        }

        public Produkt (int code, string name)
        {
            this.strichCodeNummer = code;
            this.name = name;

            //DebugInfo.DebugListe.Add("Das Produkt " + this.Name + " wurde angelegt!");
            //DebugInfo.Ausgabe();

        }

        public override string ToString()
        {
            return "Code: " + strichCodeNummer + " - Name: " + name;
        }
    }


    public class GefrierProdukt : Produkt 
    {
        // *** Eigenschaften 
        private float gefrierpunkt { get; }
        
        // *** Methoden
        public GefrierProdukt(int code, string name, float gefrierpunkt) : base (code, name)
        {
            this.gefrierpunkt = gefrierpunkt;
        }

        public float GetGefrierpunkt()
        {
            return this.gefrierpunkt;
           
        }

    }

    public class LagerProdukt : Produkt
    {
        public int Id { get; set; } = -1;
        public int HerstellerId { get; } = -1;

        public int Stueck { get; } = -1;

        public LagerProdukt (int id, int code, string name, int herstellerId, int stueck) : base ( code, name )
        {
            this.Id = id;
            this.HerstellerId = herstellerId;
            this.Stueck = stueck;

        }

        
        public override string ToString()
        {
            return "Code: " + strichCodeNummer + " - Name: " + Stueck + " " + name; 
        }
    }

}

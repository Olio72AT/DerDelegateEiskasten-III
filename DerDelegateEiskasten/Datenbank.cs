using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    public static class Datenbank
    {
        // Unsere Datenbank an Herstellern, deren Anschrift und dessen Marketing Kategorien
        public static List<Hersteller> herstellerListe = new List<Hersteller>();
        public static List<Anschrift> anschriftListe = new List<Anschrift>();
        public static List<Prioritaet> prioritaetenListe = new List<Prioritaet>();

        public static void FillIt()
        {
            anschriftListe.Add(new Anschrift() { Id = 1, Ort = "Wien", PLZ = 1553, Strasse = "Wienerstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 2, Ort = "Wien", PLZ = 1553, Strasse = "Sackstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 3, Ort = "Salzburg", PLZ = 8512, Strasse = "Ostbahngasse" });
            anschriftListe.Add(new Anschrift() { Id = 4, Ort = "Krems", PLZ = 3234, Strasse = "Kremserstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 5, Ort = "Linz", PLZ = 1234, Strasse = "Donnerstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 6, Ort = "Lunz", PLZ = 7353, Strasse = "Wolfgangstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 7, Ort = "Prach", PLZ = 4353, Strasse = "Hauseck" });
            anschriftListe.Add(new Anschrift() { Id = 8, Ort = "Offendorf", PLZ = 1234, Strasse = "Bahnstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 9, Ort = "Zins", PLZ = 1554, Strasse = "Wienerstrasse" });
            anschriftListe.Add(new Anschrift() { Id = 10, Ort = "Lunz", PLZ = 7354, Strasse = "Ganzweg" });

            herstellerListe.Add(new Hersteller() { Id = 1, AnschriftId = 1, FirmenNamen = "Reiss", GruendungsJahr = 1972, ReferenzNummer = 1323 });
            herstellerListe.Add(new Hersteller() { Id = 2, AnschriftId = 2, FirmenNamen = "Wolf", GruendungsJahr = 1980, ReferenzNummer = 2234 });
            herstellerListe.Add(new Hersteller() { Id = 3, AnschriftId = 1, FirmenNamen = "Bruder Reiss", GruendungsJahr = 1972, ReferenzNummer = 25234, Kat = Kategorie.B });
            herstellerListe.Add(new Hersteller() { Id = 4, AnschriftId = 4, FirmenNamen = "Stanislav", GruendungsJahr = 2010, ReferenzNummer = 2644 });
            herstellerListe.Add(new Hersteller() { Id = 5, AnschriftId = 5, FirmenNamen = "Grunz", GruendungsJahr = 1923, ReferenzNummer = 2555 });
            herstellerListe.Add(new Hersteller() { Id = 6, AnschriftId = 6, FirmenNamen = "Wassermann", GruendungsJahr = 1990, ReferenzNummer = 2234 });
            herstellerListe.Add(new Hersteller() { Id = 7, AnschriftId = 7, FirmenNamen = "ABGT", GruendungsJahr = 1998, ReferenzNummer = 22455 , Kat = Kategorie.B });
            herstellerListe.Add(new Hersteller() { Id = 8, AnschriftId = 8, FirmenNamen = "Walther BBK", GruendungsJahr = 2021, ReferenzNummer = 134, Kat = Kategorie.B });
            herstellerListe.Add(new Hersteller() { Id = 9, AnschriftId = 9, FirmenNamen = "Bild und Ton", GruendungsJahr = 1920, ReferenzNummer = 4 });
            herstellerListe.Add(new Hersteller() { Id = 10, AnschriftId = 10, FirmenNamen = "Rothahn", GruendungsJahr = 1876, ReferenzNummer = 22332 });

            prioritaetenListe.Add(new Prioritaet() { Id = prioritaetenListe.Count + 1, Kat = Kategorie.A, MarketingMassnahmen = "Essen gehen" });
            prioritaetenListe.Add(new Prioritaet() { Id = prioritaetenListe.Count + 1, Kat = Kategorie.B, MarketingMassnahmen = "Postwurfsendung" });

        }
    } 

    public class Hersteller
    {
        public int Id { get; set; }
        public int ReferenzNummer { get; set; }
        public string FirmenNamen { get; set; }
        public int GruendungsJahr { get; set; }

        public Kategorie Kat { get; set; } = Kategorie.A;
        public int AnschriftId { get; set; }

        
    }

    public enum Kategorie
    {
        A,B
    }

    public class Anschrift {

        public int Id { get; set; }
        public string Strasse { get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; }

        

    }

    public class Prioritaet
    {
        public int Id { get; set; }
        public Kategorie Kat { get; set; }
        public string MarketingMassnahmen { get; set; }
    }
}

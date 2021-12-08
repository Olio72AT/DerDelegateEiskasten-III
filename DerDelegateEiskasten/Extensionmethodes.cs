using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    static class Extensionmethodes
    {
        public static void Beep(this Kuehli kiste, int frequency)
        {
            DebugInfo.DebugListe.Add("Ein kurzer Beep aus den Extensionmethodes :) ");
            Console.Beep(frequency, 500);
        }

        public static void Beep(this KuehliFuerLagerProdukte kiste, int frequency)
        {
            DebugInfo.DebugListe.Add("Ein kurzer Beep aus den Extensionmethodes :) ");
            Console.Beep(frequency, 500);
        }

        // Kann nicht auf statische Klassen angewandt werden ... DebugInfo ist eine static class

        //public static void Ausgabe(this DebugInfo, string text)
        //{

        //}

        public static void Ausgabe(this Kuehli kuehli, string text)
        {
            DebugInfo.DebugListe.Add(text);
            DebugInfo.Ausgabe();
        }


        // Keine ExtensionMethod - da kein this .... dennoch über Extensionmethodes.Ausgabe verwendbar.
        public static void Ausgabe(string text)
        {
            DebugInfo.DebugListe.Add(text);
            DebugInfo.Ausgabe();
        }

    }
}

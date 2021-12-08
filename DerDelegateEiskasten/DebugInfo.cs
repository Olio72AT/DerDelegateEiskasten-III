using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DerDelegateEiskasten
{
    public static class DebugInfo
    {
        public static List<string> DebugListe = new List<string>();
        public static void Ausgabe()
        {
            if (DebugListe.Count > 0)
            {
                foreach (string line in DebugListe)
                {
                    Debug.WriteLine("*** " + DateTime.Now + " " + line);
                    Console.WriteLine("*** " + DateTime.Now + " " + line);

                }

                DebugListe.Clear();

            }

        }

    }
}

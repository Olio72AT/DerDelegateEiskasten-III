using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    class Einbaurahmen<T>
    {
        // Eigenschaften 
        public T Oberschrank { get; }
        private string _name { get; }

        // Methoden
        public Einbaurahmen (T kiste, string name)
        {
            Oberschrank = kiste;
            this._name = name;
            _name = name;

            DebugInfo.DebugListe.Add(kiste.ToString() + " '" + name 
                + "' wurde in Einbaurahmen eingebaut.");
            DebugInfo.Ausgabe();
        
        }

        public override string ToString()
        {
            return "Inventar: Im Einbaurahmen befindet sich " + Oberschrank.ToString()
                + " '" + _name + "'";
        }

    }

    class Einbaurahmen<T,U>
    {
        // Eigenschaften 
        public T Oberschrank { get; }
        public U Unterschrank { get; }


        private string _nameOberschrank { get; }
        private string _nameUnterschrank { get; }


        // Methoden
        public Einbaurahmen(T oberschrank, U unterschrank, string nameober, string nameunter)
        {
            Oberschrank = oberschrank;
            Unterschrank = unterschrank;
            this._nameOberschrank = nameober;
            this._nameUnterschrank = nameunter;

            DebugInfo.DebugListe.Add(this.ToString());
            DebugInfo.DebugListe.Add(oberschrank.ToString() + " '" + nameober + " oben und" );
            DebugInfo.DebugListe.Add(unterschrank.ToString() + " '" + nameunter + " unten im Schrank");

            DebugInfo.Ausgabe();

        }

        public override string ToString()
        {
            return "Inventar: Im Einbaurahmen befinden sich '" + _nameOberschrank
                + "' und '" + _nameUnterschrank + "'";
                
        }

    }
}

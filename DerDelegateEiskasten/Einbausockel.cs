using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    class Einbausockel<T>
    {
        // Eigenschaften 
        public T Einbaurahmen { get; }
        private string _name { get; }

        // Methoden
        public Einbausockel(T kiste, string name)
        {
            Einbaurahmen = kiste;
            this._name = name;
            _name = name;

            DebugInfo.DebugListe.Add(kiste.ToString() + " '" + name
                + "' steht nun unter Einbaurahmen.");
            DebugInfo.Ausgabe();

        }

        public override string ToString()
        {
            return "Inventar: Am Sockel befindet sich " + Einbaurahmen.ToString()
                + " '" + _name + "'";
        }

    }
}

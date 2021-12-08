using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    public interface IEiskasten<T> where T : class
    {
        // Eigenschaften
        ArtEiskasten art { get; }
        string name { get; }

        bool eingeschaltet { get { return false; } }

        List<T> kuehlspeicher { get; set; }


        // Methoden
        public void Einschalten();
        public void Ausschalten();

        public bool EtwasReinlegen(T produkt);
        public T EtwasRausnehmen(int strichCode);

        public void ZeigeAlleProdukte();
    }


    public enum ArtEiskasten
    {
        Kuehltruhe, Gefrierschrank, Microwellenherd
    }
}

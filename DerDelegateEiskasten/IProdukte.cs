using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    interface IProdukte
    {   
        // Eigenschaften 
        public int strichCodeNummer { get; }
        public string name { get; }

        // Methoden
        public int GetStrichCode();

        public string GetName();

        public string ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

// Die Idee hinter Events ... .NET Events lernen wir noch - später ...

namespace DerDelegateEiskasten
{
    public delegate bool EiskastenSteuerungsEventHandler(Auftrag auftrag);
    public class Events
    {
        public event EiskastenSteuerungsEventHandler eiskastenSteuerung;
    
        public bool MainEventsTesting (Events events)
        {
            UnabhangigeEmpfangsklasse test = new UnabhangigeEmpfangsklasse();

            events.eiskastenSteuerung += test.OnEiskastenSteuerung;

            eiskastenSteuerung(Auftrag.SagHallo);

            return true;
        }

        public bool OnEiskastenSteuerung(Auftrag meinAuftrag)
        {
            DebugInfo.DebugListe.Add("****************** Events *************");
            DebugInfo.DebugListe.Add("UnabhängigeEmpfangsklasse hat nun Auftrag erhalten: "
                + meinAuftrag.ToString());
            DebugInfo.Ausgabe();
            return true;
        }

        public bool CallEvent (Auftrag meinAuftrag)
        {
            eiskastenSteuerung(meinAuftrag);
            
            return true;
        }
    }


    class UnabhangigeEmpfangsklasse
    {
        public bool OnEiskastenSteuerung (Auftrag meinAuftrag)
        {
            DebugInfo.DebugListe.Add("****************** Events *************");
            DebugInfo.DebugListe.Add("UnabhängigeEmpfangsklasse hat nun Auftrag erhalten: " 
                + meinAuftrag.ToString());
            DebugInfo.Ausgabe();
            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DerDelegateEiskasten
{
    public delegate bool DerDelegierteAuftragserteiler(Auftrag auftrag); 

    class NachrichtenDienst
    {
        public static bool InformiereEiskasten (Auftrag informAuftrag)
        {
            DebugInfo.DebugListe.Add("*****************Delegates***************");
            DebugInfo.DebugListe.Add("Der delegierte Auftragserteiler informiert nun den Eiskasten: "
                + informAuftrag.ToString());
            DebugInfo.Ausgabe();

            Program.NachrichtEmpfangenFuerEiskasten(informAuftrag);

            // Alles ok gegangen! ;) 
            return true;
        }

        public static bool SendeDelegiertenAuftragAnUser (Auftrag informAuftrag2)
        {
            DebugInfo.DebugListe.Add("*****************Delegates***************");
            DebugInfo.DebugListe.Add("Der delegierte Auftragserteiler informiert nun den Anwender: "
                + informAuftrag2.ToString());
            DebugInfo.Ausgabe();

            Program.NachrichtEmpfangenFuerUser(informAuftrag2);

            // Alles ok gegangen! ;) 
            return true;
        }
    }

    public enum Auftrag
    {
        SagHallo,
        SenkeTemperaturUmEinGrad,
        ErhoeheTemperaturUmEinGrad,
        Einschalten,
        Ausschalten,
        DrueckeNotAus

    }
}

using System;

namespace Es_13_03
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Continente europa = new Continente("Italia");
            Paese italia = europa.Paese;

            Regione regione = new Regione("Piemonte", italia);
            Provincia provincia = new Provincia("Torino", regione);
            Comune comune = new Comune("Nichelino", provincia);
            Abitanti abitante = new Abitanti("Matteo Luccisano", comune);

            unioneEuropea UE = new unioneEuropea("Unione Europea", "Bruxelles", "Ursula Von den Leyen", 32000, "Euro");
            UE.AggiungiStato(italia);

            ONU onu = new ONU("Organizizzazione delle Nazioni Unite", "New York", "Antonio Guterres", 33049, 60000);
            onu.AggiungiStato(italia);

            NATO nato = new NATO("North Atlantic Treaty Organization", "Bruxelles", "Jens Stolenberg", 1200, 30);
            nato.AggiungiStato(italia);
                
            //Console.WriteLine($"{abitante} abita a {comune}, provincia di {provincia}, appartenete alla regione {regione}, situata in {paese}");
        }
    }
   

   


}

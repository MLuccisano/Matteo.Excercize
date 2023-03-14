using System;

namespace Es_13_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Continente europa = new Continente("Italia");

            Paese paese = europa.Paese;

            Regione regione = new Regione("Piemonte", paese);
            Provincia provincia = new Provincia("Torino", regione);
            Comune comune = new Comune("Nichelino", provincia);
            Abitanti abitante = new Abitanti("Matteo Luccisano", comune);

            //Console.WriteLine($"{abitante} abita a {comune}, provincia di {provincia}, appartenete alla regione {regione}, situata in {paese}");
        }
    }
   

   


}

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
        }
    }
   

   


}

using System;

namespace The_World
{
    class Program
    {
        static void Main(string[] args)
        {
            Continente europa = new Continente("Europa");
             europa.CreaPaese("Italia");

             Continente asia = new Continente("Asia");
             europa.changeContinente(asia);

             Continente.Paese italia = new Continente.Paese("Italia");
             italia.creaRegione("Piemonte");

            Continente.Regione piemonte = new Continente.Regione("Piemonte");
            piemonte.creaProvincia("Torino");

            Continente.Provincia torino = new Continente.Provincia("Torino");
            torino.creaComune("Nichelino");
                
        }
    } 
}

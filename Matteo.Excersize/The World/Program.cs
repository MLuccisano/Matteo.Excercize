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

            Continente.Paese.Regione piemonte = new Continente.Paese.Regione("Piemonte");
            piemonte.creaProvincia("Torino");

            Continente.Paese.Regione lombardia = new Continente.Paese.Regione("Lombardia");
            piemonte.changeRegione(lombardia);

            Continente.Paese.Regione.Provincia torino = new Continente.Paese.Regione.Provincia("Torino");
            torino.creaComune("Nichelino");              
           

             Continente.Paese.Regione.Provincia asti = new Continente.Paese.Regione.Provincia("Asti");
             torino.changeProvincia(asti);
            
        }
    } 
}

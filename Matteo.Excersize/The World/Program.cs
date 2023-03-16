using System;

namespace The_World
{
    class Program
    {
        static void Main(string[] args)
        {
            Continente europa = new Continente("Europa");      
            europa.creaPaese("Austria");
            europa.creaRegione("Sud Tirol");
            europa.creaProvincia("Bolzano");
            europa.creaComune("Merano");
            //europa.ChangeComune("Austria", "Sud Tirol", "Bolzano", "Merano");
        }


    }
}


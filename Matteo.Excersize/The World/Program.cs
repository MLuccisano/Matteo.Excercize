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
            europa.creaProvincia("Sud Tirol", "Bolzano");
            europa.creaComune("Sud Tirol", "Bolzano", "Merano");
            Console.WriteLine("ciao");
            //europa.ChangeComune("Austria", "Sud Tirol", "Bolzano", "Merano");
        }


    }
}


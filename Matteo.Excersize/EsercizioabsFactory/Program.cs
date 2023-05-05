using EsercizioabsFactory.Factory;
using System;

namespace EsercizioabsFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Europe europe = new Europe("europe", 50000);
            abstractFactory travelAgency = ClientChoiceFactory.GetFactory(europe);
            IFactory Info = travelAgency.GetInfoSectionA();
            Info.choice();


            /*abstractFactory travelAgency1 = ClientChoiceFactory.GetFactory("covid");
            IFactory choice1 = travelAgency1.GetChoice("zif");
            choice1.choice();

            Console.WriteLine("-------------------------------------------------------------------\n");
            
            abstractFactory travelAgency2 = ClientChoiceFactory.GetFactory("ticket");
            IFactory choice2 = travelAgency2.GetChoice("bus");
            choice2.choice();*/
        }
    }
}

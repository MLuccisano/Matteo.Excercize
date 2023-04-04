using System;

namespace Esercizio_di_prova
{
    class Program
    {
        static void Main(string[] args)
        {
            FinancesIntermedary financesIntermedary = new FinancesIntermedary();
            Console.WriteLine(); 

            CommercialBank commercialBank = new CommercialBank();
            Console.WriteLine();

            StockMarket stockMarket = new StockMarket();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}

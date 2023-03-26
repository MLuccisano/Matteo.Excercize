using System;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            SwiftCentralBank ecb = new SwiftCentralBank("European Central Bank", "Strasbourg", "Francia");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russian");

            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "Italy", ecb);
            CommercialBank VTBBank = new CommercialBank("VTB Bank", "Moscow", "Russian", rcb);

            IntesaSanpaolo.CreateAccount("Matteo", "Luccisano", 55100);
            VTBBank.CreateAccount("Ivan", "Rubanosky", 01999);

            Console.WriteLine($"Bank: {IntesaSanpaolo.Name}");
            Console.WriteLine($"From:{IntesaSanpaolo.Country}");
            Console.WriteLine($"Account:{IntesaSanpaolo.account.Customer.Name} {IntesaSanpaolo.account.Customer.Surname}");
            Console.WriteLine($"Bankaccount:{IntesaSanpaolo.account.BankAccount}\n");
            Console.WriteLine($"------------------------------------------------------------- \n");
            Console.WriteLine($"Bank: {VTBBank.Name}");
            Console.WriteLine($"From:{VTBBank.Country}");
            Console.WriteLine($"Account:{VTBBank.account.Customer.Name} {VTBBank.account.Customer.Surname}");
            Console.WriteLine($"Bankaccount:{VTBBank.account.BankAccount}");
            Console.ReadLine();
        }
        
    }
}

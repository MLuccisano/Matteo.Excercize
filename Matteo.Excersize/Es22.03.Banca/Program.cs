using System;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            WorldBank worldBank = new WorldBank("The World Bank", "Wanshigton", "USA");
            SwiftCentralBank ecb = new SwiftCentralBank("European Central Bank", "Strabourg", "Francia");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russia");

            ecb.createCommercialBank("Intesa Sanpaolo", "Turin", "Italy");
            rcb.createCommercialBank("VTB Bank", "Moscow", "Russia");

            CommercialBank IntesaSanpaolo = ecb.commercialBank;
            CommercialBank VTBBank = ecb.commercialBank;
            IntesaSanpaolo.CreateAccount("Matteo", "Luccisano", 55100);
            BankAccount bankaccount = IntesaSanpaolo.bankaccount;


            worldBank.FlowMoney(IntesaSanpaolo, VTBBank);
            


        }
    }
}

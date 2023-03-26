using System;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            IswiftSystem Iecb = new SwiftCentralBank("European Central Bank", "Strabourg, Francia");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow, Russia");
            CentralBank rcb2 = new CentralBank("Russian Central Bank", "Moscow, Russia");


            SwiftCentralBank ecb = (SwiftCentralBank)Iecb;
            SwiftCentralBank ecb2 = (SwiftCentralBank)Iecb;

            ecb.createCommercialBankItalian("Intesa Sanpaolo", "Turin");
            ecb2.createCommercialBankItalian("Unicredit", "Turin");
            rcb.createCommercialBankRussian("VTB Bank", "Moscow");
            rcb2.createCommercialBankRussian("Sperbank", "Moscow");

            ecb.commercialBankItalian.CreateAccount("Matteo", "Luccisano", 123456);
            ecb2.commercialBankItalian.CreateAccount("Alvaro", "Potamen", 0000000);
            rcb.commercialBankRussian.CreateAccount("Vladimir", "Putin", 654321);
            rcb2.commercialBankRussian.CreateAccount("Svletana", "Larukovic", 6539283);

            ecb.transferMoney(ecb.commercialBankItalian, ecb2.commercialBankItalian);
            ecb.transferMoney(ecb.commercialBankItalian, rcb2.commercialBankRussian);
            rcb.transferMoney(rcb.commercialBankRussian, rcb2.commercialBankRussian);

        }
    }
}

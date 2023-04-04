using System;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {

            SwiftCentralBank frs = new SwiftCentralBank("Federal Reserve System", "Washington", "USA");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russian");

            StockMarket WallStreet = new StockMarket("WallStreet", "USA", "NY");

            CommercialBank AE = new CommercialBank("AmericanExpress", "200 Vesey Street", "USA", frs, WallStreet);
            AE.buyStock(WallStreet, STOCKS.TSLA, "TESLA", 2);
            
            #region
            /*StockMarket FTSEMib = new StockMarket("FTSE Mib", "Italy", "Milan");
            //Create some commercialBank
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "Italy", bdi, FTSEMib);
            IntesaSanpaolo.buyStock(FTSEMib, STOCKS.TSLA, "TESLA", 2);*/
            #endregion
            Console.ReadLine();
        }
        
    }
}

























/*Account GFalchi = Unicredit.createAccount("Giorgia", "Falchi");
Account CConti = Unicredit.createAccount("Carlo", "Conti");
Unicredit.addAccount(GFalchi);
Unicredit.addAccount(CConti);

Account ISkanosky = Sperbank.createAccount("Ivan", "Skanosky");
Account DPetrenko = Sperbank.createAccount("Dimitri", "Petrenko");
Sperbank.addAccount(ISkanosky);
Sperbank.addAccount(DPetrenko);

Account VReznov = Gazprombank.createAccount("Viktor", "Reznov");
Account CCraccosky = Gazprombank.createAccount("Carlo", "Craccosky");
Gazprombank.addAccount(VReznov);
Gazprombank.addAccount(CCraccosky);*/

/*Visualize every account associated at commercial Bank, that created them.
Console.WriteLine("The Account into the commercialBank Intesa Sanpaolo");
IntesaSanpaolo.visualizeAccount(IntesaSanpaolo.ArrayAccount);

Console.WriteLine("The Account into the commercialBank Unicredit");
Unicredit.visualizeAccount(Unicredit.ArrayAccount);

Console.WriteLine("The Account into the commercialBank Sperbank");
Sperbank.visualizeAccount(Sperbank.ArrayAccount);

Console.WriteLine("The Account into the commercialBank Gazprombank");
Gazprombank.visualizeAccount(Gazprombank.ArrayAccount);*(


/*bdi.visualizeCommercialBank(bdi.ArrayCB);
rcb.visualizeCommercialBank(rcb.ArrayCB); In these methods visualizes a data of commercialBank created by a CentralBank of bdi and rcb, separated*/

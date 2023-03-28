using System;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Banca d'Italia and Russian Central Bank
            SwiftCentralBank bdi = new SwiftCentralBank("Banca d'Italia", "Roma", "Italia"); //bid is Banca d'Italia
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russian");// rcb is Russian Central Bank

            
            //Create some commercialBank
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "Italy", bdi);
            CommercialBank Unicredit = new CommercialBank("Unicredit", "Milan", "Italy", bdi);
            CommercialBank Sperbank = new CommercialBank("Sperbank", "Moscow", "Russian", rcb);
            CommercialBank Gazprombank = new CommercialBank("Gazprombank ", "Moscow", "Russian", rcb);

            /*Add commercial Bank to array of centralBank.
            bdi.AddCommercialBank(IntesaSanpaolo);
            bdi.AddCommercialBank(Unicredit);
            rcb.AddCommercialBank(Sperbank);
            rcb.AddCommercialBank(Gazprombank);
            bdi.visualizeCommercialBank(bdi.CommercialBanks);
            rcb.visualizeCommercialBank(rcb.CommercialBanks);*/

            //create a 2 account every commercialBank and add to array of commercialBank.
            IntesaSanpaolo.createAccount("Bruno Vespa", "BDDT66D878DQEQA");
            IntesaSanpaolo.createAccount("Renato Zero", "RNNN84845JDSI64");
            IntesaSanpaolo.createAccount("Bruno Vespa", "BDDT66D878DQEQA");
            //IntesaSanpaolo.visualizeAccount(IntesaSanpaolo.Accounts);

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

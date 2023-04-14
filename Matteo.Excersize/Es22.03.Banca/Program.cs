using System;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CentralBank
            SwiftCentralBank BDI = new SwiftCentralBank("Banca d'Italia", "Roma", "Italia");
            SwiftCentralBank frs = new SwiftCentralBank("Federal Reserve System", "Washington", "USA");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russia");
            #endregion
            

            #region StockMarket
            StockMarket WallStreet = new StockMarket("WallStreet", "USA", "NY", "Eastern Standard Time");
            StockMarket FTSEMib = new StockMarket("FTSE Mib", "Italian", "Milan", "Central Europe Standard Time");
            StockMarket Nikkei = new StockMarket("Nikkei", "Japanese", "Tokyo", "Tokyo Standard Time");
            StockMarket MOEX = new StockMarket("MOEX", "Russia", "Moscow", "Russian Standard Time");
            #endregion
           
            
            #region Commercial bank: Intesa Sanpaolo
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "Italy", BDI, FTSEMib,fiat.EURO); 
            
            IntesaSanpaolo.createAccount("Matteo Luccisano", "MOOWEE37Z57A156X", "07/03/98","it");
            int MLBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "MOOWEE37Z57A156X");

            /* IntesaSanpaolo.createAccount("Pietro Ornello", "DD8DJ4DKLYHB954", "03/10/1995", "it");
             int POBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "DD8DJ4DKLYHB954");
             IntesaSanpaolo.Deposit(250000M, MLBankAcccount);
             IntesaSanpaolo.Withdraw(100000M, MLBankAcccount);*/
            IntesaSanpaolo.buyStock(MLBankAcccount, WallStreet, STOCKS.TSLA, "TESLA", 100M);
            IntesaSanpaolo.visualizeStockAcquired(MLBankAcccount);
            #endregion

            /*#region Commercial bank: VTB Bank
            CommercialBank VTBBank = new CommercialBank("VTB Bank", "Moscow","Russia", rcb, MOEX, fiat.RUB);
            VTBBank.createAccount("Ivan Fraffesky", "IVFHJ43545JRFIOOED", "23/05/1969", "ru");
            int IFBankAccount = getNumberAccount.getBankAccount(VTBBank, "IVFHJ43545JRFIOOED");
            VTBBank.Deposit(50M, IFBankAccount);            
            #endregion

            /*IntesaSanpaolo.Transfer(1500, VTBBank, MLBankAcccount, IFBankAccount);
            IntesaSanpaolo.Transfer(1500M, IntesaSanpaolo, MLBankAcccount, POBankAcccount);  */
            Console.ReadLine();

            
        }
        
    }
}

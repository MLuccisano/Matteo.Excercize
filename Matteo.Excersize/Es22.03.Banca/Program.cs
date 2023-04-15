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
            SwiftCentralBank FRS = new SwiftCentralBank("Federal Reserve System", "Washington", "USA");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russia");
            #endregion
            
            #region StockMarket
            StockMarket WallStreet = new StockMarket("WallStreet", "USA", "NY", "Eastern Standard Time");
            StockMarket FTSEMib = new StockMarket("FTSE Mib", "Italy", "Milan", "Central Europe Standard Time");
            StockMarket Nikkei = new StockMarket("Nikkei", "Japan", "Tokyo", "Tokyo Standard Time");
            StockMarket MOEX = new StockMarket("MOEX", "Russia", "Moscow", "Russian Standard Time");

            WallStreet.addStocks(STOCKS.TSLA);
            FTSEMib.addStocks(STOCKS.GNR);
            #endregion


            #region Commercial bank: Intesa Sanpaolo
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "ITALY", BDI,FTSEMib,fiat.EUR);
            CommercialBank AE = new CommercialBank("Amnerican Express", "NY", "USA", FRS, WallStreet, fiat.USD);
            
            IntesaSanpaolo.createAccount("Matteo Luccisano", "MOOWEE37Z57A156X", "07/03/1998","it");
            int MLBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "MOOWEE37Z57A156X");

            AE.createAccount("John Doe", "JNDKD89485JNDIU8", "09/11/2001", "us");
            int JDBankAccount = getNumberAccount.getBankAccount(AE, "JNDKD89485JNDIU8");

            

            IntesaSanpaolo.createAccount("Pietro Ornello", "DD8DJ4DKLYHB954", "03/10/1995", "it");
            int POBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "DD8DJ4DKLYHB954");

            IntesaSanpaolo.Deposit(250000M, MLBankAcccount);
            IntesaSanpaolo.Withdraw(25000M, MLBankAcccount);
            IntesaSanpaolo.Transfer(10M, AE, MLBankAcccount, JDBankAccount);
            //IntesaSanpaolo.buyStock(MLBankAcccount, STOCKS.GNR, 100M);
            //IntesaSanpaolo.visualizeStockAcquired(MLBankAcccount);
            #endregion
            Console.ReadLine();

            
        }
        
    }
}

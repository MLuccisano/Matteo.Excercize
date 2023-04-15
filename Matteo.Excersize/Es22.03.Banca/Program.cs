using System;
using Es22._03.Banca.Assets;
using Es22._03.Banca.classi;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            #region CentralBank: Banca d'Italia, Federal Reserve System, Russian Central Bank
            SwiftCentralBank BDI = new SwiftCentralBank("Banca d'Italia", "Roma", "Italia");
            SwiftCentralBank FRS = new SwiftCentralBank("Federal Reserve System", "Washington", "USA");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow", "Russia");
            #endregion

            #region StockMarket: Wallstreet, FTSEMib, MOEX
            StockMarket WallStreet = new StockMarket("WallStreet", "USA", "NY", "Eastern Standard Time");
            StockMarket FTSEMib = new StockMarket("FTSE Mib", "Italy", "Milan", "Central Europe Standard Time");
            StockMarket MOEX = new StockMarket("MOEX", "Russia", "Moscow", "Russian Standard Time");

            WallStreet.addStocks(STOCKS.TSLA);
            FTSEMib.addStocks(STOCKS.GNR);
            MOEX.addStocks(STOCKS.GAZP);
            #endregion


            #region Commercial bank: Intesa Sanpaolo
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "ITALY", BDI,FTSEMib,fiat.EUR);
            
            IntesaSanpaolo.createAccount("Matteo Luccisano", "MOOWEE37Z57A156X", "07/03/1998","it");
            int MLBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "MOOWEE37Z57A156X");

            IntesaSanpaolo.createAccount("Pietro Ornello", "DD8DJ4DKLYHB954", "03/10/1995", "it");
            int POBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "DD8DJ4DKLYHB954");

            IntesaSanpaolo.Deposit(250000M, MLBankAcccount);
            IntesaSanpaolo.Withdraw(25000M, MLBankAcccount);

            #endregion

            #region Commercial Bank: American Express
            CommercialBank AE = new CommercialBank("American Express", "NY", "USA", FRS, WallStreet, fiat.USD);

            AE.createAccount("John Doe", "JNDKD89485JNDIU8", "09/11/2001", "us");
            int JDBankAccount = getNumberAccount.getBankAccount(AE, "JNDKD89485JNDIU8");

            AE.Deposit(250000M, JDBankAccount);

            #endregion

            #region Commercial Bank: VTB Bank
            CommercialBank VTBBank = new CommercialBank("VTB Bank", "Moscow", "Russia", rcb, MOEX, fiat.RUB);

            VTBBank.createAccount("Nikita Mazepin", "MZZ976SN7WEGD6", "17/09/1993","ru");
            int NMBankAccount = getNumberAccount.getBankAccount(VTBBank, "MZZ976SN7WEGD6");

            VTBBank.Deposit(250000, NMBankAccount);
            #endregion


            Console.ReadLine();

        }       
    }
}

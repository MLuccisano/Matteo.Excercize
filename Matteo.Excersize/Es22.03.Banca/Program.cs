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
            StockMarket Nikkei = new StockMarket("Nikkei", "Japan", "Tokyo", "Korea Standard Time");
            StockMarket DAX = new StockMarket("DAX", "German", "Berlin", "Central Europe Standard Time");
            StockMarket Bovespa = new StockMarket("Bovespa", "Brasil", "Sao Paulo", "East South Standard Time");
            

            WallStreet.addStocks(STOCKS.TSLA);
            FTSEMib.addStocks(STOCKS.GNR);
            MOEX.addStocks(STOCKS.GAZP);
            Nikkei.addStocks(STOCKS.HND);
            DAX.addStocks(STOCKS.BMW1);
            Bovespa.addStocks(STOCKS.PETR4);
            #endregion

            #region CryptoExchange

            CryptoExhange binance = new CryptoExhange("Binance", "Cayman Island", "Mahé");
            binance.addCrypto(CRYPTO.BTC);
            binance.addCrypto(CRYPTO.ETH);
            #endregion


            #region Commercial bank
            CommercialBank IntesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Turin", "Italy", BDI,FTSEMib,binance,fiat.EUR);
            CommercialBank AE = new CommercialBank("American Express", "NY", "USA", FRS, WallStreet, binance, fiat.USD);
            CommercialBank VTBBank = new CommercialBank("VTB Bank", "Moscow", "Russia", rcb, MOEX, binance, fiat.RUB);

            #endregion

            #region CreateAccount
            IntesaSanpaolo.createAccount("Matteo Luccisano", "MOOWEE37Z57A156X", "07/03/1998","it");
            int MLBankAcccount = getNumberAccount.getBankAccount(IntesaSanpaolo, "MOOWEE37Z57A156X");

            AE.createAccount("John Doe", "JNDKD89485JNDIU8", "09/11/2001", "us");
            int JDBankAccount = getNumberAccount.getBankAccount(AE, "JNDKD89485JNDIU8");

            VTBBank.createAccount("Nikita Mazepin", "MZZ976SN7WEGD6", "17/09/1993", "ru");
            int NMBankAccount = getNumberAccount.getBankAccount(VTBBank, "MZZ976SN7WEGD6");

            #endregion

            #region Visualize Account
            IntesaSanpaolo.visualizeAccount();
            AE.visualizeAccount();
            VTBBank.visualizeAccount();
            #endregion

            #region Banking Operation from Intesa Sanpaolo
            IntesaSanpaolo.DepositFIAT(250000M, MLBankAcccount);
            IntesaSanpaolo.WithdrawFIAT(2000M, MLBankAcccount);
            IntesaSanpaolo.buyStock(MLBankAcccount, STOCKS.GNR, 100M);
            IntesaSanpaolo.buyCrypto(100M, CRYPTO.BTC,MLBankAcccount);

            Console.WriteLine("-----------------------------------------------------------\n");
            IntesaSanpaolo.visualizeAccount();

            IntesaSanpaolo.SellCrypto(0.00362700M, CRYPTO.BTC, MLBankAcccount);
            IntesaSanpaolo.SellStocks(STOCKS.GNR, MLBankAcccount);

            Console.WriteLine("-----------------------------------------------------------\n");
            IntesaSanpaolo.visualizeAccount();
            #endregion

            #region Banking Operation from America Express
            AE.DepositFIAT(250000M, JDBankAccount);
            AE.WithdrawFIAT(2000M, JDBankAccount);
            AE.buyStock(JDBankAccount, STOCKS.TSLA, 100M);
            AE.buyCrypto(100M, CRYPTO.BTC, JDBankAccount);

            Console.WriteLine("-----------------------------------------------------------\n");
            AE.visualizeAccount();

            AE.SellCrypto(0.00330600M, CRYPTO.BTC, JDBankAccount);
            AE.SellStocks(STOCKS.TSLA, JDBankAccount);

            Console.WriteLine("-----------------------------------------------------------\n");
            AE.visualizeAccount();
            #endregion

            #region Banking Operation from VTB Bank

            VTBBank.DepositFIAT(250000M, NMBankAccount);
            VTBBank.WithdrawFIAT(2000M, NMBankAccount);
            VTBBank.buyStock(NMBankAccount, STOCKS.TSLA, 100M);
            VTBBank.buyCrypto(100M, CRYPTO.BTC, NMBankAccount);


            Console.WriteLine("-----------------------------------------------------------\n");
            VTBBank.visualizeAccount();

            VTBBank.SellCrypto(0.00004000M, CRYPTO.BTC, NMBankAccount);
            VTBBank.SellStocks(STOCKS.GAZP, NMBankAccount);

            Console.WriteLine("-----------------------------------------------------------\n");
            VTBBank.visualizeAccount();

            #endregion

            #region Example money transfer from bank to another bank and check if the bank sender o destinaton have got a swift system

            IntesaSanpaolo.Transfer(10M, AE, MLBankAcccount, JDBankAccount);
            IntesaSanpaolo.Transfer(10M, VTBBank, MLBankAcccount, NMBankAccount);

            #endregion

            Console.ReadLine();

        }       
    }
}

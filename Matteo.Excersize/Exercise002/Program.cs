using System;
using System.Runtime.InteropServices;
using static OOP.Exercise.Polimorfismo.v002.ClassSolution;

namespace Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            ////vedere lo stockMarket/Cryptoexchange dall'esterno
            //CrytoCEX binance = new CrytoCEX() { Name = "Binance" }; // Crypto Exchange 
            //StockMarket pizzaAffari = new StockMarket() { Name = "pizzaAffari" };// StockMarket -> Borsa


            // Banca _banca = new Banca();
            //_banca.BuyCrypto(binance);
            //_banca.BuyStocks(pizzaAffari);
            //MyCryptoMarket myCrypto = new MyCryptoMarket();
            //MyCommertialBank myCommertialBank = new MyCommertialBank();
            //myCommertialBank.BuyCrypto(myCrypto);
            #endregion
            
            bank banca = new bank();

            banca.buyCrypto();
            banca.buyStock();

            

            

            

            

            

            
            

            

            
        }
    }





}


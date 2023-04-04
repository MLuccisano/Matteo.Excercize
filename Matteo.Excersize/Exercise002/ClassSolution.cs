using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP.Exercise.Polimorfismo.v002
{
    internal class ClassSolution
    {
        #region
       /* public abstract class IntermdiarioFinanziario
        {
            public string Name { get; set; }

            protected virtual Asset BuyAsset(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                return intermdiarioFinanziario.BuyAsset(intermdiarioFinanziario);
            }
            public class Asset
            {

            }
        }
        public class CryptoIntermediary : IntermdiarioFinanziario
        {
            protected override Asset BuyAsset(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                return null;
            }
        }
        public class StockIntermediary : IntermdiarioFinanziario
        {
            public StockIntermediary()
            {

            }
            protected override Asset BuyAsset(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                Console.WriteLine($"I'm Buying Stocks!");
                return null;
            }

        }
        public class CrytoCEX : CryptoIntermediary
        {
            public CrytoCEX() : base()
            {

            }
            protected override Asset BuyAsset(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                Console.WriteLine($"I'm Buying Crypto from {this.Name}");
                return null;

            }
        }
        public class StockMarket : StockIntermediary
        {
            protected override Asset BuyAsset(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                Console.WriteLine($"I'm Buying Stocks from {this.Name}");
                return null;
            }
        }
        public class Banca : IntermdiarioFinanziario
        {
            public void BuyCrypto(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                base.BuyAsset(intermdiarioFinanziario);
            }
            public void BuyStocks(IntermdiarioFinanziario intermdiarioFinanziario)
            {
                base.BuyAsset(intermdiarioFinanziario);
            }
        }*/
        #endregion


       private interface IcryptoIntermediary
        {
            public void buyCrypto();
        }
        private interface IstockIntermediary
        {
            public void buyStock();
        }
        public class StockMarket : IstockIntermediary
        {
            void IstockIntermediary.buyStock()
            {
                Console.WriteLine("Sto comprando gli Stocks");
            }
        }

        public class CryptoExchange : IcryptoIntermediary
        {
            void IcryptoIntermediary.buyCrypto()
            {
                Console.WriteLine("Sto comprando le Crypto");
            }
        }

        public class bank: IcryptoIntermediary, IstockIntermediary
        {
            IstockIntermediary stockMarket;
            IcryptoIntermediary cryptoExchange;
            
            public void buyCrypto()
            {
                cryptoExchange.buyCrypto();                
            }

            public void buyStock()
            {                
                stockMarket.buyStock();
            }
        }
    }
}

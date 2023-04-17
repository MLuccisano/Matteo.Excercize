using Es22._03.Banca.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    public enum CRYPTO
    { 
        BTC,
        ETH
    }
   
    class CryptoExhange : FinancialIntermediary
    {
        Crypto _crypto;
        string _country;
        List<CRYPTO> listCrypto;

        public List<CRYPTO> ListCrypto { get => listCrypto; }
        public CryptoExhange(string name, string country, string city) : base(name, country, city)
        {
            _country = country;
            listCrypto = new List<CRYPTO>();
        }

        protected override Asset BuyCrypto(FinancialIntermediary financialIntermediary, CRYPTO cryptos)
        {

            return _crypto = new Crypto(cryptos, cryptos.ToString(), 0);            
        }

        protected override decimal SellCrypto(FinancialIntermediary financialIntermediary, CRYPTO cryptos, decimal Amount)
        {
            return _crypto.WithDraw(Amount);
        }

        internal void DepositCrypto(decimal amount)
        {
            _crypto.Deposit(amount);  
        }

        internal void WithdrawCrypto(decimal amount)
        {
            _crypto.WithDraw(amount);
        }


        public void addCrypto(CRYPTO crypto)
        {
            listCrypto.Add(crypto);
        }



        class Crypto : Asset
        {
            CRYPTO _cryptos;

            public Crypto(CRYPTO cryptos, string Name, decimal amount) : base(Name, amount)
            {
                _cryptos = cryptos;

            }
            internal void Deposit(decimal amount)
            {
                Amount += amount;
            }

            internal decimal WithDraw(decimal amount)
            {
                return Amount -= amount;
            }
        }


    }
}

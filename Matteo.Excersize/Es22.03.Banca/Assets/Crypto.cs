using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Assets
{
    public enum CRYPTO
    { 
        BTC,
        ETH,
        NFT,
        XRP
    }
    internal class Crypto : Asset
    {
        CRYPTO _crypto;
        decimal _cryptoValue;
        public Crypto(CRYPTO crypto, string Name, decimal CryptoValue) : base(Name)
        {
            _crypto = crypto;
            _cryptoValue = CryptoValue;

        }

        public void Deposit(decimal cryptoAmount)
        {
            Amount += cryptoAmount;
        }

        public void Withdraw(decimal cryptoAmount)
        {
            Amount -= cryptoAmount;
        }
    }
}

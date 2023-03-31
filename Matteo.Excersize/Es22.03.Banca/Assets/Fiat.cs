using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Assets
{
    public enum fiat
    {
        EURO,
        GBP,
        USD,
        YEN,
        CHF
    }
    class Fiat : Asset
    {
        fiat _fiat;
        decimal _amoutFiat;
        public Fiat(fiat fiat, string Name, decimal AmountFiat) : base(Name)
        {
            _fiat = fiat;
            _amoutFiat = AmountFiat;
        }

        public void Withdraw(decimal money)
        {
            Amount -= money;
        }

        public void Deposit(decimal money)
        {
            Amount += money;
        }
    }
}

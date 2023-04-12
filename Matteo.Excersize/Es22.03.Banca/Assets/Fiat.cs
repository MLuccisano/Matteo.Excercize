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
        RUB
    }
    class Fiat : Asset
    {
        fiat _fiat;
        decimal maxWithdraw;
        
        public Fiat(fiat fiat, string Name, decimal amount) : base(Name, amount)
        {
            _fiat = fiat;
            
        }

        internal bool Withdraw(decimal money, string dateMovimentNow, string dateLastMoviment)
        {

            int result = dateMovimentNow.CompareTo(dateLastMoviment);

            switch (result)
            {
                case 0:
                    maxWithdraw += money;
                    if (maxWithdraw <= 10000M)
                    {
                        Amount -= money;
                        return true;
                    } 
                    else return false;
                case 1:
                    maxWithdraw = 0;
                    maxWithdraw += money;
                    if (maxWithdraw <= 10000M)
                    {
                        Amount -= money;
                        return true;
                    }
                    else return false;
            }
            return false;
        } 

        internal void Deposit(decimal money)
        {
            Amount += money;
        }

        
    }
}

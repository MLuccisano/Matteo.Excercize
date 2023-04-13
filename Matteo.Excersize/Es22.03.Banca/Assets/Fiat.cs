using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.Assets
{
    #region Enumerator of currency
    public enum fiat
    {
        EURO,
        GBP,
        USD,
        YEN,
        RUB
    }
    #endregion
    class Fiat : Asset
    {
        #region Variable
        fiat _fiat;
        const decimal limitWithdrawDay = 10000M;
        const decimal limitWithdrawMonth = 30000M;
        decimal withdrawDay;
        decimal withdrawMonth;
        DateTime dateLastMoviment;
        #endregion
        public Fiat(fiat fiat, string Name, decimal amount) : base(Name, amount)
        {
            _fiat = fiat;            
        }

        #region Operation: Withdraw
        internal bool Withdraw(decimal money)
        {            
            withdrawDay += money;
            withdrawMonth += money;
            dateLastMoviment = DateTime.Now;
            return checkWithDraw(money);

        }

        // The method "checkWithDraw" is a method that return a bool value and check if exceeded a limit withdraw a day or month;
        private bool checkWithDraw(decimal money)
        {
            if (withdrawDay <= limitWithdrawDay)
            {
                Amount -= money;
                return true;
            }
            else
            {
                if (dateLastMoviment.ToShortDateString() != DateTime.Now.ToShortDateString())
                {
                    withdrawDay -= 10000;
                    if (checkWithDrawMonth(money))
                    {
                        Amount -= money;
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            
        }

        private bool checkWithDrawMonth(decimal money)
        {
            if (withdrawMonth <= limitWithdrawMonth) return true;
            else
            {
                if (dateLastMoviment.Month != DateTime.Now.Month)
                {
                    withdrawMonth -= 30000;
                    return true;
                }
                else return false;
            }
        }
        #endregion

        // Method Deposit 
        internal void Deposit(decimal money)
        {
            Amount += money;
        }        
    }
}

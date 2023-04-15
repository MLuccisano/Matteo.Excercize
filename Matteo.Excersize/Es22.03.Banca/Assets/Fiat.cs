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
        EUR,
        RUB,
        USD        
    }
    #endregion
    #region errorLimitWithdraw

    #endregion
    class Fiat : Asset
    {
        #region Variable
        fiat _fiat;
        const decimal limitWithdrawDay = 10000M;
        const decimal limitWithdrawMonth = 30000M;
        decimal withdrawDay;
        decimal withdrawMonth;
        DateTime dateBlackList;
        #endregion
        public Fiat(fiat fiat, string Name, decimal amount) : base(Name, amount)
        {
            _fiat = fiat;            
        }

        #region Operation: Withdraw
        internal bool Withdraw(decimal money)
        {
            if (DateTime.Now > dateBlackList) return checkWithDraw(money);
            else return false;

        }

        // The method "checkWithDraw" is a method that return a bool value and check if exceeded a limit withdraw a day or month (method checkWithdrawMonth);
        
        private bool checkWithDraw(decimal money)
        {
            withdrawDay += money;
            withdrawMonth += money;
            if (withdrawDay <= limitWithdrawDay)
            {
                Amount -= money;
                return true;
            }
            else if (withdrawDay >= limitWithdrawDay)
            {
                dateBlackList = DateTime.Now.AddDays(1);
                return false;
            }
            else
            {
                withdrawDay -= 10000;
                if (checkWithDrawMonth(money))
                {
                    Amount -= money;
                    return true;
                }
                else
                {
                    dateBlackList = DateTime.Now.AddDays(3);
                    return false;
                }
            }                        
        }

        private bool checkWithDrawMonth(decimal money)
        {
            if (withdrawMonth <= limitWithdrawMonth) return true;

            else if (withdrawMonth >= limitWithdrawMonth) return false;

            else
            {
                if (dateBlackList.Month != DateTime.Now.Month)
                {
                    withdrawMonth -= 30000;
                    return true;
                }
                else return false;
            }
        }
        #endregion

        // Method Deposit
        internal bool Deposit(decimal money)
        {
            if (DateTime.Now.Day - dateBlackList.Day >= -1)// condition if the Bank account is not locked by a exceeded limit of withdraw month
            {
                Amount += money;
                return true;
            }
            else return false;
            
        }

        // Method payment it is similar then method withdraw, unless control limit.

        internal bool payment(decimal money)
        {

            if (DateTime.Now.Day - dateBlackList.Day >= -1)// condition if the Bank account is not locked by a exceeded limit of withdraw month
            {
                Amount -= money;
                return true;
            }
            else return false;
        } 

    }
}

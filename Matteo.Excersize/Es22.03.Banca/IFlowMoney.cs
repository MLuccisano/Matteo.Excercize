using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    internal interface IFlowMoney
    {
        public void transferMoney(Bank bankSender, Bank bankDestination);

    }
}

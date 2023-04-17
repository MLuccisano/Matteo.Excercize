using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca.classi
{
    internal class getNumberAccount
    {
        public static int getBankAccount(CommercialBank commercialBank, string cf)
        {
            var result = commercialBank.ListAccounts.FindIndex(lista => lista.ClientCF.Equals(cf));
            return commercialBank.ListAccounts[result].BankAccount;
        }
    }
}

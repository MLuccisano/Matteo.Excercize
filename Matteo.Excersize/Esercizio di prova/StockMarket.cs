using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_di_prova
{
    public class StockMarket : FinancesIntermedary
    {
        public override string buystocks()
        {
            string frase = base.buystocks() + "StockMarket";
            return frase;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_di_prova
{
    class CommercialBank : FinancesIntermedary
    {
        public override string buystocks()
        {
            string frase = base.buystocks() + "CommercialBank";
            return frase;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal class BCE
    {
        public void CalcolaSpread(IUE nazione)
        {
            Italia italia = (Italia)nazione;

            Console.WriteLine($"Calcola lo spread di {italia.Name}");
            
        }
    }
}

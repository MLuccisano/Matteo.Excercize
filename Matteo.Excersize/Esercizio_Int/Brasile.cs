using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal class Brasile : IONU, IPenadimorte
    {
        public Brasile()
        {
            ApplicaPenadimorte();
            SviluppaRelazioniAmichevoli();
        }
        public void ApplicaPenadimorte()
        {
            Console.WriteLine("Il Paese Brasile applica la pena di morte");
        }

        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine("Il Paese Brasile non è amichevole"); 
        }
    }
}

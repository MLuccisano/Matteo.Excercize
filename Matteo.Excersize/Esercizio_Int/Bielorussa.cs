using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal class Bielorussa : PaeseEuropeo, IONU,IPenadimorte
    {
        public Bielorussa(string Name) : base (Name)
        {
            ApplicaPenadimorte();
            SviluppaRelazioniAmichevoli();
        }
        public void ApplicaPenadimorte()
        {
            Console.WriteLine("Il Paese Bielorussa applica la pena di morte \n");
        }

        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine("Il Paese Bielorussa non è amichevole\n");
        }
    }
}

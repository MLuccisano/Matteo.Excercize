using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal class Bielorussa : PaeseEuropeo, IONU,IPenadimorte
    {
        public override void DentroEuropaContinente(string nome)
        {
            Console.WriteLine($"Pazzesco! {nome}  nel continente Europeo");
        }

        public Bielorussa(string Name) : base (Name)
        {
            ApplicaPenadimorte();
            SviluppaRelazioniAmichevoli();
            DentroEuropaContinente(Name);
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

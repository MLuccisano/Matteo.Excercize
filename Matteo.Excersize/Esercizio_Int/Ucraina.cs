using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal class Ucraina : PaeseEuropeo, ICEDU, IONU
    {
        public override void DentroEuropaContinente(string nome)
        {
            Console.WriteLine($"Pazzesco! {nome}  nel continente Europeo \n");
        }
        public Ucraina(string Name ) : base (Name) 
        {
            CheckHumanRightsAgreement();
            SviluppaRelazioniAmichevoli();
            DentroEuropaContinente(Name);
        }
        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine("Il paese Ucraina rispetta i diritti umani");
        }

        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine("Il paese Ucraina è amichevole.");
        }
    }
}

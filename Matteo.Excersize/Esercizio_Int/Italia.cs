using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{

    internal class Italia : PaeseEuropeo, IONU, IUE, ICEDU
    {
        public override void DentroEuropaContinente(string nome)
        {
            Console.WriteLine($"Pazzesco! {nome}  nel continente Europeo");
        }
        public Italia(string Name) : base(Name)
        {
            this.Name = Name;
            ApplyCostitution();
            CheckHumanRightsAgreement();
            SviluppaRelazioniAmichevoli();
            DentroEuropaContinente(Name);
        }
        public void ApplyCostitution()
        {
            Console.WriteLine($"Il Paese {Name} applica le leggi europee \n");
        }

        public void CheckHumanRightsAgreement()
        {
            Console.WriteLine($"Il Paese {Name} rispetta i diritti umani \n");
        }

        public void SviluppaRelazioniAmichevoli()
        {
            Console.WriteLine($"Il Paese {Name} è molto amichevole \n");
        }
    }
}

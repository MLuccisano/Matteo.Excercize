using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodiceFiscale
{
    class Cittadino : IAgenziaEntrate
    {
        string _nome;
        string _cognome;

        public string Nome { get => _nome; set => _nome = value; }
        public string Cognome { get => _cognome; set => _cognome = value; }

        public Cittadino(string Nome, string Cognome)
        {
            this.Nome = Nome;
            this.Cognome = Cognome;
        }

        void IAgenziaEntrate.calcolaCF(Cittadino cittadino)
        {
            Console.WriteLine($"Calcola il CF del paese {Nome}");
        }
    }
}

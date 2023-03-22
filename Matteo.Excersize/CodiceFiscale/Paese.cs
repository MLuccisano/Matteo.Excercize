using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodiceFiscale
{
    class Paese : IAgenziaEntrate
    {
        string _nome;
        public string Nome { get => _nome; set => _nome = value; }

        public Paese(string Nome)
        {
            this.Nome = Nome;
        }

        void IAgenziaEntrate.calcolaCF(Cittadino cittadino)
        {
            Console.WriteLine($"La nazione {Nome} calcola il CF di {cittadino.Nome}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class unioneEuropea : Organizzazione
    {

        string _partiti;
        string _moneta;

        public unioneEuropea(string Nome, string Sede, string Presidente, int NumeroDipendenti, string Moneta) : base(Nome,Sede, Presidente, NumeroDipendenti)
        {
            this.Partiti = Partiti;
            this.Moneta = Moneta;
        }
        public string Partiti { get => _partiti; set => _partiti = value; }
        public string Moneta { get => _moneta; set => _moneta = value; }

         
    }
}

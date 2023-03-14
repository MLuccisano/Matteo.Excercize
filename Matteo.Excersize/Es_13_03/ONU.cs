using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class ONU : Organizzazione
    {
        int _numeroCaschiBlu;

        public ONU(string Nome, string Sede, string Presidente, int NumeroDipendenti, int NumeroCaschiBlu) : base(Nome, Sede, Presidente, NumeroDipendenti)
        {
            this.NumeroCaschiBlu = NumeroCaschiBlu;
        }

        public int NumeroCaschiBlu { get => _numeroCaschiBlu; set => _numeroCaschiBlu = value; }
    }
}

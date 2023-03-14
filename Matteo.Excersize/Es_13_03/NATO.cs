using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class NATO : Organizzazione
    {
        int _paesiAderenti;
        public NATO(string Nome, string Sede, string Presidente, string Regole, int NumeroDipendenti, int PaesiAderenti) : base(Nome, Sede, Presidente, Regole, NumeroDipendenti)
        {
            this.PaesiAderenti = PaesiAderenti;
        }
        public int PaesiAderenti { get => _paesiAderenti; set => _paesiAderenti = value; }
    }
}

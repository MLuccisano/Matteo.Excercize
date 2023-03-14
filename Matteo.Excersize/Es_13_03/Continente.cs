using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class Continente 
    {
        int numeroStati;
        List<Paese> listaPaesi;
        string emisfero;
        Paese _paese;

        public Continente(string Nome) 
        {
            listaPaesi = new List<Paese>();
            Paese = new Paese(Nome);

        }

        public int NumeroStati { get => numeroStati; set => numeroStati = value; }
        public string Emisfero { get => emisfero; set => emisfero = value; }
        internal Paese Paese { get => _paese; set => _paese = value; }


    }
}
   

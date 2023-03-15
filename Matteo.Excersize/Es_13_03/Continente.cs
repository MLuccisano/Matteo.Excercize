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

        public Continente(string Nome, string Emisfero) 
        {
            listaPaesi = new List<Paese>();
           
        }

        public void AggiungiStato(Paese paese)
        {
            listaPaesi.Add(paese);
        }
        public int NumeroStati { get => numeroStati; set => numeroStati = value; }
        public string Emisfero { get => emisfero; set => emisfero = value; }
        internal Paese Paese { get => _paese; set => _paese = value; }

    }
}
   

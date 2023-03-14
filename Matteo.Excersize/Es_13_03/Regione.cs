using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Regione //: AreaGeografica
    {
        /*string _capoluogo;
        string _caporegione;
        int _numeroProvincia;*/
        Paese _paese;
        string _nome;
        Provincia _provincia;

        public Regione(string Nome, Paese paese)//, string Coordinate, int NumeroAbitanti, string Capoluogo, string Caporegione, int NumeroProvincia ) : base(Nome, Coordinate, NumeroAbitanti)
        {
            /*this.Capoluogo = Capoluogo;
            this.Caporegione = Caporegione;
            this.NumeroProvincia = NumeroProvincia;*/
           _nome = Nome;
            this._paese = paese;
            paese.AddRegione(this);
            
        }

        public void AddProvincia(Provincia provincia)
        {
            _provincia = provincia;
        }
        public void removeProvincia()
        {
            _provincia = null;
        }

        /* public string Capoluogo { get => _capoluogo; set => _capoluogo = value; }
         public string Caporegione { get => _caporegione; set => _caporegione = value; }
         public int NumeroProvincia { get => _numeroProvincia; set => _numeroProvincia = value; }*/
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Paese
    {
        string _formaGoverno;
        string _capoStato;
        string _Capitale;
        int _numeroRegioni;
        int _numeroProvincia;
        int _numeroComune;
        Regione _regione;

        public Paese(string Nome)//, string Coordinate, int NumeroAbitanti, string FormaGoverno, string CapoStato, string Capitale, int NumeroRegioni, int NumeroProvincia, int NumeroComune) : base(Nome, Coordinate, NumeroAbitanti)
        {
           /* this.FormaGoverno = FormaGoverno;
            this.CapoStato = CapoStato;
            this.Capitale = Capitale;
            this.NumeroRegioni = NumeroRegioni;
            this.NumeroProvincia = NumeroProvincia;
            this.NumeroComune = NumeroComune;*/
;

        }
        public string FormaGoverno { get => _formaGoverno; set => _formaGoverno = value; }
        public string CapoStato { get => _capoStato; set => _capoStato = value; }
        public string Capitale { get => _Capitale; set => _Capitale = value; }
        public int NumeroProvincia { get => _numeroProvincia; set => _numeroProvincia = value; }
        public int NumeroComune { get => _numeroComune; set => _numeroComune = value; }
        internal Regione Regione { get => _regione; set => _regione = value; }

        public void AddRegione(Regione regione)
        {
            _regione = regione;
        }
        public void removeRegione (Regione regione)
        {
            _regione = null;
        }

    }
}


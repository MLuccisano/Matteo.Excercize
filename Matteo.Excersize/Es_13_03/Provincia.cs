using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Provincia //: AreaGeografica
    {
        string _assessoreProvinciale;
        int _numeroComune;
        Regione _regione;
        Comune _comune;
        string _nome;


        public Provincia(string Nome, Regione regione)//, string Coordinate, int NumeroAbitanti, string AssessoreProvinciale, int NumeroComune) : base(Nome, Coordinate, NumeroAbitanti)
        {
            // this.AssessoreProvinciale = AssessoreProvinciale;
            //this.NumeroComune = NumeroComune;

            _nome = Nome;
            this._regione = regione;
            regione.AddProvincia(this);

        }

        public void addComune(Comune comune)
        {
            _comune = comune;
        }

        public void removeComune(Comune comune)
        {
            _comune = comune;
        }
        /*public string AssessoreProvinciale { get => _assessoreProvinciale; set => _assessoreProvinciale = value; }
        public int NumeroComune { get => _numeroComune; set => _numeroComune = value; }*/
    }
}

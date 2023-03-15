using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Provincia //: AreaGeografica
    {
        /*string _assessoreProvinciale;
        int _numeroComune;
        Regione _regione;*/
        Comune comune;
        string _nome;

        public Provincia(string Nome)//, string Coordinate, int NumeroAbitanti, string AssessoreProvinciale, int NumeroComune) : base(Nome, Coordinate, NumeroAbitanti)
        {
            /* this.AssessoreProvinciale = AssessoreProvinciale;
             this.NumeroComune = NumeroComune;
             _nome = Nome;
             this._regione = regione;
             regione.AddProvincia(this);*/
            comune = new Comune(Nome);

        }

        public void changeComune(string Nome)
        {
            comune = new Comune(Nome);
        }
       /* public void addComune(Comune comune)
        {
            _comune = comune;
        }

        public void removeComune(Comune comune)
        {
            _comune = comune;
        }
        public string AssessoreProvinciale { get => _assessoreProvinciale; set => _assessoreProvinciale = value; }
        public int NumeroComune { get => _numeroComune; set => _numeroComune = value; }*/
    }

    class Comune
    {
        string _nome;
        Provincia _provincia;

        public Comune(string Nome)
        {
            _nome = Nome;   
                       
        }

       /* public void removeComune(string Nome)
        {
            _nome = null;
        }*/
        public void changeProvincia(Provincia provincia)
        {
            _provincia = provincia;
        }

    }
}

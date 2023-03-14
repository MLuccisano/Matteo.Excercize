using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Comune //: AreaGeografica
    {
        //string _municipio;
        //int _CAP;
        string _nome;
        Provincia _provincia;
        Abitanti _abitanti;

        public Comune(string Nome, Provincia provincia)//, string Coordinate, int NumeroAbitanti, int CAP, string Municipio) : base (Nome, Coordinate, NumeroAbitanti)
        {
            //this.Municipio = Municipio;
            //this.CAP = CAP;
            _nome = Nome;
            this._provincia = provincia;
            provincia.addComune(this);
        }

        public void addAbitanti(Abitanti abitanti)
        {
            _abitanti = abitanti;
        }
        public void removeAbitanti(Abitanti abitanti)
        {
            _abitanti = abitanti;
        }
        //public int CAP { get => _CAP; set => _CAP = value; }
        //public string Municipio { get => _municipio; set => _municipio = value; }

    }
}

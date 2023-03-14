using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    class Abitanti
    {
        string _nomeCompleto;
        string _cognome;
        string _CF;
        string _dataNascita;
        string _luogoNascita;
        Comune _comune;

        public Abitanti(string NomeCompleto, Comune comune) //(, string Cognome, )//, string CF, string DataNascita, string LuogoNascita)
        {

            _nomeCompleto = NomeCompleto;
            this._comune = comune;
            comune.addAbitanti(this);
            /* this.Nome = Nome;
             this.Cognome = Cognome;
             this.CF = CF;
             this.DataNascita = DataNascita;
             this.LuogoNascita = LuogoNascita;*/
        }

        
        /*public string Nome { get => _nome; set => _nome = value; }
public string Cognome { get => _cognome; set => _cognome = value; }
public string CF { get => _CF; set => _CF = value; }
public string DataNascita { get => _dataNascita; set => _dataNascita = value; }
public string LuogoNascita { get => _luogoNascita; set => _luogoNascita = value; }*/

    }
}

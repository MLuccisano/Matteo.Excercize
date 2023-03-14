using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class AreaGeografica
    {
        string _nome;
        string _coordinate;
        int _numeroAbitanti;

        public AreaGeografica(string Nome, string Coordinate, int NumeroAbitanti)
        {
            this._nome = Nome;
            this._coordinate = Coordinate;
            this._numeroAbitanti = NumeroAbitanti;

        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Coordinate { get => _coordinate; set => _coordinate = value; }
        public int NumeroAbitanti { get => _numeroAbitanti; set => _numeroAbitanti = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_Int
{
    internal abstract class PaeseEuropeo
    {
        string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public PaeseEuropeo(string Name)
        {
            this.Name = Name;
        }

        public abstract void DentroEuropaContinente(string nome);
    }
}

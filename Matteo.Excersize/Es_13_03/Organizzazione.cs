﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es_13_03
{
    internal class Organizzazione
    {
        string _nome;
        string _sede;
        string _presidente;
        string _regole;
        int _numeroDipendenti;
        Paese _paese;

        public Organizzazione(string Nome, string Sede, string Presidente, int NumeroDipendenti)
        {
            this.Nome = Nome;
            this.Sede = Sede;
            this.Presidente = Presidente;
            this.NumeroDipendenti = NumeroDipendenti;
        }

        public string Nome { get => _nome; set => _nome = value; }
        public string Sede { get => _sede; set => _sede = value; }
        public string Presidente { get => _presidente; set => _presidente = value; }
        public string Regole { get => _regole; set => _regole = value; }
        public int NumeroDipendenti { get => _numeroDipendenti; set => _numeroDipendenti = value; }
        internal Paese Paese { get => _paese; set => _paese = value; }

        public void AggiungiStato(Paese paese)
        {
            Paese = paese;
        }

    }
}

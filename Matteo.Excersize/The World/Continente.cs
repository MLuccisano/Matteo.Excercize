using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_World
{
    class Continente
    {
        Paese _paese;
        string _nomeContinente;
        public Continente(string NomeContinente)
        {
            _nomeContinente = NomeContinente;
        }

        private void AddPaese(Paese paese)
        {
            _paese = paese;
        }

        public void CreaPaese(string paese)
        {
            _paese = new Paese(paese);
        }

        public void changeContinente(Continente continente)
        {
            continente.AddPaese(_paese);
            _paese = null;
        }
        internal class Paese
        {
            Regione _regione;
            string _nomePaese;
            public Paese(string NomePaese)
            {
                _nomePaese = NomePaese;
            }

            private void addRegione(Regione regione)
            {
                _regione = regione;
            }

            public void creaRegione(string regione)
            {
                _regione = new Regione(regione);
            }

            public void changePaese (Paese paese)
            {
                paese.addRegione(_regione);
                _regione = null;
            }
        }
        internal class Regione
        {
            Provincia _provincia;
            string _nomeRegione;

            public Regione(string NomeRegione)
            {
                _nomeRegione = NomeRegione;
            }
            private void addProvincia(Provincia provincia)
            {
                _provincia = provincia;
            }

            public void creaProvincia(string provincia)
            {
                _provincia = new Provincia(provincia);
            }

            public void changeRegione(Regione regione)
            {
                regione.addProvincia(_provincia);
                _provincia = null;
            }
        }
            internal class Provincia
            {
                Comune _comune;
                string _nomeProvincia;

                public Provincia(string NomeProvincia)
                {
                    _nomeProvincia = NomeProvincia;
                }
                
                private void AddComune (Comune comune)
                {
                    _comune = comune;
                }
                public void creaComune(string comune)
                {
                    _comune = new Comune(comune);
                }

                public void changeProvincia(Provincia provincia)
                {
                    provincia.AddComune(_comune);
                    _comune = null;
                }
            }
            internal class Comune
            {
                string _nomeComune;
                public Comune(string NomeComune)
                {
                    _nomeComune = NomeComune;
                }
            }
        }

    }


}

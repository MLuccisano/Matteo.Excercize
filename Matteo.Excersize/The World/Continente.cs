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


        private void addPaese(Paese paese)
        {
            _paese = paese;
        }
        public void creaPaese(string paeseDest)
        {
            _paese = new Paese(paeseDest);
        }

        public void changePaese(string nomeContinenteDest)
        {
            Continente continene = new Continente(nomeContinenteDest);
            continene.addPaese(_paese);
            
        }

        public void creaRegione(string nomeRegioneDest)
        {
            _paese.creaRegione(nomeRegioneDest);
        }
        public void changeRegione(string nomeRegioneDest)
        {
            _paese.changeRegione(nomeRegioneDest);
        }

        public void creaProvincia(string nomeProvinciaDest)
        {
            _paese.CreaProvincia(nomeProvinciaDest);
        }

        public void changeProvincia(string nomeProvinciaDest)
        {
            _paese.changeProvincia(nomeProvinciaDest);
        }

        public void creaComune(string nomeComuneDest)
        {
            _paese.creaComune(nomeComuneDest);
        }

        public void changeComune(string nomeComuneDest, string nomeProvinciaDest)
        {
            _paese.changeComune(nomeComuneDest, nomeProvinciaDest);
        }
        /*public void ChangeComune (string nomeRegioneDest, string nomeProvinciaDest, string nomeComuneDest)
    {
         Paese paese = new Paese(paeseDest);        
        paese.ChangeComune(nomeRegioneDest, nomeProvinciaDest, nomeComuneDest, frase);           
    }*/

        class Paese
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
            public void creaRegione(string nomeRegione)
            {
                _regione = new Regione(nomeRegione);
            }

            public void changeRegione(string nomePaese)
            {
                Paese paese = new Paese(nomePaese);
                paese.addRegione(_regione);
                
            }

            public void CreaProvincia(string nomeRegione, string nomeProvincia)
            {
                _regione = new Regione(nomeRegione);        
                _regione.creaProvincia(nomeProvincia);
            }

            public void changeProvincia(string nomeRegione,string nomeProvincia)
            {
                Regione regione = new Regione(nomeRegione);
                regione.ChangeProvincia(nomeProvincia);
            }

            public void creaComune(string nomeRegione, string nomeProvincia, string nomeComune)
            {
                Regione regione = new Regione(nomeRegione);
                regione.creaComune(nomeComune, nomeProvincia);
            }
            public void changeComune(string nomeComune)
            {
                _regione.changeComune(nomeComune);
            }
            
            class Regione
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
                public void creaProvincia(string nomeProvincia)
                {
                    _provincia = new Provincia(nomeProvincia);    
                }
                public void ChangeProvincia(string nomeRegione)
                {
                    Regione regione = new Regione(nomeRegione);
                    regione.addProvincia(_provincia);
                    
                }

                public void creaComune(string nomeProvincia, string nomeComune)
                {
                    _provincia = new Provincia(nomeProvincia);
                    _provincia.creaComune(nomeComune);
                }

                public void changeComune(string nomeProvincia, string nomeComune)
                {
                    _provincia = new Provincia(nomeProvincia);
                    _provincia.ChangeComune(nomeComune);
                }

                class Provincia
                {
                    Comune _comune;
                    string _nomeProvincia;

                    public Provincia(string NomeProvincia)
                    {
                        _nomeProvincia = NomeProvincia;
                    }
                    private void AddComune(Comune comune)
                    {
                        _comune = comune;
                    }
                    public void creaComune(string nomeComuneDest)
                    {
                        _comune = new Comune(nomeComuneDest);
                    }

                    public void ChangeComune(string nomeComune)
                    {
                        _comune = new Comune(nomeComune);                
                    }
                }

                    class Comune
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
    }





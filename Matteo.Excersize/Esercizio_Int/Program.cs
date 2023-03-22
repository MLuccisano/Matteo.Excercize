using System;

namespace Esercizio_Int
{
    class Program
    {
        static void Main(string[] args)
        {
            /*PaeseEuropeo ucraina = new Ucraina("Ucraina");
            Brasile brasile = new Brasile();
            PaeseEuropeo bielorussa = new Bielorussa("Bielorussa");*/

            IUE italiaIUE = new Italia("Italia");
            BCE bce = new BCE();
            bce.CalcolaSpread(italiaIUE);
            


        }
    }
}

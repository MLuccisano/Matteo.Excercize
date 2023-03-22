using System;

namespace CodiceFiscale
{
    class Program
    {
        static void Main(string[] args)
        {
            IAgenziaEntrate italia = new Paese("Italia");
            Cittadino cittadino = new Cittadino("Matteo", "Luccisano");
            italia.calcolaCF(cittadino);
        }
    }
}

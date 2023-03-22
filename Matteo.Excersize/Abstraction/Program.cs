using System;

namespace Abstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*PaeseEuropeo italy = new Italy();
            PaeseEuropeo romania = new Romania();
            italy.Population = 60000000;
            romania.Population = 30000000;

            Console.WriteLine($"populaiton EU: {PaeseEuropeo.population}");*/
            IUE italy = new Italy();
            ApprovaNazione.approve(italy);

        }
    }

    //non può essere istanziata DIRETTAMENTE
    //Può un costruttore
    //può avere membri 
    // anche le properties possono essere di tipo ABSTRACT
    abstract class PaeseEuropeo
    {
        public static long population;// 
        public abstract long Population { get; set; }
        // The implemention  IS mandatory at least ti its first level!
        public abstract void GestionePermessodiSoggiorno(); //Contratto 


        //  L'implementazione non è Madantory! 
        public virtual void AreaSchengenRules()
        {
            Console.WriteLine("Libera circolazion dentro l'intera are se gia sei dentro! ");
        }
        public void DirittiUmani()
        {
            Console.WriteLine("Carta dei diritti umani! ");
        }



    }
    class Italy : PaeseEuropeo, IUE
    {
        public new long population;
        public override long Population
        {
            get
            { return this.population; }
            set
            {
                this.population = value;
                PaeseEuropeo.population += this.population;
            }
        }

        public void ApplyConstitution()
        {
            Console.WriteLine("Costituzione EU è stato integrato all'italia");
        }

        public sealed override void GestionePermessodiSoggiorno()
        {
            Console.WriteLine("Sto calcolando il codice per una persona italiana!");
        }
    }
    class SanMarino : Italy
    {
        //public override void GestionePermessodiSoggiorno()
        //{
        //    Console.WriteLine("Sto calcolando il codice per una persona di Sanmarino!");
        //}
    }
    class Romania : PaeseEuropeo
    {
        public new long population;
        public override long Population
        {
            get
            { return this.population; }
            set
            {
                this.population = value;
                PaeseEuropeo.population += this.population;
            }
        }

        public override void GestionePermessodiSoggiorno()
        {
            //Console.WriteLine("Sto calcolando il codice per una persona italiana!");
        }
        public override void AreaSchengenRules()
        {
            Console.WriteLine("Libera circolazion qui non è possibile! ");
        }

    }

    // non potra mai essere istanziata
    public interface IUE
    {
        public void ApplyConstitution();
    }

    public static class ApprovaNazione
    {
        public static void approve(IUE EU)
        {
            Console.WriteLine("Pazzesco sei nell'UE");
        }
    }
}

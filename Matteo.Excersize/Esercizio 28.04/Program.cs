﻿using System;
using System.Threading;

namespace Esercizio_28._04
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Matteo", "Luccisano", "ML1");
            Assicurazione assicurazione = new Assicurazione("Reale Mutua");
            EuDigitalWallet euDigitalWallet = new EuDigitalWallet(client, "ok");

            Intermediary.request();

            var response = Console.ReadLine();

            if (response.ToUpper() == "Y") Intermediary.confirm(assicurazione, euDigitalWallet.Clinical);
            else Console.WriteLine("Non hai consentito l'accesso ai tuoi dati e non puoi creare un piano assicurativo");



        }

        public class Client
        {
            string _name;
            string _surname;
            string _cf;

            public Client(string name, string surname, string cf)
            {
                _name = name;
                _surname = surname;
                _cf = cf;
            }                
        }

        public class Assicurazione : Intermediary
        {
            string _name;

            public Assicurazione(string name) 
            {
                _name = name;
            }

            public string createPlan(clinicalSituation datisanitari)
            {
                return string.Format($"I dati sanitari sono {datisanitari.Datisanitari}. Il nuovo piano è stato creato");
            }
        }

        public class EuDigitalWallet : Intermediary
        {
            clinicalSituation _clinical;
            public clinicalSituation Clinical { get => _clinical; }
            Client _client;
            public EuDigitalWallet(Client client, string datisanitari)
            {               
                _client = client;
                _clinical = new clinicalSituation(datisanitari);
                
            }

        }

        public class Intermediary
        {
            public class clinicalSituation
            {

                string _datisanitari;
                public string Datisanitari { get => _datisanitari; }
                public clinicalSituation(string datisanitari)
                {
                    _datisanitari = datisanitari;
                }
            }
            public static void request()
            {
                Console.WriteLine("Per creare un nuovo piano assicurativo, devi consentire l'accesso ai tuoi dati sanitari.\n premere Y per consentire, N per declinare.");
            }

            public static void confirm(Assicurazione assicurazione, clinicalSituation datisanitari)
            {
                
                Console.WriteLine("Ho accesso ai dati sanitari dell'utente");
                Thread.Sleep(1000);
                Console.WriteLine(string.Format(assicurazione.createPlan(datisanitari)));
            }
        }
    }
}

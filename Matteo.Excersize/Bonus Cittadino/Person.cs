using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Cittadino
{
    internal class Person
    {
        static int counter = 0;
        string _name;
        string _surname;
        int _age;
        bool _isAdult;
        decimal _bonus;
        decimal _pilComune;
        int _maturita;
        int _universita;
        bool _fedinaPenale;
        int _figli;
        bool _militare;
        bool _debiti;
        int _punteggio;
        bool _bonusRicevuto = false;
        bool _lavoro = true;


        public string Name { get { return _name; } }
        public string Surname { get { return _surname; } }
        public int Age { get { return _age; } set { _age = value; } }
        public decimal Bonus { get { return _bonus; } set { _bonus = value; _bonusRicevuto = true; } }
        public decimal PilComune { get { return _pilComune; } set { _pilComune = value; } }
        public int Maturita { get { return _maturita; } set { _maturita = value; } }
        public int Punteggio { get { return _punteggio; } set { _punteggio = value; } }
        public int Figli { get { return _figli; } set { _figli = value; } }
        public bool Debiti { get { return _debiti; } set { _debiti = value; } }
        public int Università { get { return _universita; } set { _universita = value; } }
        public bool FedinaPenale { get { return _fedinaPenale; } set { _fedinaPenale = value; } }
        public string FullName { get { return _name + " " + _surname; } }
        public bool IsAdult { get { return _isAdult; } set { _isAdult = value; } }

        public Person(
            string Name,
            string Surname,
            int Age,
            int Maturita,
            int Universita,
            bool FedinaPenale,
            int Figli,
            bool Militare,
            bool Debiti,
            decimal PilComune
            )
        {
            _name = Name;
            _surname = Surname;
            // variabili per il BONUS 
            this.Age = Age;
            this.Maturita = Maturita;
            _universita = Universita;
            _fedinaPenale = FedinaPenale;
            _figli = Figli;
            _militare = Militare;
            _debiti = Debiti;
            this.PilComune = PilComune;

            counter++;
            SetIsAdult();
            //CalcolaBonus();
        }
       /* public void GetValues()
        {
            Console.WriteLine($"Nome:{Name}");
            Console.WriteLine($"Cognome:{Surname}");
            Console.WriteLine($"Age:{this.Age}");
            Console.WriteLine($"Maturita:{this.Maturita}");
            Console.WriteLine($"Debiti:{Debiti}");
            Console.WriteLine($"Bonus ricevuto:{this.Bonus}");
        }*/

        public int GetCounter()
        {
            return counter;
        }

        private void SetIsAdult()
        {
            if (this.Age > 18)
            {
                IsAdult = true;
            }
            else
            {
                IsAdult = false;
            }
        }

        /*private void CalcolaBonus()
        {
            if (this.Maturita >= 90)
            {
                Punteggio += 7;
            }
            if (IsAdult && Age <= 28)
            {
                Punteggio += 6;
            }
            if (Università > 28)
            {
                Punteggio += 6;
            }
            if (Figli > 0)
            {
                for (int i = 0; i < Figli; i++)
                {
                    Punteggio += 4;
                }
            }
            if (!FedinaPenale)
            {
                Punteggio += 6;
            }
            if (!Debiti)
            {
                Punteggio += 6;
            }
            if (this.PilComune < 1000000)
            {
                Punteggio += 7;
            }
            if (Punteggio > IndiceBonus && IsAdult)
            {
                this.Bonus = 10000;
            }
        }*/
    }
}

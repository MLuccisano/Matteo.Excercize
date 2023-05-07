using System;

namespace Youtube
{
    class Program
    {
        static void Main(string[] args)
        {
            User naska = new User("Alberto Naska", "Naska");
            User Howard = new User("Matteo Luccisano", "Howard");
            User CookFace = new User("Pippo Baudo", "CookFace");
            User britishOld = new User("Jeremy Clarkson", "britishOld");
            User scrivaniaRotta = new User("Gerry Scotti", "scrivaniaRotta");
            User imOnFire = new User("Giovanna D'Arco", "imOnFire");
            User Anima = new User("Sascha Burci", "Anima");
            


            Howard.Subscribe(naska);
            CookFace.Subscribe(naska);
            britishOld.Subscribe(naska);
            scrivaniaRotta.Subscribe(naska);
            imOnFire.Subscribe(naska);

            Howard.Subscribe(Anima);
            britishOld.Subscribe(Anima);
        }
    }
}

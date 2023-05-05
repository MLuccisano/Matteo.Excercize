using System;

namespace Youtube
{
    class Program
    {
        static void Main(string[] args)
        {
            Youtuber naska = new Youtuber("Alberto Naska", "Naska");
            User Howard = new User("Matteo Luccisano", "Howard");
            User CookFace = new User("Pippo Baudo", "CookFace");
            User britishOld = new User("Jeremy Clarkson", "britishOld");
            User scrivaniaRotta = new User("Gerry Scotti", "scrivaniaRotta");
            User imOnFire = new User("Giovanna D'Arco", "imOnFire");


            Howard.subscribe(naska);
            CookFace.subscribe(naska);
            britishOld.subscribe(naska);
            scrivaniaRotta.subscribe(naska);
            imOnFire.subscribe(naska);
        }
    }
}

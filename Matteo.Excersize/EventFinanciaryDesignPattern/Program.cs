using System;

namespace EventFinanciaryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CentralBank bdi = new CentralBank("Banca D'Italia", "Matteo Luccisano");

            CommercialBank intesaSanpaolo = new CommercialBank("Intesa Sanpaolo", "Matteo Luccisano", bdi);
            CommercialBank unicredit = new CommercialBank("Unicredit", "Matteo Luccisano", bdi);
            CommercialBank BancaSella = new CommercialBank("Banca Sella", "Matteo Luccisano", bdi);

            bdi.Attach(intesaSanpaolo);
            bdi.Attach(unicredit);
            bdi.Attach(BancaSella);

            bdi.ChangeCeo("Giordano Bruno");
            bdi.Notify();
        }
    }
}

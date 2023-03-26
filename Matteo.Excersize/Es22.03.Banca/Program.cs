using System;

namespace Es22._03.Banca
{
    class Program
    {
        static void Main(string[] args)
        {
            SwiftCentralBank ecb = new SwiftCentralBank("European Central Bank", "Strabourg, Francia");
            CentralBank rcb = new CentralBank("Russian Central Bank", "Moscow, Russia");

        }
    }
}

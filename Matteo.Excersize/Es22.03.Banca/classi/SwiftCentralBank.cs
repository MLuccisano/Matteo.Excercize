using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es22._03.Banca
{
    class SwiftCentralBank : CentralBank, IswiftSystem
    {
        public SwiftCentralBank(string Name, string RegisteredOffice, string Country) : base(Name, RegisteredOffice, Country)
        {            
        }
        public void applySwift()
        {
            Console.WriteLine("This central bank has got a swift system");
        }
    }
}

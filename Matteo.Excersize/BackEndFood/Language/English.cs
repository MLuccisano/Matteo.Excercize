using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndDelivery.Language
{
    internal class English : ILanguage
    {
        internal English()
        {
            Console.WriteLine("Testo tradotto dall'Inglese all'Italiano");
        }
    }
}

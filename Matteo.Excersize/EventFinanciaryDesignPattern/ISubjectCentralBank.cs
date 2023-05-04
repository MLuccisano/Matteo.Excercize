using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciaryDesignPattern
{
    interface ISubjectCentralBank
    {
        public void Attach(CommercialBank commercialBank);
        public void Detach(CommercialBank commercialBank);
        public void Notify();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndDelivery
{   
    public class TranslationStore
    {
        
        TranslationStore _ts;
        string _name;
        string _city;



        public TranslationStore(string Name, string City)
        {
            _name = Name;
            _city = City;
        }

        internal TranslationStore Instance()
        {
            if (_ts == null) _ts = new TranslationStore(_name, _city);
            return _ts;

        }
        
    }
}

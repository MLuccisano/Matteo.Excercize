using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEndDelivery;

namespace Middleware
{
    class ClientFactory : AbstractFactory
    {
        TranslationStore ts;
        public override IFactory getFactory(ref char input)
        {
            switch (input)
            {
                case 'T':

                    if (ts == null) ts = new TranslationStore("Google Traduttore", "Mountain View");
                    return (IFactory)ts;
            }
            return null;
        }
    }
}

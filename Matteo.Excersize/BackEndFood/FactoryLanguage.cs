using BackEndDelivery.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndDelivery
{
    public class FactoryLanguage : IService
    {
        public ILanguage GetLanguage(int input)
        {
            switch (input)
            {
                case 1: return new English();
                case 2: return new German();
            }

            return null;
        }
    }
}

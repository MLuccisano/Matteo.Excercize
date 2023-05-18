using BackEndDelivery;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiddleWare
{
    public class ClientFactory
    {
        public static IService GetServices(ref char input)
        {
            if (input == 'Q') return null;
            var inputNum = CharUnicodeInfo.GetDecimalDigitValue(input);

            switch (inputNum)
            {
                case 1: return new FactoryLanguage();  
            }
        }
    }
}

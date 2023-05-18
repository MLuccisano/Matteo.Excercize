using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BackEndDelivery.Language
{
    public interface ILanguageFactory
    {
        ILanguage GetLanguage(int input);
    }
}

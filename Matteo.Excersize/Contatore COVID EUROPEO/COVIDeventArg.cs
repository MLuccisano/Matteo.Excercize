
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatore_COVID_EUROPEO
{
    class COVIDeventArg : EventArgs
    {
        int _peopleCovid;
        public bool cancel;

        public int PeopleCovid { get => _peopleCovid; }

        public COVIDeventArg(int PeopleCovid)
        {
            _peopleCovid = PeopleCovid;
        }
    }
}

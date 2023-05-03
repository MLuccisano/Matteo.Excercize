using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciary
{
    class ChangeCeoEventArgs : EventArgs
    {
        string _fullName;

        public string FullName { get => _fullName; set => _fullName = value; }

        public ChangeCeoEventArgs(string fullname)
        {
            _fullName = fullname;    
        }
    }
}

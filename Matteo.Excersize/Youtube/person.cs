using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    abstract public class person
    {
        string _fullname;
        string _username;
        public string Fullname { get => _fullname; }
        public string Username { get => _username; }

        public person(string fullname, string username)
        {
            _fullname = fullname;
            _username = username;
        }
    }

}

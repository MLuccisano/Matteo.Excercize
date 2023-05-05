using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    abstract class person
    {
        string _fullname;
        string _username;
        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Username { get => _username; set => _username = value; }

        public person(string fullname, string username)
        {
            _fullname = fullname;
            _username = username;
        }
    }

}

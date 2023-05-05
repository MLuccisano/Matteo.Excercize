using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    class SubscriberEventArgs : EventArgs
    {
        string _username;
        public string Username { get => _username; set => _username = value; }

        public SubscriberEventArgs(string username)
        {
            _username = username;
        }
    }
}

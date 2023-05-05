using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    class User : person, IUser
    {
        public User(string fullname, string username) : base(fullname, username)
        {
            
        }

        public void subscribe(Youtuber youtuber)
        {
            youtuber.Notify();
            youtuber.ListFollower.Add(this);
        }

        public void update(Youtuber youtuber)
        {
            Console.WriteLine($"NOTIFICA PER {Username}: un nuovo membro si è iscrito al canale di {youtuber.Username}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    class Youtuber : person, IYoutuber
    {
        List<User> listFollower;

        public List<User> ListFollower { get => listFollower; }

        public Youtuber(string fullname, string username) : base(fullname, username)
        {
            listFollower = new List<User>();
        }

        public void Notify()
        {
            foreach (User user in listFollower)
            {
                user.update(this);
            }
            Console.WriteLine("\n-------------------------------------------------------------\n");
        }
    }

}

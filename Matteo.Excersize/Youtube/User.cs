using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    public class User : person, IUser
    {
        List<User> listFollower;
        public User(string fullname, string username) : base(fullname, username)
        {
            listFollower = new List<User>();    
        }
        public void Subscribe(User user)
        {
            Notify(user);
            user.listFollower.Add(this);           
        }

        public void Notify(User user)
        {
            foreach (var follower in user.listFollower)
            {
                Console.WriteLine($"NOTIFICA PER {follower.Username.ToUpper()}: Si è iscritto {this.Username} al canale di {user.Username}\n ");                
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------\n");
        }

    }
}

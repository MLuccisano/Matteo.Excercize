using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
    interface IUser
    {
        public void subscribe(Youtuber youtuber);
        public void update(Youtuber youtuber);
    }
}

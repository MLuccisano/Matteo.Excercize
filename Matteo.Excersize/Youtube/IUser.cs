﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube
{
   public interface IUser
    {
         public void Subscribe(User user);
         public void Notify(User user);
    }
}

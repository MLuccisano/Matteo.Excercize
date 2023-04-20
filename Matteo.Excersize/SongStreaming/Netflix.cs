using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongStreaming
{
    public sealed class Netflix : StreamingPlatform
    {
        public Netflix()
        {
            files = new NetflixVideo[] {
                new NetflixVideo(){ title ="Titanic",Color = System.ConsoleColor.Blue},
                new NetflixVideo(){ title ="Terminator", Color = System.ConsoleColor.Cyan},
                new NetflixVideo(){ title ="Alien", Color = System.ConsoleColor.Green},
                new NetflixVideo(){ title ="Avatar", Color = System.ConsoleColor.Yellow}

                };

            totalTacks = files.Length;
            multimedia = "film";
        }
        private class NetflixVideo : Video
        {
            public NetflixVideo()
            {
            }
        }
    }
}

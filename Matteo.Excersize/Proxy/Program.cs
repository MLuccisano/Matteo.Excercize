using System;
using System.Collections.Generic;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy1 = Proxy.Instance();

            Console.WriteLine("La lista degli ip disponibili del server proxy1:\n");
            CallIP(proxy1);
            
            Proxy proxy2 = Proxy.Instance();
            Console.WriteLine("Il server Proxy2 chiama la lista degli IP, la quale deve contenere gli ip uguali alla lista precedente\n");

            CallIP(proxy2);
            

        }

        public static void CallIP (Proxy p)
        {
            p.GetListIp();
            Console.WriteLine("---------------------------------------------------------\n");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Chiamata all'IP {p.GetIP()}");
                Thread.Sleep(500);
            }
            Console.WriteLine("---------------------------------------------------------\n");
        }

        public class Proxy
        {
            static Proxy serverProxy;
            Random random = new Random();
            List<int> listIp = new List<int>();
            protected Proxy()
            { 
                
                for (int i = 0; i < 4; i++)
                {
                    int ip = random.Next(1, 100);
                    listIp.Add(ip);                    
                }
            }

            public static Proxy Instance()
            {
                if (serverProxy == null) serverProxy = new Proxy();
                return serverProxy;
            }

            public void GetListIp()
            {
                for (int i = 0; i < listIp.Count; i++)
                {
                    Console.WriteLine($"IP: {listIp[i]}");
                }
            }

            public int GetIP()
            {
                int position = random.Next(0, listIp.Count);
                return listIp[position];
            }
        }
    }
}

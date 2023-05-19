using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationJudgeToOfficeManager
{
    internal class OfficeManager
    {
        string _fullName;
        public string FullName { get => _fullName; }
        internal OfficeManager(string FullName)
        {
            _fullName = FullName;   
        }

        internal void ChoiceFactory(ref char input)
        {
            Console.Clear();
            switch (input)
            {
                case 'T': 
            }
        }
    }
}

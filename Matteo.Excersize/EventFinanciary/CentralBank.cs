using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciary
{
    class CentralBank
    {
        string _nameCentralBank;
        public string NameCentralBank { get => _nameCentralBank; }
        CEO _ceo;

        public CEO Ceo 
        {
            get => _ceo;
            set
            {
                if (Ceo != value)
                {
                    ChangeCeoEventArgs e = new ChangeCeoEventArgs(value.FullName);
                    ChangeCEOHandler(this, e);
                    _ceo = value;
                }
            }
                
        }

        public delegate void ChangeCeoEventHandler(object sender, ChangeCeoEventArgs e);
        public event ChangeCeoEventHandler ChangeCEOHandler;
        public CentralBank(string nameIF, string fullName)
        {
            _nameCentralBank = nameIF;
            _ceo = new CEO(fullName);
        }



        public class CEO
        {
            string _fullName;
           
            public string FullName { get => _fullName; set => _fullName = value; }

            public CEO(string fullName)
            {
                _fullName = fullName;
            }
        }

        public void ChangeCeo(string fullname)
        {
            Ceo = new CEO(fullname);
        }

        public virtual void EventChangeCeo(object sender, ChangeCeoEventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFinanciaryDesignPattern
{
    internal class CentralBank : bank,  ISubjectCentralBank
    {
        string _nameCentralBank;
        public string NameCentralBank { get => _nameCentralBank; }
        CEO _ceo;

        public CEO Ceo { get => _ceo; set => _ceo = value; }

        public CentralBank(string nameIF, string fullName) : base(nameIF, fullName)
        {
            _nameCentralBank = nameIF;
            _ceo = new CEO(fullName);
        }

       internal class CEO
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

        List<CommercialBank> listCommercialBanks = new List<CommercialBank>();

        public void Attach(CommercialBank commercialBank)
        {
            listCommercialBanks.Add(commercialBank);
        }

        public void Detach(CommercialBank commercialBank)
        {
            listCommercialBanks.Remove(commercialBank);
        }
        public void Notify()
        {
            foreach (CommercialBank commercialBank in listCommercialBanks)
            {
                commercialBank.Update();
            }
        }
    }



}

namespace TEST.OOP.BankAccount.Abstract
{
    abstract class Bank : FinancialIntermediary
    {

        public string Name { get => _name; }
        public string Country { get => _country; }

        public Bank(string city, string country, string name) : base (city, country, name)
        {

        }

        public virtual bool Transfer(Bank to, FIATDespositRequest data)
        {
            return false;
        }
    }

}


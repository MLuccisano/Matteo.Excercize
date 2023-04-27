using System;

namespace EsercizioDelegate
{
    class Program
    {
        public delegate int sumNumber(int num1, int num2);
        static void Main(string[] args)
        {

            numbers nums = new numbers(100, 200);
            int n1 = nums.getNumbers1();
            int n2 = nums.getNumbers2();
            
            sumNumber sum = (num1, num2) => num1 + num2;

            Func<sumNumber,int,int, int> operazioneSomma = (somma, num1, num2) =>
            {
                int result = somma(num1, num2);
                return result;
            };

            int somma = operazioneSomma(sum, n1, n2);

            Predicate<int> result = delegate (int somma)
            {
                 return somma > 100 ? true : false;               
            };

            bool checkisMajor = result(somma);

            Action<bool> output = (bool checkisMajor) =>
            {
                if (checkisMajor) Console.WriteLine("ok!");
            };

            output(checkisMajor);

        }
        #region costruttore numeri
        class numbers
        {
            int _num1;
            int _num2;
            public numbers(int num1, int num2)
            {
                _num1 = num1;
                _num2 = num2;
            }

            public int getNumbers1()
            {
                return _num1;
            }

            public int getNumbers2()
            {
                return _num2;
            }
        }
        #endregion
    }
}

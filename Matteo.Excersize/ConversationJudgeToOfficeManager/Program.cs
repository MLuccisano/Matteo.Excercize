using System.Globalization;
using System;

namespace ConversationJudgeToOfficeManager
{
    class Program
    {
        
        static void Main(string[] args)
        {
            OfficeManager officeManager = new("Mario Rossi");
            Action<char> choiceFactory = delegate (char input) { officeManager.ChoiceFactory(ref input); };
            char input;

            do
            {
                Console.WriteLine("Scegli la tipologia");
                input = char.ToUpper(Console.ReadKey().KeyChar);
                int inputNumber = CharUnicodeInfo.GetDecimalDigitValue(input);

                switch (input)
                {
                    case 'T':
                        choiceFactory(input);
                        break;
                    case 'C':
                        choiceFactory(input);
                        break;
                    case 'Q':
                        break;
                }
            } while (input != 'Q');
        }
    }
} 

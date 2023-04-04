using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TEST.OOP.BankAccount;
using TEST.OOP.BankAccount.Abstract;
using TEST.OOP.BankAccount.Enum;

namespace TEST.OOP.BankAccount
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //  BANCHE CENTRALI DI RIFERIMENTO 
            CentralBank RussianCentralBank = new CentralBank("Russia Central Bank", "Russia", 5);
            CentralBank BancaDitalia = new SwiftCentralBank("Banca D'Italia", "Italia", 3);



            //  BORSE DI RIFERIEMENTO COMMERCIALI 
            StockMarket borsaDiMosca = new StockMarket("Moscow", "Russia", "Moscow");
            StockMarket WallStreet = new StockMarket("NY", "USA", "WallStreet");

            CryptoExchange binance = new CryptoExchange("Mahé", "Isole Cayman", "Binance");
            




            //  BANCHE COMMERCIALI 
            CommertialBank SberBank = new CommertialBank("Moscow", "SberBank", "Russia", RussianCentralBank, borsaDiMosca, binance);
            CommertialBank Unicredit = new CommertialBank("Milano", "Unicredit", "Italy", BancaDitalia, WallStreet, binance);

            // Crea un conto Corrente e deposita dentro un dei soldi 
            SberBank.CreateAccount("Vladimir Putin", "NO DATA");
            SberBank.DepositFiat(100000M);
            SberBank.DepositCrypto(4);

            //SberBank.InvestInStock(STOCK.TESLA, 1);


            // Crea un conto Corrente con saldo zero
            Unicredit.CreateAccount("Bruno Ferreira", "FRBBRIIM394NFNNF");


            // Stampa Saldo iniziale dei due conti  
            Console.WriteLine("-------------------------------------- SALDO INIZIALE -------------------");

            Console.WriteLine($" L'account di Vladimir Putin ha un credito di :  {SberBank.account.Balance}");
            Console.WriteLine($" L'account di Bruno Ferreira ha un credito di :  {Unicredit.account.Balance}");
            Console.WriteLine("-------------------------------------------------------------------------------");


            /*bool result = SberBank.Transfer(Unicredit, new FIATDespositRequest() { _amount = 1000M, _accountfrom = 5548485187, _accountTo = 1112355477 });

            if (!result)
            {
                Console.WriteLine("Amount not Transfered! ");
                return;// Fine Programma! 
            }*/


            // Stampa Saldo Fianale dei due conti  
            Console.WriteLine("-------------------------------------- SALDO FINALE -------------------");

            Console.WriteLine($" L'account di Vladimir Putin ha un credito di :  {SberBank.account.Balance}");
            Console.WriteLine($" L'account di Bruno Ferreira ha un credito di :  {Unicredit.account.Balance}");
            Console.WriteLine("-------------------------------------------------------------------------------");


            Console.ResetColor();

            // Show After before Transfer  

            Console.ReadLine();


        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankCore.Models;
using BankCore.Repositories;
using BankCore.Services;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new RealConsole();
            var clock = new Clock();
            var transactionRepository = new TransactionRepository(clock);
            var statementPrinter = new StatementPrinter(console);
            var account = new Account(transactionRepository, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();
            Console.ReadLine();
        }

        public class RealConsole : TestConsole
        {
            public override void PrintLine(string text)
            {
                Console.WriteLine(text);
            }
        }
    }
}

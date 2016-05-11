using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BankCore.Models;

namespace BankCore.Services
{
    public class StatementPrinter
    {
        private readonly TestConsole _console;
        private readonly List<string> _transactionStrings;

        public StatementPrinter(TestConsole console)
        {
            _console = console;
            _transactionStrings = new List<String>();
        }

        public List<string> TransactionStrings
        {
            get { return new List<string>(_transactionStrings.AsReadOnly()); }
        }

        public virtual void Print(List<Transaction> initialTransactions)
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");

            var tempBalance = 0;

            foreach (var transaction in initialTransactions.OrderBy(T=>Convert.ToDateTime(T.Date)))
            {
                _transactionStrings.Add(transaction.Date + " | " + transaction.Amount.ToString("F2") + " | " + (tempBalance += transaction.Amount).ToString("F2"));
            }

            _transactionStrings.Reverse();

            foreach (var transactionString in _transactionStrings)
            {
                _console.PrintLine(transactionString);
            }
        }
    }
}
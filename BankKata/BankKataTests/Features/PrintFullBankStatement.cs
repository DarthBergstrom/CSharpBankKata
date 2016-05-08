using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Moq;
using BankCore.Models;
using BankCore.Repositories;
using BankCore.Services;
using BankCore;

namespace BankKataTests
{
    [TestFixture]
    public class PrintBankStatementFeature
    {
        [Test]
        public void Print_Statement_Containing_All_Transactions()
        {
            var mockConsole = new Mock<TestConsole>();
            var mockClock = new Mock<Clock>();
            var transactionRepository = new TransactionRepository(mockClock.Object);
            var statementPrinter = new StatementPrinter();
            var account = new Account(transactionRepository, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(500);
            account.Deposit(500);

            account.PrintStatement();

            mockConsole.Verify(self => self.PrintLine("DATE | AMOUNT | BALANCE"));
            mockConsole.Verify(self=>self.PrintLine("10 / 04 / 2014 | 500.00 | 1400.00"));
            mockConsole.Verify(self=>self.PrintLine("02 / 04 / 2014 | -100.00 | 900.00"));
            mockConsole.Verify(self=>self.PrintLine("01 / 04 / 2014 | 1000.00 | 1000.00"));
        }
    }
}

using System.Collections.Generic;
using BankCore.Models;
using BankCore.Services;
using Moq;
using NUnit.Framework;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private const string StatementHeader = "DATE | AMOUNT | BALANCE";

        [Test]
        public void Always_Print_A_Header()
        {
            var mockConsole = new Mock<TestConsole>();
            var noTransactions = new List<Transaction>();
            var statementPrinter = new StatementPrinter(mockConsole.Object);

            statementPrinter.Print(noTransactions);

            mockConsole.Verify(self => self.PrintLine(StatementHeader));
        }

        [Test]
        public void Calculate_Balance_From_Transactions_In_Cronological_Order()
        {
            var mockConsole = new Mock<TestConsole>();
            var transactions = new List<Transaction>()
                                 {
                                     Deposit("10/04/2014",50),
                                     Withdrawl("11/04/2014",5),
                                     Deposit("2/04/2014",4),
                                     Deposit("3/04/2014",500)
                                 };
            var statementPrinter = new StatementPrinter(mockConsole.Object);

            statementPrinter.Print(transactions);

            mockConsole.Verify(self => self.PrintLine(StatementHeader));
            mockConsole.Verify(self => self.PrintLine("11/04/2014 | -5.00 | 549.00"));
            Assert.That(statementPrinter.TransactionStrings[0], Is.EqualTo("11/04/2014 | -5.00 | 549.00"));
            
        }

        private Transaction Withdrawl(string date, int amount)
        {
            return new Transaction(date, -amount);
        }

        private Transaction Deposit(string date, int amount)
        {
            return new Transaction(date, amount);
        }
    }
}

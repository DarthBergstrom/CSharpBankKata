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
        private Mock<BaseConsole> _mockConsole;
        private List<Transaction> _emptyListOfTransactions;
        private List<Transaction> _listWithTransactions;
        private const string StatementHeader = "DATE | AMOUNT | BALANCE";

        [TestFixtureSetUp]
        public void Init()
        {
            _mockConsole = new Mock<BaseConsole>();
            _emptyListOfTransactions = new List<Transaction>();
            _listWithTransactions = new List<Transaction>()
                                    {
                                        Deposit("10/04/2014",50),
                                        Withdrawl("11/04/2014",5),
                                        Deposit("2/04/2014",4),
                                        Deposit("3/04/2014",500)
                                    };
        }

        [Test]
        public void Always_Print_A_Header()
        {
            var statementPrinter = new StatementPrinter(_mockConsole.Object);

            statementPrinter.Print(_emptyListOfTransactions);

            _mockConsole.Verify(self => self.PrintLine(StatementHeader));
        }

        [Test]
        public void Calculate_Balance_From_Transactions_In_Cronological_Order()
        {
            var statementPrinter = new StatementPrinter(_mockConsole.Object);

            statementPrinter.Print(_listWithTransactions);

            _mockConsole.Verify(self => self.PrintLine(StatementHeader));
            _mockConsole.Verify(self => self.PrintLine("11/04/2014 | -5.00 | 549.00"));
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

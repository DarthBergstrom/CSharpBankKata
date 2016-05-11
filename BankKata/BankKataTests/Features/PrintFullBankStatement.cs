using BankCore;
using BankCore.Models;
using BankCore.Repositories;
using BankCore.Services;
using Moq;
using NUnit.Framework;

namespace BankKataTests.Features
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
            var statementPrinter = new StatementPrinter(mockConsole.Object);
            var account = new Account(transactionRepository, statementPrinter);

            mockClock.Setup(self => self.TodayAsString()).Returns(() => "01/04/2014");  
            account.Deposit(1000);

            mockClock.Setup(self => self.TodayAsString()).Returns(() => "02/04/2014");
            account.Withdraw(100);

            mockClock.Setup(self => self.TodayAsString()).Returns(() => "10/04/2014");
            account.Deposit(500);

            account.PrintStatement();

            mockConsole.Verify(self => self.PrintLine("DATE | AMOUNT | BALANCE"));
            mockConsole.Verify(self=>self.PrintLine("10/04/2014 | 500.00 | 1400.00"));
            mockConsole.Verify(self=>self.PrintLine("02/04/2014 | -100.00 | 900.00"));
            mockConsole.Verify(self=>self.PrintLine("01/04/2014 | 1000.00 | 1000.00"));
        }
    }
}

using NUnit.Framework;
using Moq;
using BankCore.Models;
using BankCore.Services;
using System.Collections.Generic;
using BankCore.Repositories;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<TransactionRepository> _mockTransactionRepository;
        private Mock<StatementPrinter> _mockStatementPrinter;
        private Account _account;
        private Mock<Clock> _mockClock;
        private Mock<BaseConsole> _mockConsole;

        [SetUp]
        public void Init()
        {
            _mockClock = new Mock<Clock>();
            _mockConsole = new Mock<BaseConsole>();
            _mockTransactionRepository = new Mock<TransactionRepository>(_mockClock.Object);
            _mockStatementPrinter = new Mock<StatementPrinter>(_mockConsole.Object);
            _account = new Account(_mockTransactionRepository.Object, _mockStatementPrinter.Object);
        }

        [Test]
        public void Store_A_Deposit_Transaction()
        {
            _account.Deposit(100);

            _mockTransactionRepository.Verify(accountClassCalls => accountClassCalls.AddDeposit(100));
        }

        [Test]
        public void Store_A_Withdrawal_Transaction()
        {
            _account.Withdraw(100);

            _mockTransactionRepository.Verify(accountClassCalls => accountClassCalls.AddWithdrawal(100));
        }

        [Test]
        public void Print_A_Statment()
        {
            var emptyListOfTransactions = new List<Transaction>();
            _mockTransactionRepository
                .Setup(self => self.AllTransactions())
                .Returns(()=>emptyListOfTransactions);

            _account.PrintStatement();

            _mockStatementPrinter.Verify(accountClassCalls => accountClassCalls.Print(emptyListOfTransactions));
        }
    }
}

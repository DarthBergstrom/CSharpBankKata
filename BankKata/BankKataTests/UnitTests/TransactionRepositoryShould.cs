using NUnit.Framework;
using BankCore.Models;
using Moq;
using BankCore.Repositories;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private TransactionRepository _transactionRepository;
        private Mock<Clock> _mockClock;
        private const string Today = "12/05/2015";

        [SetUp]
        public void Init()
        {
            _mockClock = new Mock<Clock>();
            _transactionRepository = new TransactionRepository(_mockClock.Object);
            _mockClock.Setup(self => self.TodayAsString()).Returns(() => Today);
        }

        [Test]
        public void Create_And_Store_A_Deposit_Transaction()
        {
            _transactionRepository.AddDeposit(100);
            var transactions = _transactionRepository.AllTransactions();
            
            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0], Is.EqualTo(Transaction(Today, 100)));
        }

        [Test]
        public void Create_And_Store_A_Withdrawal_Transaction()
        {
            _transactionRepository.AddWithdrawal(100);
            var transactions = _transactionRepository.AllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0], Is.EqualTo(Transaction(Today, -100)));
        }

        private Transaction Transaction(string date, int amount)
        {
            return new Transaction(date, amount);
        }
    }
}

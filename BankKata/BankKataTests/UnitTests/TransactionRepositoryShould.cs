using System;
using NUnit.Framework;
using BankCore.Repositories;
using BankCore.Models;
using Moq;
using BankCore;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class TransactionRepositoryShould
    {
        private TransactionRepository transactionRepository;
        private Mock<Clock> mockClock;
        private const string TODAY = "12/05/2015";

        [TestFixtureSetUp]
        public void Init()
        {
            transactionRepository = new TransactionRepository();

        }

        [Test]
        public void Create_and_store_a_Deposit_Transaction()
        {
            mockClock.Setup(self => self.TodayAsString()).Returns(() => TODAY);

            transactionRepository.AddDeposit(100);
            var transactions = transactionRepository.AllTransactions();
            
            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0], Is.EqualTo(transaction(TODAY, 100)));
        }

        private Transaction transaction(string date, int amount)
        {
            return new Transaction(date, amount);
        }
    }
}

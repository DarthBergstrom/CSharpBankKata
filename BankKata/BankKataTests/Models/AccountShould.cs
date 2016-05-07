using System;
using NUnit.Framework;
using Moq;
using BankCore.Models;
using BankCore.Repositories;

namespace BankKataTests.Models
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void store_a_transaction()
        {
            var transactionRepository = new Mock<TransactionRepository>();
            var account = new Account(transactionRepository.Object);

            account.Deposit(100);

            transactionRepository.Verify(self => self.AddDeposit(100));
        }
    }
}

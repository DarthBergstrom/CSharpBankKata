using System;
using NUnit.Framework;
using Moq;
using BankCore.Models;
using BankCore.Repositories;
using BankCore.Services;
using System.Collections.Generic;
using BankCore;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        private Mock<TransactionRepository> mockTransactionRepository;
        private Mock<StatementPrinter> mockStatementPrinter;
        private Account account;

        [TestFixtureSetUp]
        public void init()
        {
            mockTransactionRepository = new Mock<TransactionRepository>();
            mockStatementPrinter = new Mock<StatementPrinter>();
            account = new Account(mockTransactionRepository.Object, mockStatementPrinter.Object);
        }

        [Test]
        public void store_a_deposit_transaction()
        {
            account.Deposit(100);

            mockTransactionRepository.Verify(self => self.AddDeposit(100));
        }

        [Test]
        public void store_a_withdrawal_transaction()
        {
            account.Withdraw(100);

            mockTransactionRepository.Verify(self => self.AddWithdrawal(100));
        }

        [Test]
        public void print_a_statment()
        {
            var transactions = new List<Transaction>();
            mockTransactionRepository
                .Setup(self => self.AllTransactions())
                .Returns(()=>transactions);

            account.PrintStatement();

            mockStatementPrinter.Verify(self => self.Print(transactions));
        }
    }
}

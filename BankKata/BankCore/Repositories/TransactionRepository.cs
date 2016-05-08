using BankCore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankCore.Repositories
{
    public class TransactionRepository
    {
        private Clock Clock;
        private List<Transaction> transactions;

        public TransactionRepository(Clock clock)
        {
            Clock = clock;
            transactions = new List<Transaction>();
        }

        public virtual void AddDeposit(int amount)
        {
            var depositTransaction = new Transaction(Clock.TodayAsString(), amount);
            transactions.Add(depositTransaction);
        }

        public virtual void AddWithdrawal(int amount)
        {
            var withdrawalTransaction = new Transaction(Clock.TodayAsString(), -amount);
            transactions.Add(withdrawalTransaction);
        }

        public virtual List<Transaction> AllTransactions()
        {
            return new List<Transaction>(transactions.AsReadOnly());
        }
    }
}
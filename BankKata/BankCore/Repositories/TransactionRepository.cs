using BankCore.Models;
using System;
using System.Collections.Generic;

namespace BankCore.Repositories
{
    public class TransactionRepository
    {
        public virtual void AddDeposit(int amount)
        {
            throw new NotImplementedException();
        }

        public virtual void AddWithdrawal(int amount)
        {
            throw new NotImplementedException();
        }

        public virtual List<Transaction> AllTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
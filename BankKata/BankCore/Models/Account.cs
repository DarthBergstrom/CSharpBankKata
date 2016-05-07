using BankCore.Repositories;
using System;

namespace BankCore.Models
{
    public class Account
    {
        private TransactionRepository transactionRepository;

        public Account(TransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        public void Deposit(int amount)
        {
            transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            
        }

        public void PrintStatement()
        {
            
        }
    }
}
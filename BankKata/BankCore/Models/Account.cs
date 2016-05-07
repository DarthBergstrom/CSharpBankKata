using BankCore.Repositories;
using BankCore.Services;
using System;

namespace BankCore.Models
{
    public class Account
    {
        private TransactionRepository transactionRepository;
        private StatementPrinter statementPrinter;

        public Account(TransactionRepository transactionRepository, StatementPrinter statementPrinter)
        {
            this.transactionRepository = transactionRepository;
            this.statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            transactionRepository.AddDeposit(amount);
        }

        public void Withdraw(int amount)
        {
            transactionRepository.AddWithdrawal(amount);
        }

        public void PrintStatement()
        {
            statementPrinter.Print(transactionRepository.AllTransactions());
        }
    }
}
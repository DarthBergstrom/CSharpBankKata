Public Class Account
    ReadOnly _transactionRepository As TransactionRepository
    ReadOnly _statementPrinter As StatementPrinter

    Sub New(transactionRepository As TransactionRepository, statementPrinter As StatementPrinter)
        _transactionRepository = transactionRepository
        _statementPrinter = statementPrinter
    End Sub

    Sub Deposit(amount As Integer)
        _transactionRepository.AddDeposit(amount)
    End Sub

    Sub Withdraw(amount As Integer)
        _transactionRepository.AddWithdrawal(amount)
    End Sub

    Sub PrintStatement()
        _statementPrinter.Print(_transactionRepository.AllTransactions())
    End Sub
End Class

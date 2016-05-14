Public Class TransactionRepository
    Private ReadOnly _clock As Clock
    Private ReadOnly _transactions As List(Of BankCoreVBNetEdition.Transaction)

    Public Sub New(clock As Clock)
        _clock = clock
        _transactions = New List(Of BankCoreVBNetEdition.Transaction)
    End Sub

    Public Overridable Sub AddDeposit(amount As Integer)
        Dim depositTransaction = New BankCoreVBNetEdition.Transaction(_clock.TodayAsString(), amount)
        _transactions.Add(depositTransaction)
    End Sub

    Public Overridable Function AllTransactions() As List(Of BankCoreVBNetEdition.Transaction)
        Return New List(Of BankCoreVBNetEdition.Transaction)(_transactions.AsReadOnly())
    End Function

    Public Overridable Sub AddWithdrawal(amount As Integer)
        Dim withdrawalTransaction = New BankCoreVBNetEdition.Transaction(_clock.TodayAsString(), -amount)
        _transactions.Add(withdrawalTransaction)
    End Sub
End Class
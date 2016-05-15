Public Class StatementPrinter

    Private ReadOnly _console As BaseConsole
    Private ReadOnly _transactionStrings As List(Of String)

    Public Sub New(console As BaseConsole)

        _console = console
        _transactionStrings = New List(Of String)()

    End Sub

    Public ReadOnly Property TransactionStrings As List(Of String)
        Get
            Return New List(Of String)(_transactionStrings.AsReadOnly())
        End Get
    End Property

    Public Overridable Sub Print(initialTransactions As List(Of Transaction))
        _console.PrintLine("DATE | AMOUNT | BALANCE")

        Dim runningBalance As Integer

        For Each transaction As Transaction In initialTransactions.OrderBy(Function(T) Convert.ToDateTime(T.Date))
            runningBalance += transaction.Amount
            _transactionStrings.Add(transaction.Date + " | " + transaction.Amount.ToString("F2") + " | " + runningBalance.ToString("F2"))
        Next

        _transactionStrings.Reverse()

        For Each transactionString As String In _transactionStrings
            _console.PrintLine(transactionString)
        Next

    End Sub
End Class
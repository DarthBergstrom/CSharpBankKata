Imports BankCoreVBNetEdition
Imports Moq
Imports NUnit.Framework

Namespace UnitTests

    <TestFixture()>
    Public Class StatementPrinterShould

        Private _mockConsole As Mock(Of BaseConsole)
        Private _emptyListOfTransactions As List(Of Transaction)
        Private _listWithTransactions As List(Of Transaction)
        Private Const StatementHeader As String = "DATE | AMOUNT | BALANCE"

        <TestFixtureSetUp()>
        Public Sub InitializeOnceForTests()
            _mockConsole = New Mock(Of BaseConsole)()
            _emptyListOfTransactions = New List(Of Transaction)()
            _listWithTransactions = New List(Of Transaction)(New Transaction() {
                Deposit("10/04/2014", 50),
                Withdrawl("11/04/2014", 5),
                Deposit("2/04/2014", 4),
                Deposit("3/04/2014", 500)
            })

        End Sub

        <Test()>
        Public Sub Always_Print_A_Header()
            Dim statementPrinter = New StatementPrinter(_mockConsole.Object)

            statementPrinter.Print(_emptyListOfTransactions)

            _mockConsole.Verify(Sub(self) self.PrintLine(StatementHeader))
        End Sub

        <Test()>
        Public Sub Calculate_Balance_From_Transaction_In_Cronological_Order()
            Dim statementPrinter = New StatementPrinter(_mockConsole.Object)

            statementPrinter.Print(_listWithTransactions)

            _mockConsole.Verify(Sub(self) self.PrintLine(StatementHeader))
            _mockConsole.Verify(Sub(self) self.PrintLine("11/04/2014 | -5.00 | 549.00"))
            Assert.That(statementPrinter.TransactionStrings(0), [Is].EqualTo("11/04/2014 | -5.00 | 549.00"))
        End Sub

        Private Function Withdrawl([date] As String, amount As Integer) As Transaction
            Return New Transaction([date], -amount)
        End Function

        Private Function Deposit([date] As String, amount As Integer) As Transaction
            Return New Transaction([date], amount)
        End Function
    End Class
End Namespace
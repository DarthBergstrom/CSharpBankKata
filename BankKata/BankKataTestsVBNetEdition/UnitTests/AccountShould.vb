Imports NUnit.Framework
Imports Moq
Imports BankCoreVBNetEdition

Namespace UnitTests

    <TestFixture()>
    Public Class AccountShould
        Private _account As Account
        Private _mockTransactionRepository As Mock(Of TransactionRepository)
        Private _mockStatementPrinter As Mock(Of StatementPrinter)
        Private _mockClock As Mock(Of Clock)
        Private _mockConsole As Mock(Of BaseConsole)

        <TestFixtureSetUp()>
        Sub Init()
            _mockClock = New Mock(Of Clock)
            _mockConsole = New Mock(Of BaseConsole)
            _mockTransactionRepository = New Mock(Of TransactionRepository)(_mockClock.Object)
            _mockStatementPrinter = New Mock(Of StatementPrinter)(_mockConsole.Object)
            _account = New Account(_mockTransactionRepository.Object, _mockStatementPrinter.Object)
        End Sub

        <Test()>
        Public Sub Store_A_Deposit_Transaction()
            _account.Deposit(100)

            _mockTransactionRepository.Verify(Sub(accountClassCalls) accountClassCalls.AddDeposit(100))
        End Sub

        <Test()>
        Public Sub Store_A_Withdrawal_Transation()
            _account.Withdraw(100)

            _mockTransactionRepository.Verify(Sub(accountClassCalls) accountClassCalls.AddWithdrawal(100))
        End Sub

        <Test()>
        Public Sub Print_A_Statement()
            Dim emptyListOfTransactions = New List(Of Transaction)

            _mockTransactionRepository.Setup(Function(self) self.AllTransactions()).Returns(emptyListOfTransactions)

            _account.PrintStatement()

            _mockStatementPrinter.Verify(Sub(accountClassCalls) accountClassCalls.Print(emptyListOfTransactions))
        End Sub

    End Class
End Namespace
Imports BankCoreVBNetEdition
Imports Moq

Namespace Features

    <TestClass()>
    Public Class PrintFullBankStatement
        Private _mockConsole As Mock(Of BaseConsole)
        Private _mockClock As Mock(Of Clock)
        Private _transactionRepository As TransactionRepository
        Private _statementPrinter As StatementPrinter
        Private _account As Account

        <TestMethod()>
        Public Sub Print_Statement_Containing_All_Transactions()
            InitializeAllObjectsForTest()

            ExecuteLogicToMakeDepositsAndPrintStatement()

            VerifyStatementProducedMeetsAcceptanceTest()
        End Sub

        Private Sub InitializeAllObjectsForTest()

            _mockConsole = New Mock(Of BaseConsole)
            _mockClock = New Mock(Of Clock)
            _transactionRepository = New TransactionRepository(_mockClock.Object)
            _statementPrinter = New StatementPrinter(_mockConsole.Object)
            _account = New Account(_transactionRepository, _statementPrinter)
        End Sub

        Private Sub ExecuteLogicToMakeDepositsAndPrintStatement()

            SetupMockDateForNextTransaction("01/04/2014")
            _account.Deposit(1000)
            SetupMockDateForNextTransaction("02/04/2014")
            _account.Withdraw(100)
            SetupMockDateForNextTransaction("10/04/2014")
            _account.Deposit(500)
            _account.PrintStatement()
        End Sub

        Private Sub VerifyStatementProducedMeetsAcceptanceTest()

            _mockConsole.Verify(Sub(self) self.PrintLine("DATE | AMOUNT | BALANCE"))
            _mockConsole.Verify(Sub(self) self.PrintLine("10/04/2014 | 500.00 | 1400.00"))
            _mockConsole.Verify(Sub(self) self.PrintLine("02/04/2014 | -100.00 | 900.00"))
            _mockConsole.Verify(Sub(self) self.PrintLine("01/04/2014 | 1000.00 | 1000.00"))
        End Sub

        Private Sub SetupMockDateForNextTransaction(mockDate As String)
            _mockClock.Setup(Function(self) self.TodayAsString()).Returns(mockDate)
        End Sub
    End Class
End Namespace
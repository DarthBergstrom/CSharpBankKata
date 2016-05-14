Imports BankCoreVBNetEdition
Imports Moq
Imports NUnit.Framework

Namespace UnitTests

    <TestFixture()> Public Class TransactionRepositoryShould
        Private _mockClock As Mock(Of Clock)
        Private _transactionRepository As TransactionRepository
        Private Const Today As String = "12/05/2015"

        <SetUp()>
        Sub Init()
            _mockClock = New Mock(Of Clock)
            _transactionRepository = New TransactionRepository(_mockClock.Object)
            _mockClock.Setup(Function(self) self.TodayAsString()).Returns(Today)
        End Sub

        <Test()> Public Sub Create_And_Store_A_Deposit_Transaction()
            _transactionRepository.AddDeposit(100)
            Dim transactions = _transactionRepository.AllTransactions()

            Assert.That(transactions.Count, [Is].EqualTo(1))
            Assert.That(transactions(0), [Is].EqualTo(GetTransaction(Today, 100)))
        End Sub

        Private Function GetTransaction([date] As String, [amount] As Integer) As BankCoreVBNetEdition.Transaction
            Return New BankCoreVBNetEdition.Transaction([date], [amount])
        End Function
    End Class
End Namespace
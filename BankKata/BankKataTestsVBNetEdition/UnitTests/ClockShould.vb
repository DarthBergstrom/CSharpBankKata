Imports BankCoreVBNetEdition
Imports NUnit.Framework

Namespace UnitTests

    <TestFixture()>
    Public Class ClockShould

        Protected Const TestDate As String = "07/04/2016"

        <Test()>
        Public Sub Return_Todays_Date_In_Dd_Mm_Yyyy_Format()
            Dim clock As New TestableClock()

            Assert.That(clock.TodayAsString(), [Is].EqualTo(TestDate))
        End Sub

        Public Class TestableClock
            Inherits Clock

            Protected Overrides Function Today() As String
                Return TestDate
            End Function
        End Class
    End Class
End NameSpace
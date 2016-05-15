Public Class Clock
    Private Const DdMmYyyy As String = "dd/MM/yyyy"

    Public Overridable Function TodayAsString() As String
        Return Today()
    End Function

    Protected Overridable Function Today() As String
        Return Date.Today.ToString(DdMmYyyy)
    End Function
End Class
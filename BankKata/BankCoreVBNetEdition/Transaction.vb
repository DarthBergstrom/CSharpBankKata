Public Class Transaction
    Private _amount As Integer
    Private _date As String

    Public Sub New([date] As String, amount As Integer)
        _date = [date]
        _amount = amount
    End Sub


    Public ReadOnly Property Amount As Integer
        Get
            Return _amount
        End Get
    End Property

    Public ReadOnly Property [Date] As String
        Get
            Return _date
        End Get
    End Property

    Public Overrides Function Equals(obj As Object) As Boolean
        If (obj Is Me) Then
            Return True
        End If
        If (obj Is Nothing Or TypeOf obj IsNot Transaction) Then
            Return False
        End If

        Dim that As Transaction = CType(obj, Transaction)

        If (_date <> that._date Or _amount <> that._amount) Then
            Return False
        End If

        Return True

    End Function


End Class

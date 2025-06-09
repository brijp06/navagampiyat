Imports WeightPavti.CLS
Public Class Dashbord
    Private Sub Dashbord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cashbank()
    End Sub
    Public Sub cashbank()
        Dim dt As DataTable = ob.Returntable("Select Account_id,Account_Name from Account_Master where Group_id=117", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            If i = 0 Then
                DGbank.Rows.Add()
                DGbank.Rows(DGbank.Rows.Count - 1).Cells(0).Value = "રોકડ સીલ્લક"
                DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(cramt),0)-isnull(sum(Dramt),0) from acdata where acid=149", ob.getconnection())
            End If
            DGbank.Rows.Add()
            DGbank.Rows(DGbank.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Account_Name")
            DGbank.Rows(DGbank.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select isnull(sum(cramt),0)-isnull(sum(Dramt),0) from acdata where acid=" & dt.Rows(i).Item("Account_id") & "", ob.getconnection())
        Next
    End Sub
End Class
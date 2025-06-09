Imports WeightPavti.CLS
Public Class UpdateName
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select * from tmpmem WHERE     (sname <> '')", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            ob.Execute("Update Member_Master set Second_Name=N'" & dt.Rows(i).Item("sname") & "' where  Member_id=" & dt.Rows(i).Item("id") & "", ob.getconnection())
        Next
        MessageBox.Show("Done")
    End Sub
End Class
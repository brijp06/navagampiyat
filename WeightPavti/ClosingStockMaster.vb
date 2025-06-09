Public Class ClosingStockMaster
    Private Sub Dg_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.CellLeave
        If Val(Dg.Rows(e.RowIndex).Cells(0).Value) <> 0 Then
            Dg.Rows(e.RowIndex).Cells(1).Value = ob.FindOneString("select Account_Name from Account_Master Where Account_id=" & Val(Dg.Rows(e.RowIndex).Cells(0).Value) & "", ob.getconnection())
        End If
        If Val(Dg.Rows(e.RowIndex).Cells(2).Value) <> 0 Then
            Dg.Rows(e.RowIndex).Cells(3).Value = ob.FindOneString("select Account_Name from Account_Master Where Account_id=" & Val(Dg.Rows(e.RowIndex).Cells(2).Value) & "", ob.getconnection())
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dg.Rows.Add()
    End Sub

    Private Sub ClosingStockMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt As DataTable = ob.Returntable("select * from Closingstock", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            Dg.Rows.Add()
            Dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("Opid")
            Dg.Rows(i).Cells(1).Value = ob.FindOneString("select Account_Name from Account_Master Where Account_id=" & Val(dt.Rows(i).Item("Opid")) & "", ob.getconnection())
            Dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("Clid")
            Dg.Rows(i).Cells(3).Value = ob.FindOneString("select Account_Name from Account_Master Where Account_id=" & Val(dt.Rows(i).Item("Clid")) & "", ob.getconnection())
        Next
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from Closingstock", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            ob.Execute("Insert Into Closingstock(opid, clid) Values(" & Val(Dg.Rows(i).Cells(0).Value) & "," & Val(Dg.Rows(i).Cells(2).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("Saved")
        Me.Close()
    End Sub
End Class
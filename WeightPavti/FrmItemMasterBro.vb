Imports System.Data
Imports WeightPavti.CLS
Public Class FrmItemMasterBro

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select * from Item_Master where Department='" & Trim(Cmbdepartment.Text) & "' Order by Item_id", ob.getconnection())
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("Item_id")
            dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Item_Name")
            dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("Padt_rate")
            dg.Rows(i).Cells(3).Value = dt.Rows(i).Item("Sell_Rate")
            dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("RiberPer")
            dg.Rows(i).Cells(5).Value = dt.Rows(i).Item("CGST_Per")
            dg.Rows(i).Cells(6).Value = dt.Rows(i).Item("SGST_Per")
        Next
        dg.RowsDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For i As Integer = 0 To dg.Rows.Count - 1
            ob.Execute("Update Item_Master set RiberPer=" & (dg.Rows(i).Cells(4).Value) & " where Item_id=" & Val(dg.Rows(i).Cells(0).Value) & "", ob.getconnection())
        Next
        MessageBox.Show("Save")
    End Sub
End Class
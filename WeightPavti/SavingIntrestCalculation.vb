Imports WeightPavti.CLS
Public Class SavingIntrestCalculation
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ob.Execute("Delete from Savingintcal", ob.getconnection())
        Dim dt As DataTable = ob.Returntable("select PartyId from Acmain where Acid=" & Val(txtint.Text) & " group by partyid order  by PartyId", ob.getconnection())
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dt.Rows.Count
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim dts As String = ob.FindOneString("select sum(receiptamt)-sum(paymentamt) from Acmain where Acid=" & Val(txtint.Text) & "  and Partyid=" & dt.Rows(i).Item("PartyId") & " and billdate<'" & ob.DateConversion(intdate.Text) & "'", ob.getconnection())
            If Val(dts) <> 0 Then
                dg.Rows.Add()
                dg.Rows(dg.Rows.Count - 1).Cells(0).Value = dg.Rows.Count + 1
                dg.Rows(dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("PartyId")
                dg.Rows(dg.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Member_Name from Member_Master Where Member_id=" & Val(dt.Rows(i).Item("PartyId")) & "", ob.getconnection())
                Dim intt As Double = 0
                intt = Val(dts) * (Val(txtper.Text) * 365) / 36500
                intt = Math.Round(Val(intt))
                dg.Rows(dg.Rows.Count - 1).Cells(3).Value = Val(intt)
            End If
            'ProgressBar1.Value = ProgressBar1.Value + 1
            'ProgressBar1.Refresh()
            'lbl.Text = (Format((dg.Rows.Count - 1 / dt.Rows.Count) * 100, "###0")) & "%"
            'lbl.Refresh()
        Next
        MessageBox.Show("Done")
    End Sub
    Public Sub loaddg()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("select * from Savingintcal order  by PId", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(i).Cells(0).Value = i + 1
            dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Pid")
            dg.Rows(i).Cells(2).Value = ob.FindOneString("select Member_Name from Member_Master Where Member_id=" & Val(dt.Rows(i).Item("Pid")) & "", ob.getconnection())
            dg.Rows(i).Cells(3).Value = dt.Rows(i).Item("Netamt")
        Next
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
End Class
Public Class ViewLed

    Private Sub txtloanno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtloanno.Validated
        If txtloanno.Text <> "" Then
            Dim dt As DataTable = ob.Returntable("select name from loan where loanno=" & txtloanno.Text & "", ob.getconnection(sysdbname))
            txtname.Text = dt.Rows(0).Item("Name")
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select * from loan_detail where loanno=" & txtloanno.Text & "", ob.getconnection(sysdbname))
        dtg.Columns.Add("", "")
        dtg.Columns.Add("", "")
        dtg.Columns.Add("", "")
        dtg.Columns.Add("", "")
        dtg.Columns.Add("", "")
        dtg.Rows.Add()
        dtg.Rows(0).Cells(0).Value = "No Emi"
        dtg.Rows(0).Cells(1).Value = "Emi Rs"
        dtg.Rows(0).Cells(2).Value = "Emi Date"
        dtg.Rows(0).Cells(3).Value = "Rec Emi"
        dtg.Rows(0).Cells(4).Value = "Rec Date"
        Dim b As Integer = 1
        For i = 0 To dt.Rows.Count - 1
            dtg.Rows.Add()
            dtg.Rows(b).Cells(0).Value = dt.Rows(i).Item("noemi")
            dtg.Rows(b).Cells(1).Value = dt.Rows(i).Item("Emirs")
            dtg.Rows(b).Cells(2).Value = ob.DateConversion(dt.Rows(i).Item("emidate"))
            dtg.Rows(b).Cells(3).Value = dt.Rows(i).Item("Recrs")
            dtg.Rows(b).Cells(4).Value = ob.IfNullThen(dt.Rows(i).Item("Recdate"), "-")
            If dtg.Rows(b).Cells(3).Value = "0" Then
                dtg.Rows(b).Cells(4).Value = "-"
            Else
                dtg.Rows(b).Cells(4).Value = ob.DateConversion(dt.Rows(i).Item("Recdate"))
            End If
            b = b + 1
        Next
    End Sub

    Private Sub txtloanno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtloanno.KeyPress
        tabkey(sender, e)
    End Sub
End Class
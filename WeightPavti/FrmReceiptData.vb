Imports WeightPavti.CLS

Public Class FrmReceiptData
    Private Sub FrmReceiptData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        Cmbdepartment.Text = FrmReceiptEntry.Cmbdepartment.Text
        Cname.Tag = FrmReceiptEntry.Cname.Tag
        Cname.Text = FrmReceiptEntry.Cname.Text
        loaddg()
    End Sub
    Public Sub loaddg()
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("select * from receipt where partyid=" & Val(Cname.Tag) & " and ptype='" & Trim(Cmbdepartment.Text) & "' order by billno,yearid", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            Dg.Rows.Add()
            Dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("billno")
            Dg.Rows(i).Cells(1).Value = dt.Rows(i).Item("Docno")
            Dg.Rows(i).Cells(2).Value = Format(dt.Rows(i).Item("docdate"), "dd/MM/yyyy")
            Dg.Rows(i).Cells(3).Value = dt.Rows(i).Item("receiptamt")
            Dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("yearid")

            Dg.Rows(i).Cells(0).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(i).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(i).Cells(2).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(i).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dg.Rows(i).Cells(4).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Next
        loadd()
    End Sub
    Public Sub loadd()
        If dg2.Rows.Count > 0 Then
            dg2.Rows.Clear()
        End If
        Dim dt As DataTable = ob.Returntable("select * from acmain where partyid=" & Val(Cname.Tag) & " and department='" & Trim(Cmbdepartment.Text) & "' order by billno,billdate", ob.getconnection())
        For i As Integer = 0 To dt.Rows.Count - 1
            dg2.Rows.Add()
            dg2.Rows(i).Cells(0).Value = dt.Rows(i).Item("billno")
            dg2.Rows(i).Cells(1).Value = Format(dt.Rows(i).Item("billdate"), "dd/MM/yyyy")
            dg2.Rows(i).Cells(2).Value = dt.Rows(i).Item("remarks")
            dg2.Rows(i).Cells(3).Value = dt.Rows(i).Item("receiptamt")
            dg2.Rows(i).Cells(4).Value = dt.Rows(i).Item("paymentamt")
            If Val(dt.Rows(i).Item("receiptamt")) <> 0 Then
                dg2.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
            End If
        Next
        dg2.RowsDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loaddg()
    End Sub
End Class
Imports WeightPavti.CLS
Public Class FrmRatePosting
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ob.Execute("delete from ratemaster", ob.getconnection())
        Dim dt As DataTable = ob.Returntable("SELECT  itemid,Sizeid,barcode from acstock where Department='bhandar' and sizeid is not null group by itemid,Sizeid,barcode ", ob.getconnection())
        ProgressBar1.Value = 0
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dt.Rows.Count
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim rr As String = 0
            rr = ob.FindOneString("select isnull(pdtrate,0) as rate from acstock  where barcode='" & Trim(dt.Rows(i).Item("barcode").ToString) & "' and itemid=" & Val(dt.Rows(i).Item("itemid")) & " and sizeid='" & Trim(dt.Rows(i).Item("sizeid")) & "' and ptype='purchase' and billdate<='" & Format(CDate(Me.TxtToDate.Text), "yyyy/MM/dd") & "'  order by billno desc", ob.getconnection())
            If Val(rr) = 0 Then
                rr = ob.FindOneString("select rate from acstock  where barcode='" & Trim(dt.Rows(i).Item("barcode").ToString) & "' and itemid=" & Val(dt.Rows(i).Item("itemid")) & " and sizeid='" & Trim(dt.Rows(i).Item("sizeid")) & "' and ptype='Opening' order by billno desc", ob.getconnection())
            End If
            ob.Execute("insert into ratemaster(itemid,sizeid,barcode,rate) values (" & Val(dt.Rows(i).Item("itemid")) & "," & aq(dt.Rows(i).Item("sizeid")) & "," & aq(dt.Rows(i).Item("barcode")) & "," & Val(rr) & ") ", ob.getconnection())
            ProgressBar1.Value = ProgressBar1.Value + 1
            ProgressBar1.Refresh()
            lbl.Text = (Format((i / ProgressBar1.Maximum) * 100, "###0")) & "%"
            lbl.Refresh()
        Next
        MessageBox.Show("Done")
    End Sub

    Private Sub FrmRatePosting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtToDate.Text = Now
    End Sub
End Class
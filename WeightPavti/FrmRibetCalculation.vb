Imports System.Data
Imports WeightPavti.CLS
Public Class FrmRibetCalculation
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ob.Execute("update item_master set RiberPer=0 where RiberPer is null", ob.getconnection())
        Dim dt As DataTable = ob.Returntable("select * from ViewRibet where billdate between '2022/04/01' and '" & ob.DateConversion(billDt.Text) & "'", ob.getconnection())
        ob.Execute("delete from tmpribet", ob.getconnection())

        For i As Integer = 0 To dt.Rows.Count - 1
            Dim amt As Double = 0
            amt = Val(dt.Rows(i).Item("RiberPer")) * Val(dt.Rows(i).Item("Stockout")) * Val(dt.Rows(i).Item("Rate")) / 100
            ob.Execute("Insert Into tmpribet(Id, Name, Amount) values(" & Val(dt.Rows(i).Item("Partyid")) & ",N'" & dt.Rows(i).Item("Member_Name") & "'," & Val(amt) & ")", ob.getconnection())
        Next
        Dim dts As DataTable = ob.Returntable("select sum(Amount) as amt,id,name from tmpribet  Group By id,Name Order by Id", ob.getconnection())
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        For j As Integer = 0 To dts.Rows.Count - 1
            dg.Rows.Add()
            dg.Rows(j).Cells(0).Value = dts.Rows(j).Item("id")
            dg.Rows(j).Cells(1).Value = dts.Rows(j).Item("Name")
            dg.Rows(j).Cells(2).Value = dts.Rows(j).Item("Amt")
        Next
        dg.RowsDefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow

        MessageBox.Show("Done")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ssql As String = ""
        clsVariables.ReportSql = ssql
        'clsVariables.FromDate = TxtfromDate.Text
        clsVariables.ToDate = billDt.Text
        clsVariables.Repheader = "Intrest Report"
        clsVariables.ReportName = "IntrestReport.rpt"
        Dim frm As New Reportform
        frm.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ssql As String = ""
        clsVariables.ReportSql = ssql
        'clsVariables.FromDate = TxtfromDate.Text
        clsVariables.ToDate = billDt.Text
        clsVariables.Repheader = "Intrest Report"
        clsVariables.ReportName = "IntrestReportvillagewise.rpt"
        Dim frm As New Reportform
        frm.Show()
    End Sub
End Class
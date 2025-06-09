Imports WeightPavti.CLS
Public Class CalculateIntrest
    Private Sub CalculateIntrest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtfromdate.Text = gFinYearBegin
        txttodate.Text = gFinYearEnd
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dt As DataTable = ob.Returntable("select * from acmain where  ptype not in ('Fixdpayment','intrespayment','intrest') and department='Fixd' and billdate<='" & ob.DateConversion(txttodate.Text) & "' order by Fdno", ob.getconnection())
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim dts As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(dt.Rows(i).Item("Fdno")) & " and ptype='fixdPayment'", ob.getconnection())
                If dts.Rows.Count = 0 Then
                    Dim ddate As Date = dt.Rows(i).Item("billdate")
                    Dim nzdate As Date = txttodate.Text
                    Dg.Rows.Add()
                    Dim days As Integer = 365
                    Dim ldate As Date = dt.Rows(i).Item("billdate")
                    Dim ndate As Date = txtfromdate.Text
                    Dim tsdate As Date = txttodate.Text
                    If ldate > ndate Then
                        days = DateAndTime.DateDiff(DateInterval.Day, ldate, tsdate)
                    End If
                    Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = i + 1
                    Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Fdno")
                    If Val(dt.Rows(i).Item("Fdno")) = 0 Then
                        Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("billno")
                    End If
                    Dg.Rows(Dg.Rows.Count - 1).Cells(2).Tag = Val(dt.Rows(i).Item("partyid"))
                    Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = ob.FindOneString("select Member_Name from Member_master where member_id=" & Val(dt.Rows(i).Item("partyid")) & "", ob.getconnection())
                    Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("ReceiptAmt")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = 7
                    Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Val(dt.Rows(i).Item("ReceiptAmt")) * Val(7) * Val(days) / 36500
                    Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Math.Round(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value), 0)
                End If
            Next
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ob.Execute("delete from acmain where year_id='" & clsVariables.WorkingYear & "' and acid=105 and ptype='intrest'", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            ob.Execute("Insert Into acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks,ReceiptAmt, ptype,Fdno,intresamt) values(1,'" & clsVariables.WorkingYear & "','Fixd','CASH'," & Dg.Rows(i).Cells(0).Value & ",'" & ob.DateConversion(txttodate.Text) & "'," & Val(Dg.Rows(i).Cells(2).Tag) & ",105,N'" & txttodate.Text & " સુધી નું વ્યાજ'," & Val(Dg.Rows(i).Cells(5).Value) & ",'intrest'," & Val(Dg.Rows(i).Cells(1).Value) & "," & Val(Dg.Rows(i).Cells(5).Value) & ")", ob.getconnection())
        Next
        MessageBox.Show("Saved")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ob.Execute("delete from tmpintrest", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            Dim intdate As String = ob.FindOneString("select billdate from acmain where fdno=" & Val(Dg.Rows(i).Cells(1).Value) & "", ob.getconnection())
            ob.Execute("Insert Into tmpintrest(srno, fixdno, mname, Fixdamt, per, intamt,fixddate) values(" & i + 1 & "," & Val(Dg.Rows(i).Cells(1).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "'," & Val(Dg.Rows(i).Cells(3).Value) & "," & Val(Dg.Rows(i).Cells(4).Value) & "," & Val(Dg.Rows(i).Cells(5).Value) & ",'" & ob.DateConversion(intdate) & "')", ob.getconnection())
        Next
        Dim ssql As String = ""
        clsVariables.ReportSql = ssql
        'clsVariables.FromDate = TxtfromDate.Text
        clsVariables.ToDate = txttodate.Text
        clsVariables.Repheader = "Intrest Report"
        clsVariables.ReportName = "IntrestReportfd.rpt"
        Dim frm As New Reportform
        frm.Show()
    End Sub
End Class
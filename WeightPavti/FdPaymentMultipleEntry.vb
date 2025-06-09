Imports WeightPavti.CLS
Public Class FdPaymentMultipleEntry
    Dim int As String = 0
    Dim intprv As String = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(frmfd.Text) <> 0 And Val(Tofd.Text) <> 0 Then
            Dim dt As DataTable = ob.Returntable("select * from acmain where fdno between " & Val(frmfd.Text) & " and " & Val(Tofd.Text) & " and ptype<>'Fixdpayment'", ob.getconnection())
            If dt.Rows.Count > 0 Then
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("Billno")
                    Dg.Rows(i).Cells(1).Value = Format(dt.Rows(i).Item("Billdate"), "dd/MM/yyyy")
                    Dg.Rows(i).Cells(2).Tag = dt.Rows(i).Item("Partyid") 'ob.FindOneString("select Member_name from Member_master where Member_id=" & Val(dt.Rows(i).Item("Partyid")) & "", ob.getconnection())
                    Dg.Rows(i).Cells(2).Value = ob.FindOneString("select Member_name from Member_master where Member_id=" & Val(dt.Rows(i).Item("Partyid")) & "", ob.getconnection())
                    Dg.Rows(i).Cells(3).Value = dt.Rows(i).Item("Receiptamt")
                    Dim due As String = ob.FindOneString("select Duedate from acmain where fdno=" & Val(dt.Rows(i).Item("fdno")) & "", ob.getconnection())
                    Dim per As String = ob.FindOneString("select Per from acmain where fdno=" & Val(dt.Rows(i).Item("fdno")) & "", ob.getconnection())
                    calint(billDt.Text, due, Dg.Rows(i).Cells(1).Value, per, Dg.Rows(i).Cells(3).Value)
                    Dg.Rows(i).Cells(4).Value = Val(int)
                    calintlast(billDt.Text, due, Dg.Rows(i).Cells(1).Value, per, Dg.Rows(i).Cells(3).Value)
                    Dg.Rows(i).Cells(5).Value = Val(intprv)
                    Dg.Rows(i).Cells(6).Value = Val(intprv) + Val(int)
                    If Val(Dg.Rows(i).Cells(3).Value) > "20000" Then
                        Dg.Rows(i).Cells(9).Value = "BANK"
                    Else
                        Dg.Rows(i).Cells(9).Value = "CASH"
                    End If
                    If Dg.Rows(i).Cells(9).Value = "CASH" Then
                        Dg.Rows(i).Cells(10).Tag = 149
                        Dg.Rows(i).Cells(10).Value = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Dg.Rows(i).Cells(10).Tag) & "", ob.getconnection())
                    ElseIf Dg.Rows(i).Cells(9).Value = "BANK" Then
                        Dg.Rows(i).Cells(10).Tag = payac.Tag
                        Dg.Rows(i).Cells(10).Value = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Dg.Rows(i).Cells(10).Tag) & "", ob.getconnection())
                    End If

                Next
                Dg.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow

            End If
        End If
    End Sub
    Public Sub calint(nndate As String, lbd As String, du As String, per As String, fd As String)
        Dim ndate As Date = billDt.Text
        Dim ddate As Date = lbd
        If DGo.Rows.Count > 0 Then
            DGo.Rows.Clear()
        End If
        DGo.Rows.Add()
        Dim due As Date = du
        Dim ckdate As Date = gFinYearBegin
        If due > ckdate Then
            DGo.Rows(DGo.Rows.Count - 1).Cells(0).Value = Format(due, "dd/MM/yyyy")
        Else
            DGo.Rows(DGo.Rows.Count - 1).Cells(0).Value = Format(ckdate, "dd/MM/yyyy")
        End If

        DGo.Rows(DGo.Rows.Count - 1).Cells(1).Value = billDt.Text
        DGo.Rows(DGo.Rows.Count - 1).Cells(2).Value = fd
        Dim ddyas As String = 0
        ddyas = DateDiff(DateInterval.Day, DGo.Rows(DGo.Rows.Count - 1).Cells(0).Value, DGo.Rows(DGo.Rows.Count - 1).Cells(1).Value)
        If Val(ddyas) >= 0 And Val(ddyas) <= 30 Then
            per = 0
        ElseIf Val(ddyas) >= 31 And Val(ddyas) <= 90 Then
            per = 4
        ElseIf Val(ddyas) >= 91 And Val(ddyas) <= 180 Then
            per = 6
        Else
            per = 7
        End If
        DGo.Rows(DGo.Rows.Count - 1).Cells(3).Value = per
        DGo.Rows(DGo.Rows.Count - 1).Cells(4).Value = ddyas 'DateDiff(DateInterval.Day, DGo.Rows(DGo.Rows.Count - 1).Cells(0).Value, DGo.Rows(DGo.Rows.Count - 1).Cells(1).Value)
        DGo.Rows(DGo.Rows.Count - 1).Cells(5).Value = Format(Val(fd) * Val(per) * Val(ddyas) / 36500, "###0.00")
        DGo.Rows(DGo.Rows.Count - 1).Cells(5).Value = Math.Round(Val(DGo.Rows(DGo.Rows.Count - 1).Cells(5).Value))
        int = DGo.Rows(DGo.Rows.Count - 1).Cells(5).Value

    End Sub

    Public Sub calintlast(nndate As String, lbd As String, du As String, per As String, fd As String)
        'Dim ndate As Date = billDt.Text
        'Dim ddate As Date = lbd
        'If DG1.Rows.Count > 0 Then
        '    DG1.Rows.Clear()
        'End If
        'DG1.Rows.Add()
        'Dim due As Date = du
        'Dim ckdate As Date = gFinYearBegin
        'If due > ckdate Then
        '    DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = Format(due, "dd/MM/yyyy")
        'Else
        '    DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = Format(ckdate, "dd/MM/yyyy")
        'End If

        'DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value = billDt.Text
        'DG1.Rows(DG1.Rows.Count - 1).Cells(2).Value = fd
        Dim ndate As Date = billDt.Text
        Dim ddate As Date = lbd
        If DG1.Rows.Count > 0 Then
            DG1.Rows.Clear()
        End If
        DG1.Rows.Add()
        Dim due As Date = du
        Dim ckdate As Date = gFinYearBegin
        Dim bill As Date = billDt.Text
        If due < ckdate Then

            DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = due
            DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value = ckdate.AddDays(-1)

        Else
            intprv = 0
            Exit Sub
            DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = Format(ckdate, "dd/MM/yyyy")
            DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value = Format(bill, "dd/MM/yyyy") 'billDt.Text
        End If

        DG1.Rows(DG1.Rows.Count - 1).Cells(2).Value = fd
        Dim ddyas As String = DateDiff(DateInterval.Day, DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value, DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value)
        If Val(ddyas) >= 0 And Val(ddyas) <= 30 Then
            per = 0
        ElseIf Val(ddyas) >= 31 And Val(ddyas) <= 90 Then
            per = 4
        ElseIf Val(ddyas) >= 91 And Val(ddyas) <= 180 Then
            per = 6
        Else
            per = 7
        End If
        DG1.Rows(DG1.Rows.Count - 1).Cells(3).Value = per
        DG1.Rows(DG1.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Day, DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value, DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value)
        DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value = Format(Val(fd) * Val(DG1.Rows(DG1.Rows.Count - 1).Cells(3).Value) * Val(DG1.Rows(DG1.Rows.Count - 1).Cells(4).Value) / 36500, "###0.00")
        DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value = Math.Round(Val(DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value))
        intprv = DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value

    End Sub

    Private Sub FdPaymentMultipleEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        billDt.Text = Format(DateTime.Now, "dd/MM/yyyy")
        DGo.Columns.Add("Fromdate", "Fromdate")
        DGo.Columns.Add("Todate", "Todate")
        DGo.Columns.Add("Amount", "Amount")

        DGo.Columns.Add("Int.Rate", "Int.Rate")
        DGo.Columns.Add("Days", "Days")
        DGo.Columns.Add("Int.Amount", "Int.Amount")

        DG1.Columns.Add("Fromdate", "Fromdate")
        DG1.Columns.Add("Todate", "Todate")
        DG1.Columns.Add("Amount", "Amount")

        DG1.Columns.Add("Int.Rate", "Int.Rate")
        DG1.Columns.Add("Days", "Days")
        DG1.Columns.Add("Int.Amount", "Int.Amount")
    End Sub

    Private Sub Dg_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles Dg.RowValidating
        ' Dg.Rows(e.RowIndex).Cells(6).Value = Val(Dg.Rows(e.RowIndex).Cells(4).Value) + Val(Dg.Rows(e.RowIndex).Cells(5).Value)

    End Sub

    Private Sub Dg_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.RowLeave
        'Dg.Rows(e.RowIndex).Cells(6).Value = Val(Dg.Rows(e.RowIndex).Cells(4).Value) + Val(Dg.Rows(e.RowIndex).Cells(5).Value)

    End Sub

    Private Sub Dg_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles Dg.CellLeave
        Dg.Rows(e.RowIndex).Cells(6).Value = Val(Dg.Rows(e.RowIndex).Cells(4).Value) + Val(Dg.Rows(e.RowIndex).Cells(5).Value)
        If Dg.Rows(e.RowIndex).Cells(9).Value = "CASH" Then
            Dg.Rows(e.RowIndex).Cells(10).Tag = 149
            Dg.Rows(e.RowIndex).Cells(10).Value = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Dg.Rows(e.RowIndex).Cells(10).Tag) & "", ob.getconnection())
        ElseIf Dg.Rows(e.RowIndex).Cells(9).Value = "BANK" Then
            Dg.Rows(e.RowIndex).Cells(10).Tag = payac.Tag
            Dg.Rows(e.RowIndex).Cells(10).Value = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Dg.Rows(e.RowIndex).Cells(10).Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim billno As String = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='FixdPayment' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        For i As Integer = 0 To Dg.Rows.Count - 1
            If Dg.Rows(i).Cells(11).Value = True Then
                Dg.Rows(i).Cells(7).Value = Val(billno)
                Dg.Rows(i).Cells(8).Value = billDt.Text
                billno = Val(billno) + 1
            End If
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        For i As Integer = 0 To Dg.Rows.Count - 1
            If Dg.Rows(i).Cells(11).Value = True Then
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,PaymentAmt,ptype, Per, Period, Duedate,fdno,intamt,intresamt,cbj) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq("FIXD") & "," & aq(Dg.Rows(i).Cells(9).Value) & "," & Val(Dg.Rows(i).Cells(7).Value) & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Val(Dg.Rows(i).Cells(2).Tag) & "," & Val(10) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "'," & Val(Dg.Rows(i).Cells(6).Value) + Val(Dg.Rows(i).Cells(3).Value) & "," & Val(Dg.Rows(i).Cells(3).Value) & ",'FixdPayment',0,0,'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Val(Dg.Rows(i).Cells(0).Value) & "," & Val(Dg.Rows(i).Cells(4).Value) & "," & Val(Dg.Rows(i).Cells(5).Value) & "," & Val(Dg.Rows(i).Cells(10).Value) & ")", ob.getconnection())
                If Trim(Dg.Rows(i).Cells(9).Value) = "CASH" Then
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 100 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(3).Value & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Dg.Rows(i).Cells(3).Value & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 70 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 105 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Val(Dg.Rows(i).Cells(5).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(8).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Val(Dg.Rows(i).Cells(5).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                Else
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 100 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(3).Value & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Dg.Rows(i).Cells(3).Value & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 70 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Val(Dg.Rows(i).Cells(4).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & 105 & ",N'" & Dg.Rows(i).Cells(9).Value & "'," & Val(Dg.Rows(i).Cells(5).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & Dg.Rows(i).Cells(9).Value & "'," & Dg.Rows(i).Cells(7).Value & ",'" & ob.DateConversion(Dg.Rows(i).Cells(8).Value) & "'," & Dg.Rows(i).Cells(10).Tag & ",N'" & Dg.Rows(i).Cells(10).Value & "'," & Val(Dg.Rows(i).Cells(5).Value) & ",N'" & Trim(Dg.Rows(i).Cells(2).Value) & "',0,'FixdPayment','fixd')", ob.getconnection())
                End If
            End If
        Next
        MessageBox.Show("Save")
    End Sub

    Private Sub payac_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles payac.Validating

        clsVariables.HelpId = "Account_id"
            clsVariables.HelpName = "Account_Name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_Name"
            HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Group_id=117"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
            payac.Tag = clsVariables.RtnHelpId
            payac.Text = clsVariables.RtnHelpName
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        For i As Integer = 0 To Dg.Rows.Count - 1
            Dg.Rows(i).Cells(11).Value = True
        Next
    End Sub
End Class
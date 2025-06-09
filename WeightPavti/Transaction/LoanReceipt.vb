Imports System.Data.SqlClient
Imports WeightPavti.CLS
Public Class LoanReceipt


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        TxtFill("Select Column_name from Column_Master", Columnname)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='LoanReceipt'", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()

        pac.Tag = 40
        pac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(pac.Tag) & "", ob.getconnection())

    End Sub
    Public Sub TxtFill(ByVal Sqlstring As String, ByVal txtBox As TextBox)
        Dim sStringColl As New AutoCompleteStringCollection
        Dim qryCity As String
        Dim SqlConnString As String = "Password=advsys;Data Source=" & servername & ";Initial Catalog=" & dbname & ";Integrated Security=False;Persist Security Info=False;User ID=advsys;Max Pool Size=5000;Connect Timeout=0"
        qryCity = "SELECT DISTINCT NAME FROM ACMASTER  ORDER By NAME"

        Using connection As New SqlConnection(SqlConnString)

            Dim cmdCity As New SqlCommand(Sqlstring, connection)
            connection.Open()

            Dim city_reader As SqlDataReader = cmdCity.ExecuteReader()

            ' Loop through the data.
            While city_reader.Read()
                sStringColl.AddRange(New String() {Trim(city_reader(0).ToString)})
            End While

            city_reader.Close()
        End Using
        txtBox.AutoCompleteCustomSource = sStringColl
        txtBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub sname_Validated(sender As Object, e As EventArgs) Handles sname.Validated
        If sname.Text <> "" Then
            sname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(sname.Text) & "' or Member_Id=" & Val(sname.Text) & "", ob.getconnection())
            If Val(sname.Tag) <> 0 Then
                sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
                Txtremark.Text = sname.Text
                ' chaln()
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where ptype='LoanReceipt' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("delete from Acdata where ptype='LoanReceipt' and Docno=" & Val(Billno.Text) & "", ob.getconnection())

        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Clid, Netamt,Receiptamt,ptype, Loanno, Per,intamt) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Columnname.Tag) & "," & Val(Netamt.Text) & "," & Val(amount.Text) & ",'LoanReceipt'," & Loanno.Text & "," & percent.Text & "," & Val(intamt.Text) & ")", ob.getconnection())
        If Trim(cmbtype.Text) = "CASH" Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            If Val(pamt.Text) <> 0 Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & pac.Tag & ",N'" & pac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            End If
            If (intamt.Text) <> 0 Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & intac.Tag & ",N'" & intac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            End If
        Else
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Netamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            'If Val(pamt.Text) <> 0 Then
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & pac.Tag & ",N'" & pac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            'End If
            'If (intamt.Text) <> 0 Then
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,dramt ,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & intac.Tag & ",N'" & intac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            '    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, cramt,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            'End If
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & amount.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            '    If Val(pamt.Text) <> 0 Then
            '   ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & pac.Tag & ",N'" & pac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            '  ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & pamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            'End If
            If (intamt.Text) <> 0 Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & intac.Tag & ",N'" & intac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'LoanReceipt')", ob.getconnection())
            End If
        End If
        payint()
        clear()
        MessageBox.Show("Save")
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='LoanReceipt'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub payint()
        Dim damt As Double = amount.Text

        For i As Integer = 0 To Dgflat.Rows.Count - 1
            If Dgflat.Rows(i).Cells(4).Value <> 0 Then
                If Val(damt) <= Dgflat.Rows(i).Cells(2).Value And Val(damt) <> 0 Then
                    'namt = Dg.Rows(i).Cells(2).Value
                    ob.Execute("Update Passing_Due_Date_Data set Amtpay=" & Val(damt) & " where Sr_no=" & Val(Dgflat.Rows(i).Cells(0).Value) & " and doc_no=" & Loanno.Text & "", ob.getconnection())
                    damt = 0
                ElseIf Val(damt) > Dgflat.Rows(i).Cells(2).Value Then
                    damt = Val(damt) - Val(Dgflat.Rows(i).Cells(4).Value)
                    ob.Execute("Update Passing_Due_Date_Data set Amtpay=" & Val(Dgflat.Rows(i).Cells(2).Value) & " where Sr_no=" & Val(Dgflat.Rows(i).Cells(0).Value) & " and doc_no=" & Loanno.Text & "", ob.getconnection())
                End If
            End If
        Next
        Dim iamt As Double = intamt.Text
        For j As Integer = 0 To Dgflat.Rows.Count - 1
            If Dgflat.Rows(j).Cells(7).Value <> 0 Then
                If Val(iamt) <= Dgflat.Rows(j).Cells(5).Value And Val(iamt) <> 0 Then
                    'namt = Dg.Rows(i).Cells(2).Value
                    ob.Execute("Update Passing_Due_Date_Data set Intpay=" & Val(iamt) & " where Sr_no=" & Val(Dgflat.Rows(j).Cells(0).Value) & " and doc_no=" & Loanno.Text & "", ob.getconnection())
                    iamt = 0
                ElseIf Val(iamt) > Dgflat.Rows(j).Cells(5).Value Then
                    iamt = Val(iamt) - Val(Dgflat.Rows(j).Cells(7).Value)
                    ob.Execute("Update Passing_Due_Date_Data set Intpay=" & Val(Dgflat.Rows(j).Cells(5).Value) & " where Sr_no=" & Val(Dgflat.Rows(j).Cells(0).Value) & " and doc_no=" & Loanno.Text & "", ob.getconnection())
                End If
            End If
        Next
    End Sub
    Public Sub clear()
        Billno.Clear()
        '  billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        Netamt.Clear()
        acname.Clear()
        Columnname.Clear()
        percent.Clear()
        Loanno.Clear()
        payac.Clear()
        cmbtype.Text = ""
        pamt.Clear()
        intamt.Clear()
        If Dgflat.Rows.Count > 0 Then
            Dgflat.Rows.Clear()
        End If
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub



    Private Sub Columnname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Columnname.Validating
        If Columnname.Text <> "" Then
            Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
            Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            acname.Enabled = False
            percent.Text = "0.50"
            Loanno.Text = ob.FindOneString("Select Loanno From Acmain Where  partyid=" & Val(sname.Tag) & " and clid=" & Columnname.Tag & " and ptype in ('LoanPayment','LoanOpening')", ob.getconnection())
            newloan()

            intac.Tag = 27
            intac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(intac.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles cmbtype.Validated
        If cmbtype.Text = "CASH" Then
            payac.Tag = 164
            payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
            payac.Enabled = False
        Else
            payac.Enabled = True
            payac.Tag = 0
            payac.Focus()
        End If
    End Sub

    Private Sub payac_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles payac.Validating
        payac.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Id=" & Val(payac.Text) & " Or Account_Name=N'" & Trim(payac.Text) & "'", ob.getconnection())
        payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
        amount.Focus()
    End Sub



    Private Sub Billno_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, pamt.KeyDown, intamt.KeyDown, amount.KeyDown, sname.KeyDown, Netamt.KeyDown, Columnname.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown, payac.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub
    Public Sub newloan()
        Dim lbdate As String = billDt.Text
        'Dim pp As Integer
        'pp = Val(RasClass.GetValue("select PercentL from QualityMaster where SabhasadName=" & Val(SabhasadName.Tag) & " and ColName=" & Val(ColumnName.Tag) & ""))
        'Percnt.Text = 10

        ' sABHASADnAME.Tag = SabhasadNo.Text

        Dim dt As DataTable
        ' Dim myConn As New SqlConnection(MDIParent1.ProjConn)
        dt = ob.Returntable("select billno as TranNo,billdate as TransDate,Department as TransMode,PaymentAmt,ReceiptAmt,isnull(intamt,0) as intamt from Acmain where Partyid=" & Val(sname.Tag) & " and billdate <= '" & Format(CDate(lbdate), "yyyy/MM/dd") & "'  and Acid=20 order by billdate", ob.getconnection())
        If DG.Rows.Count > 0 Then
            DG.Rows.Clear()
        End If

        'dt = RasClass.Returntable("select * from TransactionMaster where PartyAccountId=" & PartyName.Tag & " and transdate between '" & DateConversion(fromdate.Text) & "' and '" & DateConversion(todate.Text) & "'  order by TransDate", myConn)
        'Dim int As String = RasClass.GetValue("select percnt from columnmaster where code=" & ColumnName.Tag & "")
        Dim lamount As Double
        'If Val(ColumnName.Tag) <> 3 And Val(ColumnName.Tag) <> 4 And Val(ColumnName.Tag) <> 11 And Val(ColumnName.Tag) <> 12 Then
        'lamount = Val(RasClass.GetValue("select sum(paymentamt-ReceiptAmt) from TransactionMAster where PartyAccountID=" & Val(SabhasadName.Tag) & " and ColumnId=" & Val(ColumnName.Tag) & ""))
        'If Val(lamount) <= 300000 Then
        '    pp = 7
        'Else
        '    pp = 10
        'End If
        'Percnt.Text = pp
        'Else
        ' Percnt.Text = RasClass.GetValue("Select Percnt from ShowLoan1 where ColumnID=" & Val(ColumnName.Tag) & "")
        ' End If
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                DG.Rows.Add()
                DG.Rows(i).Cells(1).Value = dt.Rows(i).Item("TranNo")
                DG.Rows(i).Cells(0).Value = Format(dt.Rows(i).Item("TransDate"), "dd/MM/yyyy")
                DG.Rows(i).Cells(2).Value = dt.Rows(i).Item("TransMode")
                DG.Rows(i).Cells(3).Value = dt.Rows(i).Item("PaymentAmt")
                DG.Rows(i).Cells(4).Value = dt.Rows(i).Item("ReceiptAmt")
                If dt.Rows(i).Item("PaymentAmt") <> "0.00" Then
                    DG.Rows(i).Cells(7).Value = 0
                    DG.Rows(i).Cells(6).Value = dt.Rows(i).Item("intamt")
                    DG.Rows(i).Cells(6).Value = Math.Round(Val(DG.Rows(i).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
                Else
                    DG.Rows(i).Cells(6).Value = 0
                    Dim iamt As Double = dt.Rows(i).Item("intamt")
                    DG.Rows(i).Cells(7).Value = dt.Rows(i).Item("intamt")
                    DG.Rows(i).Cells(7).Value = Math.Round(Val(DG.Rows(i).Cells(7).Value), 0, MidpointRounding.AwayFromZero)
                End If
                DG.Rows(i).Cells(9).Value = dt.Rows(i).Item("Transmode")
            Next
            '            Dim ldate As Date = Now.Date.AddDays(+1)
            Dim ldate As Date = lbdate
            DG.Rows.Add()
            DG.Rows(DG.Rows.Count - 1).Cells(0).Value = Format(ldate, "dd/MM/yyyy")
            DG.Rows(DG.Rows.Count - 1).Cells(1).Value = "9999"
            DG.Rows(DG.Rows.Count - 1).Cells(3).Value = "0.00"
            DG.Rows(DG.Rows.Count - 1).Cells(4).Value = "0.00"
            DG.Rows(DG.Rows.Count - 1).Cells(7).Value = "0.00"
            DG.Rows(DG.Rows.Count - 1).Cells(5).Value = DG.Rows(DG.Rows.Count - 2).Cells(5).Value
            Dim nowdate As Date = Format(Now, "dd/MM/yyyy")
            DG.Rows(DG.Rows.Count - 1).Cells(8).Value = DateDiff(DateInterval.Day, DG.Rows(DG.Rows.Count - 2).Cells(0).Value, nowdate)
            DG.Rows(DG.Rows.Count - 1).Cells(6).Value = Format(DG.Rows(DG.Rows.Count - 1).Cells(5).Value * DG.Rows(DG.Rows.Count - 1).Cells(8).Value * Val(percent.Text) / 36500, "###0.00")
            DG.Rows(DG.Rows.Count - 1).Cells(6).Value = Math.Round(Val(DG.Rows(DG.Rows.Count - 1).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
            DG.Rows(DG.Rows.Count - 1).Cells(6).Value = Format(Val(DG.Rows(DG.Rows.Count - 1).Cells(6).Value), "###0.00")
            DG.Rows(DG.Rows.Count - 1).Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            Dim kj As Integer = 1
            Dim mns As Integer = 1
            For jk As Integer = 0 To DG.Rows.Count - 1
                DG.Rows(jk).Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                If jk = 0 Then
                    DG.Rows(0).Cells(8).Value = 0

                End If
                If jk = DG.Rows.Count - 1 Then
                    DG.Rows(jk).Cells(8).Value = DateDiff(DateInterval.Day, DG.Rows(jk - 1).Cells(0).Value, DG.Rows(kj - 1).Cells(0).Value)
                Else
                    DG.Rows(kj).Cells(8).Value = DateDiff(DateInterval.Day, DG.Rows(jk).Cells(0).Value, DG.Rows(kj).Cells(0).Value)
                End If
                'DG.Rows(kj).Cells(8).Value = DateDiff(DateInterval.Day, DG.Rows(jk).Cells(0).Value, DG.Rows(kj).Cells(0).Value)
                kj = kj + 1
                'mns = mns + 1
            Next
            'balance
            For ij As Integer = 0 To DG.Rows.Count - 1
                Dim cr As Double
                Dim db As Double
                cr += DG.Rows(ij).Cells(3).Value
                db += DG.Rows(ij).Cells(4).Value
                'If cr > db Then
                '    DG.Rows(ij).Cells(5).Value = Format(cr - db, "###0.00")
                'Else
                '    DG.Rows(ij).Cells(5).Value = Format(db - cr, "###0.00")
                'End If
                DG.Rows(ij).Cells(5).Value = Format(cr - db, "###0.00")

            Next

            For mn As Integer = 0 To DG.Rows.Count - 1

                If mn = 0 Then
                    ' DG.Rows(mn).Cells(6).Value = "0"
                Else
                    Dim bal As Double = DG.Rows(mn - 1).Cells(5).Value
                    If Val(bal) > 0 Then
                        Dim days As String = DG.Rows(mn).Cells(8).Value
                        If bal <= 300000 Then
                            'If DG.Rows(mn).Cells(5).Value = 0 Then
                            '    days = Val(days) + 1
                            '    DG.Rows(mn).Cells(6).Value = Format(bal * days * Val(7) / 36500, "###0.00")
                            'Else
                            DG.Rows(mn).Cells(6).Value = Format(bal * Val(percent.Text) / 100, "###0.00")
                            ' End If
                        Else
                            'If DG.Rows(mn).Cells(5).Value = 0 Then
                            '    days = Val(days) + 1
                            '    DG.Rows(mn).Cells(6).Value = Format(bal * days * Val(10) / 36500, "###0.00")
                            'Else
                            DG.Rows(mn).Cells(6).Value = Format(bal * Val(percent.Text) / 100, "###0.00")

                            ' End If
                        End If
                        DG.Rows(mn).Cells(6).Value = Math.Round(Val(DG.Rows(mn).Cells(6).Value), 1, MidpointRounding.ToEven)
                        ' DG.Rows(mn).Cells(6).Value = ForPoint(Val(DG.Rows(mn).Cells(6).Value))
                        DG.Rows(mn).Cells(6).Value = Format(Val(DG.Rows(mn).Cells(6).Value), "###0.00")
                        DG.Rows(mn).Cells(7).Value = Format(Val(DG.Rows(mn).Cells(7).Value), "###0.00")
                    End If

                End If
                'DG.Rows(mn).Cells(7).Value = Format(Val(DG.Rows(mn - 1).Cells(5).Value) * Val(DG.Rows(mn).Cells(8).Value) * int / 36500, "###0.00")
            Next
            'lastdate

            total()
        End If
    End Sub
    Public Sub total()
        Dim dbt As Double
        Dim cr As Double
        Dim deint As Double
        Dim crdeit As Double
        For i As Integer = 0 To DG.Rows.Count - 1
            dbt += Val(DG.Rows(i).Cells(3).Value)
            cr += Val(DG.Rows(i).Cells(4).Value)
            deint += Val(DG.Rows(i).Cells(6).Value)
            crdeit += Val(DG.Rows(i).Cells(7).Value)
        Next
        DG.Rows.Add()
        DG.Rows(DG.Rows.Count - 1).Cells(0).Value = "Total"
        DG.Rows(DG.Rows.Count - 1).Cells(3).Value = Format(dbt, "###0.00")
        DG.Rows(DG.Rows.Count - 1).Cells(4).Value = Format(cr, "###0.00")
        DG.Rows(DG.Rows.Count - 1).Cells(5).Value = DG.Rows(DG.Rows.Count - 2).Cells(5).Value
        DG.Rows(DG.Rows.Count - 1).Cells(6).Value = Format(deint, "###0.00")
        DG.Rows(DG.Rows.Count - 1).Cells(7).Value = Format(crdeit, "###0.00")
        DG.Rows(DG.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Blue

        DG.Rows.Add()
        DG.Rows(DG.Rows.Count - 1).Cells(6).Value = DG.Rows(DG.Rows.Count - 2).Cells(5).Value
        'If crdeit = 0 Then
        'DG.Rows(DG.Rows.Count - 1).Cells(7).Value = 0
        ' Else
        If deint > crdeit Then
            DG.Rows(DG.Rows.Count - 1).Cells(7).Value = deint - crdeit
        Else
            DG.Rows(DG.Rows.Count - 1).Cells(7).Value = crdeit - deint
            ' End If
        End If
        DG.Rows(DG.Rows.Count - 1).Cells(7).Value = Format(DG.Rows(DG.Rows.Count - 1).Cells(7).Value, "###0.00")

        DG.Rows(DG.Rows.Count - 1).Cells(8).Value = Val(DG.Rows(DG.Rows.Count - 2).Cells(5).Value) + Val(DG.Rows(DG.Rows.Count - 1).Cells(7).Value)
        DG.Rows(DG.Rows.Count - 1).Cells(8).Value = Format(Val(DG.Rows(DG.Rows.Count - 1).Cells(8).Value), "###0.00")

        DG.Rows(DG.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
        DG.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Rows(DG.Rows.Count - 1).Cells(8).Style.Alignment = DataGridViewContentAlignment.MiddleRight
        Label14.Text = Val(DG.Rows(DG.Rows.Count - 2).Cells(5).Value)
        Label14.Refresh()
        intamt.Text = Format(Val(DG.Rows(DG.Rows.Count - 1).Cells(7).Value), "###0.00")
        'If Balance.Text = 0 Then
        '    MessageBox.Show("Loan Is AllReady Paid")
        'End If
        ' IntAmt.Text = TotalInt.Text
        'TotalBalance.Text = Val(Balance.Text) + Val(IntAmt.Text)
        DG.DefaultCellStyle.BackColor = Color.LightPink

    End Sub
    Public Sub newloanflat()
        Dim lbdate As String = billDt.Text


        Dim dt As DataTable
        ' Dim myConn As New SqlConnection(MDIParent1.ProjConn)
        dt = ob.Returntable("Select * from Passing_Due_Date_Data where Doc_no=" & Val(Loanno.Text) & "", ob.getconnection())
        If Dgflat.Rows.Count > 0 Then
            Dgflat.Rows.Clear()
        End If
        For i As Integer = 0 To dt.Rows.Count - 1
            Dgflat.Rows.Add()
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Sr_no")
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(1).Value = Format(dt.Rows(i).Item("Due_date"), "dd/MM/yyyy")
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Interest_Amount") '
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Amtpay") '
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(6).Value = dt.Rows(i).Item("Intpay") '
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(5).Value = dt.Rows(i).Item("Installment_Amount")
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(0).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(1).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(2).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(3).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(4).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(5).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(6).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(7).Style.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Next
        Dim cr As Double = 0
        Dim db As Double = 0
        Dim cri As Double = 0
        Dim dbi As Double = 0
        For j As Integer = 0 To Dgflat.Rows.Count - 1
            cr += Dgflat.Rows(j).Cells(2).Value
            db += Dgflat.Rows(j).Cells(3).Value
            Dgflat.Rows(j).Cells(4).Value = Format(cr - db, "###0.00")
            cri += Dgflat.Rows(j).Cells(5).Value
            dbi += Dgflat.Rows(j).Cells(6).Value
            Dgflat.Rows(j).Cells(7).Value = Format(cri - dbi, "###0.00")
        Next
        Dgflat.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
        'Intrest
        Dim int As Double = 0
        For jb As Integer = 0 To Dgflat.Rows.Count - 1
            Dim bdate As Date = billDt.Text
            Dim gdate As Date = Dgflat.Rows(jb).Cells(1).Value
            If bdate > gdate Then
                int += Val(Dgflat.Rows(jb).Cells(5).Value) - Val(Dgflat.Rows(jb).Cells(6).Value)
            End If
        Next
        intamt.Text = int
        Label14.Text = Math.Round(Val(Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(4).Value))
        Label16.Text = Math.Round(Val(Dgflat.Rows(Dgflat.Rows.Count - 1).Cells(7).Value))
    End Sub

    Private Sub pamt_Validated(sender As Object, e As EventArgs) Handles pamt.Validated
        'amount.Text = Val(amount.Text) - Val(pamt.Text) - Val(intamt.Text)
        Netamt.Text = Val(amount.Text) + Val(pamt.Text) + Val(intamt.Text)
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where ptype='LoanReceipt' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                sname.Tag = dt.Rows(0).Item("partyid")
                sname.Text = dt.Rows(0).Item("Remarks")
                Columnname.Tag = dt.Rows(0).Item("Clid")
                Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                cmbtype.Text = dt.Rows(0).Item("Billtype")
                If cmbtype.Text = "CASH" Then
                    payac.Tag = 164
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                Else
                    payac.Tag = 19
                    payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
                    payac.Enabled = True
                End If
                acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                acname.Enabled = False
                percent.Text = "0.50"
                Loanno.Text = ob.FindOneString("Select Loanno From Acmain Where  partyid=" & Val(sname.Tag) & " and clid=" & Columnname.Tag & " and ptype in ('LoanPayment','LoanOpening')", ob.getconnection())
                amount.Text = dt.Rows(0).Item("ReceiptAmt")
                intamt.Text = dt.Rows(0).Item("intamt")
                Netamt.Text = dt.Rows(0).Item("Netamt")
                intac.Tag = 27
                intac.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(intac.Tag) & "", ob.getconnection())
            End If
        End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where ptype='LoanReceipt' and billno=" & Val(Billno.Text) & "", ob.getconnection())
        ob.Execute("delete from Acdata where ptype='LoanReceipt' and Docno=" & Val(Billno.Text) & "", ob.getconnection())
        MessageBox.Show("Delete")
        clear()
    End Sub
End Class
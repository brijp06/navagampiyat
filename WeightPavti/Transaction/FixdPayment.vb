Imports System.Data.SqlClient
Imports WeightPavti.CLS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FixdPayment


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        'TxtFill("Select Account_name from Column_Master", Acc)
        TxtFill("Select Remarks from Acmain", Txtremark)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='FixdPayment'", ob.getconnection())
        acname.Tag = 100
        acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        Intac.Tag = 70
        Intac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Intac.Tag) & "", ob.getconnection())
        txtprovac.Tag = 105
        txtprovac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(txtprovac.Tag) & "", ob.getconnection())
        billDt.Text = Now
        Billno.Focus()
        Dg.Columns.Add("Fromdate", "Fromdate")
        Dg.Columns.Add("Todate", "Todate")
        Dg.Columns.Add("Amount", "Amount")

        Dg.Columns.Add("Int.Rate", "Int.Rate")
        Dg.Columns.Add("Days", "Days")
        Dg.Columns.Add("Int.Amount", "Int.Amount")
        Dg.Columns(0).Width = 70
        Dg.Columns(1).Width = 70
        Dg.Columns(2).Width = 70
        Dg.Columns(3).Width = 50
        Dg.Columns(4).Width = 50
        Dg.Columns(5).Width = 75

        DG1.Columns.Add("Fromdate", "Fromdate")
        DG1.Columns.Add("Todate", "Todate")
        DG1.Columns.Add("Amount", "Amount")

        DG1.Columns.Add("Int.Rate", "Int.Rate")
        DG1.Columns.Add("Days", "Days")
        DG1.Columns.Add("Int.Amount", "Int.Amount")
        DG1.Columns(0).Width = 70
        DG1.Columns(1).Width = 70
        DG1.Columns(2).Width = 70
        DG1.Columns(3).Width = 50
        DG1.Columns(4).Width = 50
        DG1.Columns(5).Width = 75
        Dg.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        DG1.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)

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
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        ob.Execute("delete from acmain where ptype='FixdPayment' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where  ptype='FixdPayment' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Remarks, Netamt,PaymentAmt,ptype, Per, Period, Duedate,fdno,intamt,intresamt,cbj) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & "," & Val(acname.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(Netamt.Text) & "," & Val(Fixdamt.Text) & ",'FixdPayment'," & percent.Text & "," & Period.Text & ",'" & ob.DateConversion(duedt.Text) & "'," & Val(Fixno.Text) & "," & Val(Intamt.Text) & "," & Val(txtprov.Text) & "," & Val(payac.Tag) & ")", ob.getconnection())
        If Trim(cmbtype.Text) = "CASH" Then
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Intac.Tag & ",N'" & Intac.Text & "'," & Val(Intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(Intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & txtprovac.Tag & ",N'" & txtprovac.Text & "'," & Val(txtprov.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(txtprov.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
        Else
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,cramt ,Remarks,dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Intac.Tag & ",N'" & Intac.Text & "'," & Intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Intamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Fixdamt.Text & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Intac.Tag & ",N'" & Intac.Text & "'," & Val(Intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(Intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & txtprovac.Tag & ",N'" & txtprovac.Text & "'," & Val(txtprov.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & payac.Tag & ",N'" & payac.Text & "'," & Val(txtprov.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'FixdPayment')", ob.getconnection())
        End If
        MessageBox.Show("Save")
        If MessageBox.Show("Do You Want To Print This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ButPrint_Click(Nothing, Nothing)
        End If
        clear()
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='FixdPayment'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        Netamt.Clear()
        acname.Clear()
        'Columnname.Clear()
        percent.Clear()
        ' Loanno.Clear()
        Period.Clear()
        duedt.Clear()
        payac.Clear()
        cmbtype.Text = ""
        Fixno.Clear()
        Intamt.Clear()
        Fixdamt.Clear()
        Fixno.Enabled = True
    End Sub

    Private Sub txtAdmissionfee_Validated(sender As Object, e As EventArgs)
        ' Netamt.Text = Val(txtShareAmount.Text) + Val(txtAdmissionfee.Text)
    End Sub



    Private Sub Columnname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'If Columnname.Text <> "" Then
        '    Columnname.Tag = ob.FindOneString("Select Column_Id From Column_Master Where Column_Name=N'" & Trim(Columnname.Text) & "' or Column_Id=" & Val(Columnname.Text) & "", ob.getconnection())
        '    Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
        '    acname.Tag = ob.FindOneString("Select Account_Id From Column_Master Where Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
        '    acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        '    acname.Enabled = False
        'End If
    End Sub

    Private Sub ComboBox1_Validated(sender As Object, e As EventArgs) Handles cmbtype.Validated
        If cmbtype.Text = "CASH" Then
            payac.Tag = 149
            payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
            payac.Enabled = False
        Else
            payac.Enabled = True
            payac.Tag = 0
            payac.Focus()
        End If
    End Sub

    Private Sub payac_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles payac.Validating
        'payac.Tag = ob.FindOneString("Select Account_Id From Account_Master Where Account_Id=" & Val(payac.Text) & " Or Account_Name=N'" & Trim(payac.Text) & "'", ob.getconnection())
        'payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
        If Val(payac.Tag) = 0 Or Trim(payac.Text) = "" Then
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
        End If
    End Sub

    Private Sub TextBox3_Validated(sender As Object, e As EventArgs) Handles Period.Validated
        Dim dat As Date = billDt.Text
        duedt.Text = DateAndTime.DateAdd(DateInterval.Month, Val(Period.Text), dat)
    End Sub

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, Netamt.KeyDown, Intamt.KeyDown, Fixno.KeyDown, Fixdamt.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Fixno_Validated(sender As Object, e As EventArgs) Handles Fixno.Validated
        Dim dt As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ptype not in('fixdPayment','intrest','intrespayment')", ob.getconnection())
        If Val(dt.Rows.Count) > 0 Then
            Dim dts As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ptype='fixdPayment'", ob.getconnection())
            If dts.Rows.Count = 0 Then
                sname.Tag = dt.Rows(0).Item("PartyId")
                sname.Text = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(sname.Tag) & "", ob.getconnection())
                Txtremark.Text = sname.Text
                percent.Text = dt.Rows(0).Item("Per")
                Period.Text = dt.Rows(0).Item("Period")
                Period.Text = dt.Rows(0).Item("Period")
                Fixdamt.Text = dt.Rows(0).Item("Receiptamt")
                duedt.Text = dt.Rows(0).Item("Billdate")
                lbldate.Text = dt.Rows(0).Item("Duedate")
                calint()
                calintlast()
            Else
                MessageBox.Show("Fixd No Paid")
                Fixno.Clear()
                Fixno.Focus()
            End If
        Else
            MessageBox.Show("Invalid Fixd No")
            Fixno.Clear()
            Fixno.Focus()
        End If
    End Sub
    Public Sub calint()
        Dim ndate As Date = billDt.Text
        Dim ddate As Date = lbldate.Text
        If Dg.Rows.Count > 0 Then
            Dg.Rows.Clear()
        End If
        Dg.Rows.Add()
        Dim due As Date = duedt.Text
        Dim ckdate As Date = gFinYearBegin
        If due > ckdate Then
            Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = Format(due, "dd/MM/yyyy")
        Else
            Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = Format(ckdate, "dd/MM/yyyy")
        End If

        Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = billDt.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(2).Value = Fixdamt.Text
        Dim ddyas As String = DateDiff(DateInterval.Day, Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value, Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value)
        If Val(ddyas) >= 0 And Val(ddyas) <= 30 Then
            percent.Text = 0
        ElseIf Val(ddyas) >= 31 And Val(ddyas) <= 90 Then
            percent.Text = 4
        ElseIf Val(ddyas) >= 91 And Val(ddyas) <= 180 Then
            percent.Text = 6
        Else
            percent.Text = 7
        End If
        Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value = percent.Text
        Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Day, Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value, Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value)
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Format(Val(Fixdamt.Text) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(3).Value) * Val(Dg.Rows(Dg.Rows.Count - 1).Cells(4).Value) / 36500, "###0.00")
        Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value = Math.Round(Val(Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value))
        Intamt.Text = Dg.Rows(Dg.Rows.Count - 1).Cells(5).Value
    End Sub
    Public Sub calintlast()
        Dim ndate As Date = billDt.Text
        Dim ddate As Date = lbldate.Text
        If DG1.Rows.Count > 0 Then
            DG1.Rows.Clear()
        End If
        DG1.Rows.Add()
        Dim due As Date = duedt.Text
        Dim ckdate As Date = gFinYearBegin
        Dim bill As Date = billDt.Text
        If due < ckdate Then

            DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = duedt.Text
            DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value = ckdate.AddDays(-1)

        Else
            txtprov.Text = 0
            Exit Sub
            DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value = Format(ckdate, "dd/MM/yyyy")
            DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value = Format(bill, "dd/MM/yyyy") 'billDt.Text
        End If

        DG1.Rows(DG1.Rows.Count - 1).Cells(2).Value = Fixdamt.Text
        Dim ddyas As String = DateDiff(DateInterval.Day, DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value, DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value)
        If Val(ddyas) >= 0 And Val(ddyas) <= 30 Then
            percent.Text = 0
        ElseIf Val(ddyas) >= 31 And Val(ddyas) <= 90 Then
            percent.Text = 4
        ElseIf Val(ddyas) >= 91 And Val(ddyas) <= 180 Then
            percent.Text = 6
        Else
            percent.Text = 7
        End If
        DG1.Rows(DG1.Rows.Count - 1).Cells(3).Value = percent.Text
        DG1.Rows(DG1.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Day, DG1.Rows(DG1.Rows.Count - 1).Cells(0).Value, DG1.Rows(DG1.Rows.Count - 1).Cells(1).Value)
        DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value = Format(Val(Fixdamt.Text) * Val(DG1.Rows(DG1.Rows.Count - 1).Cells(3).Value) * Val(DG1.Rows(DG1.Rows.Count - 1).Cells(4).Value) / 36500, "###0.00")
        DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value = Math.Round(Val(DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value))
        txtprov.Text = DG1.Rows(DG1.Rows.Count - 1).Cells(5).Value
    End Sub

    Private Sub Intamt_Validated(sender As Object, e As EventArgs) Handles Intamt.Validated
        Netamt.Text = Val(Fixdamt.Text) + Val(Intamt.Text) + Val(txtprov.Text)
    End Sub

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & " and ptype='FixdPayment' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                billDt.Text = dt.Rows(0).Item("Billdate")
                sname.Tag = dt.Rows(0).Item("partyid")
                sname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())
                ' Columnname.Tag = dt.Rows(0).Item("clid")
                acname.Tag = dt.Rows(0).Item("Acid")
                acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
                'Columnname.Text = ob.FindOneString("Select Column_Name From Column_Master Where  Column_Id=" & Val(Columnname.Tag) & "", ob.getconnection())
                cmbtype.Text = dt.Rows(0).Item("Billtype")


                'percent.Text = dt.Rows(0).Item("Per")
                'Period.Text = dt.Rows(0).Item("Period")
                'duedt.Text = dt.Rows(0).Item("Duedate")
                Fixno.Text = dt.Rows(0).Item("Fdno")
                'Fixno_Validated(Nothing, Nothing)
                getalldata()
                txtprov.Text = dt.Rows(0).Item("intresamt")
                Intamt.Text = dt.Rows(0).Item("intamt")
                Netamt.Text = Val(Fixdamt.Text) + Val(txtprov.Text) + Val(Intamt.Text)
                'getdata()
                'Txtremark.Text = dt.Rows(0).Item("Remarks")
                'Netamt.Text = dt.Rows(0).Item("Receiptamt")
                payac.Tag = dt.Rows(0).Item("cbj")
                payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())


            End If
        End If
    End Sub
    Public Sub getalldata()
        Dim dt As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ptype not in('fixdPayment','intrest','intrespayment')", ob.getconnection())

        sname.Tag = dt.Rows(0).Item("PartyId")
        sname.Text = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(sname.Tag) & "", ob.getconnection())
        Txtremark.Text = sname.Text
        percent.Text = dt.Rows(0).Item("Per")
        Period.Text = dt.Rows(0).Item("Period")
        Period.Text = dt.Rows(0).Item("Period")
        Fixdamt.Text = dt.Rows(0).Item("Receiptamt")
        duedt.Text = dt.Rows(0).Item("Billdate")
        lbldate.Text = dt.Rows(0).Item("Duedate")
        Fixno.Enabled = False
        'calint()
        'calintlast()

    End Sub
    Public Sub getdata()
        Dim dt As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ptype<>'fixdPayment'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            sname.Tag = dt.Rows(0).Item("PartyId")
            sname.Text = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(sname.Tag) & "", ob.getconnection())
            percent.Text = dt.Rows(0).Item("Per")
            Period.Text = dt.Rows(0).Item("Period")
            Period.Text = dt.Rows(0).Item("Period")
            Fixdamt.Text = dt.Rows(0).Item("Receiptamt")
            duedt.Text = dt.Rows(0).Item("Billdate")
            lbldate.Text = dt.Rows(0).Item("Duedate")

        End If
    End Sub

    Private Sub ButPrint_Click(sender As Object, e As EventArgs) Handles ButPrint.Click
        Dim ssql As String
        ssql = "{Acmain.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Acmain.ptype}='FixdPayment'"
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(Netamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "PaymentPrinting.rpt"
        print()
    End Sub
    Public Sub print()
        Dim CrystalReportViewer1 As New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Text = clsVariables.Repheader & "                                              Report File Name : " & clsVariables.ReportName
        'If rpttype = "" Then
        '    Dim ds As DataSet = New DataSet()
        '    Dim adpt As SqlDataAdapter = New SqlDataAdapter
        '    sCommands.setsqlCommand(ds, adpt, clsVariables.ReportSql, clsVariables.RptTable)
        '    Dim report As CrystalDecisions.CrystalReports.Engine.ReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        '    If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
        '        MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        Me.Close()
        '        Exit Sub
        '    End If
        '    report.Load(clsVariables.RptLocation & clsVariables.ReportName)
        '    report.SetDataSource(ds)
        '    report.SetParameterValue("@CompanyName", clsVariables.CompnyName)
        '    report.SetParameterValue("@Repheader", clsVariables.Repheader)
        '    report.SetParameterValue("@fromdate", clsVariables.FromDate)
        '    report.SetParameterValue("@Todate", clsVariables.ToDate)
        '    CrystalReportViewer1.ReportSource = report
        'Else
        If FileIO.FileSystem.FileExists(clsVariables.RptLocation & clsVariables.ReportName) = False Then
            MessageBox.Show("File Does Not Exists Path is " & clsVariables.RptLocation & clsVariables.ReportName, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Exit Sub
        End If
        Dim crtableLogoninfos As New TableLogOnInfos()
        Dim crtableLogoninfo As New TableLogOnInfo()
        Dim crConnectionInfo As New ConnectionInfo()
        Dim CrTables As Tables
        Dim CrTable As Table
        Dim crReportDocument As New ReportDocument()
        crReportDocument.Load(clsVariables.RptLocation & clsVariables.ReportName)
        Dim i As Integer
        i = 0
        If LCase(clsVariables.ReportName) <> LCase("NewRojmalReport.rpt") And LCase(clsVariables.ReportName) <> LCase("BankBookReport.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalTrialBalanceTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("FinalBalanceSheetTFormat.rpt") And LCase(clsVariables.ReportName) <> LCase("PayslipPrinting.rpt") And LCase(clsVariables.ReportName) <> LCase("PadyRojmalReport.rpt") Then

            If LCase(clsVariables.ReportName) = LCase("OfficeReport.Rpt") Or LCase(clsVariables.ReportName) = LCase("JaminDetailReport.Rpt") Then
                Do While i < crReportDocument.Subreports.Count
                    crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSql1
                    i += 1
                Loop
            Else
                Do While i < crReportDocument.Subreports.Count
                    '  crReportDocument.Subreports(i).RecordSelectionFormula = clsVariables.ReportSubSql(i)
                    i += 1
                Loop
            End If
        End If
        With crConnectionInfo
            .ServerName = "assdsn"
            .DatabaseName = dbname
            If DbAuth <> "WIN" Then
                .UserID = "advsys"
                .Password = "advsys"
            End If
        End With
        CrTables = crReportDocument.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next
        crReportDocument.VerifyDatabase()
        'If LCase(clsVariables.ReportName) = LCase("NewRojmalReport.rpt") Then
        '    crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal
        'End If
        i = 0
        Do While i < crReportDocument.ParameterFields.Count
            If LCase(crReportDocument.ParameterFields(i).Name) = LCase("@CompanyName") Then
                crReportDocument.SetParameterValue(i, clsVariables.CompnyName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@RepHeader") Then
                crReportDocument.SetParameterValue(i, clsVariables.Repheader)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@fromDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@toDate") Then
                crReportDocument.SetParameterValue(i, clsVariables.ToDate)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@OpeningBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dOpeningBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@ClosingBal") Then
                crReportDocument.SetParameterValue(i, clsVariables.dClosingBal)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@NumtoWord") Then
                crReportDocument.SetParameterValue(i, clsVariables.NumtoWord)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Year_Id") Then
                crReportDocument.SetParameterValue(i, clsVariables.WorkingYear)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab1") Then
                '    crReportDocument.SetParameterValue(i, Slab1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Val1") Then
                '    crReportDocument.SetParameterValue(i, Val1)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab2") Then
                '    crReportDocument.SetParameterValue(i, Slab2)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab3") Then
                '    crReportDocument.SetParameterValue(i, Slab3)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab4") Then
                '    crReportDocument.SetParameterValue(i, Slab4)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab5") Then
                '    crReportDocument.SetParameterValue(i, Slab5)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Slab6") Then
                'crReportDocument.SetParameterValue(i, Slab6)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@UserName") Then
                crReportDocument.SetParameterValue(i, fulluserName)
            ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Date") Then
                crReportDocument.SetParameterValue(i, clsVariables.FromDate & " To " & clsVariables.ToDate)

                '    crReportDocument.SetParameterValue(i, MdiMain.ComboDept.Text)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTDRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtDbIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@MINTCRPER") Then
                '    crReportDocument.SetParameterValue(i, Val(MemberInterestLedger.txtCrIntRate.Text))
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@BasedRate") Then
                '    crReportDocument.SetParameterValue(i, BasedRate)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Season_Id") Then
                '    crReportDocument.SetParameterValue(i, Season_Id)
                'ElseIf LCase(crReportDocument.ParameterFields(i).Name) = LCase("@Department_Id") Then
                '    crReportDocument.SetParameterValue(i, Val(MdiMain.ComboDept.SelectedValue))
            End If
            i += 1
        Loop
        'CrystalReportViewer1.ParameterFieldInfo = pf
        ' Dim pr As String
        ' pr = clsVariables.print
        'If pr <> 2 Then
        '    CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        '    CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        '    'End If
        '    rpttype = ""
        '    'End If

        '    'CrystalReportViewer1.Print()
        '    CrystalReportViewer1.Zoom(100)
        '    CrystalReportViewer1.Refresh()
        'Else
        'CrystalReportViewer1.ReportSource = crReportDocument  'clsVariables.RptLocation & clsVariables.ReportName
        CrystalReportViewer1.SelectionFormula = clsVariables.ReportSql
        crReportDocument.RecordSelectionFormula = clsVariables.ReportSql
        CrystalReportViewer1.ReportSource = crReportDocument
        crReportDocument.PrintToPrinter(2, False, 0, 0)
        'End If

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where ptype='FixdPayment' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where  ptype='FixdPayment' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("Done")
        clear()
    End Sub

    Private Sub payac_KeyDown(sender As Object, e As KeyEventArgs) Handles payac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtremark.Focus()
        End If
    End Sub
End Class
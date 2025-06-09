Imports System.Data.SqlClient
Imports WeightPavti.CLS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class OldMangnaReceipt


    Private Sub Txtremark_TextChanged(sender As Object, e As EventArgs) Handles Txtremark.TextChanged

    End Sub



    Private Sub MemberInward_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select Member_name from Member_Master", sname)
        'TxtFill("Select Account_name from Column_Master", Acc)
        TxtFill("Select Remarks from Acmain", Txtremark)
        TxtFill("Select column_name from column_Master", txtvillageid)
        TxtFill("Select name from itemgroup", txtcolumn)
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='OReceipt' and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        acname.Tag = 21
        acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
        Intac.Tag = 66
        Intac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(Intac.Tag) & "", ob.getconnection())
        txtprovac.Tag = 24
        txtprovac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(txtprovac.Tag) & "", ob.getconnection())
        txtvillageid.Tag = 5
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where  column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
        txtvillageid.Enabled = False
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
        Cmbdepartment.SelectedIndex = 0
        txtprint.Text = 1
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
        ob.Execute("delete from acmain where department='" & Cmbdepartment.Text & "' and ptype='OReceipt' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where department='" & Cmbdepartment.Text & "' and ptype='OReceipt' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())



        If Val(txtdisamt.Text) <> 0 Then
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Netamt,ReceiptAmt,intamt,ptype,cbj,basic,roundoff,per,fdno,tid,clid,remarks,rate,share) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & ",21," & Val(netamt.Text) & "," & Val(Billamt.Text) - Val(txtdisamt.Text) & "," & intamt.Text & ",'OReceipt'," & payac.Tag & "," & Val(Billamt.Text) & "," & Val(txtdisamt.Text) & "," & Val(txtprovac.Text) & "," & Val(Intac.Text) & "," & Val(txtcolumn.Tag) & "," & Val(txtvillageid.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(txtdis.Text) & "," & Val(txtintrest.Text) & ")", ob.getconnection())
        Else
            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Netamt,ReceiptAmt,intamt,ptype,cbj,basic,roundoff,per,fdno,tid,clid,remarks,rate,share) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & aq(cmbtype.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(sname.Tag) & ",21," & Val(netamt.Text) & "," & Val(Billamt.Text) & "," & Val(intamt.Text) & ",'OReceipt'," & payac.Tag & "," & Val(Billamt.Text) & "," & Val(txtdisamt.Text) & "," & Val(txtprovac.Text) & "," & Val(Intac.Text) & "," & Val(txtcolumn.Tag) & "," & Val(txtvillageid.Tag) & ",N'" & Trim(Txtremark.Text) & "'," & Val(txtdis.Text) & "," & Val(txtintrest.Text) & ")", ob.getconnection())
        End If
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',21,N'-'," & Val(Billamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'OReceipt','" & Cmbdepartment.Text & "')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(payac.Tag) & ",N'" & acname.Text & "'," & Val(netamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'OReceipt','" & Cmbdepartment.Text & "')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',24,N'-'," & Val(intamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'OReceipt','" & Cmbdepartment.Text & "')", ob.getconnection())
        ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',66,N'" & acname.Text & "'," & Val(txtdisamt.Text) & ",N'" & Trim(Txtremark.Text) & "',0,'OReceipt','" & Cmbdepartment.Text & "')", ob.getconnection())
        MessageBox.Show("Save")
        If MessageBox.Show("Do You Want To Print This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ButPrint_Click(Nothing, Nothing)
        End If
        clear()
        Billno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where ptype='OReceipt' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        Billno.Focus()
    End Sub
    Public Sub clear()
        Billno.Clear()
        billDt.Text = Now
        sname.Clear()
        sname.Tag = 0
        Txtremark.Clear()
        netamt.Clear()
        acname.Clear()

        percent.Clear()
        ' Loanno.Clear()
        Period.Clear()
        duedt.Clear()
        payac.Clear()
        cmbtype.Text = ""
        Fixno.Clear()
        intamt.Clear()
        txtcolumn.Clear()
        netamt.Clear()
        Billamt.Clear()
        txtdisamt.Clear()
        txtintrest.Clear()
        txtdis.Clear()
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
            payac.Tag = 9941
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
            HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Group_id=8"
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

    Private Sub Billno_KeyDown(sender As Object, e As KeyEventArgs) Handles Txtremark.KeyDown, Fixno.KeyDown, cmbtype.KeyDown, Billno.KeyDown, billDt.KeyDown, sname.KeyDown, txtvillageid.KeyDown, txtcolumn.KeyDown, Billamt.KeyDown, txtdisamt.KeyDown, intamt.KeyDown, netamt.KeyDown, txtdis.KeyDown, txtintrest.KeyDown
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
                'Fixdamt.Text = dt.Rows(0).Item("Receiptamt")
                duedt.Text = dt.Rows(0).Item("Billdate")
                lbldate.Text = dt.Rows(0).Item("Duedate")
                'calint()
                'calintlast()
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


    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & "  and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='OReceipt' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            'If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

            billDt.Text = dt.Rows(0).Item("Billdate")
            sname.Tag = dt.Rows(0).Item("partyid")
            sname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())
            cmbtype.Text = dt.Rows(0).Item("Billtype")
            acname.Tag = dt.Rows(0).Item("cbj")
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            Txtremark.Text = ob.IfNullThen(dt.Rows(0).Item("Remarks"), "")
            Billamt.Text = dt.Rows(0).Item("basic")
            intamt.Text = dt.Rows(0).Item("Intamt")
            netamt.Text = dt.Rows(0).Item("Netamt")
            txtdisamt.Text = dt.Rows(0).Item("roundoff")
            'txtintrest.Text = dt.Rows(0).Item("per")
            'txtdis.Text = dt.Rows(0).Item("fdno")
            txtcolumn.Tag = dt.Rows(0).Item("tid")
            txtvillageid.Tag = dt.Rows(0).Item("clid")
            txtintrest.Text = ob.IfNullThen(dt.Rows(0).Item("share"), 0)
            txtdis.Text = ob.IfNullThen(dt.Rows(0).Item("rate"), 0)
            If (txtcolumn.Tag) <> 0 Then
                txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            End If
            If Val(txtvillageid.Tag) <> 0 Then
                txtvillageid.Text = ob.FindOneString("select column_name from column_master where  column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
            End If
            payac.Tag = dt.Rows(0).Item("cbj")
            payac.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(payac.Tag) & "", ob.getconnection())
            acname.Enabled = False
            'loaddgdate()
            'End If
        End If
    End Sub
    Public Sub getalldata()


    End Sub
    Public Sub getdata()
        Dim dt As DataTable = ob.Returntable("select * from acmain where Fdno=" & Val(Fixno.Text) & " and ptype<>'fixdPayment'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            sname.Tag = dt.Rows(0).Item("PartyId")
            sname.Text = ob.FindOneString("select Member_Name from Member_Master where Member_id=" & Val(sname.Tag) & "", ob.getconnection())
            percent.Text = dt.Rows(0).Item("Per")
            Period.Text = dt.Rows(0).Item("Period")
            Period.Text = dt.Rows(0).Item("Period")
            '  Fixdamt.Text = dt.Rows(0).Item("Receiptamt")
            duedt.Text = dt.Rows(0).Item("Billdate")
            lbldate.Text = dt.Rows(0).Item("Duedate")

        End If
    End Sub

    Private Sub ButPrint_Click(sender As Object, e As EventArgs) Handles ButPrint.Click
        Dim ssql As String
        ssql = "{Acmain.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Acmain.ptype}='OReceipt'"
        ssql = ssql & " and {Acmain.year_id}='" & clsVariables.WorkingYear & "'"
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(netamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "Receipt.rpt"
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
        crReportDocument.PrintToPrinter(Val(txtprint.Text), False, 0, 0)
        'End If

    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where department='" & Cmbdepartment.Text & "' and ptype='OReceipt' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where department='" & Cmbdepartment.Text & "' and ptype='OReceipt' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("Done")
        clear()
    End Sub

    Private Sub payac_KeyDown(sender As Object, e As KeyEventArgs) Handles payac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txtremark.Focus()
        End If
    End Sub
    Private Sub txtvillageid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillageid.Validating
        txtvillageid.Tag = ob.FindOneString("select column_id from column_master where column_name=N'" & Val(txtvillageid.Text) & "' or column_id=" & Val(txtvillageid.Text) & "", ob.getconnection())
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
    End Sub
    Private Sub txtcolumn_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtcolumn.Validating

        txtcolumn.Tag = ob.FindOneString("select code from itemgroup where name=N'" & Val(txtcolumn.Text) & "' or code=" & Val(txtcolumn.Text) & "", ob.getconnection())
        If Val(txtcolumn.Tag) <> 0 Then
            txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            'loaddg()
            Billamt.Text = ob.FindOneString("select isnull(paymentamt,0)-isnull(receiptamt,0) from acmain where  partyid=" & Val(sname.Tag) & " and clid=" & Val(txtvillageid.Tag) & "", ob.getconnection())

        End If


    End Sub

    Private Sub txtdisamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtdisamt.Validating
        cal()
    End Sub
    Public Sub cal()
        netamt.Text = Val(Billamt.Text) + Val(intamt.Text) - Val(txtdisamt.Text)
        'lbltotal.Text = Val(netamt.Text)
    End Sub

    Private Sub intamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles intamt.Validating
        If Trim(intamt.Text) = "" Then
            intamt.Text = 0
        End If
        cal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clsVariables.Findqueri = "select billno,billdate,PartyId,m.member_name as membername,Netamt from Acmain as a inner join MEMBER_MASTER as m on a.PartyId=m.Member_Id where year_id='" & clsVariables.WorkingYear & "' and ptype='OReceipt' order by billno"
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Billno.Text = clsVariables.HelpId
        Billno_Validating(Nothing, Nothing)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ssql As String
        ssql = "{Acmain.billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {Acmain.ptype}='OReceipt'"
        ssql = ssql & " and {Acmain.year_id}='" & clsVariables.WorkingYear & "'"
        clsVariables.ReportSql = ssql
        clsVariables.NumtoWord = ob.Num_To_Guj_Word(Val(netamt.Text))
        clsVariables.Repheader = "BillPrint"
        clsVariables.ReportName = "Receipt.rpt"
        Dim frm As New Reportform
        frm.Show()
    End Sub

    Private Sub txtdis_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtdis.Validating
        If Val(txtdis.Text) Then
            txtdisamt.Text = Val(Billamt.Text) * Val(txtdis.Text) / 100
            txtdisamt.Text = Math.Round(Val(txtdisamt.Text), 0)
            cal()
        Else
            txtdisamt.Focus()
        End If
    End Sub

    Private Sub txtintrest_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtintrest.Validating
        If Val(txtintrest.Text) Then
            intamt.Text = Val(Billamt.Text) * Val(txtintrest.Text) / 100
            intamt.Text = Math.Round(Val(intamt.Text), 0)
            'lblInt.Text = Val(intamt.Text)
            cal()
        Else
            intamt.Focus()
        End If
    End Sub
End Class
Imports System.Data.SqlClient
Imports WeightPavti.CLS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmReceiptEntry
    Dim addnew As Boolean
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Cmbdepartment_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cmbdepartment.Validating
        Billno.Text = ob.FindOneString("Select isnull(max(Billno),0)+1 from Acmain Where Year_id='" & clsVariables.WorkingYear & "' and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Receipt'", ob.getconnection())
    End Sub

    Private Sub FrmReceiptEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFill("Select column_name from column_Master", txtvillageid)
        TxtFill("Select name from itemgroup", txtcolumn)
        TxtFill("Select Member_name from Member_Master", Cname)
        billDt.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        txtprint.Text = 1
        addnew = True
        Cmbdepartment.SelectedIndex = 0
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

    Private Sub Cname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cname.Validating
        If Cname.Text <> "" Then
            Cname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(Cname.Text) & "' or Member_Id=" & Val(Cname.Text) & "", ob.getconnection())
            If Val(Cname.Tag) <> 0 Then
                Cname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())
                If addnew = True Then
                    'loaddg()
                End If
            End If
        End If

    End Sub
    Public Sub loaddg()
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Dim dts As DataTable = ob.Returntable("select Itemid,srno,blockNo,ServeNo,AHektar,AGuntha,LFund,Amount,TotalAmount,a.billno,a.clid,a.Tid,a.year_id from acstock as s inner join Acmain as a on a.Billno=s.Billno and a.Year_id=s.Year_id and a.ptype=s.ptype where a.PartyId=" & Val(Cname.Tag) & " and s.ptype='Mangna' ", ob.getconnection())
        For i As Integer = 0 To dts.Rows.Count - 1
            Dim dt As DataTable = ob.Returntable("select * from receipt where partyid=" & Val(Cname.Tag) & " and docno=" & Val(dts.Rows(i).Item("billno")) & " and receiptyear='" & Trim(dts.Rows(i).Item("year_id")) & "' and srno=" & Val(dts.Rows(i).Item("srno")) & " and Receiptamt=" & Val(dts.Rows(i).Item("TotalAmount")) & "", ob.getconnection())
            If dt.Rows.Count = 0 Then
                Dim df As String = ob.FindOneString("select sum(isnull(Receiptamt,0)) from receipt where partyid=" & Val(Cname.Tag) & " and docno=" & Val(dts.Rows(i).Item("billno")) & " and receiptyear='" & Trim(dts.Rows(i).Item("year_id")) & "'", ob.getconnection())
                If Val(df) <> Val(dts.Rows(i).Item("TotalAmount")) Then
                    dg.Rows.Add()
                    dg.Rows(dg.Rows.Count - 1).Cells(0).Value = Val(dts.Rows(i).Item("srno"))
                    dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = Val(dts.Rows(i).Item("Itemid"))
                    dg.Rows(dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select village_name from village_master where  village_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(2).Value = Val(dts.Rows(i).Item("clid"))
                    dg.Rows(dg.Rows.Count - 1).Cells(3).Value = ob.FindOneString("select column_name from column_master where column_id=" & Val(dts.Rows(i).Item("clid")) & "", ob.getconnection())
                    dg.Rows(dg.Rows.Count - 1).Cells(4).Value = Val(dts.Rows(i).Item("blockNo"))
                    dg.Rows(dg.Rows.Count - 1).Cells(5).Value = Val(dts.Rows(i).Item("ServeNo"))
                    dg.Rows(dg.Rows.Count - 1).Cells(6).Value = Val(dts.Rows(i).Item("AHektar"))
                    dg.Rows(dg.Rows.Count - 1).Cells(7).Value = Val(dts.Rows(i).Item("AGuntha"))
                    dg.Rows(dg.Rows.Count - 1).Cells(8).Value = Val(dts.Rows(i).Item("Amount"))
                    dg.Rows(dg.Rows.Count - 1).Cells(9).Value = Val(dts.Rows(i).Item("LFund"))
                    If Val(df) <> 0 Then
                        dg.Rows(dg.Rows.Count - 1).Cells(10).Value = Val(dts.Rows(i).Item("TotalAmount")) - Val(df)
                    Else
                        dg.Rows(dg.Rows.Count - 1).Cells(10).Value = Val(dts.Rows(i).Item("TotalAmount"))
                    End If
                    dg.Rows(dg.Rows.Count - 1).Cells(12).Value = Val(dts.Rows(i).Item("billno"))
                    dg.Rows(dg.Rows.Count - 1).Cells(13).Value = Val(dts.Rows(i).Item("clid"))
                    dg.Rows(dg.Rows.Count - 1).Cells(14).Value = Val(dts.Rows(i).Item("Tid"))
                    dg.Rows(dg.Rows.Count - 1).Cells(15).Value = Trim(dts.Rows(i).Item("year_id"))
                End If
            End If
        Next
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

    End Sub
    Public Sub loaddgdate()
        'ob.Execute("delete from tmpReceipt", ob.getconnection())
        'Dim dvb As DataTable = ob.Returntable("select * from Acmain where PartyId=" & Val(Cname.Tag) & " and Department='" & Trim(Cmbdepartment.Text) & "' and ptype in ('Sales','opening') and billdate<'" & ob.DateConversion(billDt.Text) & "'", ob.getconnection())

        'If dvb.Rows.Count > 0 Then
        '    For j As Integer = 0 To dvb.Rows.Count - 1
        '        Dim dss As DataTable = ob.Returntable("select isnull(sum(Receiptamt),0) as  amt from Receipt where partyid=" & dvb.Rows(j).Item("Partyid") & " and Billno<>" & Val(Billno.Text) & " and ptype='" & Trim(Cmbdepartment.Text) & "'", ob.getconnection())
        '        If dss.Rows.Count > 0 Then
        '            Dim bal As Double = Val(dss.Rows(0).Item("amt"))

        '            ob.Execute("Insert Into tmpReceipt(Docno, Docdate, Partyid, Receiptamt,ptype) values(" & dvb.Rows(j).Item("Billno") & ",'" & ob.DateConversion(dvb.Rows(j).Item("Billdate")) & "'," & dvb.Rows(j).Item("Partyid") & "," & Val(bal) & ",'" & Trim(Cmbdepartment.Text) & "')", ob.getconnection())

        '            'If Val(dvb.Rows(j).Item("PaymentAmt")) - Val(dss.Rows(0).Item("amt")) <> 0 Then
        '            '    Dim bal As Double = Val(dvb.Rows(j).Item("PaymentAmt")) - Val(dss.Rows(0).Item("amt"))
        '            '    ob.Execute("Insert Into tmpReceipt(Docno, Docdate, Partyid, Receiptamt,ptype) values(" & dvb.Rows(j).Item("Billno") & ",'" & ob.DateConversion(dvb.Rows(j).Item("Billdate")) & "'," & dvb.Rows(j).Item("Partyid") & "," & Val(bal) & ",'" & Trim(Cmbdepartment.Text) & "')", ob.getconnection())
        '            'End If
        '        Else
        '                Dim bal As Double = Val(dvb.Rows(j).Item("PaymentAmt"))

        '            ob.Execute("Insert Into tmpReceipt(Docno, Docdate, Partyid, Receiptamt,ptype) values(" & dvb.Rows(j).Item("Billno") & ",'" & ob.DateConversion(dvb.Rows(j).Item("Billdate")) & "'," & dvb.Rows(j).Item("Partyid") & "," & Val(bal) & ",'" & Trim(Cmbdepartment.Text) & "')", ob.getconnection())

        '        End If
        '    Next
        'End If


        'Dim dt As DataTable = ob.Returntable("select * from Receipt where billno=" & Val(Billno.Text) & " and ptype='" & Cmbdepartment.Text & "' and partyid=" & Val(Cname.Tag) & " and receiptyear=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        'If dg.Rows.Count > 0 Then
        '    dg.Rows.Clear()
        'End If
        'If dt.Rows.Count > 0 Then
        '    For i As Integer = 0 To dt.Rows.Count - 1

        '        dg.Rows.Add()
        '        dg.Rows(dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Docno")
        '        dg.Rows(dg.Rows.Count - 1).Cells(1).Value = Format(dt.Rows(i).Item("Docdate"), "dd/MM/yyyy")
        '        dg.Rows(dg.Rows.Count - 1).Cells(2).Value = dt.Rows(i).Item("Receiptamt")
        '        dg.Rows(dg.Rows.Count - 1).Cells(3).Value = dt.Rows(i).Item("Receiptamt") 'ob.FindOneString("select Receiptamt from Receipt where billno=" & Val(Billno.Text) & " and Docno=" & dt.Rows(i).Item("Docno") & " and ptype='" & Trim(Cmbdepartment.Text) & "'", ob.getconnection())
        '        dg.Rows(i).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        '        Dim ddate As Date = billDt.Text
        '        dg.Rows(dg.Rows.Count - 1).Cells(4).Value = DateDiff(DateInterval.Day, dg.Rows(i).Cells(1).Value, ddate)
        '        If Val(dg.Rows(dg.Rows.Count - 1).Cells(4).Value) > 1 And Val(dg.Rows(dg.Rows.Count - 1).Cells(4).Value) < 180 Then
        '            dg.Rows(dg.Rows.Count - 1).Cells(5).Value = 9
        '        Else
        '            dg.Rows(dg.Rows.Count - 1).Cells(5).Value = 12
        '        End If
        '        dg.Rows(dg.Rows.Count - 1).Cells(6).Value = (Val(dg.Rows(dg.Rows.Count - 1).Cells(2).Value) * Val(dg.Rows(dg.Rows.Count - 1).Cells(5).Value) * Val(dg.Rows(dg.Rows.Count - 1).Cells(4).Value)) / 36500
        '        dg.Rows(dg.Rows.Count - 1).Cells(6).Value = Math.Round(Val(dg.Rows(dg.Rows.Count - 1).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
        '        '   DG.Rows(DG.Rows.Count - 1).Cells(3).Value = 0
        '        dg.Rows(dg.Rows.Count - 1).Cells(7).Value = 0

        '    Next
        '    dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

        'End If
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        Dim dts As DataTable
        dts = ob.Returntable("select Itemid,srno,blockNo,ServeNo,AHektar,AGuntha,LFund,Amount,TotalAmount,a.billno,a.clid,a.Tid,a.year_id from acstock as s inner join Acmain as a on a.Billno=s.Billno and a.Year_id=s.Year_id and a.ptype=s.ptype where a.PartyId=" & Val(Cname.Tag) & " and s.ptype='Mangna' ", ob.getconnection())
        For i As Integer = 0 To dts.Rows.Count - 1
            Dim dt As DataTable
            If clsVariables.WorkingYear = "2022-2023" Then
                dt = ob.Returntable("select * from receipt where partyid=" & Val(Cname.Tag) & " and docno=" & Val(dts.Rows(i).Item("billno")) & " and receiptyear='" & Trim(dts.Rows(i).Item("year_id")) & "' and billno=" & Val(Billno.Text) & " and srno=0", ob.getconnection())
            Else
                dt = ob.Returntable("select * from receipt where partyid=" & Val(Cname.Tag) & " and docno=" & Val(dts.Rows(i).Item("billno")) & " and receiptyear='" & Trim(dts.Rows(i).Item("year_id")) & "' and billno=" & Val(Billno.Text) & " and srno=" & Val(dts.Rows(i).Item("srno")) & "", ob.getconnection())
            End If
            If dt.Rows.Count > 0 Then
                dg.Rows.Add()
                dg.Rows(dg.Rows.Count - 1).Cells(0).Value = Val(dts.Rows(i).Item("srno"))
                dg.Rows(dg.Rows.Count - 1).Cells(1).Tag = Val(dts.Rows(i).Item("Itemid"))
                dg.Rows(dg.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select village_name from village_master where  village_id=" & Val(dts.Rows(i).Item("Itemid")) & "", ob.getconnection())
                dg.Rows(dg.Rows.Count - 1).Cells(2).Value = Val(dts.Rows(i).Item("clid"))
                dg.Rows(dg.Rows.Count - 1).Cells(3).Value = ob.FindOneString("select column_name from column_master where column_id=" & Val(dts.Rows(i).Item("clid")) & "", ob.getconnection())
                dg.Rows(dg.Rows.Count - 1).Cells(4).Value = Val(dts.Rows(i).Item("blockNo"))
                dg.Rows(dg.Rows.Count - 1).Cells(5).Value = Val(dts.Rows(i).Item("ServeNo"))
                dg.Rows(dg.Rows.Count - 1).Cells(6).Value = Val(dts.Rows(i).Item("AHektar"))
                dg.Rows(dg.Rows.Count - 1).Cells(7).Value = Val(dts.Rows(i).Item("AGuntha"))
                dg.Rows(dg.Rows.Count - 1).Cells(8).Value = Val(dts.Rows(i).Item("Amount"))
                dg.Rows(dg.Rows.Count - 1).Cells(9).Value = Val(dts.Rows(i).Item("LFund"))
                dg.Rows(dg.Rows.Count - 1).Cells(10).Value = Val(dts.Rows(i).Item("TotalAmount"))
                dg.Rows(dg.Rows.Count - 1).Cells(11).Value = True
                dg.Rows(dg.Rows.Count - 1).Cells(12).Value = Val(dts.Rows(i).Item("billno"))
                dg.Rows(dg.Rows.Count - 1).Cells(13).Value = Val(dts.Rows(i).Item("clid"))
                dg.Rows(dg.Rows.Count - 1).Cells(14).Value = Val(dts.Rows(i).Item("Tid"))
                dg.Rows(dg.Rows.Count - 1).Cells(15).Value = Trim(dts.Rows(i).Item("year_id"))
            End If
        Next
        dg.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub
    Private Sub cmbType_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbType.Validating
        If cmbType.Text = "Bank" Then
            acname.Enabled = True
            ' acname.Tag = 37
            'acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
            acname.Focus()
        Else
            acname.Tag = 9941
            acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & acname.Tag & "", ob.getconnection())
            acname.Enabled = False
        End If
        If Trim(cmbType.Text) <> "" Then
        Else
            MessageBox.Show("Place Select Type")
            cmbType.Focus()
        End If
    End Sub

    Private Sub acname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles acname.Validating
        acname.Tag = ob.FindOneString("Select Account_id From Account_Master Where Account_Name=N'" & Trim(acname.Text) & "' or Account_id=" & Val(acname.Text) & "", ob.getconnection())
        acname.Text = ob.FindOneString("select Account_name from Account_master Where Account_id=" & Val(acname.Tag) & "", ob.getconnection())

        If Val(acname.Tag) = 0 Or Trim(acname.Text) = "" Then
            clsVariables.HelpId = "Account_id"
            clsVariables.HelpName = "Account_Name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_Name"
            HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Group_id=8"
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                acname.Tag = clsVariables.RtnHelpId
                acname.Text = clsVariables.RtnHelpName
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim rec As Double = 0
        Dim ints As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            If dg.Rows(i).Cells(11).Value = True Then
                ints += dg.Rows(i).Cells(10).Value
            Else
                'rec += DG.Rows(i).Cells(3).Value
                'ints += DG.Rows(i).Cells(7).Value
            End If
        Next
        Billamt.Text = Val(ints)
        'intamt.Text = Val(ints)
        'netamt.Text = Val(rec) + Val(ints)
        'netamt.Focus()
        txtdis.Focus()
    End Sub

    Private Sub Cmbdepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles netamt.KeyDown, intamt.KeyDown, Cname.KeyDown, cmbType.KeyDown, Cmbdepartment.KeyDown, Billno.KeyDown, billDt.KeyDown, Billamt.KeyDown, acname.KeyDown, txtvillageid.KeyDown, txtcolumn.KeyDown, txtintrest.KeyDown, txtdis.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Remarks_KeyDown(sender As Object, e As KeyEventArgs) Handles Remarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButSave.Focus()
        End If
    End Sub

    Private Sub ButSave_Click(sender As Object, e As EventArgs) Handles ButSave.Click
        Dim sdate As Date = billDt.Text

        If sdate >= gFinYearBegin And sdate <= gFinYearEnd Then
            ob.Execute("delete from acmain where department='" & Cmbdepartment.Text & "' and ptype='Receipt' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Acdata where department='" & Cmbdepartment.Text & "' and ptype='Receipt' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("delete from Receipt where ptype='Receipt' and Billno=" & Val(Billno.Text) & " and yearid=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())


            ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid, Netamt,ReceiptAmt,intamt,ptype,cbj,basic,Lessamt,per,fdno,tid,clid,Roundoff) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(Cmbdepartment.Text) & "," & aq(cmbType.Text) & "," & Val(Billno.Text) & ",'" & ob.DateConversion(billDt.Text) & "'," & Val(Cname.Tag) & ",15," & Val(netamt.Text) & "," & Val(Billamt.Text) & "," & Val(intamt.Text) & ",'Receipt'," & acname.Tag & "," & Val(Billamt.Text) & "," & Val(txtdisamt.Text) & "," & Val(txtintrest.Text) & "," & Val(txtdis.Text) & "," & Val(txtcolumn.Tag) & "," & Val(txtvillageid.Tag) & ",0)", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',15,N'-'," & Val(Billamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Receipt','" & Cmbdepartment.Text & "')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "'," & acname.Tag & ",N'" & acname.Text & "'," & Val(netamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Receipt','" & Cmbdepartment.Text & "')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, cramt,Remarks,dramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',24,N'-'," & Val(intamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Receipt','" & Cmbdepartment.Text & "')", ob.getconnection())
            ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, dramt,Remarks,cramt,ptype,Department) Values(1,'" & clsVariables.WorkingYear & "','" & cmbType.Text & "'," & Billno.Text & ",'" & ob.DateConversion(billDt.Text) & "',66,N'" & acname.Text & "'," & Val(txtdisamt.Text) & ",N'" & Trim(Remarks.Text) & "',0,'Receipt','" & Cmbdepartment.Text & "')", ob.getconnection())

            For i As Integer = 0 To dg.Rows.Count - 1
                If Val(dg.Rows(i).Cells(11).Value) = True Then
                    If clsVariables.WorkingYear <> "2022-2023" Then
                        ob.Execute("Insert Into Receipt(Docno, Partyid,ptype,Billno,yearid,receiptyear,srno,Receiptamt) values(" & Val(dg.Rows(i).Cells(12).Value) & "," & Cname.Tag & ",'Receipt'," & Val(Billno.Text) & ",'" & clsVariables.WorkingYear & "','" & Trim(dg.Rows(i).Cells(15).Value) & "'," & Val(dg.Rows(i).Cells(0).Value) & "," & Val(dg.Rows(i).Cells(10).Value) & ")", ob.getconnection())
                    Else
                        ob.Execute("Insert Into Receipt(Docno, Partyid,ptype,Billno,yearid,receiptyear,srno,Receiptamt) values(" & Val(dg.Rows(i).Cells(12).Value) & "," & Cname.Tag & ",'Receipt'," & Val(Billno.Text) & ",'" & clsVariables.WorkingYear & "','" & Trim(dg.Rows(i).Cells(15).Value) & "',0," & Val(dg.Rows(i).Cells(10).Value) & ")", ob.getconnection())

                    End If
                End If
            Next
            'ob.Execute("delete from Tmpprint", ob.getconnection())



            MessageBox.Show("saved")
            If MessageBox.Show("Do You Want To Print This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ButPrint_Click(Nothing, Nothing)
            End If

            'If MessageBox.Show("Do You Want To Send SMS...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
            '    Dim mnum As String = ob.FindOneString("select Mobile_No from Member_Master where Member_id=" & Cname.Tag & "", ob.getconnection())
            '    If Cmbdepartment.Text = "bhandar" Then
            '        Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and  acid=139", ob.getconnection())
            '        '(KSMMOL){#var#} {#var#} તા:-{#var#} રસીદ નં.:{#var#} રકમ : {#var#} વ્યાજ રકમ : {#var#} બાકી રકમ રૂપિયા.:{#var#} 
            '        Dim msg As String = "(KSMMOL)ભંડાર વિભાગ તા:-" & billDt.Text & " રસીદ નં.:" & Billno.Text & " રકમ : " & Billamt.Text & " વ્યાજ રકમ : " & intamt.Text & " બાકી રકમ રૂપિયા.:" & Val(bal) & ""
            '        ob.SendSMS(mnum, msg)
            '    Else
            '        Dim bal As String = ob.FindOneString("select sum(paymentamt)-sum(receiptamt) from acmain where partyid=" & Cname.Tag & " and acid=141", ob.getconnection())
            '        Dim msg As String = "(KSMMOL)ખાતર વિભાગ તા:-" & billDt.Text & " રસીદ નં.:" & Billno.Text & " રકમ :" & Billamt.Text & " વ્યાજ રકમ : " & intamt.Text & " બાકી રકમ રૂપિયા.:" & Val(bal) & ""
            '        ob.SendSMS(mnum, msg)
            '    End If
            'End If

            clear()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            billDt.Focus()
        End If
    End Sub
    Public Sub clear()
        Cname.Clear()
        netamt.Clear()
        Billamt.Clear()
        intamt.Clear()
        acname.Clear()
        Cmbdepartment.Focus()
        addnew = True
        If dg.Rows.Count > 0 Then
            dg.Rows.Clear()
        End If
        txtintrest.Clear()
        txtdis.Clear()
        txtdisamt.Clear()
        txtcolumn.Clear()
        txtcolumn.Tag = 0
        txtvillageid.Clear()
        txtvillageid.Tag = 0
        Remarks.Clear()
    End Sub

    Private Sub ButPrint_Click(sender As Object, e As EventArgs) Handles ButPrint.Click
        Dim ssql As String
        ssql = "{acmain.Billno}=" & Val(Billno.Text) & ""
        ssql = ssql & " and {acmain.ptype}='Receipt'"
        ssql = ssql & " and {acmain.Year_id}=" & aq(clsVariables.WorkingYear)
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

    Private Sub Billno_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Billno.Validating
        Dim dt As DataTable = ob.Returntable("select * from acmain where billno=" & Val(Billno.Text) & "  and Department='" & Trim(Cmbdepartment.Text) & "' and ptype='Receipt' and year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        If dt.Rows.Count > 0 Then
            'If MessageBox.Show("Do You Want To Edit This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            addnew = False
            billDt.Text = dt.Rows(0).Item("Billdate")
            Cname.Tag = dt.Rows(0).Item("partyid")
            Cname.Text = ob.FindOneString("select Member_name from Member_Master where Member_id=" & dt.Rows(0).Item("partyid") & "", ob.getconnection())
            cmbType.Text = dt.Rows(0).Item("Billtype")
            acname.Tag = dt.Rows(0).Item("cbj")
            acname.Text = ob.FindOneString("Select Account_Name From Account_Master Where Account_Id=" & Val(acname.Tag) & "", ob.getconnection())
            'Remarks.Text = dt.Rows(0).Item("Remarks")
            Billamt.Text = dt.Rows(0).Item("ReceiptAmt")
            intamt.Text = dt.Rows(0).Item("Intamt")
            netamt.Text = dt.Rows(0).Item("Netamt")
            txtdisamt.Text = dt.Rows(0).Item("Lessamt")
            txtintrest.Text = dt.Rows(0).Item("per")
            txtdis.Text = dt.Rows(0).Item("fdno")
            txtcolumn.Tag = dt.Rows(0).Item("tid")
            txtvillageid.Tag = dt.Rows(0).Item("clid")
            If (txtcolumn.Tag) <> 0 Then
                txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            End If
            If Val(txtvillageid.Tag) <> 0 Then
                txtvillageid.Text = ob.FindOneString("select column_name from column_master where  column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
            End If
            acname.Enabled = False
            loaddgdate()
        End If
        'End If
    End Sub

    Private Sub ButDelete_Click(sender As Object, e As EventArgs) Handles ButDelete.Click
        ob.Execute("delete from acmain where department='" & Cmbdepartment.Text & "' and ptype='Receipt' and Billno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Acdata where department='" & Cmbdepartment.Text & "' and ptype='Receipt' and Docno=" & Val(Billno.Text) & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        ob.Execute("delete from Receipt where ptype='Receipt' and Billno=" & Val(Billno.Text) & " and yearid=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        MessageBox.Show("delete")
        clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rec As Double = 0
        Dim ints As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            dg.Rows(i).Cells(11).Value = True
            If dg.Rows(i).Cells(11).Value = True Then
                ints += dg.Rows(i).Cells(10).Value
            End If
        Next
        Billamt.Text = Val(ints)
        'intamt.Text = Val(ints)
        'netamt.Text = Val(rec) + Val(ints)
        'netamt.Focus().
        txtdis.Focus()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub DG_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs)
        'Dim y As Double
        'Dim x As Double
        'For i As Integer = 0 To dg.Rows.Count - 1
        '    If Val(dg.Rows(i).Cells(5).Value) <> 0 Then
        '        dg.Rows(i).Cells(8).Value = (Val(dg.Rows(i).Cells(5).Value) * Val(dg.Rows(i).Cells(7).Value) * Val(dg.Rows(i).Cells(6).Value)) / 36500
        '        dg.Rows(i).Cells(6).Value = Math.Round(Val(dg.Rows(i).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
        '        dg.Rows(i).Cells(7).Value = Math.Round(Val(dg.Rows(i).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
        '        y = y + Val(Format((dg.Rows(i).Cells(3).Value)))
        '        x = x + Val(Format((dg.Rows(i).Cells(6).Value)))
        '        Me.PayBill.Text = Format(y, "###0.00")
        '        Me.lblInt.Text = Format(x, "###0.00")
        '        lbltotal.Text = (Val(PayBill.Text) + Val(lblInt.Text))
        '    Else
        '        dg.Rows(i).Cells(6).Value = (Val(dg.Rows(i).Cells(2).Value) * Val(dg.Rows(i).Cells(5).Value) * Val(dg.Rows(i).Cells(4).Value)) / 36500
        '        dg.Rows(i).Cells(6).Value = Math.Round(Val(dg.Rows(i).Cells(6).Value), 0, MidpointRounding.AwayFromZero)
        '    End If

        'Next

    End Sub

    Private Sub billDt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles billDt.Validating
        ob.validdate(sender, billDt.Text, True)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FrmReceiptData.Show()
    End Sub

    Private Sub txtcolumn_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtcolumn.Validating

        txtcolumn.Tag = ob.FindOneString("select code from itemgroup where name=N'" & Val(txtcolumn.Text) & "' or code=" & Val(txtcolumn.Text) & "", ob.getconnection())
        If Val(txtcolumn.Tag) <> 0 Then
            txtcolumn.Text = ob.FindOneString("select name from itemgroup where  code=" & Val(txtcolumn.Tag) & "", ob.getconnection())
            loaddg()
        End If

        Dim rec As Double = 0
        Dim ints As Double = 0
        For i As Integer = 0 To dg.Rows.Count - 1
            rec += dg.Rows(i).Cells(8).Value
        Next
        lblTBags.Text = Val(rec)

    End Sub

    Private Sub txtvillageid_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvillageid.Validating
        txtvillageid.Tag = ob.FindOneString("select column_id from column_master where column_name=N'" & Val(txtvillageid.Text) & "' or column_id=" & Val(txtvillageid.Text) & "", ob.getconnection())
        If Val(txtvillageid.Tag) <> 0 Then
            txtvillageid.Text = ob.FindOneString("select column_name from column_master where column_id=" & Val(txtvillageid.Tag) & "", ob.getconnection())
        End If
    End Sub

    Private Sub txtintrest_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtintrest.Validating
        If Val(txtintrest.Text) Then
            intamt.Text = Val(Billamt.Text) * Val(txtintrest.Text) / 100
            intamt.Text = Math.Round(Val(intamt.Text), 0)
            lblInt.Text = Val(intamt.Text)
            cal()
        Else
            intamt.Focus()
        End If
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
    Public Sub cal()
        netamt.Text = Val(Billamt.Text) + Val(intamt.Text) - Val(txtdisamt.Text)
        lbltotal.Text = Val(netamt.Text)
    End Sub

    Private Sub txtintrest_TextChanged(sender As Object, e As EventArgs) Handles txtintrest.TextChanged

    End Sub

    Private Sub Billno_VisibleChanged(sender As Object, e As EventArgs) Handles Billno.VisibleChanged

    End Sub

    Private Sub txtdisamt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdisamt.KeyDown
        If e.KeyCode = Keys.Enter Then
            cal()
            txtintrest.Focus()
        End If
    End Sub

    Private Sub intamt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles intamt.Validating
        cal()
        netamt.Focus()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        clsVariables.Findqueri = "select billno,billdate,PartyId,m.member_name as membername,Netamt from Acmain as a inner join MEMBER_MASTER as m on a.PartyId=m.Member_Id where year_id='" & clsVariables.WorkingYear & "' and ptype='Receipt' order by billno"
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Billno.Text = clsVariables.HelpId
        Billno_Validating(Nothing, Nothing)
        'filldata(Val(Billno.Text))
    End Sub
End Class
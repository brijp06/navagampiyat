Imports WeightPavti.CLS
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Public Class Danavak

    Private Sub Danavak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdocdate.Text = Format(DateTime.Now.Date, "dd/MM/yyyy")
        Dim dt As DataTable
        dt = ob.Returntable("select isnull(max(doc_no),0)+1 as dc from danavak where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        txtdocno.Text = dt.Rows(0).Item("dc")

    End Sub

    Private Sub txtpart_id_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Party_id"
            clsVariables.HelpName = "Party_Name"
            clsVariables.TbName = "Party_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Party_Name"
            HelpWin.tsql = "Select Party_Id,Party_Name from Party_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtpart_id.Text = clsVariables.RtnHelpId
                txtpartyname.Text = clsVariables.RtnHelpName
                txtmonth.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Party_id"
            clsVariables.HelpName = "Party_Name"
            clsVariables.TbName = "Party_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Party_Id"
            HelpWin.tsql = "Select Party_Id,Party_Name from Party_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtpart_id.Text = clsVariables.RtnHelpId
                txtpartyname.Text = clsVariables.RtnHelpName
                txtmonth.Focus()
            End If
        End If

    End Sub

    Private Sub txtpart_id_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpart_id.Validating
        If txtpart_id.Text <> "" Then
            Dim dt As DataTable
            dt = ob.Returntable("select party_name from party_master where party_id=" & txtpart_id.Text & "", ob.getconnection())
            If dt.Rows.Count > 0 Then
                txtpartyname.Text = dt.Rows(0).Item("party_name")
                Dim dts As DataTable = ob.Returntable("select isnull(sum(amount),0) as amt from party_detail where party_id=" & txtpart_id.Text & "", ob.getconnection())
                txtamount.Text = dts.Rows(0).Item("amt")
                '   chek()
            Else
                MessageBox.Show("Invalid Party Id")
                txtpart_id.Clear()
                txtpart_id.Focus()
            End If

        Else
            MessageBox.Show("Place Enter Party Id")
            txtpart_id.Focus()
        End If
    End Sub
    Public Sub chek()
        Dim dpen As Double = 0
        'Dim ddates As Date = DateTime.Now.Date
        Dim ddates As Date = "05/05/2019"
        Dim mnd As String = ddates.Month
        If mnd <> 1 Then
            Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=1", ob.getconnection())
            If mnd = 1 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo a
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=1", ob.getconnection())
                dpen += dtb
                GoTo a
            End If
        ElseIf mnd <> 2 Then
a:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=2", ob.getconnection())
            If mnd = 2 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo b
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=2", ob.getconnection())
                dpen += dtb
                GoTo b
            End If
        ElseIf mnd <> 3 Then
b:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=3", ob.getconnection())
            If mnd = 3 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo c
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=3", ob.getconnection())
                dpen += dtb
                GoTo c
            End If
        ElseIf mnd <> 4 Then
c:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=4", ob.getconnection())
            If mnd = 4 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo d
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=4", ob.getconnection())
                dpen += dtb
                GoTo d
            End If
        ElseIf mnd <> 5 Then
d:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=5", ob.getconnection())
            If mnd = 5 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo e
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=5", ob.getconnection())
                dpen += dtb
                GoTo e
            End If
        ElseIf mnd <> 6 Then
E:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=6", ob.getconnection())
            If mnd = 6 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo f
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=6", ob.getconnection())
                dpen += dtb
                GoTo f
            End If
        ElseIf mnd <> 7 Then
f:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=7", ob.getconnection())
            If mnd = 7 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo g
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=7", ob.getconnection())
                dpen += dtb
                GoTo g
            End If
        ElseIf mnd <> 8 Then
g:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=8", ob.getconnection())
            If mnd = 8 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo h
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=8", ob.getconnection())
                dpen += dtb
                GoTo h
            End If
        ElseIf mnd <> 9 Then
h:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=9", ob.getconnection())
            If mnd = 9 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo i
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=9", ob.getconnection())
                dpen += dtb
                GoTo i
            End If
        ElseIf mnd <> 10 Then
i:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=10", ob.getconnection())
            If mnd = 10 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo j
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=10", ob.getconnection())
                dpen += dtb
                GoTo j
            End If
        ElseIf mnd <> 11 Then
j:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=11", ob.getconnection())
            If mnd = 11 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then
                GoTo k
            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=11", ob.getconnection())
                dpen += dtb
                GoTo k
            End If
        ElseIf mnd <> 12 Then
k:          Dim dt As DataTable = ob.Returntable("select * from  Danavak where year_id=" & aq(clsVariables.WorkingYear) & " and party_id=" & txtpart_id.Text & " and month_id=12", ob.getconnection())
            If mnd = 12 Then
                GoTo bm
            End If
            If dt.Rows.Count > 0 Then

            Else
                Dim dtb As String = ob.FindOneString("select pen_amt from month where year_id=" & aq(clsVariables.WorkingYear) & " and id=12", ob.getconnection())
                dpen += dtb

            End If
        Else


        End If
bm:     txtpen.Text = dpen
    End Sub

    Private Sub txtmonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.F2 Then
        '    clsVariables.HelpId = "id"
        '    clsVariables.HelpName = "Monthname"
        '    clsVariables.TbName = "month"
        '    HelpWin.scodename = "Name"
        '    HelpWin.sorderby = " order by Monthname"
        '    HelpWin.tsql = "Select Id,Monthname from month"
        '    HelpWin.ShowDialog()
        '    If clsVariables.RtnHelpId <> "" Then
        '        txtmonth.Text = clsVariables.RtnHelpId
        '        txtmonthname.Text = clsVariables.RtnHelpName
        '        txtamt.Focus()
        '    End If

        'ElseIf e.KeyCode = Keys.F4 Then
        '    clsVariables.HelpId = "id"
        '    clsVariables.HelpName = "Monthname"
        '    clsVariables.TbName = "month"
        '    HelpWin.scodename = "Code"
        '    HelpWin.sorderby = " order by Id"
        '    HelpWin.tsql = "Select Id,Monthname from month"
        '    HelpWin.ShowDialog()
        '    If clsVariables.RtnHelpId <> "" Then
        '        txtmonth.Text = clsVariables.RtnHelpId
        '        txtmonthname.Text = clsVariables.RtnHelpName
        '        txtamt.Focus()
        '    End If
        'End If

    End Sub

    Private Sub txtmonth_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmonth.Validated
        If txtmonth.Text <> "" Then
            Dim dst As DataTable
            dst = ob.Returntable("select * from Danavak where party_id=" & txtpart_id.Text & " and Month_id=" & txtmonth.Text & "", ob.getconnection())
            If dst.Rows.Count > 0 Then
                MessageBox.Show("All Ready Paid To This Month " & txtmonth.Text & "")
                txtmonth.Clear()
                txtmonth.Focus()
            Else

                Dim dt As DataTable
                dt = ob.Returntable("select * from month where id=" & txtmonth.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
                If dt.Rows.Count > 0 Then
                    txtmonthname.Text = dt.Rows(0).Item("Monthname")
                    txtamt.Text = dt.Rows(0).Item("Amount")
                Else
                    MessageBox.Show("Invalid Month Id")
                    txtmonth.Clear()
                    txtmonth.Focus()
                End If
            End If
        Else
            MessageBox.Show("Place Enter Month Id")
            txtmonth.Focus()
        End If

    End Sub

    Private Sub txtdocno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpen.KeyDown, txtpart_id.KeyDown, txtmonth.KeyDown, txtdocno.KeyDown, txtdocdate.KeyDown, txtamt.KeyDown, txtamount.KeyDown
        tabkey(sender, e)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txtpart_id.Text <> "" Then
            ob.Execute("delete from danavak where doc_no=" & txtdocno.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("insert into danavak (year_id,Doc_no, Doc_date, Party_id, Month_id, Amount, Pen) values(" & aq(clsVariables.WorkingYear) & "," & txtdocno.Text & "," & aq(ob.DateConversion(txtdocdate.Text)) & "," & txtpart_id.Text & "," & txtmonth.Text & "," & txtamt.Text & "," & txtpen.Text & ")", ob.getconnection())
            ob.Execute("delete from party_detail where party_id=" & txtpart_id.Text & " and month_id=" & txtmonth.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            ob.Execute("insert into party_detail (year_id,Doc_no,Party_id, Month_id, Amount, pen) values (" & aq(clsVariables.WorkingYear) & "," & txtdocno.Text & "," & txtpart_id.Text & "," & txtmonth.Text & "," & txtamt.Text & "," & txtpen.Text & ")", ob.getconnection())
            'lsms()
            txtpart_id.Clear()
            txtpartyname.Clear()
            txtamount.Clear()
            txtmonth.Clear()
            txtmonthname.Clear()
            txtamt.Clear()
            txtpen.Clear()
            Dim dt As DataTable
            dt = ob.Returntable("select isnull(max(doc_no),0)+1 as dc from danavak where year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
            txtdocno.Text = dt.Rows(0).Item("dc")
            txtpart_id.Focus()
        End If
    End Sub
    Public Sub lsms()
        Dim strResponse, strURL As String
        Dim GetURL As New System.Net.WebClient
        Dim dt As DataTable = ob.Returntable("select mobileno from Party_master where party_id=" & txtpart_id.Text & "", ob.getconnection())
        strURL = "https://bulksms.smsroot.com/app/smsapi/index.php?key=35DB655F91246B&campaign=0&routeid=13&type=text&contacts=" & dt.Rows(0).Item("mobileno") & "&senderid=NVYMKV&msg=Greetings from Navyuvak Mandal Kavitha , Thank You For Paying " & txtamt.Text & " For " & txtmonthname.Text & "."

        Dim data As System.IO.Stream = GetURL.OpenRead(strURL)

        Dim reader As New System.IO.StreamReader(data)
        strResponse = reader.ReadToEnd()
        data.Close()
        reader.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dt As DataTable
        dt = ob.Returntable("select * from party_detail where party_id=" & txtpart_id.Text & "", ob.getconnection())
        Grd.dg.Columns.Add("Party_id", "Party Id")
        Grd.dg.Columns.Add("MonthName", "Month Name")
        Grd.dg.Columns.Add("Docno", "Bill No")
        Grd.dg.Columns.Add("Date", "Date")
        Grd.dg.Columns.Add("Penalty", "Penalty")

        If dt.Rows.Count > 0 Then
            For i = 0 To dt.Rows.Count - 1
                Grd.dg.Rows.Add()
                Grd.dg.Rows(i).Cells(0).Value = dt.Rows(i).Item("Party_id")
                Dim dts As DataTable = ob.Returntable("select Monthname from month where id=" & dt.Rows(i).Item("Month_id") & "", ob.getconnection())
                Grd.dg.Rows(i).Cells(1).Value = dts.Rows(0).Item("Monthname")
                Grd.dg.Rows(i).Cells(2).Value = dt.Rows(i).Item("Doc_no")
                Dim df As DataTable = ob.Returntable("select doc_date from danavak where doc_no=" & dt.Rows(i).Item("Doc_no") & "", ob.getconnection())
                Grd.dg.Rows(i).Cells(3).Value = ob.DateConversion(df.Rows(0).Item("doc_date"))
                Grd.dg.Rows(i).Cells(4).Value = dt.Rows(i).Item("pen")

            Next
        End If
        Grd.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ob.Execute("delete from danavak where doc_no=" & txtdocno.Text & "", ob.getconnection())
        ob.Execute("delete from party_detail where party_id=" & txtpart_id.Text & " and month_id=" & txtmonth.Text & "", ob.getconnection())
        MessageBox.Show("Delete")
        Me.Close()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim result1 As DialogResult = MessageBox.Show("Do You Want to Print?", "Important Question", MessageBoxButtons.YesNo)
        If result1 = Windows.Forms.DialogResult.Yes Then
            clsVariables.ReportName = "Receipt.rpt"

            Dim report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim ssql As String
            ssql = "select * from Danavak where Doc_NO=" & txtdocno.Text & ""
            Dim dts As DataSet = ob.ReturnDataset(ssql, ob.getconnection(), "Danavak")
            report.Load(clsVariables.RptLocation & clsVariables.ReportName)
            Dim crtableLogoninfos As New TableLogOnInfos()
            Dim crtableLogoninfo As New TableLogOnInfo()
            Dim crConnectionInfo As New ConnectionInfo()
            Dim CrTables As Tables
            Dim CrTable As Table

            CrTables = report.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            With crConnectionInfo
                .ServerName = "assdsn"
                .DatabaseName = dbname
                If DbAuth <> "WIN" Then
                    .UserID = "advsys"
                    .Password = "advsys"
                End If
            End With
            CrTables = report.Database.Tables
            For Each CrTable In CrTables
                crtableLogoninfo = CrTable.LogOnInfo
                crtableLogoninfo.ConnectionInfo = crConnectionInfo
                CrTable.ApplyLogOnInfo(crtableLogoninfo)
            Next

            report.VerifyDatabase()
            report.SetDataSource(dts)
            report.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub txtdocno_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtdocno.Validated
       
        Dim dt As DataTable
        dt = ob.Returntable("select * from Danavak where doc_no=" & txtdocno.Text & " and year_id=" & aq(clsVariables.WorkingYear) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            If result1 = Windows.Forms.DialogResult.Yes Then
                txtdocdate.Text = ob.DateConversion(dt.Rows(0).Item("doc_date"))
                txtpart_id.Text = dt.Rows(0).Item("party_id")
                txtpartyname.Text = ob.FindOneString("select party_name from party_master where party_id=" & txtpart_id.Text & "", ob.getconnection())
                txtmonth.Text = dt.Rows(0).Item("month_id")
                txtmonthname.Text = ob.FindOneString("select Monthname from month where id=" & txtmonth.Text & "", ob.getconnection())
                txtamt.Text = dt.Rows(0).Item("Amount")
                txtpen.Text = dt.Rows(0).Item("pen")

            End If
        End If
    End Sub
End Class
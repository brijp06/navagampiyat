Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports WeightPavti.CLS
'Imports System.Web.HttpRequest
Public Class Login
    Dim ds As New DataSet
    Public KeyValue As String
    Private Sub cmbCompany_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.Enter
        cmbCompany.DroppedDown = True
    End Sub

    Private Sub cmbCompany_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCompany.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub cmbWorkingYear_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbWorkingYear.Enter
        cmbWorkingYear.DroppedDown = True
    End Sub
    Private Sub cmbWorkingYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbWorkingYear.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub Login_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub
    Private Sub Login_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButCancel.KeyUp, ButLogin.KeyUp, cmbCompany.KeyUp, cmbWorkingYear.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Close()
            Application.Exit()
        End If
    End Sub
    'CREDIT_SOCIETY_GVB
    Public Sub FillCoboWorkingYear()
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            Dim sSQL As String
            sSQL = "Select * from Year_Master ORDER BY Year_id desc"
            cmbWorkingYear.DataSource = ob.Returntable(sSQL, ob.getconnection)
            cmbWorkingYear.DisplayMember = "Year_id"
            cmbWorkingYear.ValueMember = "Year_id"
            If cmbWorkingYear.Items.Count > 0 Then
                cmbWorkingYear.SelectedIndex = 0
            End If
            'sSQL = "Select Season_id From Season_master "
            'sSQL = sSQL & " Order by Season_id"
            'ComboSeason.DataSource = ob.Returntable(sSQL, ob.getconnection)
            'ComboSeason.DisplayMember = "Season_id"
            'ComboSeason.ValueMember = "Season_id"
            'If ComboSeason.Items.Count > 0 Then
            '    ComboSeason.SelectedIndex = 0
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub
    Public Sub AddField()
        Dim dt As New DataTable
        Dim ssql As String
        ssql = "Select * from Sysobjects where xtype='U' order by Name"
        dt = ob.Returntable(ssql, ob.getconnection(ob.Getconn))
        Dim i As Integer
        i = 0
        Do While i < dt.Rows.Count
            Dim nm As String
            nm = dt.Rows(i).Item("Name")
            If nm <> "ACCESS_SECURITY" And nm <> "AGENT_INTEREST_DATA" And nm <> "BANK_SUMMARY" And nm <> "BONUS_REPORT" And nm <> "COLUMN_SUMMARY" And nm <> "DEAD_STOCK_BALANCE" And nm <> "DEAD_STOCK_LEDGER" And nm <> "EMP_LAST_SALARY" And nm <> "FINAL_ACCOUNT_BALANCE" And nm <> "FINAL_ACCOUNT_LEDGER" And nm <> "FINAL_ACCOUNT_LEDGER_INT" And nm <> "FINAL_ACCOUNT_OPENING_BALANCE" And nm <> "FINAL_INTEREST_DATA" And nm <> "FINAL_PARTY_BALANCE" And nm <> "FINAL_PARTY_BALANCE_REPORT" And nm <> "FINAL_PARTY_LEDGER" And nm <> "FINAL_PARTY_OPENING_BALANCE" And nm <> "FINAL_TARIJ_REPORT" And nm <> "FIXD_BALANCE_REPORT" And nm <> "FIXD_DUE_REPORT" And nm <> "FIXD_LEDGER" And nm <> "FORM_INFO" And nm <> "FUND_ACCOUNT_BALANCE" And nm <> "FUND_ACCOUNT_LEDGER" And nm <> "FUND_ACCOUNT_OPENING_BALANCE" And nm <> "FUND_PARTY_BALANCE" And nm <> "FUND_PARTY_BALANCE_REPORT" And nm <> "FUND_PARTY_LEDGER" And nm <> "FUND_PARTY_OPENING_BALANCE" And nm <> "FUND_TARIJ_REPORT" And nm <> "GRAM_LAXMI_BALANCE_REPORT" And nm <> "GRAM_LAXMI_DUE_REPORT" And nm <> "GRAM_LAXMI_LEDGER" And nm <> "INVESTMENT_BALANCE_REPORT" And nm <> "INVESTMENT_LEDGER" And nm <> "JOINT_TRIAL_BALANCE" And nm <> "KAMDHENU_BALANCE_REPORT" And nm <> "KAMDHENU_LEDGER" And nm <> "LEAVE_LEDGER" And nm <> "LEAVE_WAGES_REPORT" And nm <> "LOAN_DUE_LEDGER" And nm <> "Loan_Opening_Balance_Detail" And nm <> "LOAN_OVER_DUE_REPORT" And nm <> "LOCKER_LEDGER" And nm <> "MEMBER_DATA" And nm <> "MEMBER_LEDGER" And nm <> "MONTHLY_MEMBER_LEDGER" And nm <> "MONTHLY_RUNNING_BALANCE" And nm <> "NEW_ROJMEL" And nm <> "PAYROLL_REGISTER" And nm <> "ROJMEL" And nm <> "SAVING_INTEREST_DATA" And nm <> "SAVING_MEMBER_BALANCE" And nm <> "SAVING_MEMBER_LEDGER" And nm <> "SAVING_RUNNING_BALANCE" And nm <> "SUPPLI_ACCOUNT_OPENING_BALANCE" And nm <> "SUPPLI_PARTY_BALANCE_REPORT" And nm <> "SUPPLI_PARTY_LEDGER" And nm <> "SUPPLI_PARTY_OPENING_BALANCE" And nm <> "TMP_Fixd_INTEREST_DATA" And nm <> "TMP_GRAM_LAXMI_INTEREST_DATA" Then
                If ob.CheckField("Ip_Address", dt.Rows(i).Item("Name"), ob.getconnection) = False Then
                    ob.Execute("Alter Table " & dt.Rows(i).Item("name") & " add Ip_Address nvarchar(50)", ob.getconnection)
                End If
                If ob.CheckField("Mach_Name", dt.Rows(i).Item("Name"), ob.getconnection) = False Then
                    ob.Execute("Alter Table " & dt.Rows(i).Item("name") & " add Mach_Name nvarchar(50)", ob.getconnection)
                End If
            End If

            i += 1
        Loop
        dt.Clear()
        dt.Dispose()
        ssql = "Select * from Sysobjects where xtype='U' order by Name"
        dt = ob.Returntable(ssql, ob.getconnection(ob.Getconn(BackDbname)))
        i = 0
        Do While i < dt.Rows.Count
            Dim nm As String
            nm = dt.Rows(i).Item("Name")
            If nm <> "ACCESS_SECURITY" And nm <> "AGENT_INTEREST_DATA" And nm <> "BANK_SUMMARY" And nm <> "BONUS_REPORT" And nm <> "COLUMN_SUMMARY" And nm <> "DEAD_STOCK_BALANCE" And nm <> "DEAD_STOCK_LEDGER" And nm <> "EMP_LAST_SALARY" And nm <> "FINAL_ACCOUNT_BALANCE" And nm <> "FINAL_ACCOUNT_LEDGER" And nm <> "FINAL_ACCOUNT_LEDGER_INT" And nm <> "FINAL_ACCOUNT_OPENING_BALANCE" And nm <> "FINAL_INTEREST_DATA" And nm <> "FINAL_PARTY_BALANCE" And nm <> "FINAL_PARTY_BALANCE_REPORT" And nm <> "FINAL_PARTY_LEDGER" And nm <> "FINAL_PARTY_OPENING_BALANCE" And nm <> "FINAL_TARIJ_REPORT" And nm <> "FIXD_BALANCE_REPORT" And nm <> "FIXD_DUE_REPORT" And nm <> "FIXD_LEDGER" And nm <> "FORM_INFO" And nm <> "FUND_ACCOUNT_BALANCE" And nm <> "FUND_ACCOUNT_LEDGER" And nm <> "FUND_ACCOUNT_OPENING_BALANCE" And nm <> "FUND_PARTY_BALANCE" And nm <> "FUND_PARTY_BALANCE_REPORT" And nm <> "FUND_PARTY_LEDGER" And nm <> "FUND_PARTY_OPENING_BALANCE" And nm <> "FUND_TARIJ_REPORT" And nm <> "GRAM_LAXMI_BALANCE_REPORT" And nm <> "GRAM_LAXMI_DUE_REPORT" And nm <> "GRAM_LAXMI_LEDGER" And nm <> "INVESTMENT_BALANCE_REPORT" And nm <> "INVESTMENT_LEDGER" And nm <> "JOINT_TRIAL_BALANCE" And nm <> "KAMDHENU_BALANCE_REPORT" And nm <> "KAMDHENU_LEDGER" And nm <> "LEAVE_LEDGER" And nm <> "LEAVE_WAGES_REPORT" And nm <> "LOAN_DUE_LEDGER" And nm <> "Loan_Opening_Balance_Detail" And nm <> "LOAN_OVER_DUE_REPORT" And nm <> "LOCKER_LEDGER" And nm <> "MEMBER_DATA" And nm <> "MEMBER_LEDGER" And nm <> "MONTHLY_MEMBER_LEDGER" And nm <> "MONTHLY_RUNNING_BALANCE" And nm <> "NEW_ROJMEL" And nm <> "PAYROLL_REGISTER" And nm <> "ROJMEL" And nm <> "SAVING_INTEREST_DATA" And nm <> "SAVING_MEMBER_BALANCE" And nm <> "SAVING_MEMBER_LEDGER" And nm <> "SAVING_RUNNING_BALANCE" And nm <> "SUPPLI_ACCOUNT_OPENING_BALANCE" And nm <> "SUPPLI_PARTY_BALANCE_REPORT" And nm <> "SUPPLI_PARTY_LEDGER" And nm <> "SUPPLI_PARTY_OPENING_BALANCE" And nm <> "TMP_Fixd_INTEREST_DATA" And nm <> "TMP_GRAM_LAXMI_INTEREST_DATA" Then
                If ob.CheckField("Ip_Address", dt.Rows(i).Item("Name"), ob.getconnection(ob.Getconn(BackDbname))) = False Then
                    ob.Execute("Alter Table " & dt.Rows(i).Item("name") & " add Ip_Address nvarchar(50)", ob.getconnection(ob.Getconn(BackDbname)))
                End If
                If ob.CheckField("Mach_Name", dt.Rows(i).Item("Name"), ob.getconnection(ob.Getconn(BackDbname))) = False Then
                    ob.Execute("Alter Table " & dt.Rows(i).Item("name") & " add Mach_Name nvarchar(50)", ob.getconnection(ob.Getconn(BackDbname)))
                End If
            End If

            i += 1


        Loop
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Credit Society ERP System Login"
        KeyValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "")
        If KeyValue <> "dd/MM/yyyy" Then
            MsgBox(KeyValue)
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
        End If
        txtuserid.Text = "admin"
        txtpassword.Focus()
        ' txtpassword.Text = "a"
        'clsVariables.ScurrentSysDateFromate = Microsoft.Win32.Registry.GetValue("Hkey_Current_User\Control Panel\International", "sShortDate", "")
        'Microsoft.Win32.Registry.SetValue("Hkey_Current_User\Control Panel\International", "sShortDate", clsVariables.sReqSysDateFormate)
        For Each arg As String In My.Application.CommandLineArgs
            Select Case Trim(LCase(arg))
                Case "usr=admin"
                    ob.checktable()
            End Select
        Next

        objconnec.GetConnection()
        objDataTrns.FillCmb(cmbCompany, "Company", "company_name")
        FillCoboWorkingYear()
        If cmbCompany.Items.Count > 0 Then
            cmbCompany.Text = cmbCompany.Items(0)
        End If


        'ob.CreateDSN("Assdsn", dbname)
    End Sub
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub
    Private Sub txtUserId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            enterpress()
        End If
    End Sub
    Public Sub enterpress()

        If validuser() = False Then
            Me.Hide()
            MdiMain.Show()
        End If

    End Sub
    Private Sub txtUserId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LbDate.Text = Format(Now.Date, "dd-MMM-yyyy")
        Lbtime.Text = Now.ToShortTimeString
    End Sub
    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCancel.Click
        Me.Close()
        Application.Exit()
    End Sub
    Public Function validuser() As Boolean
        Dim isadd As Boolean
        If Len(txtuserid.Text) = 0 Then
            MsgBox("Please Enter User Id", MsgBoxStyle.Critical, Application.ProductName)
            isadd = True
            txtuserid.Focus()
            GoTo p
        ElseIf Len(txtpassword.Text) = 0 Then
            MsgBox("Please Enter User Password", MsgBoxStyle.Critical, Application.ProductName)
            isadd = True
            txtpassword.Focus()
            GoTo p
        End If
        If ob.FindOneinteger("Select Count(*) from LOGINMST where usrId='" & ob.ChartoAsc(txtuserid.Text) & "'", ob.getconnection(ob.Getconn())) = 0 Then
            isadd = True
            MsgBox("Please Enter Correct User Id", MsgBoxStyle.Critical, Application.ProductName)
            txtuserid.Focus()
            GoTo p
        ElseIf ob.FindOneinteger("Select Count(*) from LOGINMST where USRID='" & ob.ChartoAsc(txtuserid.Text) & "' and PassWd='" & ob.ChartoAsc(txtpassword.Text) & "'", ob.getconnection(ob.Getconn())) = 0 Then
            isadd = True
            MsgBox("Please Enter Correct User Id Or Password", MsgBoxStyle.Critical, Application.ProductName)
            txtpassword.Focus()
            GoTo p
        End If
        MdiMain.cl = 0
        guser = txtuserid.Text
        'tm = Now.ToLongTimeString
        MachineName = My.Computer.Name
        'machineName = System.Net.Dns.GetHostName
        IPAddress = System.Net.Dns.GetHostByName(MachineName).AddressList(0).ToString()
        clsVariables.CompnyName = cmbCompany.SelectedItem.ToString
        clsVariables.WorkingYear = cmbWorkingYear.SelectedValue.ToString
        'clsVariables.WorkingYear = "2022-2023"
        clsVariables.CompnyId = "1"
        clsVariables.UserName = txtuserid.Text
        gCompanyId = clsVariables.CompnyId
        Season_Id = ComboSeason.SelectedValue

        fulluserName = ob.FindOneString("Select UsrName from LoginMst where USrID='" & ob.ChartoAsc(txtuserid.Text) & "'", ob.getconnection(ob.Getconn(dbname)))
        vIsadmin = (ob.FindOneString("Select IsAdmin from LoginMst where USrID='" & ob.ChartoAsc(txtuserid.Text) & "'", ob.getconnection(ob.Getconn(dbname))))
        gUserId = IIf(ob.FindOneString("Select Status from LOginMst where UsrId=" & aq(ob.ChartoAsc(txtuserid.Text)), ob.getconnection(ob.Getconn(dbname))) = True, 1, 0)
        ob.FilSt()

        ob.CreateDSN("assdsn", dbname)
        ob.LoadFinYear()
        '  ob.loadsystem()
p:
        Return isadd
    End Function
    Public tm As String
    Private Sub ButLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLogin.Click
        Try
            If validuser() = False Then
                Me.Hide()
                MdiMain.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub txtpassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub

    Private Sub txtUsrname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            enterpress()
        End If
    End Sub

    Private Sub txtpassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub

    Private Sub txtUsrname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmbCompany_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.GotFocus
        Textactive(sender)

    End Sub

    Private Sub cmbWorkingYear_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbWorkingYear.GotFocus
        Textactive(sender)
        FillCoboWorkingYear()
    End Sub

    Private Sub cmbCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCompany.SelectedIndexChanged

    End Sub

    Private Sub cmbWorkingYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkingYear.SelectedIndexChanged

    End Sub

    Private Sub cmbWorkingYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbWorkingYear.LostFocus
        Textreset(sender)
    End Sub
    Private Sub cmbCompany_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCompany.LostFocus
        Textreset(sender)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub


    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub btnlogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        ButLogin_Click(Nothing, Nothing)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Login_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

    End Sub

    Private Sub txtuserid_KeyDown(sender As Object, e As KeyEventArgs) Handles txtuserid.KeyDown, txtpassword.KeyDown
        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{Tab}")

        End If
    End Sub

    Private Sub cmbWorkingYear_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbWorkingYear.KeyDown

        If e.KeyCode = Keys.Enter Then

            ButLogin.Focus()

        End If
    End Sub

    Private Sub btnlogin_KeyDown(sender As Object, e As KeyEventArgs) Handles btnlogin.KeyDown
        If e.KeyCode = Keys.Enter Then

            btnlogin_Click(Nothing, Nothing)
        End If
    End Sub
End Class
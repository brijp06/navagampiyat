Imports WeightPavti.CLS
Imports System.IO
Imports ComponentAce.Compression.ZipForge
Imports ComponentAce.Compression.Archiver
Public Class MdiMain
    Public cl As Integer

    Private Sub MdiMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If cl <> 1 Then
            'Microsoft.Win32.Registry.SetValue("Hkey_Current_User\Control Panel\International", "sShortDate", clsVariables.ScurrentSysDateFromate)
            'AccountJournalEntry.drop()
            'BankEntry.drop()
            'FixdInterestSlabEntry.drop()
            'FixdReservePaymentEntry.drop()
            'AddjustmentEntry.Drop()
            'BatchEntry.Drop()
            'BatchFormulaEntry.Drop()
            'ShareIssue.drop()
            'ShareTransfer.drop()
            'SavingPaymentEntry.drop()
            'SavingReceiptEntry.drop()
            'TransactionEntry.droptable()
            'LeaveEntry.droptable()
            'LeaveDetailEntry.droptable()
            'DaSlabEntry.drop()
            Application.Exit()

        End If
    End Sub
    Private Sub MdiMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cl <> 1 Then
            If MessageBox.Show("Do You Want To Backup", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                'Shell(CurDir() & "\Autobackup\Autobackup.exe")
                Dim databasename As String = dbname
                Dim cn As New System.Data.SqlClient.SqlConnection
                Dim cmd As System.Data.SqlClient.SqlCommand

                'AddRecord("backup database " & databasename & " to disk='E:\Project\Backup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak'")
                cn.ConnectionString = ob.Getconn
                cmd = New System.Data.SqlClient.SqlCommand("backup database " & databasename & " to disk='" & Application.StartupPath & "\DailyBackup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
                Dim archiver As ZipForge = New ZipForge()
                Try
                    ' The name of the ZIP file to be created
                    archiver.FileName = Application.StartupPath & "\DailyBackup\" & databasename & Now.Day & Now.Month & Now.Year & ".Zip"
                    ' Specify FileMode.Create to create a new ZIP file
                    ' or FileMode.Open to open an existing archive
                    archiver.OpenArchive(System.IO.FileMode.Create)
                    ' Default path for all operations                
                    archiver.BaseDir = "D:"
                    ' Add file C:\file.txt the archive; wildcards can be used as well                
                    archiver.AddFiles(Application.StartupPath & "\DailyBackup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak")
                    ' Close archive
                    archiver.CloseArchive()
                    If File.Exists(Application.StartupPath & "\DailyBackup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak") Then
                        File.Delete(Application.StartupPath & "\DailyBackup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak")
                        MessageBox.Show("Delete")
                    Else
                    End If
                    MessageBox.Show("Backup Done")
                    ' Catch all exceptions of the ArchiverException type
                Catch ae As ArchiverException
                    Console.WriteLine("Message: {0} Error code: {1}", ae.Message, ae.ErrorCode)
                    ' Wait for keypress
                    Console.ReadLine()
                End Try
            End If
            If MessageBox.Show("Do You Want To Exit Application " & Application.ProductName & " ...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Me.Enabled = True
            Else
                'gCSCnn.Close()
            End If
        End If
    End Sub
    Private Sub MdiMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    End Sub
    Public Sub loadimage()
        Try
            Dim vpath As String
            vpath = ImagePath & "BackGround\Master.jpg"
            If FileIO.FileSystem.FileExists(vpath) = True Then
                Dim newimg As New Bitmap(vpath)
                Dim fPhoto As New FileInfo(vpath)
                PicMaster.SizeMode = PictureBoxSizeMode.StretchImage
                PicMaster.Image = DirectCast(newimg, Image)
            Else
                'PicMaster.Image = Nothing
            End If
            vpath = ImagePath & "BackGround\Report.jpg"
            If FileIO.FileSystem.FileExists(vpath) = True Then
                Dim newimg As New Bitmap(vpath)
                Dim fPhoto As New FileInfo(vpath)
                PicReport.SizeMode = PictureBoxSizeMode.StretchImage
                PicReport.Image = DirectCast(newimg, Image)
            Else
                'PicReport.Image = Nothing
            End If
            vpath = ImagePath & "BackGround\Transaction.jpg"
            If FileIO.FileSystem.FileExists(vpath) = True Then
                Dim newimg As New Bitmap(vpath)
                Dim fPhoto As New FileInfo(vpath)
                PicTransaction.SizeMode = PictureBoxSizeMode.StretchImage
                PicTransaction.Image = DirectCast(newimg, Image)
            Else
                'PicTransaction.Image = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub MdiMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = sysname & "         Wel Come Login User Id:" & guser & "        Login Time :" & Login.tm
        'loadimage()
        If FileIO.FileSystem.FileExists(ImagePath & "BackGround\BackGround.jpg") = True Then
            Dim newimg As New Bitmap(ImagePath & "BackGround\BackGround.jpg")
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.BackgroundImage = DirectCast(newimg, Image)
        End If
        If FileIO.FileSystem.FileExists(ImagePath & "BackGround\" & Now.Day & ".jpg") = True Then
            Dim newimg As New Bitmap(ImagePath & "BackGround\" & Now.Day & ".jpg")
            Me.BackgroundImageLayout = ImageLayout.Stretch
            Me.BackgroundImage = DirectCast(newimg, Image)
        End If

        lbCompanyname.Text = clsVariables.CompnyName
        lbCompanyname.Text = clsVariables.CompnyName
        lbCompanyname.Top = StatusStrip1.Top + 2
        lbCompanyname.Width = StatusStrip1.Right
        'lbCompanyname.Spring = True
        'lbCompanyname.Text = clsVariables.CompnyName
        lbuser.Text = clsVariables.UserName
        Lbyear.Text = clsVariables.WorkingYear
        Dim dt As New DataTable
        dt = ob.Returntable("Select * from Company where Company_id=" & Val(clsVariables.CompnyId), ob.getconnection(ob.Getconn))
        If dt.Rows.Count > 0 Then
            If Not IsDBNull(dt.Rows(0).Item("fin_year_begin")) Then
                ob.SetFinYear(Trim(clsVariables.CompnyId), clsVariables.WorkingYear, CDate(dt.Rows(0).Item("fin_year_begin")), CDate(dt.Rows(0).Item("fin_year_End")), CDate(dt.Rows(0).Item("Previous_reserve_Date")))
            Else
                If Not IsDBNull(dt.Rows(0).Item("fin_year_begin")) Then
                    ob.SetFinYear(clsVariables.CompnyId, clsVariables.WorkingYear, CDate(dt.Rows(0).Item("fin_year_begin")), CDate(dt.Rows(0).Item("fin_year_End")), CDate(dt.Rows(0).Item("Previous_reserve_Date")))
                Else
                    MsgBox("Cannot proceed. Financial Year beginning date has been modified.", vbCritical, Application.ProductName)
                    End
                End If
            End If
        End If
        ob.LoadFinYear()
        If clsVariables.UserName <> "saipc" Then

        End If
        ' ComboDept.Font = New Font("Shree-guj-0768-s02", 11, FontStyle.Bold)
        'Dim dty As New DataTable
        'i = 1
        'dty = ob.Returntable("Select * from User_Department_master where Company_Id=" & clsVariables.CompnyId & " and User_id=" & aq(clsVariables.UserName) & " and Status=1", ob.getconnection())
        'ComboDept.DataSource = ob.Returntable("Select Dm.Department_id,Dm.Department_name from Department_master as Dm ,User_Department_master as UDM where Dm.COmpany_id=UDm.Company_id and Dm.Department_Id=UDm.Department_Id and UDM.Company_id=" & clsVariables.CompnyId & " and UDM.User_id=" & aq(clsVariables.UserName) & " and UDm.Status=1 Order by Dm.Department_iD", ob.getconnection)
        'ComboDept.DisplayMember = "Department_name"
        'ComboDept.ValueMember = "Department_id"
        'i = 0
        'ComboDept_Validating(Nothing, Nothing)
        'If dty.Rows.Count = 1 Then
        '    ComboDept.Enabled = False
        'End If
        DG.Columns.Add("", "")
        DG.Columns.Add("", "")
        'Button2_Click(Nothing, Nothing)
        'WeightPavtiReport.Show()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public frm As String
    'Private Sub AUserMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UserMst.Tag = "User Master"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, UserMst.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "usr"
    '    UserMst.Show()
    '    UserMst.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        LBtime.Text = Format(Now, "dd/MM/yyyy HH:mm:ss tt")
    End Sub
    Private Sub BCalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("calc")
    End Sub
    Private Sub TitleHorizontalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitleHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub TitleVerticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TitleVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    'Private Sub BVillageMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    VillageMst.Close()
    '    sdepartment = "member"
    '    VillageMst.Tag = "Village Master (Member)"
    '    VillageMst.Show()
    'End Sub
    'Private Sub AMemberMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberMaster.Close()
    '    sdepartment = "member"
    '    MemberMaster.Tag = "Member Master (Member)"
    '    MemberMaster.Show()
    'End Sub
    'Private Sub CDescriptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DescriptionMaster.Close()
    '    sdepartment = "member"
    '    DescriptionMaster.Tag = "Description Master (Member)"
    '    DescriptionMaster.Show()
    'End Sub
    'Private Sub DYearMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    YearMaster.Close()
    '    sdepartment = "member"
    '    YearMaster.Tag = "Year Master (Member)"
    '    YearMaster.Show()
    'End Sub

    'Private Sub ToolStripMenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    VillageMst.Close()
    '    VillageMst.Tag = "Village Master (Account)"
    '    VillageMst.Show()
    'End Sub
    'Private Sub ToolStripMenuItem55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DescriptionMaster.Tag = "Description Master (Account)"
    '    DescriptionMaster.Show()
    'End Sub

    'Private Sub ToolStripMenuItem57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    YearMaster.Tag = "Year Master (Account)"
    '    YearMaster.Show()
    'End Sub

    'Private Sub ToolStripMenuItem56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    VoucherMaster.Close()
    '    VoucherMaster.Tag = "Voucher Master (Account)"
    '    VoucherMaster.Show()
    'End Sub
    'Private Sub ToolStripMenuItem58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AccountGrpMaster.Close()
    '    AccountGrpMaster.Tag = "Account Group Master (Account)"
    '    AccountGrpMaster.Show()
    'End Sub
    'Private Sub ToolStripMenuItem59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AccountMaster.Close()
    '    AccountMaster.Tag = "Account Master (Account)"
    '    AccountMaster.Show()
    'End Sub

    Private Sub ToolStripMenuItem63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem63.Click
        cl = 1
        'Login.txtpassword.Text = ""
        'Login.txtUserId.Text = ""
        Me.Close()
        Login.Show()
        'Login.txtUserId.Focus()

    End Sub
    'Private Sub ToolStripMenuItem60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BookGroupMaster.Tag = "Book Group Master (Account)"
    '    BookGroupMaster.Show()
    'End Sub

    'Private Sub ToolStripMenuItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BookMaster.Tag = "Book Master (Account)"
    '    BookMaster.Show()
    'End Sub
    'Private Sub AInwardEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Inward.Tag = "Inward Entry (Member)"
    '    Inward.Show()
    'End Sub

    'Private Sub BShareIssueEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareIssue.Tag = "Share Issue Entry (Member)"
    '    ShareIssue.Show()
    'End Sub

    'Private Sub CShareReceiptEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareReceipt.Tag = "Share Receipt Entry (Member)"
    '    ShareReceipt.Show()
    'End Sub

    'Private Sub DShareTransferEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareTransfer.Tag = "Share Transfer Entry (Member)"
    '    ShareTransfer.Show()
    'End Sub

    'Private Sub ToolStripMenuItem71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    InwardRep.Tag = "Inward Report (Member)"
    '    InwardRep.Show()
    'End Sub

    'Private Sub ToolStripMenuItem72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareIssueRep.Tag = "Share Issue Report (Member)"
    '    ShareIssueRep.Show()
    'End Sub

    'Private Sub ToolStripMenuItem73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareReceiptRep.Tag = "Share Receipt Report (Member)"
    '    ShareReceiptRep.Show()
    'End Sub

    'Private Sub ToolStripMenuItem74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareTransferRep.Tag = "Share Transfer Report (Member)"
    '    ShareTransferRep.Show()
    'End Sub

    'Private Sub AShareLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareLedgerRep.Tag = "Share Ledger Report (Member)"
    '    ShareLedgerRep.Show()
    'End Sub

    'Private Sub BShareBalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SharebalanceRep.Tag = "Share Balance Report (Member)"
    '    SharebalanceRep.Show()
    'End Sub
    Public Dividendpayment As Boolean
    'Private Sub HDividendPaymentEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareDividendPayment.Close()
    '    Dividendpayment = False
    '    ShareDividendPayment.Tag = "Dividend Payament Entry (Member)"
    '    ShareDividendPayment.Show()
    'End Sub

    'Private Sub EDividendPaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareDividendPaymentRep.Tag = "Dividend Payment Report (Member)"
    '    ShareDividendPaymentRep.Show()
    'End Sub

    Private Sub CaseCadeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CaseCadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub ArrangeIcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArrangeIcodeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        lbCompanyname.Top = StatusStrip1.Top + 4


        lbCompanyname.Left = lbCompanyname.Left - 1
        If lbCompanyname.Left + lbCompanyname.Width < 0 Then
            lbCompanyname.Left = Me.Size.Width
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ChangeWorkingYear.Show()
    End Sub

    Private Sub BChangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BChangeToolStripMenuItem.Click
        ChangeWorkingYear.Show()
    End Sub

    'Private Sub AChangeCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AChangeCompanyToolStripMenuItem.Click
    '    ChangeCompany.Show()
    'End Sub

    Private Sub CChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CChangePasswordToolStripMenuItem.Click
        ChangePassword.Show()
    End Sub

    'Private Sub ATarijReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TarijRep.Tag = "Tarij Report (Account)"
    '    TarijRep.Show()
    'End Sub

    'Private Sub BTrialBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalTrialbalancerep.Tag = "Trial Balance Report (Account)"
    '    FinalTrialbalancerep.Show()
    'End Sub

    'Private Sub CTradingAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalTradingRep.Tag = "Trading Account (Account)"
    '    FinalTradingRep.Show()
    'End Sub

    'Private Sub DProfitAndLossAccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalProfitLossAccountRep.Tag = "Profit and Loss Account Report (Account)"
    '    FinalProfitLossAccountRep.Show()
    'End Sub
    'Private Sub EBalanceSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalBalanceSheetRep.Tag = "Balance Sheet Report (Account)"
    '    FinalBalanceSheetRep.Show()
    'End Sub
    'Private Sub ARojmalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RojmalEntry.Tag = "Rojmal Entry (Account)"
    '    RojmalEntry.Show()
    'End Sub
    'Private Sub ARojmalReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RojmelNewRep.Tag = "Rojmal Report (Account)"
    '    RojmelNewRep.Show()
    'End Sub
    'Private Sub BBankEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BankEntry.Tag = "Bank Entry (Account)"
    '    BankEntry.Show()
    'End Sub
    'Private Sub EJournalEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AccountJournalEntry.Tag = "Journal Entry (Account)"
    '    AccountJournalEntry.Show()
    'End Sub
    'Private Sub FBankBookToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BankBookRep.Tag = "Bank Book Report (Account)"
    '    BankBookRep.Show()
    'End Sub
    'Private Sub GBankSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BankSummaryRep.Tag = "Bank Summary Report (Account)"
    '    BankSummaryRep.Show()
    'End Sub
    'Private Sub IJournalBookReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalJournalRep.Tag = "Journal Book Report (Account)"
    '    FinalJournalRep.Show()
    'End Sub
    'Private Sub AAccountLedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalAccountLedgerRep.Tag = "Account Ledger Report (Account)"
    '    FinalAccountLedgerRep.Show()
    'End Sub
    'Private Sub CAccountInterestLedherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalAccountInterestLedgerRep.Tag = "Account Interest Ledger Report (Account)"
    '    FinalAccountInterestLedgerRep.Show()
    'End Sub
    'Private Sub DPartyLedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalPartyLedgerRep.Tag = "Member Ledger Report (Account)"
    '    FinalPartyLedgerRep.Show()
    'End Sub
    'Private Sub EPartyBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalPartyBalancerep.Tag = "Member Balance Report (Account)"
    '    FinalPartyBalancerep.Show()
    'End Sub
    'Private Sub GBankPassBookReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalbankPassBookRep.Tag = "Bank PassBook Report (Account)"
    '    FinalbankPassBookRep.Show()
    'End Sub

    'Private Sub BdeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DeptMst.Tag = "User Department Master"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, DeptMst.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "dept"
    '    DeptMst.Show()
    '    DeptMst.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub

    'Private Sub CFormInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FormInfo.Tag = "Form Information"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, FormInfo.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "frm"
    '    FormInfo.Show()
    '    FormInfo.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub

    'Private Sub DAccessSecurityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AccessSecurityBrowser.Tag = "Access Security Browser"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, AccessSecurityBrowser.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "access"
    '    AccessSecurityBrowser.Show()
    '    AccessSecurityBrowser.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub
    'Private Sub EReportMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ReportMaster.Tag = "Report Master"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, AccessSecurityBrowser.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "report"
    '    ReportMaster.Show()
    '    ReportMaster.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub

    'Private Sub FDividendSavingTransferEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ShareDividendPayment.Close()
    '    Dividendpayment = True
    '    ShareDividendPayment.Tag = "Dividend Saving Transfer Entry (Member)"
    '    ShareDividendPayment.Show()
    'End Sub
    'Private Sub DMemberBalancePostingDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PostingBalanceData.Tag = "Balance Posting Data"
    '    PostingBalanceData.Show()
    'End Sub

    'Private Sub BPostingDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberUpdatePosting.Tag = "Member Posting Data (Member)"
    '    MemberUpdatePosting.Show()
    'End Sub

    'Private Sub EMemebrOpeningBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sdepartment = "member"
    '    ShareOpeningBalanceBrowser.Tag = "Share Member Opening Balance Browser (Member)"
    '    ShareOpeningBalanceBrowser.Show()
    'End Sub

    'Private Sub BComputeDividendToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberComputeDividend.Tag = "Compute Dividend (Member)"
    '    MemberComputeDividend.Show()
    'End Sub
    'Private Sub KAccountOpeningBalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FinalAccountOpeningEntryBrowser.Tag = "Account Opening Balance Browser (Account)"
    '    FinalAccountOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub FUserListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'Form1.Show()
    '    ViewUserdetail.Tag = "View User Detail"
    '    If ob.AuthorizedTo(AccessMode.ViewMode, UserMst.Tag, ob.getconnection(ob.Getconn)) = False Then
    '        messageright(AccessMode.ViewMode)
    '        'Me.Close()
    '        Exit Sub
    '    End If
    '    frm = "usrd"
    '    ViewUserdetail.Show()
    '    ViewUserdetail.Hide()
    '    ViewUserdetail.Enabled = False
    '    ConfirmPassword.Show()
    '    ConfirmPassword.Focus()
    'End Sub
    'Private Sub COutStandingDividendReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    OutStandingDividendRep.Tag = "Out Standing Dividend Report (Member)"
    '    OutStandingDividendRep.Show()
    'End Sub

    Private Sub QCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CompanyMst.Tag = "Company Master Entry"
        CompanyMst.Show()
    End Sub
    'Private Sub ELahaniReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LahaniRep.Tag = "Lahani Report (Member)"
    '    LahaniRep.Show()
    'End Sub

    'Private Sub DDividendRegisterReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DividendRegisterRep.Tag = "Dividend Register Report (Member)"
    '    DividendRegisterRep.Show()
    'End Sub
    'Private Sub EMatDarYadiReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MatDarYadiReport.Tag = "Matdar Yadi Report (Member)"
    '    MatDarYadiReport.Show()
    'End Sub

    'Private Sub ToolStripMenuItem62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    VoucherGroupMaster.Tag = "Voucher Group Master (Account)"
    '    VoucherGroupMaster.Show()
    'End Sub

    'Private Sub LDepartmentMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DepartmentMaster.Tag = "Department Master (Account)"
    '    DepartmentMaster.Show()
    'End Sub

    'Private Sub MBranchMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BranchMaster.Tag = "Branch Master (Account)"
    '    BranchMaster.Show()
    'End Sub

    'Private Sub FMemberTypeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberTypeMaster.Tag = "Member Type Master (Member)"
    '    MemberTypeMaster.Show()
    'End Sub

    'Private Sub AMalAvakEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MalAvakEntry.Tag = "Mal Avak Entry (Inventory)"
    '    MalAvakEntry.Show()
    'End Sub

    'Private Sub AProductMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ProductMst.Tag = "Prodcut Master (Inventory)"
    '    ProductMst.Show()
    'End Sub

    'Private Sub BQualityMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    QualityMst.Tag = "Quality Master (Inventory)"
    '    QualityMst.Show()
    'End Sub

    'Private Sub CItemMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ItemMst.Tag = "Item Master (Inventory)"
    '    ItemMst.Show()
    'End Sub

    'Private Sub KVNEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    KVNENtry.Tag = "KVN Entry (Inventory)"
    '    KVNENtry.Show()
    'End Sub



    'Private Sub AddjustmentEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AddJustmentEntry.Tag = "Addjustment Entry (Inventory)"
    '    AddJustmentEntry.Show()
    'End Sub

    'Private Sub MalAvakReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MalAvakReport.Tag = "Mal Avak Report (Inventory)"
    '    MalAvakReport.Show()
    'End Sub

    'Private Sub KVNReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    KVNReport.Tag = "KVN Report (Inventory)"
    '    KVNReport.Show()
    'End Sub

    'Private Sub SaleReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaleReport.Tag = "Sales Report (Inventory)"
    '    SaleReport.Show()
    'End Sub

    'Private Sub AddjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AddjustmentReport.Tag = "Addjustment Report (Inventory)"
    '    AddjustmentReport.Show()
    'End Sub

    'Private Sub ItemStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ItemStockRep.Tag = "Item Stock Report (Inventory)"
    '    ItemStockRep.Show()
    'End Sub

    'Private Sub ItemOpeningEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ItemOpeningEntryBrowser.Tag = "Item Opening Entry Browser (Inventory)"
    '    ItemOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub VibhagMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    VibhagMaster.Tag = "Vibhag Master (Member)"
    '    VibhagMaster.Show()
    'End Sub

    'Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    'SalesNewEntry.Tag = "Sales New Entry (Inventory)"
    '    'SalesNewEntry.Show()
    'End Sub

    'Private Sub GUserDepartmentMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UserDeptMst.Tag = "User Department Master"
    '    UserDeptMst.Show()
    'End Sub

    'Private Sub TankMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TankMaster.Tag = "Tank Master (Account)"
    '    TankMaster.Show()
    'End Sub

    'Private Sub DipMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DipMaster.Tag = "Dip Master (Account)"
    '    DipMaster.Show()
    'End Sub

    'Private Sub PumpMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PumpMaster.Tag = "Pump Master (Account)"
    '    PumpMaster.Show()
    'End Sub

    'Private Sub PumpOpeningEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PumpOpeningEntryBrowser.Tag = "Pump Opening Entry Browser (Account)"
    '    PumpOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub TankOpeningEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TankOpeningEntryBrowser.Tag = "Tank Opening Entry Browser (Account)"
    '    TankOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub MeterReadingEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DailyPumpReadingEntry.Tag = "Daily Pump Reading Entry (Account)"
    '    DailyPumpReadingEntry.Show()
    'End Sub

    'Private Sub MemberAccountOpeningBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberOpeningEntryBrowser.Tag = "Member Account Opening Balance Entry Browser (Account)"
    '    MemberOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub DailyTankReadingEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DailyTankReadingEntry.Tag = "Daily Tank Reading Entry (Account)"
    '    DailyTankReadingEntry.Show()
    'End Sub
    'Private Sub PumpReadingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PumpReadingRep.Tag = "Pump Reading Report (Account)"
    '    PumpReadingRep.Show()
    'End Sub
    'Private Sub TankReadingReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TankReadingRep.Tag = "Tank Reading Report (Account)"
    '    TankReadingRep.Show()
    'End Sub
    'Private Sub ItemStockStatusReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ItemStockStatusRep.Tag = "Item Stock Status Report (Inventory)"
    '    ItemStockStatusRep.Show()
    'End Sub
    Dim i As Integer
    Private Sub ComboDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If i <> 1 Then
            'If Len(ComboDept.Text) <> 0 Then
            '    If Val(ComboDept.SelectedValue) = 1 Or Val(ComboDept.SelectedValue) = 3 Or Val(ComboDept.SelectedValue) = 4 Or Val(ComboDept.SelectedValue) = 7 Or Val(ComboDept.SelectedValue) = 8 Then
            '        clsVariables.sDeptID = " and Department_Id in (1,3,4,7,8,10,11,12)"
            '        clsVariables.sdepartment = "(1,3,4,7,8,10,11,12)"
            '    ElseIf Val(ComboDept.SelectedValue) = 10 Then
            '        clsVariables.sDeptID = " and Department_Id in (1,10)"
            '        clsVariables.sdepartment = "(1,10)"
            '    ElseIf Val(ComboDept.SelectedValue) = 11 Then
            '        clsVariables.sDeptID = " and Department_Id in (1,11)"
            '        clsVariables.sdepartment = "(1,11)"
            '    ElseIf Val(ComboDept.SelectedValue) = 12 Then
            '        clsVariables.sDeptID = " and Department_Id in (1,12)"
            '        clsVariables.sdepartment = "(1,12)"

            '    Else
            '        'ElseIf ComboDept.SelectedValue = 2 Or ComboDept.SelectedValue = 3 Or ComboDept.SelectedValue = 4 Or ComboDept.SelectedValue = 5 Or ComboDept.SelectedValue = 6 Then
            '        clsVariables.sDeptID = " and Department_Id in (" & ComboDept.SelectedValue & ")"
            '        clsVariables.sdepartment = "(" & ComboDept.SelectedValue & ")"
            '    End If
            'Else
            '    clsVariables.sDeptID = " and Department_Id in (Select Department_ID From Department_Master where company_Id  = " & clsVariables.CompnyId & ")"
            '    clsVariables.sdepartment = "(Select Department_ID From Department_Master where company_Id  = " & clsVariables.CompnyId & ")"
            'End If
        End If
    End Sub
    Private Sub ComboDept_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'If Len(ComboDept.Text) <> 0 Then
        '    If Val(ComboDept.SelectedValue) = 1 Or Val(ComboDept.SelectedValue) = 3 Or Val(ComboDept.SelectedValue) = 4 Or Val(ComboDept.SelectedValue) = 7 Or Val(ComboDept.SelectedValue) = 8 Then
        '        clsVariables.sDeptID = " and Department_Id in (1,3,4,7,8,9,10,11,12)"
        '        clsVariables.sdepartment = "(1,3,4,7,8,9,10,11,12)"
        '        'ElseIf Val(ComboDept.SelectedValue) = 10 Then
        '        '    clsVariables.sDeptID = " and Department_Id in (1,10)"
        '        '    clsVariables.sdepartment = "(1,10)"
        '    Else
        '        'ElseIf ComboDept.SelectedValue = 2 Or ComboDept.SelectedValue = 3 Or ComboDept.SelectedValue = 4 Or ComboDept.SelectedValue = 5 Or ComboDept.SelectedValue = 6 Then
        '        clsVariables.sDeptID = " and Department_Id in (" & ComboDept.SelectedValue & ")"
        '        clsVariables.sdepartment = "(" & ComboDept.SelectedValue & ")"
        '    End If
        'Else
        '    clsVariables.sDeptID = " and Department_Id in (Select Department_ID From Department_Master where company_Id  = " & clsVariables.CompnyId & ")"
        '    clsVariables.sdepartment = "(Select Department_ID From Department_Master where company_Id  = " & clsVariables.CompnyId & ")"
        'End If
    End Sub
    'Private Sub BatchFormulaEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BatchFormulaEntry.Tag = "Batch Formula Entry (Inventory)"
    '    BatchFormulaEntry.Show()
    'End Sub
    'Private Sub BatchEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BatchEntry.Tag = "Batch Entry"
    '    BatchEntry.Show()
    'End Sub
    'Private Sub BatchReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BatchReport.Tag = "Batch Report"
    '    BatchReport.Show()
    'End Sub
    'Private Sub MemberInterestLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberInterestLedger.Tag = "Member Interest Ledger (Account)"
    '    MemberInterestLedger.Show()
    'End Sub

    'Private Sub MemberMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberMaster.Close()
    '    sdepartment = "savings"
    '    MemberMaster.Tag = "Member Master (Savings)"
    '    MemberMaster.Show()
    'End Sub

    'Private Sub ColumnMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sdepartment = "saving"
    '    Columnmaster.Tag = "Column Master (Savings)"
    '    Columnmaster.Show()
    'End Sub

    'Private Sub SavingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub ReceiptEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SavingReceiptEntry.Tag = "Receipt Entry (Savings)"
    '    SavingReceiptEntry.Show()
    'End Sub

    'Private Sub PaymentEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SavingPaymentEntry.Tag = "Payment Entry (Savings)"
    '    SavingPaymentEntry.Show()
    'End Sub

    'Private Sub ReceiptReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SavingReceiptRep.Tag = "Receipt Report (Savings)"
    '    SavingReceiptRep.Show()
    'End Sub

    'Private Sub PaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SavingPaymentRep.Tag = "Payment Report (Savings)"
    '    SavingPaymentRep.Show()
    'End Sub

    'Private Sub MemberMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberMaster.Close()
    '    sdepartment = "Fixd"
    '    MemberMaster.Tag = "Member Master (Fixd)"
    '    MemberMaster.Show()
    'End Sub

    'Private Sub ColumnMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    sdepartment = "Fixd"
    '    Columnmaster.Tag = "Column Master (Fixd)"
    '    Columnmaster.Show()
    'End Sub

    'Private Sub ReceiptEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdReceiptEntry.Tag = "Receipt Entry (Fixd)"
    '    FixdReceiptEntry.Show()
    'End Sub

    'Private Sub PaymentEntryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdPaymentEntry.Tag = "Payment Entry (Fixd)"
    '    FixdPaymentEntry.Show()
    'End Sub

    'Private Sub ReservePaymentEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdReservePaymentEntry.Tag = "Reserve Payment Entry (Fixd)"
    '    FixdReservePaymentEntry.Show()
    'End Sub

    'Private Sub ReceiptReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdReceiptRep.Tag = "Receipt Report (Fixd)"
    '    FixdReceiptRep.Show()
    'End Sub

    'Private Sub PaymentReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdPaymentRep.Tag = "Payment Report (Fixd)"
    '    FixdPaymentRep.Show()
    'End Sub

    'Private Sub ReservePaymentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdReservePaymentRep.Tag = "Reserve Payment Report (Fixd)"
    '    FixdReservePaymentRep.Show()
    'End Sub

    'Private Sub MemberLedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdLedgerRep.Tag = "Fixd Ledger Report (Fixd)"
    '    FixdLedgerRep.Show()
    'End Sub

    'Private Sub MemberWiseBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdMemberBalanceRep.Tag = "Member Wise Balance Report (Fixd)"
    '    FixdMemberBalanceRep.Show()
    'End Sub

    'Private Sub FixdBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdmemberBalanceNewRep.Tag = "Member Balance (New) Report (Fixd)"
    '    FixdmemberBalanceNewRep.Show()
    'End Sub

    'Private Sub FixdDueReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdDueRep.Tag = "Due Report (Fixd)"
    '    FixdDueRep.Show()
    'End Sub

    'Private Sub InterestReserveReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdInterestReserveRep.Tag = "Interest Reserve Report (Fixd)"
    '    FixdInterestReserveRep.Show()
    'End Sub

    'Private Sub InOutSummaryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdInOutSummaryRep.Tag = "In Out Summary Report (Fixd)"
    '    FixdInOutSummaryRep.Show()
    'End Sub

    'Private Sub InterestSlabReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdInterestSlabRep.Tag = "Interest Slab Report (Fixd)"
    '    FixdInterestSlabRep.Show()
    'End Sub

    'Private Sub ViewFixdDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdMemberView.Tag = "Member View Data (Fixd)"
    '    FixdMemberView.Show()
    'End Sub

    'Private Sub AUpdatePostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdUpdatePosting.Tag = "Update Posting (Fixd)"
    '    FixdUpdatePosting.Show()
    'End Sub

    'Private Sub CComputeInterestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdComputeInterest.Tag = "Compute Interest (Fixd)"
    '    FixdComputeInterest.Show()
    'End Sub

    'Private Sub FixdOpeningBalanceEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdOpeningBalanceEntry.Tag = "Fixd Opening Balance Entry (Fixd)"
    '    FixdOpeningBalanceEntry.Show()
    'End Sub

    'Private Sub ClosingStockEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ClosingStockEntry.Show()
    'End Sub
    Private Sub UpdateMalAvakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If clsVariables.UserName = "admin" Then
            Dim dt As DataTable
            Dim ssql As String
            Dim i As Integer
            'ssql = "Select k.doc_no,k.doc_type,M.Doc_date,k.Mal_avak_No ,k.Mal_avak_Type,Mal_avak_Year From KVN_DETAIL  as k inner join KVN_Main  as m on  k.Company_Id=m.Company_Id and k.YEar_Id=m.year_Id and k.Doc_type=m.Doc_type and k.doc_no=m.Doc_no where M.company_Id=" & clsVariables.CompnyId & "  and M.Year_ID ='" & clsVariables.WorkingYear & "'"
            'dt = ob.Returntable(ssql, ob.getconnection(ob.Getconn))
            'If dt.Rows.Count > 0 Then
            '    For i = 0 To dt.Rows.Count - 1
            '        ssql = "Update MAL_AVAK_MAIN set KVN_Type =" & dt.Rows(i).Item("Doc_type") & " ,KVN_Date= " & aq(dt.Rows(i).Item("Doc_Date")) & ",KVN_No=" & dt.Rows(i).Item("Doc_no") & "  where company_Id=" & clsVariables.CompnyId & "  and Year_ID ='" & dt.Rows(i).Item("Mal_avak_Year") & "' and Doc_type=" & dt.Rows(i).Item("Mal_avak_Type") & "  and Doc_no=" & dt.Rows(i).Item("Mal_avak_no") & " "
            '        ob.Execute(ssql, ob.getconnection(ob.Getconn))
            '    Next
            'End If

            ssql = "Select k.doc_no,k.doc_type,M.Doc_date,k.Mal_avak_No ,k.Mal_avak_Type,Mal_avak_Year From KVN_ITEM_DETAIL  as k inner join KVN_Main  as m on  k.Company_Id=m.Company_Id and k.YEar_Id=m.year_Id and k.Doc_type=m.Doc_type and k.doc_no=m.Doc_no where M.company_Id=" & clsVariables.CompnyId & "  and M.Year_ID ='" & clsVariables.WorkingYear & "'"
            dt = ob.Returntable(ssql, ob.getconnection(ob.Getconn))
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    ssql = "Update MAL_AVAK_MAIN set KVN_Type =" & dt.Rows(i).Item("Doc_type") & " ,KVN_Date= " & aq(dt.Rows(i).Item("Doc_Date")) & ",KVN_No=" & dt.Rows(i).Item("Doc_no") & "  where company_Id=" & clsVariables.CompnyId & "  and Year_ID ='" & dt.Rows(i).Item("Mal_avak_Year") & "' and Doc_type=" & dt.Rows(i).Item("Mal_avak_Type") & "  and Doc_no=" & dt.Rows(i).Item("Mal_avak_no") & " "
                    ob.Execute(ssql, ob.getconnection(ob.Getconn))
                Next
            End If
        End If
    End Sub

    'Private Sub MemberOpeningBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SavingsMemberOpeingBalanceBrowser.Show()
    'End Sub

    'Private Sub AddDedMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AddDedMst.Show()
    'End Sub

    'Private Sub ProfessionalTaxMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ProfTaxMst.Show()
    'End Sub

    'Private Sub AccountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AccountOpeningTransfer.Show()
    'End Sub

    'Private Sub ICalculateInterestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CalculateMemberInterestLedger.Show()
    'End Sub

    'Private Sub InterestReserverReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberInterestReserveRep.Show()
    'End Sub

    'Private Sub MemberMasterReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberMasterRep.Show()
    'End Sub

    'Private Sub RentBillEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RentBillEntry.Show()
    'End Sub

    'Private Sub RentBillReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RentBillReport.Show()
    'End Sub

    'Private Sub EmployeeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    EmployeeMaster.Show()
    'End Sub

    'Private Sub DepartmentMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    EmployeeDepartmentMaster.Show()
    'End Sub

    'Private Sub TransactionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TransactionEntry.Show()
    'End Sub

    'Private Sub LeaveDetailEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeaveDetailEntry.Show()
    'End Sub

    'Private Sub LeaveEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeaveEntry.Show()
    'End Sub

    'Private Sub PostingDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PostingDataU.Show()
    'End Sub

    'Private Sub LeaveMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeaveMaster.Show()
    'End Sub

    'Private Sub PerameterMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ParameterMaster.Show()
    'End Sub

    'Private Sub DAMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    DaSlabEntry.Show()
    'End Sub

    'Private Sub ATransactionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TransactionRep.Tag = "Transaction Report (Payroll)"
    '    TransactionRep.Show()
    'End Sub

    'Private Sub BPayrollRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PayrollRegisterRep.Tag = "Register (Payroll)"
    '    PayrollRegisterRep.Show()
    'End Sub

    'Private Sub CDeductionReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    AddDedRep.Tag = "Deduction Report (Payroll)"
    '    AddDedRep.Show()
    'End Sub

    'Private Sub DLeaveReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeaveWagesRep.Tag = "Leave Wages Report (Payroll)"
    '    LeaveWagesRep.Show()
    'End Sub

    'Private Sub EPFReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PfRep.Tag = "PF Report (Payroll)"
    '    PfRep.Show()
    'End Sub

    'Private Sub FLeaveLedgerReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LeaveLedgerRep.Tag = "Leave Ledger Report (Payroll)"
    '    LeaveLedgerRep.Show()
    'End Sub

    'Private Sub GBonusReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Bonusrep.Tag = "Bonus Report (Payroll)"
    '    Bonusrep.Show()
    'End Sub

    'Private Sub HGrossEarningReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    GrossEarningRep.Tag = "Gross Earning Report (Payroll)"
    '    GrossEarningRep.Show()
    'End Sub

    'Private Sub IGrossPFReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    GrossPfRep.Tag = "Gross PF Report (Payroll)"
    '    GrossPfRep.Show()
    'End Sub

    'Private Sub StorageMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageMaster.Show()
    'End Sub

    'Private Sub StorageItemOpeningBalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageItemOpeningStockEntry.Show()
    'End Sub

    'Private Sub StorageInEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageInEntry.Show()
    'End Sub

    'Private Sub StorageOutEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageOutEntry.Show()
    'End Sub

    'Private Sub StorageInReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageinReport.Show()
    'End Sub

    'Private Sub StorageOutReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageOutReport.Show()
    'End Sub

    'Private Sub StorageItemStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    StorageItemStockRep.Show()
    'End Sub

    'Private Sub InterestSlabEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    FixdInterestSlabEntry.Tag = "Interest Slab Entry (Fixd)"
    '    FixdInterestSlabEntry.Show()
    'End Sub


    'Private Sub ItemSizeDetailMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ItemSizeDetailMaster.Show()
    'End Sub

    'Private Sub SizeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SizeMaster.Show()
    'End Sub

    'Private Sub BarcodePrintingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BarcodePrinting.Show()
    'End Sub

    'Private Sub UpdatePostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UpdateStockPosting.Show()
    'End Sub

    'Private Sub ManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaleEntry.Tag = "Sales Entry (Inventory)"
    '    SaleEntry.Entrytype = "manual"
    '    SaleEntry.Show()
    'End Sub

    'Private Sub BarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaleEntry.Tag = "Sales Entry (Inventory)"
    '    SaleEntry.Entrytype = "barcode"
    '    SaleEntry.Show()
    'End Sub

    'Private Sub UpdateRateEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    UpdateRateEntry.Show()
    'End Sub

    'Private Sub ReceiptEntryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ReceiptEntry.Show()
    'End Sub

    'Private Sub PaymentEntryToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PaymentEntry.Show()
    'End Sub

    'Private Sub ReceiptReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    receiptRep.Show()
    'End Sub

    'Private Sub PaymentReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    paymentRep.Show()
    'End Sub

    Private Sub WeightPavtiEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WeightPavtiEntry.Show()
    End Sub

    Private Sub WeightPavtiReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeightPavtiReportToolStripMenuItem.Click
        'WeightPavtiReport.Show()

        'StockReport.Show()
    End Sub

    Private Sub TransportMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'TransportMaster.Show()
    End Sub

    Private Sub TypeMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  TypeMaster.Show()
    End Sub

    'Private Sub BankMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BankMaster.Show()
    'End Sub

    'Private Sub SalesReturnEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaleReturnEntry.Show()
    'End Sub

    'Private Sub PurchaseReturnEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PurchaseReturnEntry.Show()
    'End Sub

    'Private Sub SalesReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaleReturnReport.Show()
    'End Sub

    'Private Sub PurchaseReturnReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PurchaseReturnReport.Show()
    'End Sub



    'Private Sub TypeMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyTypemaster.Tag = "Type Master (Pady)"
    '    PadyTypemaster.Show()

    'End Sub

    'Private Sub QualityMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyQualityMaster.Tag = "Quality Master (Pady)"
    '    PadyQualityMaster.Show()

    'End Sub

    'Private Sub TruckMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    TruckMaster.Tag = "Truck Master (Pady)"
    '    TruckMaster.Show()
    'End Sub

    'Private Sub ItemMasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyItemMaster.Tag = "Item Master (Pady)"
    '    PadyItemMaster.Show()

    'End Sub

    'Private Sub RateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyRateMaster.Tag = "Rate Master (Pady)"
    '    PadyRateMaster.Show()

    'End Sub

    'Private Sub SeasonMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SeasonMasterBrowser.Tag = "Season Master Browser (Pady)"
    '    SeasonMasterBrowser.Show()

    'End Sub

    'Private Sub BrockerMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BrokerMasterBrowser.Tag = "Broker Master Browser (Pady)"
    '    BrokerMasterBrowser.Show()

    'End Sub

    'Private Sub ItemTypeQualityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyItemTypeQualityBrowser.Tag = "Item Type Quality Browser"
    '    PadyItemTypeQualityBrowser.Show()

    'End Sub

    'Private Sub SalesPurchaseAccountMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SalesPurchaseAccountMaster.Show()

    'End Sub

    'Private Sub ItemOpeningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyItemOpeningEntryBrowser.Tag = "Item Opening Browser (Pady)"
    '    PadyItemOpeningEntryBrowser.Show()
    'End Sub

    'Private Sub ReciptEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub SalesBillEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySalesBillEntry.Tag = "Sales Entry (Pady)"
    '    PadySalesBillEntry.Show()
    'End Sub

    'Private Sub PaymentEntryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyRojmalEntry.Tag = "Rojmel Entry (Pady)"
    '    PadyRojmalEntry.Show()
    'End Sub

    'Private Sub ProductionEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyProductionEntry.Tag = "Production Entry (Pady)"
    '    PadyProductionEntry.Show()

    'End Sub

    'Private Sub ChallanEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyChallanEntry.Tag = "Challan Entry (Pady)"
    '    PadyChallanEntry.Show()
    'End Sub

    'Private Sub BardanAdjustmentEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyAddjustmentEntry.Tag = "Addjustment Entry (Pady)"
    '    PadyAddjustmentEntry.Show()
    'End Sub

    'Private Sub BardanIssueEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyBardanENtry.Tag = "Bardan Entry (Pady)"
    '    PadyBardanENtry.Show()
    'End Sub

    'Private Sub PadyReceiptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyReceiptRep.Tag = "Pady Receipt Report (Pady)"
    '    PadyReceiptRep.Show()
    'End Sub

    'Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyRojmelNewRep.Tag = "Rojmel Report (Pady)"
    '    PadyRojmelNewRep.Show()
    'End Sub

    'Private Sub PadyChallanReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyChallanRep.Tag = "Challan Report (Pady)"
    '    PadyChallanRep.Show()
    'End Sub

    'Private Sub PadySalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySalesBillRep.Tag = "Sales Report (Pady)"
    '    PadySalesBillRep.Show()
    'End Sub

    'Private Sub ReceiptEntryToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyReceiptEntry.Tag = "Pady Receipt Entry (Pady)"
    '    PadyReceiptEntry.Show()
    'End Sub


    'Private Sub ItemStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyItemStockRep.Tag = "Pady Item Stock Status"
    '    PadyItemStockRep.Show()
    'End Sub

    'Private Sub MemberLedgerReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberLedgerRep.Close()
    '    MemberLedgerRep.Tag = "Member Ledger Report (Pady)"
    '    MemberLedgerRep.Show()
    'End Sub

    'Private Sub MemberBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MemberLedgerRep.Close()
    '    MemberLedgerRep.Tag = "Member Account Balance Report (Pady)"
    '    MemberLedgerRep.Show()
    'End Sub

    'Private Sub RatePostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    RatePosting.Show()
    'End Sub

    'Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MillingRep.Show()
    'End Sub

    'Private Sub PadyBardanReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    BardanRep.Tag = "Bardan Report (Pady)"
    '    BardanRep.Show()
    'End Sub

    'Private Sub AdjustmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyAddjustmentReport.Tag = "Addjustment Report (Pady)"
    '    PadyAddjustmentReport.Show()
    'End Sub

    'Private Sub TransferEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyItemTransferEntry.Tag = "Item Transfer Entry (Pady)"
    '    PadyItemTransferEntry.Show()
    'End Sub

    'Private Sub SidhiKharidiChallanEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiChallanEntry.Tag = "Sidhi Kharidi Challan Entry (Pady)"
    '    PadySidhiKharidiChallanEntry.Show()
    'End Sub

    'Private Sub SidhiKharidiReceiptEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiReceiptEntry.Tag = "Sidhi Kharidi Receipt Entry (Pady)"
    '    PadySidhiKharidiReceiptEntry.Show()
    'End Sub

    'Private Sub SidhiKharidiSalesEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiSalesEntry.Tag = "Sidhi Kharidi Sales Entry (Pady)"
    '    PadySidhiKharidiSalesEntry.Show()
    'End Sub

    'Private Sub PadyToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub SidhiKharidiChallanReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiChallanRep.Tag = "Sidhi Kharidi Challan Report (Pady)"
    '    PadySidhiKharidiChallanRep.Show()
    'End Sub

    'Private Sub SidhiKharidiReceiptReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiReceiptRep.Tag = "Sidhi Kharidi Receipt Report (Pady)"
    '    PadySidhiKharidiReceiptRep.Show()
    'End Sub

    'Private Sub SidhiKharidiSalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiSalesBillRep.Tag = "Sidhi Kharidi Sales Report (Pady)"
    '    PadySidhiKharidiSalesBillRep.Show()
    'End Sub

    'Private Sub BardanStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyBardanStockRep.Tag = "Bardan Stock Report (Pady)"
    '    PadyBardanStockRep.Show()

    'End Sub

    'Private Sub SidhiKharidiItemOpeningToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiItemOpeningEntryBrowser.Tag = "Item Opening Browser (Sidhi Kharidi)"
    '    PadySidhiKharidiItemOpeningEntryBrowser.Show()

    'End Sub

    'Private Sub SidhiKharidiItemStockReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadySidhiKharidiItemStockRep.Tag = "Sidhi Kharidi Stock Report (Pady)"
    '    PadySidhiKharidiItemStockRep.Show()
    'End Sub

    'Private Sub KuskaSalesVatReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    KushkaSalesVatRep.Tag = "Kuska Sales Vat Report (Pady)"
    '    KushkaSalesVatRep.Show()
    'End Sub

    'Private Sub IncomeCertificateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyIncomeCertificate.Tag = "Income Certificate (Pady)"
    '    PadyIncomeCertificate.Show()
    'End Sub

    'Private Sub PadyTransportReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyTransportRep.Tag = "Transport Report(Pady)"
    '    PadyTransportRep.Show()

    'End Sub

    'Private Sub ClosingStockPostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ClosingStockPosting.Show()

    'End Sub

    'Private Sub JCreateNewDBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CreatNewDb.Show()
    'End Sub

    'Private Sub PadyStockPostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    PadyStockUpdatePosting.Show()

    'End Sub

    Private Sub MdiMain_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter

    End Sub

    Private Sub Transactionmenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Transactionmenu.Click

    End Sub

    Private Sub WeightBridgeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeightBridgeToolStripMenuItem.Click
        PartyMaster.Show()
    End Sub

    Private Sub TypeMasterToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ItemMst.Show()
    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub LoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'LonePassing.Show()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Payment.Show()
    End Sub

    Private Sub LoneLedgureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ViewLed.Show()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Purchase.Show()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Sales.Show()
    End Sub

    Private Sub PostingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Posting.Show()
    End Sub

    Private Sub DeletToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Deleteloan.Show()
    End Sub

    Private Sub FindLoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'FindPhone.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Rojmed.Show()
    End Sub

    Private Sub DanAvakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DanAvakToolStripMenuItem.Click
        MaintenanceEntry.Show()
    End Sub

    Private Sub JanAvakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JanAvakToolStripMenuItem.Click
        Javak.Show()
    End Sub

    Private Sub RateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateMasterToolStripMenuItem.Click
        Rate_Master.Show()
    End Sub

    Private Sub MemberMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemberMasterToolStripMenuItem.Click
        ' Member_Opening.Show()
        'MemberMaster.Show()
        FrmMemberMasterNew.Show()
    End Sub

    Private Sub ProductMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductMasterToolStripMenuItem.Click
        ProductMst.Show()
    End Sub

    Private Sub OtherIncomeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherIncomeToolStripMenuItem.Click
        Other_Income.Show()
    End Sub

    Private Sub MainteanceDebitEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainteanceDebitEntryToolStripMenuItem.Click
        MaintenanceDebitEntry.Show()
    End Sub

    Private Sub FreeEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FreeEntryToolStripMenuItem.Click
        FreeEntri.Show()
    End Sub

    Private Sub YearMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearMasterToolStripMenuItem.Click
        YearEntry.Show()
    End Sub

    Private Sub HouseDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HouseDetailToolStripMenuItem.Click
        HousedetailMaster.Show()
    End Sub

    Private Sub HouseTransToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HouseTransToolStripMenuItem.Click
        Transfer.Show()
    End Sub

    Private Sub AccountMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMasterToolStripMenuItem.Click
        AccountGrpMaster.Show()
    End Sub

    Private Sub AccountMasterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountMasterToolStripMenuItem1.Click
        AccountMaster.Show()
    End Sub

    Private Sub AccountEntryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountEntryToolStripMenuItem.Click
        'AccountEntry.Show()
    End Sub

    Private Sub TrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrToolStripMenuItem.Click
        'Tr.Show()
        'Form1.Show()
        pra.Show()
    End Sub

    Private Sub RojmedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RojmedToolStripMenuItem.Click
        Rojmed.Show()
    End Sub

    Private Sub AccountLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountLedgerToolStripMenuItem.Click
        Acledger.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        TarijReport.Show()
    End Sub

    Private Sub TrialBalanceReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrialBalanceReportToolStripMenuItem.Click
        TrialBalanceReport.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        TradingAccountReport.Show()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ProfitandLossAccountReport.Show()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        BalanceSheet.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'If DG.Rows.Count > 0 Then
        '    DG.Rows.Clear()
        'End If

        'DG.Columns(0).Width = 160
        'DG.Columns(1).Width = 70
        'Dim dt As DataTable = ob.Returntable("select * from Account_Master where group_id=8", ob.getconnection())
        'If dt.Rows.Count > 0 Then
        '    For iss = 0 To dt.Rows.Count - 1
        '        DG.Rows.Add()
        '        DG.Rows(DG.Rows.Count - 1).Cells(0).Value = dt.Rows(iss).Item("Account_Name")
        '        DG.Rows(DG.Rows.Count - 1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        '        DG.Rows(DG.Rows.Count - 1).Cells(1).Value = ob.FindOneString("select sum(Cramt)-sum(Dramt) from Acdata where Acid=" & dt.Rows(iss).Item("Account_Id") & "", ob.getconnection())
        '    Next
        'End If
        'DG.Visible = False
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        FinalAccountOpeningEntryBrowser.Show()
    End Sub

    Private Sub VillageMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VillageMasterToolStripMenuItem.Click
        VillageMst.Show()
    End Sub

    Private Sub ItemMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemMasterToolStripMenuItem.Click
        ItemMst.Show()
    End Sub

    Private Sub SalesEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesEntryToolStripMenuItem.Click
        FrmSalesEntry.Show()
    End Sub

    Private Sub PurchaseEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseEntryToolStripMenuItem.Click
        FrmPurchaseEntry.Show()
    End Sub

    Private Sub MalAvakEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MalAvakEntryToolStripMenuItem.Click
        FrmMalavakEntry.Show()
    End Sub

    Private Sub MemberInwardToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberInwardToolStripMenuItem.Click
        MemberInward.Show()
    End Sub

    Private Sub MemberReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberReceiptToolStripMenuItem.Click
        MemberReceipt.Show()
    End Sub

    Private Sub LoanPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoanPaymentToolStripMenuItem.Click
        LoanPayment.Show()
    End Sub

    Private Sub LoanReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoanReceiptToolStripMenuItem.Click
        LoanReceipt.Show()
    End Sub

    Private Sub FixdReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixdReceiptToolStripMenuItem.Click
        FixdReceipt.Show()
    End Sub

    Private Sub FixdPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixdPaymentToolStripMenuItem.Click
        FixdPayment.Show()
    End Sub

    Private Sub SavingReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavingReceiptToolStripMenuItem.Click
        SavingReceipt.Show()
    End Sub

    Private Sub SavingPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SavingPaymentToolStripMenuItem.Click
        SavingPayment.Show()
    End Sub

    Private Sub MemberReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberReportToolStripMenuItem.Click
        Membledger.Show()
    End Sub

    Private Sub ColumnMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnMasterToolStripMenuItem.Click
        Columnmaster.Show()
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        LoanPassingEntry.Show()
    End Sub

    Private Sub FixdReceiptToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FixdReceiptToolStripMenuItem1.Click
        GramlaxmiFixdReceipt.Show()
    End Sub

    Private Sub FixdPaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FixdPaymentToolStripMenuItem1.Click
        GramLaxmiFixdPayment.Show()
    End Sub

    Private Sub MemberOpeningEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberOpeningEntryToolStripMenuItem.Click
        MemberOpeningEntry.Show()
    End Sub

    Private Sub MemberLoanOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberLoanOpeningToolStripMenuItem.Click
        LoanOpeningEntry.Show()
    End Sub

    Private Sub LoanReceiptReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoanReceiptReportToolStripMenuItem.Click
        LoanReceiptReport.Show()
    End Sub

    Private Sub LoanPaymentReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoanPaymentReportToolStripMenuItem.Click
        LoanPaymenttReport.Show()
    End Sub

    Private Sub FixdPaymentReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixdPaymentReportToolStripMenuItem.Click
        FixdPaymentReport.Show()
    End Sub

    Private Sub FixdReceiptReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FixdReceiptReportToolStripMenuItem.Click
        FixdReceiptReport.Show()
    End Sub

    Private Sub MemberFidOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberFidOpeningToolStripMenuItem.Click
        FixdOpening.Show()
    End Sub

    Private Sub MonthlyPostingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyPostingToolStripMenuItem.Click
        MonthlyPosting.Show()
    End Sub

    Private Sub MonthlyReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyReportToolStripMenuItem.Click
        MonthlyReport.Show()
    End Sub

    Private Sub MonthlyCashEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyCashEntryToolStripMenuItem.Click
        SavingReceipt.Show()
    End Sub

    Private Sub RajinamaEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RajinamaEntryToolStripMenuItem.Click
        RajinamaEntry.Show()
        'Intro.Show()
    End Sub

    Private Sub RajinamaReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RajinamaReportToolStripMenuItem.Click
        RajinamaReport.Show()
    End Sub

    Private Sub CashEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashEntryToolStripMenuItem.Click
        RojmalEntry.Show()
    End Sub

    Private Sub BankEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BankEntryToolStripMenuItem.Click
        BankEntry.Show()
    End Sub

    Private Sub JVEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JVEntryToolStripMenuItem.Click
        'JVEntry.Show()
        FrmJventryNew.Show()
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        SavingIntrestCalculation.Show()
    End Sub

    Private Sub ReceiptEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiptEntryToolStripMenuItem.Click
        FrmReceiptEntry.Show()
    End Sub

    Private Sub MalAvakReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MalAvakReportToolStripMenuItem.Click
        MalavakReport.Show()
    End Sub

    Private Sub DStockTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DStockTransferToolStripMenuItem.Click
        Frmstocktransfer.Show()
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReportToolStripMenuItem.Click
        SalesReport.Show()
    End Sub

    Private Sub StockReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockReportToolStripMenuItem.Click
        frmStockreport.Show()
    End Sub

    Private Sub PurchaseEntryBhandarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseEntryBhandarToolStripMenuItem.Click
        FrmPurchaseEntryBhandar.Show()
    End Sub

    Private Sub SalesEntryBhandarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesEntryBhandarToolStripMenuItem.Click
        FrmSalesEntryBhandar.Show()
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        RatePosting.Show()
    End Sub

    Private Sub ReceiptReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiptReportToolStripMenuItem.Click
        ReceiptReport.Show()
    End Sub

    Private Sub PurchaseReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PurchaseReportToolStripMenuItem.Click
        PurchaseReport.Show()
    End Sub

    Private Sub FCloudBackupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FCloudBackupToolStripMenuItem.Click
        Dim databasename As String = "Mandli"
        Dim cn As New System.Data.SqlClient.SqlConnection
        Dim cmd As System.Data.SqlClient.SqlCommand

        'AddRecord("backup database " & databasename & " to disk='E:\Project\Backup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak'")
        cn.ConnectionString = ob.Getconn
        cmd = New System.Data.SqlClient.SqlCommand("backup database " & databasename & " to disk='" & Application.StartupPath & "\Backup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak'", cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        Dim archiver As ZipForge = New ZipForge()
        Try
            ' The name of the ZIP file to be created
            archiver.FileName = Application.StartupPath & "\Backup\" & databasename & Now.Day & Now.Month & Now.Year & ".Zip"
            ' Specify FileMode.Create to create a new ZIP file
            ' or FileMode.Open to open an existing archive
            archiver.OpenArchive(System.IO.FileMode.Create)
            ' Default path for all operations                
            archiver.BaseDir = "E:"
            ' Add file C:\file.txt the archive; wildcards can be used as well                
            archiver.AddFiles(Application.StartupPath & "\Backup\" & databasename & Now.Day & Now.Month & Now.Year & ".bak")
            ' Close archive
            archiver.CloseArchive()
            ' Catch all exceptions of the ArchiverException type
        Catch ae As ArchiverException
            Console.WriteLine("Message: {0} Error code: {1}", ae.Message, ae.ErrorCode)
            ' Wait for keypress
            Console.ReadLine()
        End Try
        Form1.Show()
    End Sub

    Private Sub GstReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GstReportToolStripMenuItem.Click
        GSTReport.Show()
    End Sub

    Private Sub MemberViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MemberViewToolStripMenuItem.Click
        MemberView.Show()
    End Sub

    Private Sub CardMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CardMasterToolStripMenuItem.Click
        PartyMaster.Show()
    End Sub

    Private Sub PurchaseToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PurchaseToolStripMenuItem.Click
        'FrmPurchaseEntryR.Show()
    End Sub

    Private Sub SalesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        'FrmSalesEntryR.Show()
    End Sub

    Private Sub SalesReportRetionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesReportRetionToolStripMenuItem.Click
        '  SalesReportR.Show()
    End Sub

    Private Sub MigNiAºTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MigNiAºTToolStripMenuItem.Click
        FrmMangnaEntry.Show()
    End Sub

    Private Sub GDataTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GDataTransferToolStripMenuItem.Click
        FrmDataTrasfer.Show()
    End Sub

    Private Sub LoanToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LoanToolStripMenuItem.Click
        FrmDataTrasfer.Show()
    End Sub

    Private Sub MigNiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MigNiToolStripMenuItem.Click
        FrmReceiptEntry.Show()
    End Sub

    Private Sub JniToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JniToolStripMenuItem.Click
        OldMangnaReceipt.Show()
    End Sub

    Private Sub SBisdJmnRpiTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SBisdJmnRpiTToolStripMenuItem.Click
        landReport.Show()
    End Sub

    Private Sub MigNiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MigNiToolStripMenuItem1.Click
        MangnaReport.Show()
    End Sub

    Private Sub MigNiRsdAºTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MigNiRsdAºTToolStripMenuItem.Click
        MangnaReceiptReport.Show()
    End Sub

    Private Sub KitivhBlºsTiAfrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KitivhBlºsTiAfrToolStripMenuItem.Click
        AccountBalanceTransfer.Show()
    End Sub

    Private Sub NvVPBnivvToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NvVPBnivvToolStripMenuItem.Click
        CreateNewYear.Show()
    End Sub

    Private Sub HToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HToolStripMenuItem.Click
        CreateNewYear.Show()
    End Sub

    Private Sub IAccoutBalanceTrasferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IAccoutBalanceTrasferToolStripMenuItem.Click
        AccountBalanceTransfer.Show()
    End Sub

    Private Sub RijmlRpiTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RijmlRpiTToolStripMenuItem.Click
        Rojmed.Show()

    End Sub

    Private Sub SBisdSrTiºsfrToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SBisdSrTiºsfrToolStripMenuItem.Click
        FrmShareTrasfer.Show()
    End Sub

    Private Sub SrKitivhToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SrKitivhToolStripMenuItem.Click
        Shareledger.Show()
    End Sub

    Private Sub RationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RationToolStripMenuItem.Click

    End Sub

    Private Sub AkiuºTSaitNAºTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AkiuºTSaitNAºTToolStripMenuItem.Click
        FrmMemberOpeningEntry.Show()
    End Sub

    Private Sub SrSBisdAºTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SrSBisdAºTToolStripMenuItem.Click
        FrmShareOpening.Show()
    End Sub
End Class
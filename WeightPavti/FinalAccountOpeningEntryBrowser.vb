Imports WeightPavti.CLS

Public Class FinalAccountOpeningEntryBrowser

    Private Sub FinalAccountOpeningEntryBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Butreferesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Butreferesh.Click
        Try
            Dim sSql As String
            'sSql = "SELECT MOB.Account_Id, MM.Account_name,"
            'sSql = sSql & "  MOB.cr_opening, MOB.dr_opening "
            'sSql = sSql & " FROM FINAL_ACCOUNT_OPENING_BALANCE AS MOB LEFT OUTER JOIN"
            'sSql = sSql & " Account_Master AS MM ON MOB.Company_Id = MM.Company_Id AND MOB.Account_Id = MM.Account_id "
            'sSql = sSql & " where MOB.Company_id=" & clsVariables.CompnyId
            'sSql = sSql & " and MOB.Year_id=" & aq(clsVariables.WorkingYear)
            'If Len(TXtAccountId.Text) > 0 Then
            '    sSql = sSql & " and MOb.Account_Id=" & Val(TXtAccountId.Text)
            'End If
            'If Len(TXtdepartmentId.Text) > 0 Then
            '    sSql = sSql & " and MM.department_Id=" & Val(TXtdepartmentId.Text)
            'End If
            'If Len(TxtAccountName.Text) > 0 Then
            '    sSql = sSql & " and MM.Account_name like '" & AddQuote(TxtAccountName.Text) & "%'"
            'End If
            'sSql = sSql & " ORDER BY MOB.Account_Id"
            sSql = "select acid,account_master.account_name,cramt,dramt from acdata inner join account_master on account_master.account_id=acdata.acid where year_id='" & clsVariables.WorkingYear & "' and TYPE='opening' "
            DG.DataSource = ob.Returntable(sSql, ob.getconnection)
            lbTotal.Text = "Total : " & DG.Rows.Count
            total()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub total()
        Dim cc As Double = 0
        Dim dd As Double = 0
        For i As Integer = 0 To DG.Rows.Count - 1
            cc = Val(cc) + Val(DG.Rows(i).Cells(2).Value)
            dd = Val(dd) + Val(DG.Rows(i).Cells(3).Value)
        Next
        lblcr.Text = Val(cc)
        lbldr.Text = Val(dd)
    End Sub
    Private Sub txtMemberNAme_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccountName.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtMemberNAme_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAccountName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub MemberOpeingBalanceBrowser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BUtAdd.KeyUp, butClear.KeyUp, BUtDelete.KeyUp, ButEdit.KeyUp, butExit.KeyUp, ButPrint.KeyUp, Butreferesh.KeyUp, TXtAccountId.KeyUp, TxtAccountName.KeyUp
        If e.KeyCode = Keys.F3 Then
            DG.Focus()
        ElseIf e.KeyCode = Keys.F5 Then
            Butreferesh_Click(e, e)
        End If
    End Sub

    Private Sub MemberOpeingBalanceBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = Screen.PrimaryScreen.Bounds.Height - 175
        Me.Text = Me.Tag
        'Me.BackgroundImage = MdiMain.PicTransaction.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        Me.MdiParent = MdiMain

        DG.Width = Me.Width - 30
        DG.Height = Me.Height - 165
        GroupBox2.Top = DG.Bottom + 1
        GroupBox1.Width = DG.Width
        GroupBox2.Width = DG.Width
        GroupBox1.Top = GroupBox2.Bottom + 1
        Butreferesh_Click(e, e)
        DG.Columns(0).HeaderText = "Account Id"
        DG.Columns(0).Width = 100
        DG.Columns(1).HeaderText = "Account Name"
        DG.Columns(1).Width = 350
        DG.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 11, FontStyle.Regular)
        DG.Columns(2).HeaderText = "Credit"
        DG.Columns(3).HeaderText = "Debit"
        DG.Columns(2).Width = 150
        DG.Columns(3).Width = 150
        DG.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DG.Columns(2).DefaultCellStyle.Format = g2Dec
        DG.Columns(3).DefaultCellStyle.Format = g2Dec
    End Sub

    Private Sub butClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butClear.Click
        TXtAccountId.Clear()
        TxtAccountName.Clear()
    End Sub

    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        'FinalAccountOpeningBalanceRep.Tag = "Account Opening Balance Report (Account)"
        'FinalAccountOpeningBalanceRep.Show()
    End Sub

    Private Sub txtmemberid_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtmemberid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtAccountId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtmemberid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtAccountId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtmemberid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXtAccountId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Account_id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_name"
            HelpWin.tsql = "Select Account_id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TXtAccountId.Text = clsVariables.RtnHelpId
                TxtAccountName.Text = clsVariables.RtnHelpName
                TxtAccountName.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Account_id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_id"
            HelpWin.tsql = "Select Account_id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TXtAccountId.Text = clsVariables.RtnHelpId
                TxtAccountName.Text = clsVariables.RtnHelpName
                TxtAccountName.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            DG.Focus()
        End If
    End Sub

    Private Sub txtmemberid_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtAccountId.Validated
        Try
            Dim ssql As String
            If TXtAccountId.Text <> "" Then
                ssql = "Select Account_name from Account_Master where Account_id= " & Val(TXtAccountId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                ssql = ssql & clsVariables.sDeptID
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    TxtAccountName.Text = dt.Rows(0).Item(0).ToString
                Else
                    MsgBox("Invalid Account Id")
                    TxtAccountName.Text = ""
                    TXtAccountId.Focus()
                End If
            Else
                TxtAccountName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BUtDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtDelete.Click
        If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.DeleteMode)
            Exit Sub
        End If
        Dim ssql As String
        If DG.Rows.Count > 0 Then
            If MessageBox.Show("Do You Want To Delete Thise Entry ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                ssql = "Delete from FINAL_ACCOUNT_OPENING_BALANCE where Company_id=" & clsVariables.CompnyId
                ssql = ssql & " and Account_Id=" & Val(ob.IfNullThen(DG.Rows(DG.CurrentRow.Index).DataBoundItem("Account_Id"), 0))
                ssql = ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                ob.Execute(ssql, ob.getconnection)
                ob.Execute("Delete from Acdata where cid=" & clsVariables.CompnyId & " and Year_id=" & aq(clsVariables.WorkingYear) & " and Acid=" & TXtAccountId.Text & " and Type='Opening'", ob.getconnection())
                Butreferesh_Click(e, e)
            End If
        End If
    End Sub

    Private Sub BUtAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtAdd.Click
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        FInalAccountOpeningEntry.vad = 0
        FInalAccountOpeningEntry.Tag = "Account Opening Balance Entry (Account)"
        FInalAccountOpeningEntry.Show()
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.ChangeMode)
            Exit Sub
        End If
        If DG.Rows.Count > 0 Then
            FInalAccountOpeningEntry.vad = 1
            FInalAccountOpeningEntry.vAccount_id = ob.IfNullThen(DG.Rows(DG.CurrentRow.Index).DataBoundItem("acid"), 0)
            FInalAccountOpeningEntry.Tag = "Account Opening Balance Entry (Account)"
            FInalAccountOpeningEntry.Show()
        End If
    End Sub


    Private Sub txtMemberNAme_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccountName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub DG_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DG.DoubleClick
        ButEdit_Click(e, e)
    End Sub

    Private Sub TXtdepartmentId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtdepartmentId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtdepartmentId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtdepartmentId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtdepartmentId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXtdepartmentId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Department_Id"
            clsVariables.HelpName = "Department_Name"
            clsVariables.TbName = "Department_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Department_Name"
            HelpWin.tsql = "Select Department_Id,Department_Name from Department_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TXtdepartmentId.Text = clsVariables.RtnHelpId
                txtDepartmentName.Text = clsVariables.RtnHelpName
                Butreferesh.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Department_id"
            clsVariables.HelpName = "Department_Name"
            clsVariables.TbName = "Department_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Department_Id"
            HelpWin.tsql = "Select Department_Id,Department_Name from Department_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TXtdepartmentId.Text = clsVariables.RtnHelpId
                txtDepartmentName.Text = clsVariables.RtnHelpName
                Butreferesh.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            DG.Focus()
        End If
    End Sub

    Private Sub TXtdepartmentId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtdepartmentId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtdepartmentId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtdepartmentId.Validated
        Try
            Dim ssql As String
            If Val(TXtdepartmentId.Text) <> 0 Then
                ssql = "Select Department_Name from Department_Master where Department_id= " & Val(TXtdepartmentId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtDepartmentName.Text = dt.Rows(0).Item(0).ToString
                Else
                    'If BUtAdd.Enabled = False Then
                    MsgBox("Invalid Department Id")
                    txtDepartmentName.Text = ""
                    TXtdepartmentId.Focus()
                    'End If
                End If
            Else
                TXtdepartmentId.Text = ""
                txtDepartmentName.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lblcr.Click

    End Sub
End Class
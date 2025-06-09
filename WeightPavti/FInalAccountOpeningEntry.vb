Imports WeightPavti.CLS

Public Class FInalAccountOpeningEntry

    Public vAccount_id As Integer
    Public vad As Integer
    Dim isadd As Boolean

    Private Sub FInalAccountOpeningEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.BackgroundImage = MdiMain.PicTransaction.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        Me.MdiParent = MdiMain
        If vad = 0 Then
            ButAdd_Click(e, e)
        Else
            TxtAccountId.Text = vAccount_id

            Filltext(Val(TxtAccountId.Text))
            butstyle2()
            isadd = False
            TxtAccountId.Enabled = False
            TxtCredit.Focus()
        End If
    End Sub

    Private Sub TxtMemberId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtMemberId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAccountId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtMemberId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccountId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCredit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredit.GotFocus, TxtDebit.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCredit.KeyPress, TxtDebit.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtCredit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredit.LostFocus, TxtDebit.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCredit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCredit.Validated
        TxtCredit.Text = Format(Val(TxtCredit.Text), g2Dec)
    End Sub

    Private Sub TxtCredit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCredit.Validating, TxtDebit.Validating
        CheckNumeric(sender, e)
    End Sub

    Private Sub TxtDebit_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDebit.Validated
        TxtDebit.Text = Format(Val(TxtDebit.Text), g2Dec)
    End Sub

    Public Sub butstyle1()
        ButAdd.Enabled = True
        ButEdit.Enabled = True
        ButDelete.Enabled = True
        ButSave.Enabled = False
        ButCAncel.Enabled = False
        ButPrint.Enabled = True
        ButFirst.Enabled = True
        ButNExt.Enabled = True
        BUtPrev.Enabled = True
        ButLast.Enabled = True

        TxtAccountId.Enabled = False
        TXtAccountName.Enabled = False
        TxtCredit.Enabled = False
        TxtDebit.Enabled = False
    End Sub

    Public Sub butstyle2()
        ButAdd.Enabled = False
        ButEdit.Enabled = False
        ButDelete.Enabled = False
        ButSave.Enabled = True
        ButCAncel.Enabled = True
        ButPrint.Enabled = False
        ButFirst.Enabled = False
        ButNExt.Enabled = False
        BUtPrev.Enabled = False
        ButLast.Enabled = False

        TxtAccountId.Enabled = True
        TXtAccountName.Enabled = True
        TxtCredit.Enabled = True
        TxtDebit.Enabled = True
    End Sub

    Public Sub Cleartxt()
        TxtAccountId.Clear()
        TXtAccountName.Clear()
        TxtCredit.Clear()
        TxtDebit.Clear()
    End Sub

    Public Sub Filltext(ByVal Account_id As String)
        Try
            Cleartxt()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from FINAL_ACCOUNT_OPENING_BALANCE where Company_id=" & clsVariables.CompnyId & " and Account_id=" & Val(Account_id) & " and Year_id=" & aq(clsVariables.WorkingYear), ob.getconnection)
            If dt.Rows.Count > 0 Then
                TxtAccountId.Text = ob.IfNullThen(dt.Rows(0).Item("Account_Id"), "")
                TXtAccountName.Text = ob.FindOneString("select Account_name from Account_Master where Company_id=" & clsVariables.CompnyId & " and Account_Id=" & Val(TxtAccountId.Text), ob.getconnection)
                TxtCredit.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("Cr_Opening"), 0)), g2Dec)
                TxtDebit.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("Dr_Opening"), 0)), g2Dec)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        Try
            If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                butstyle1()
                messageright(AccessMode.ChangeMode)
                Exit Sub
            End If
            If Len(TxtAccountId.Text) = 0 Then
                MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Me.Text = Me.Tag & " { Edit } "
                butstyle2()
                isadd = False
                TxtAccountId.Enabled = False
                TxtCredit.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                butstyle1()
                messageright(AccessMode.DeleteMode)
                Exit Sub
            End If
            If Len(TxtAccountId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim ssql As String
                    ssql = "Delete from FINAL_ACCOUNT_OPENING_BALANCE"
                    ssql = ssql & " where Company_id = " & Val(clsVariables.CompnyId)
                    ssql = ssql & " And Account_Id = " & Val(TxtAccountId.Text)
                    ssql = ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                    ob.Execute(ssql, ob.getconnection)
                    ob.Execute("Delete from Acdata where cid=" & clsVariables.CompnyId & " and Year_id=" & aq(clsVariables.WorkingYear) & " and Acid=" & TxtAccountId.Text & " and Type='Opening'", ob.getconnection())
                    MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
                    If Entry_Move("next") = False Then
                        If Entry_Move("prev") = False Then
                            Cleartxt()
                        End If
                    End If
                End If
            End If
            'Else
            'butstyle1()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from FINAL_ACCOUNT_OPENING_BALANCE where Company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Year_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " Order by Account_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from FINAL_ACCOUNT_OPENING_BALANCE "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Year_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " and Account_Id>" & Val(TxtAccountId.Text)
                sql = sql & " Order by Account_Id"
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from FINAL_ACCOUNT_OPENING_BALANCE "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Year_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " and Account_Id<" & Val(TxtAccountId.Text)
                sql = sql & " Order by Account_Id desc "
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from FINAL_ACCOUNT_OPENING_BALANCE where Company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Year_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " Order by Account_Id desc "
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                Filltext(ob.IfNullThen(dt.Rows(0).Item("Account_Id"), 0))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        Filltext(Val(TxtAccountId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFirst.Click
        Entry_Move("first")
    End Sub

    Private Sub ButNExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButNExt.Click
        Entry_Move("next")
    End Sub

    Private Sub BUtPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtPrev.Click
        Entry_Move("prev")
    End Sub

    Private Sub ButLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLast.Click
        Entry_Move("last")
    End Sub

    Private Sub BuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuExit.Click
        Me.Close()
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Try
            If Len(TxtAccountId.Text) = 0 Then
                MessageBox.Show("Please Enter Member Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtAccountId.Focus()
                Exit Sub
            Else
                Dim ssql As String
                ssql = "Select Count(*) from FINAL_ACCOUNT_OPENING_BALANCE where Company_id=" & clsVariables.CompnyId
                ssql = ssql & " and Account_Id=" & Val(TxtAccountId.Text)
                ssql = ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                If ob.FindOneinteger(ssql, ob.getconnection) > 0 Then
                    ssql = "update FINAL_ACCOUNT_OPENING_BALANCE set "
                    ssql = ssql & " Cr_Opening=" & Val(TxtCredit.Text)
                    ssql = ssql & ",dr_Opening=" & Val(TxtDebit.Text)
                    ssql = ssql & " where Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Account_Id=" & Val(TxtAccountId.Text)
                    ssql = ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                    ob.Execute(ssql, ob.getconnection)
                    ob.Execute("Delete from Acdata where cid=" & clsVariables.CompnyId & " and Year_id=" & aq(clsVariables.WorkingYear) & " and Acid=" & TxtAccountId.Text & " and Type='Opening'", ob.getconnection())
                    Dim ddate As Date = gFinYearBegin
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt) Values(1,'" & clsVariables.WorkingYear & "','Opening',1,'" & ob.DateConversion(ddate) & "'," & TxtAccountId.Text & ",'" & TXtAccountName.Text & "'," & Val(TxtDebit.Text) & ",'S@ait n)  bik)'," & Val(TxtCredit.Text) & ")", ob.getconnection())
                Else
                    ssql = "Insert into FINAL_ACCOUNT_OPENING_BALANCE(Company_id,Year_id,Account_Id,Cr_Opening,Dr_Opening) values("
                    ssql = ssql & clsVariables.CompnyId & "," & aq(clsVariables.WorkingYear) & ","
                    ssql = ssql & Val(TxtAccountId.Text) & ","
                    ssql = ssql & Val(TxtCredit.Text) & ","
                    ssql = ssql & Val(TxtDebit.Text)
                    ssql = ssql & ")"
                    ob.Execute(ssql, ob.getconnection)
                    ob.Execute("Delete from Acdata where cid=" & clsVariables.CompnyId & " and Year_id=" & aq(clsVariables.WorkingYear) & " and Acid=" & TxtAccountId.Text & " and Type='Opening'", ob.getconnection())
                    Dim ddate As Date = gFinYearBegin
                    'ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName, Cramt,Remarks,Dramt) Values(1,'" & clsVariables.WorkingYear & "','Opening',1,'" & ob.DateConversion(ddate) & "'," & TxtAccountId.Text & ",'" & TXtAccountName.Text & "'," & Val(TxtDebit.Text) & ",'S@ait n)  bik)'," & Val(TxtCredit.Text) & ")", ob.getconnection())
                    ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt) Values(1,'" & clsVariables.WorkingYear & "','Opening',1,'" & ob.DateConversion(ddate) & "'," & TxtAccountId.Text & ",'" & TXtAccountName.Text & "'," & Val(TxtDebit.Text) & ",'S@ait n)  bik)'," & Val(TxtCredit.Text) & ")", ob.getconnection())

                End If
                ButAdd_Click(e, e)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            butstyle1()
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        Me.Text = Me.Tag & " { Add } "
        butstyle2()
        Cleartxt()
        isadd = True
        TxtAccountId.Focus()
    End Sub

    Private Sub txtmemberid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtAccountId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Account_Id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_name"
            HelpWin.tsql = "Select Account_Id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TxtAccountId.Text = clsVariables.RtnHelpId
                TXtAccountName.Text = clsVariables.RtnHelpName
                LoadMember()
                TxtCredit.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Account_Id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_Id"
            HelpWin.tsql = "Select Account_Id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TxtAccountId.Text = clsVariables.RtnHelpId
                TXtAccountName.Text = clsVariables.RtnHelpName
                LoadMember()
                TxtCredit.Focus()
            End If
        End If
    End Sub

    Private Sub TxtAccountId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAccountId.Validated
        Try
            Dim ssql As String
            If TxtAccountId.Text <> "" Then
                ssql = "Select Account_name from Account_Master where Account_Id= " & Val(TxtAccountId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                ssql = ssql & clsVariables.sDeptID
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    TXtAccountName.Text = dt.Rows(0).Item(0).ToString
                    LoadMember()
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Account Id")
                        TXtAccountName.Text = ""
                        TxtAccountId.Focus()
                    End If
                End If
            Else
                TXtAccountName.Text = ""
                If ButAdd.Enabled = False Then
                    MsgBox("Member Id Doesn't Blank  !")
                    TXtAccountName.Text = ""
                    TxtAccountId.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadMember()
        Try
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Account_Master where Company_Id=" & Val(clsVariables.CompnyId) & " and Account_Id=" & Val(TxtAccountId.Text), ob.getconnection(ob.Getconn))
            If dt.Rows.Count > 0 Then
                TXtAccountName.Text = ob.IfNullThen(dt.Rows(0).Item("Account_name"), "")
                Dim ssql As String
                ssql = "select * from FINAL_ACCOUNT_OPENING_BALANCE "
                ssql = ssql & " where COmpany_id=" & clsVariables.CompnyId
                ssql = ssql & " and Account_id=" & Val(TxtAccountId.Text)
                ssql = ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                Dim dtd As New DataTable
                dtd = ob.Returntable(ssql, ob.getconnection)
                If dtd.Rows.Count > 0 Then
                    TxtCredit.Text = Format(Val(ob.IfNullThen(dtd.Rows(0).Item("Cr_opening"), 0)), g2Dec)
                    TxtDebit.Text = Format(Val(ob.IfNullThen(dtd.Rows(0).Item("Dr_opening"), 0)), g2Dec)
                End If
            End If
            dt.Clear()
            dt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        'FinalAccountOpeningBalanceRep.Tag = "Account Opening Balance Report (Account)"
        'FinalAccountOpeningBalanceRep.Show()
    End Sub
End Class
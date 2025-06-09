Imports WeightPavti.CLS
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports System.Data
Imports System.Data.SqlClient
Public Class RojmalEntry

    Dim Isadd As String
    Dim Ssql As String

    Private Sub ComboDocType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.Enter
        cmbtype.DroppedDown = True
    End Sub

    Private Sub ComboDocType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.GotFocus
        Textactive(sender)
    End Sub

    Private Sub ComboDocType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbtype.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub ComboDocType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbtype.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtDocNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Docno.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtDocNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Docno.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtDocNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Docno.LostFocus
        Textreset(sender)
    End Sub

    Public Sub FillPrinter()
        Try
            Dim pkInstalledPrinters As String
            For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
                cboInstalledPrinters.Items.Add(pkInstalledPrinters)
            Next pkInstalledPrinters
            ' Set the combo to the first printer in the list
            Dim ps As New PrinterSettings()
            cboInstalledPrinters.Text = ps.PrinterName
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub RojMalEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        'Me.MdiParent = MdiMain

        'Me.BackgroundImage = MdiMain.PicTransaction.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
        FillPrinter()
        TxtFill("select Remarks from acdata", Remarks)

        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    ComboDocType.DataSource = ob.Returntable("Select Doc_Type,Doc_name from  Voucher_Master where Doc_Group_Name='Cash' and Department_id=" & Val(MdiMain.ComboDept.SelectedValue), ob.getconnection(ob.Getconn))
        'Else
        '    ComboDocType.DataSource = ob.Returntable("Select Doc_Type,Doc_name from  Voucher_Master where Doc_Group_Name='Cash'", ob.getconnection(ob.Getconn))
        'End If
        'ComboDocType.DisplayMember = "Doc_Name"
        'ComboDocType.ValueMember = "Doc_Type"
        ButAdd_Click(e, e)
        Drac.Tag = 9941
        Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
    End Sub

    Private Sub txtDocDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Textactive(sender)
    End Sub

    Private Sub txtDocDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        'tabkey(sender, e)
    End Sub

    Private Sub txtDocDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Textreset(sender)
    End Sub

    Private Sub txtDocDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        'If ButAdd.Enabled = False Then
        '    ' ob.validdate(sender, Ddate.Text, True)
        'End If
    End Sub

    Private Sub txtBookId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookId.GotFocus, txtPartyId.GotFocus, txtAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtBookId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBookId.KeyPress, txtPartyId.KeyPress, txtAccountId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtBookId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBookId.KeyUp

    End Sub

    Private Sub txtAccountId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Account_Id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Account_name"
            HelpWin.tsql = "Select Account_Id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtAccountId.Text = clsVariables.RtnHelpId
                txtAccountName.Text = clsVariables.RtnHelpName
                LoadAccountBalance()
                txtPartyId.Focus()
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
                txtAccountId.Text = clsVariables.RtnHelpId
                txtAccountName.Text = clsVariables.RtnHelpName
                LoadAccountBalance()
                txtPartyId.Focus()
            End If
        End If
    End Sub

    Private Sub txtBookId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookId.LostFocus, txtPartyId.LostFocus, txtAccountId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtparticulars_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Remarks.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtparticulars_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Remarks.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtparticulars_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Remarks.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Description_Name"
            clsVariables.HelpName = "Description_Name"
            clsVariables.TbName = "Description_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Description_Name"
            HelpWin.tsql = "Select Description_Name,Description_Name as Name from Description_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                Remarks.Text = Trim(Remarks.Text) & " " & clsVariables.RtnHelpId
                If txtReceiptAmt.Visible = True Then
                    txtReceiptAmt.Focus()
                Else
                    Amount.Focus()
                End If
                txtTaxableamt.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Description_Name"
            clsVariables.HelpName = "Description_Name"
            clsVariables.TbName = "Description_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Description_Name"
            HelpWin.tsql = "Select Description_Name,Description_Name  as Name from Description_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                Remarks.Text = Trim(Remarks.Text) & " " & clsVariables.RtnHelpId
                If txtReceiptAmt.Visible = True Then
                    txtReceiptAmt.Focus()
                Else
                    Amount.Focus()
                End If
                txtTaxableamt.Focus()
            End If
        End If
    End Sub

    Private Sub txtparticulars_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Remarks.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtReceiptAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptAmt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtReceiptAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceiptAmt.KeyPress
        tabkey(sender, e)
        Comman.Amount(sender, e)
        'Numeric(sender, e)
    End Sub

    Private Sub txtReceiptAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceiptAmt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtPaymentAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Amount.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtPaymentAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Amount.KeyPress
        tabkey(sender, e)
        'Amount.Text = Format(Val((Val(txtTaxableamt.Text) + Val(txtsgstamt.Text) + Val(txtcgstamt.Text) + Val(txtigstamt.Text))), g3Dec)
        'Amount(sender, e)
        'Numeric(sender, e)
    End Sub

    Private Sub txtPaymentAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Amount.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtPaymentAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Amount.Validating
        If CheckNumeric(sender, e) = True Then
            If Val(Amount.Text) < 0 Then
                MsgBox("Payment Amount Must Be Greater Than Zero...", vbInformation, Application.ProductName)
                Amount.Focus()
            Else
                Amount.Text = Format(Val(Amount.Text), "##0.00")
                ButSave.Focus()
            End If
        End If
    End Sub

    Private Sub txtReceiptAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtReceiptAmt.Validating
        If CheckNumeric(sender, e) = True Then
            If Val(txtReceiptAmt.Text) < 0 Then
                MsgBox("Receipt Amount Must Be Greater Than Zero...", vbInformation, Application.ProductName)
                txtReceiptAmt.Focus()
            Else
                'sender.text = CurrencyFormate(sender, 2, sender.text)
                txtReceiptAmt.Text = Format(Val(txtReceiptAmt.Text), "##0.00")
            End If
        End If
    End Sub

    Public Sub loadBook()
        Try
            txtBookId.Text = ob.FindOneinteger("Select Book_id From Voucher_master where Company_Id=" & clsVariables.CompnyId & " and Doc_Type=" & Val(cmbtype.SelectedValue), ob.getconnection)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub AutoDocno()
        Try
            Docno.Text = ob.FindOneString("select isnull(max(Billno),0)+1 from Acmain where cid=" & Val(clsVariables.CompnyId) & " and ptype='" & Trim(cmbtype.Text) & "' and Year_id='" & clsVariables.WorkingYear & "'", ob.getconnection())
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ComboDocType_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtype.Validating
        If Len(cmbtype.Text) > 0 Then
            If Isadd = True Then
                AutoDocno()
                '  loadBook()
            End If
            loadtxt()
        Else
            MessageBox.Show("Select Doc Type", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbtype.Focus()
        End If
    End Sub

    Private Sub txtBookId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookId.Validated

    End Sub

    Public Sub loadtxt()
        'Try
        '    Ssql = "Select DEfault_Action from Voucher_master where Doc_Type=" & Val(ComboDocType.SelectedValue)
        '    Ssql = Ssql & " and Company_id=" & clsVariables.CompnyId
        '    Dim dt As New DataTable
        '    dt = ob.Returntable(Ssql, ob.getconnection)
        '    If dt.Rows.Count > 0 Then
        '        If ob.IfNullThen(dt.Rows(0).Item("Default_Action"), "") = "Credit" Then
        '            LbRece.Visible = True
        '            txtReceiptAmt.Visible = True
        '            txtPaymentAmt.Visible = False
        '            Lbpay.Visible = False
        '        Else
        '            LbRece.Visible = False
        '            txtReceiptAmt.Visible = False
        '            txtPaymentAmt.Visible = True
        '            Lbpay.Visible = True
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try
    End Sub

    Public Sub LoadBookBalance()
        Try
            txtBookBalance.Text = Format(Val(ob.LoadAccountBalance(Val(ob.FindOneString("Select Account_Id from Book_master where Company_Id=" & clsVariables.CompnyId & " and Book_id=" & Val(txtBookId.Text), ob.getconnection(ob.Getconn))), sFunction.DateConversion(Ddate.Text), ob.getconnection())), "##0.00")
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadAccountBalance()
        Try
            txtAccountBalance.Text = Format(Val(ob.LoadAccountBalance(Val(txtAccountId.Text), sFunction.DateConversion(Ddate.Text), ob.getconnection())), "##0.00")
            txtAccountName.Text = ob.FindOneString("Select Account_name from Account_Master where Company_id=" & clsVariables.CompnyId & " and Account_id=" & Val(txtAccountId.Text), ob.getconnection(ob.Getconn))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtAccountId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.Validated
        Try
            If txtAccountId.Text <> "" Then
                Ssql = "Select Account_Name from Account_Master where Account_Id= " & Val(txtAccountId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                Ssql = Ssql & clsVariables.sDeptID
                Dim dt As New DataTable
                dt = ob.Returntable(Ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtAccountName.Text = dt.Rows(0).Item(0).ToString
                    LoadAccountBalance()
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Account Id")
                        txtAccountName.Text = ""
                        txtAccountId.Focus()
                    End If
                End If
            Else
                txtAccountName.Text = ""
                If ButAdd.Enabled = False Then
                    MsgBox("Account Id Doesn't Blank  !")
                    txtAccountName.Text = ""
                    txtAccountId.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtmemberid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartyId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Member_Id"
            clsVariables.HelpName = "Member_Name"
            clsVariables.TbName = "Member_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Member_Name"
            HelpWin.tsql = "Select Member_Id,Member_Name from Member_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtPartyId.Text = clsVariables.RtnHelpId
                sname.Text = clsVariables.RtnHelpName
                LoadPartyName()
                Remarks.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Member_Id"
            clsVariables.HelpName = "Member_Name"
            clsVariables.TbName = "Member_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Member_Id"
            HelpWin.tsql = "Select Member_Id,Member_Name from Member_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtPartyId.Text = clsVariables.RtnHelpId
                sname.Text = clsVariables.RtnHelpName
                LoadPartyName()
                Remarks.Focus()
            End If
        End If
    End Sub

    Private Sub txtmemberid_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPartyId.Validated
        Try
            Dim ssql As String
            If Val(txtPartyId.Text) <> 0 Then
                ssql = "Select Member_Name from Member_Master where Member_Id= " & Val(txtPartyId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                ssql = ssql & clsVariables.sDeptID
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    sname.Text = dt.Rows(0).Item(0).ToString
                    LoadPartyName()
                    Exit Sub
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Member Id")
                        sname.Text = ""
                        txtPartyId.Focus()
                    End If
                End If
            Else
                sname.Text = ""
                'If ButAdd.Enabled = False Then
                '    MsgBox("Member Id Doesn't Blank  !")
                '    txtpartyname.Text = ""
                '    txtpartyid.Focus()
                '    Exit Sub
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function LoadPartyName() As Boolean
        Try
            Dim rst As New DataTable
            Ssql = "Select * from Member_Master where Company_Id=" & Val(clsVariables.CompnyId)
            Ssql = Ssql & " and Member_Id=" & Val(txtPartyId.Text)
            rst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
            If Len(txtPartyId.Text) > 0 Then
                If rst.Rows.Count > 0 Then
                    txtVillagename.Text = ob.FindOneString("Select Village_name from Village_master where Company_Id=" & clsVariables.CompnyId & " and Village_Id=" & Val(rst.Rows(0).Item("Village_id")), ob.getconnection(ob.Getconn))
                    'Ssql = "SELECT isnull(Balance_Amount,0) FROM  Final_Party_Balance "
                    'Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Member_Id = " & Val(txtPartyId.Text)
                    'Ssql = Ssql & " and Account_id=" & Val(txtAccountId.Text)
                    'Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                    txtPartyBalance.Text = Format(Val(ob.LoadMemberAccountBalance(Val(txtAccountId.Text), Val(txtPartyId.Text), CDate(sFunction.DateConversion(Ddate.Text)), ob.getconnection(ob.Getconn))), g2Dec)
                    sname.Text = ob.IfNullThen(rst.Rows(0).Item("Member_Name"), "")
                    LoadPartyName = False
                Else
                    LoadPartyName = True
                    txtPartyBalance.Clear()
                    txtVillagename.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Private Sub txtDocNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Docno.Validated
        Dim dt As New DataTable
        dt = ob.Returntable("Select * from Acdata where Docno=" & Val(Docno.Text) & " and Type='" & Trim(cmbtype.Text) & "' and year_id='" & clsVariables.WorkingYear & "' and cid=" & Val(clsVariables.CompnyId) & "", ob.getconnection())
        If dt.Rows.Count > 0 Then
            Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
            If result1 = 6 Then
                ButEdit_Click(e, e)
                For i As Integer = 0 To dt.Rows.Count - 1
                    If Trim(cmbtype.Text) = "Cash Receipt" Then
                        If Val(dt.Rows(i).Item("Dramt")) = 0 Then
                            txtAccountName.Tag = dt.Rows(i).Item("Acid")
                            txtAccountName.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())
                            sname.Tag = ob.FindOneString("select PartyId from Acmain where Billtype='" & Trim(cmbtype.Text) & "' and Billno=" & Val(Docno.Text) & "", ob.getconnection())
                            sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
                            Amount.Text = dt.Rows(i).Item("cramt")
                            Remarks.Text = dt.Rows(i).Item("Remarks")
                            Ddate.Text = dt.Rows(i).Item("docdate")
                        Else
                            Drac.Tag = dt.Rows(i).Item("Acid")
                            Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
                            'Dramt.Text = dt.Rows(i).Item("cramt")
                        End If
                    Else
                        If Val(dt.Rows(i).Item("Dramt")) <> 0 Then
                            txtAccountName.Tag = dt.Rows(i).Item("Acid")
                            txtAccountName.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())
                            sname.Tag = ob.FindOneString("select PartyId from Acmain where Billtype='" & Trim(cmbtype.Text) & "' and Billno=" & Val(Docno.Text) & "", ob.getconnection())
                            sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())
                            Amount.Text = dt.Rows(i).Item("dramt")
                            Remarks.Text = dt.Rows(i).Item("Remarks")
                            Ddate.Text = dt.Rows(i).Item("docdate")
                        Else
                            Drac.Tag = dt.Rows(i).Item("Acid")
                            Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
                            'Dramt.Text = dt.Rows(i).Item("cramt")
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        Try
            If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                butstyle1()
                messageright(AccessMode.AddMode)
                Exit Sub
            End If
            Isadd = True
            cleartext()
            butstyle2()
            cmbtype.Focus()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        Try
            If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.ChangeMode)
                butstyle1()
                Exit Sub
            End If
            If Val(Docno.Text) = 0 Or Len(cmbtype.Text) = 0 Then
                MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK)
            Else
                Isadd = False
                butstyle2()
                cmbtype.Enabled = False
                Docno.Enabled = False
                Ddate.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click


        If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())
            ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and Billno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())

            cleartext()
        End If

    End Sub
    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        'filltext(Val(Docno.Text))
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

    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from  Final_Rojmal_Data where company_id=" & Val(clsVariables.CompnyId) & " and YEar_id=" & aq(clsVariables.WorkingYear) & " and Doc_type=" & Val(cmbtype.SelectedValue) & " Order by Company_Id,Year_id,Doc_type,Doc_no"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from  Final_Rojmal_Data "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId) & " and YEar_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " And Doc_no>" & Val(Docno.Text) & " and Doc_type=" & Val(cmbtype.SelectedValue)
                sql = sql & " Order by  Company_Id,Year_id,Doc_type,Doc_no "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from  Final_Rojmal_Data "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId) & " and YEar_id=" & aq(clsVariables.WorkingYear)
                sql = sql & " And Doc_no<" & Val(Docno.Text) & " and Doc_type=" & Val(cmbtype.SelectedValue)
                sql = sql & " Order by  Company_Id,Year_id,Doc_type,Doc_no desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from  Final_Rojmal_Data where company_id=" & Val(clsVariables.CompnyId) & " and YEar_id=" & aq(clsVariables.WorkingYear) & " and Doc_type=" & Val(cmbtype.SelectedValue)
                sql = sql & " Order by  Company_Id,Year_id,Doc_type,Doc_no desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Doc_no"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Sub cleartext()
        Ddate.Text = Format(CDate(Now.Date), "dd/MM/yyyy")
        Docno.Clear()
        txtAccountId.Clear()
        txtAccountName.Clear()
        txtAccountBalance.Clear()
        txtPartyBalance.Clear()
        txtPartyId.Clear()
        sname.Clear()
        Remarks.Clear()
        'txtBookId.Clear()
        'txtBookName.Clear()
        txtBookBalance.Clear()
        txtReceiptAmt.Clear()
        Amount.Clear()
        txtVillagename.Clear()
        txtcgstamt.Clear()
        txtcgstper.Clear()
        txtsgstamt.Clear()
        txtsgstper.Clear()
        txtigstamt.Clear()
        txtigstper.Clear()
        txtTaxableamt.Clear()
        CheckBox1.Checked = False
        cmbtype.Focus()
        TxtFill("select Remarks from acdata", Remarks)

    End Sub
    Public Sub TxtFill(ByVal Sqlstring As String, ByVal txtBox As TextBox)
        Dim sStringColl As New AutoCompleteStringCollection
        Dim qryCity As String
        qryCity = "SELECT DISTINCT NAME FROM ACMASTER  ORDER By NAME"

        Using connection As New SqlConnection(ob.Getconn)

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

    Public Sub butstyle1()
        ButAdd.Enabled = True
        ButEdit.Enabled = True
        ButDelete.Enabled = True
        ButSave.Enabled = False
        ButCAncel.Enabled = False
        ButFind.Enabled = True
        ButFirst.Enabled = True
        ButNExt.Enabled = True
        BUtPrev.Enabled = True
        ButLast.Enabled = True

        Ddate.Enabled = False
        Docno.Enabled = False
        cmbtype.Enabled = False
        txtBookId.Enabled = False
        txtBookName.Enabled = False
        txtBookBalance.Enabled = False
        txtVillagename.Enabled = False
        Remarks.Enabled = False
        txtAccountId.Enabled = False
        txtAccountName.Enabled = False
        txtAccountBalance.Enabled = False
        txtPartyBalance.Enabled = False
        txtPartyId.Enabled = False
        sname.Enabled = False
        txtReceiptAmt.Enabled = False
        Amount.Enabled = False
        txtcgstamt.Enabled = False
        txtcgstper.Enabled = False
        txtsgstamt.Enabled = False
        txtsgstper.Enabled = False
        txtigstamt.Enabled = False
        txtigstper.Enabled = False
        CheckBox1.Enabled = False
        txtTaxableamt.Enabled = False
    End Sub

    Public Sub butstyle2()
        ButAdd.Enabled = False
        ButEdit.Enabled = False
        ButDelete.Enabled = False
        ButSave.Enabled = True
        ButCAncel.Enabled = True
        ButFind.Enabled = False
        ButFirst.Enabled = False
        ButNExt.Enabled = False
        BUtPrev.Enabled = False
        ButLast.Enabled = False

        Ddate.Enabled = True
        Docno.Enabled = True
        cmbtype.Enabled = True
        txtBookId.Enabled = True
        txtBookName.Enabled = True
        txtBookBalance.Enabled = False
        txtVillagename.Enabled = True
        Remarks.Enabled = True
        txtAccountId.Enabled = True
        txtAccountName.Enabled = True
        txtAccountBalance.Enabled = True
        txtPartyBalance.Enabled = True
        txtPartyId.Enabled = True
        sname.Enabled = True
        txtReceiptAmt.Enabled = True
        Amount.Enabled = True
        txtcgstamt.Enabled = True
        txtcgstper.Enabled = True
        txtsgstamt.Enabled = True
        txtsgstper.Enabled = True
        txtigstamt.Enabled = True
        txtigstper.Enabled = True
        CheckBox1.Enabled = True
        txtTaxableamt.Enabled = True
    End Sub

    Public Sub filltext(ByVal Docno As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from  Final_Rojmal_Data where Doc_no=" & Val(Docno) & " and Year_id=" & aq(clsVariables.WorkingYear) & " and Doc_type=" & Val(cmbtype.SelectedValue) & " and Company_id=" & clsVariables.CompnyId, ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                Me.Docno.Text = IIf(IsDBNull(dt.Rows(0).Item("Doc_no")), "", dt.Rows(0).Item("Doc_no"))
                Ddate.Text = Format(CDate(IIf(IsDBNull(dt.Rows(0).Item("Doc_Date")), "", dt.Rows(0).Item("Doc_Date"))), "dd/MM/yyyy")
                Remarks.Text = IIf(IsDBNull(dt.Rows(0).Item("Remarks")), "", dt.Rows(0).Item("Remarks"))
                txtBookId.Text = ob.IfNullThen(dt.Rows(0).Item("Book_id"), "")
                'txtBookName.Text = ob.FindOneString("Select Book_name from Book_master where Company_id=" & clsVariables.CompnyId & " and Book_Id=" & Val(txtBookId.Text) & " and Book_Group_name='CASH'", ob.getconnection(ob.Getconn))
                txtBookName.Text = ob.FindOneString("Select Book_name from Book_master where Company_id=" & clsVariables.CompnyId & " and Book_Id=" & Val(txtBookId.Text), ob.getconnection(ob.Getconn))
                txtAccountId.Text = ob.IfNullThen(dt.Rows(0).Item("Account_Id"), "")
                LoadBookBalance()
                LoadAccountBalance()
                txtPartyId.Text = ob.IfNullThen(dt.Rows(0).Item("Member_Id"), "")
                LoadPartyName()
                txtReceiptAmt.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("Receipt_Amt"), 0)), g2Dec)
                Amount.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("Payment_Amt"), 0)), g2Dec)
                txtcgstamt.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("CGST_Amt"), 0)), g2Dec)
                txtsgstamt.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("SGST_Amt"), 0)), g2Dec)
                txtigstamt.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("IGST_Amt"), 0)), g2Dec)
                txtcgstper.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("CGST_Per"), 0)), g2Dec)
                txtsgstper.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("SGST_Per"), 0)), g2Dec)
                txtigstper.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("IGST_Per"), 0)), g2Dec)
                txtTaxableamt.Text = Format(Val(ob.IfNullThen(dt.Rows(0).Item("Taxable_Amt"), 0)), g2Dec)
                CheckBox1.Checked = IIf(IsDBNull(dt.Rows(0).Item("GSTRCM")), False, dt.Rows(0).Item("GSTRCM"))
                'loadtxt()
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Dim sdate As Date = Ddate.Text
        If (sdate) >= gFinYearBegin And (sdate) <= gFinYearEnd Then


            ob.Execute("Delete from Acdata where year_id='" & clsVariables.WorkingYear & "' and Docno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())
            ob.Execute("Delete from Acmain where year_id='" & clsVariables.WorkingYear & "' and Billno=" & Docno.Text & " and ptype='" & cmbtype.Text & "'", ob.getconnection())

            If Trim(cmbtype.Text) <> "Cash Receipt" Then
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Dramt ,Remarks,Cramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & txtAccountName.Tag & ",N'" & txtAccountName.Text & "'," & Amount.Text & ",N'" & Trim(Remarks.Text) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Cramt,Remarks,Dramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Amount.Text & ",N'" & Trim(Remarks.Text) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                ' If Val(sname.Tag) <> 0 Then
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Paymentamt,ptype,Remarks) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(sname.Tag) & "," & Val(txtAccountName.Tag) & "," & Val(Amount.Text) & ",'" & cmbtype.Text & "',N'" & Remarks.Text & "')", ob.getconnection())

                ' End If
            Else
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate, Acid, ACName,Cramt ,Remarks,Dramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & txtAccountName.Tag & ",N'" & txtAccountName.Text & "'," & Amount.Text & ",N'" & Trim(Remarks.Text) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                ob.Execute("Insert Into Acdata(Cid, Year_id, Type, Docno, Docdate,Acid, ACName, Dramt,Remarks,Cramt,ptype) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "','" & cmbtype.Text & "'," & Docno.Text & ",'" & ob.DateConversion(Ddate.Text) & "'," & Drac.Tag & ",N'" & Drac.Text & "'," & Amount.Text & ",N'" & Trim(Remarks.Text) & "',0,'" & cmbtype.Text & "')", ob.getconnection())
                '  If Val(sname.Tag) <> 0 Then
                ob.Execute("Insert Into Acmain(Cid, Year_id, Department, Billtype, Billno, Billdate, PartyId, Acid,Receiptamt,ptype,Remarks) Values(" & clsVariables.CompnyId & ",'" & clsVariables.WorkingYear & "'," & aq(cmbtype.Text) & "," & aq(cmbtype.Text) & "," & Val(Docno.Text) & ",'" & ob.DateConversion(Ddate.Text) & "'," & Val(sname.Tag) & "," & Val(txtAccountName.Tag) & "," & Val(Amount.Text) & ",'" & cmbtype.Text & "',N'" & Remarks.Text & "')", ob.getconnection())

                'End If
            End If
            MessageBox.Show("Saved")
            cleartext()
        Else
            MsgBox("Date Falls Out Side Current Financial Year ", MsgBoxStyle.Critical, Application.ProductName)
            Ddate.Focus()
        End If
    End Sub

    Public Sub Updateoldbalance()
        Try
            Ssql = "SELECT book_id,Account_id,Member_Id,Receipt_Amt,Payment_Amt FROM "
            Ssql = Ssql & " Final_Rojmal_Data "
            Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId
            Ssql = Ssql & " AND doc_type = " & Val(cmbtype.SelectedValue) & " AND doc_no = " & Val(Docno.Text)
            Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
            Dim rst As New DataTable
            rst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
            If rst.Rows.Count > 0 Then
                'Account
                Ssql = "UPDATE  Final_Account_Balance  SET Debit_Amount = isnull(Debit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0) & ")"
                Ssql = Ssql & ",Credit_Amount = isnull(Credit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0) & ")"
                Ssql = Ssql & ", balance_amount =  balance_amount  - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0) & " - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0) & ")"
                Ssql = Ssql & ") WHERE company_id = " & clsVariables.CompnyId & " and account_id = " & ob.IfNullThen(rst.Rows(0).Item("account_id"), 0)
                Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))

                'Book
                Dim brst As New DataTable
                Ssql = "SELECT account_id From Book_Master WHERE company_id = " & clsVariables.CompnyId & " and Book_id = " & ob.IfNullThen(rst.Rows(0).Item("Book_ID"), 0) & " "
                brst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
                If brst.Rows.Count > 0 Then
                    Ssql = "UPDATE  Final_Account_Balance  SET Debit_Amount = isnull(Debit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0) & ")"
                    Ssql = Ssql & ",Credit_Amount = isnull(credit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0) & ")"
                    Ssql = Ssql & ", balance_amount =  isnull(balance_amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0)
                    Ssql = Ssql & " - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0) & ")"
                    Ssql = Ssql & ") WHERE company_id = " & clsVariables.CompnyId & " and account_id = " & ob.IfNullThen(brst.Rows(0).Item("account_id"), 0)
                    Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                    ob.Execute(Ssql, ob.getconnection(ob.Getconn))
                End If
                brst.Clear()
                brst.Dispose()
                'Party
                Ssql = "Update  Final_Party_Balance  SET Credit_Amount = isnull(Credit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0) & ")"
                Ssql = Ssql & ",Debit_Amount = isnull(Debit_Amount,0) - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0) & ")"
                Ssql = Ssql & ", balance_amount =  isnull(balance_amount,0)  - (" & ob.IfNullThen(rst.Rows(0).Item("payment_amt"), 0)
                Ssql = Ssql & " - (" & ob.IfNullThen(rst.Rows(0).Item("receipt_amt"), 0) & ")"
                Ssql = Ssql & ") WHERE company_id = " & clsVariables.CompnyId & " and Member_Id = " & ob.IfNullThen(rst.Rows(0).Item("Member_Id"), 0)
                Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))
            End If
            rst.Clear()
            rst.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub Updatebalance()
        Try
            Dim rst As New DataTable
            Ssql = "SELECT account_id From  Final_Account_Balance"
            Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Account_id = " & Val(txtAccountId.Text) & " "
            Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
            rst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
            If rst.Rows.Count > 0 Then
                Ssql = "UPDATE  Final_Account_Balance "
                Ssql = Ssql & " SET Credit_Amount = isnull(Credit_Amount,0) + " & Val(txtReceiptAmt.Text)
                Ssql = Ssql & ",Debit_Amount = isnull(Debit_Amount,0) + " & Val(Amount.Text)
                Ssql = Ssql & ", balance_amount =  isnull(balance_amount,0) + " & Val(Amount.Text)
                Ssql = Ssql & "  - " & Val(txtReceiptAmt.Text)
                Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and account_id = " & (txtAccountId.Text) & " "
                Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))
            Else
                Ssql = "INSERT INTO  Final_Account_Balance (Company_id,Account_Id,Credit_Amount,Debit_Amount,Balance_Amount,Year_Id)"
                Ssql = Ssql & " VALUES(" & clsVariables.CompnyId & "," & Val(txtAccountId.Text) & "," & Val(txtReceiptAmt.Text)
                Ssql = Ssql & "," & Val(Amount.Text) & "," & Val(Amount.Text) - Val(txtReceiptAmt.Text)
                Ssql = Ssql & "," & aq(clsVariables.WorkingYear)
                Ssql = Ssql & ")"
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))
            End If
            rst.Clear()
            rst.Dispose()

            'Book
            Dim brst As New DataTable
            Ssql = "SELECT account_id From Book_Master "
            Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Book_id = " & Val(txtBookId.Text) & " "
            brst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
            If brst.Rows.Count > 0 Then
                Ssql = "SELECT account_id From  Final_Account_Balance "
                Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Account_id = " & ob.IfNullThen(brst.Rows(0).Item("account_id"), 0)
                Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                rst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
                If rst.Rows.Count > 0 Then
                    Ssql = "UPDATE  Final_Account_Balance "
                    Ssql = Ssql & " SET Debit_Amount = isnull(Debit_Amount,0) + " & Val(txtReceiptAmt.Text)
                    Ssql = Ssql & ",Credit_Amount = isnull(Credit_Amount,0) + " & Val(Amount.Text)
                    Ssql = Ssql & ", balance_amount =  isnull(balance_amount,0)  +(" & Val(txtReceiptAmt.Text) & " - (" & Val(Amount.Text) & "))"
                    Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and account_id = " & ob.IfNullThen(brst.Rows(0).Item("account_id"), 0) & " "
                    Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                    ob.Execute(Ssql, ob.getconnection(ob.Getconn))
                Else
                    Ssql = "INSERT INTO  Final_Account_Balance(Company_id,Account_Id,Credit_Amount,Debit_Amount,Balance_Amount,Year_id)"
                    Ssql = Ssql & " VALUES(" & clsVariables.CompnyId & "," & ob.IfNullThen(brst.Rows(0).Item("account_id"), 0)
                    Ssql = Ssql & "," & Val(Amount.Text) & "," & Val(txtReceiptAmt.Text)
                    Ssql = Ssql & "," & Val(txtReceiptAmt.Text) - Val(Amount.Text)
                    Ssql = Ssql & "," & aq(clsVariables.WorkingYear)
                    Ssql = Ssql & ")"
                    ob.Execute(Ssql, ob.getconnection(ob.Getconn))
                End If
                rst.Clear()
                rst.Dispose()
            End If
            brst.Clear()
            brst.Dispose()

            'Party
            Ssql = "SELECT Member_Id From  Final_Party_Balance "
            Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Member_Id = " & Val(txtPartyId.Text)
            Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
            rst = ob.Returntable(Ssql, ob.getconnection(ob.Getconn))
            If rst.Rows.Count > 0 Then
                Ssql = "Update  Final_Party_Balance "
                Ssql = Ssql & " SET Credit_Amount = isnull(Credit_Amount,0) + " & Val(txtReceiptAmt.Text)
                Ssql = Ssql & ",Debit_Amount = isnull(Debit_Amount,0) + " & Val(Amount.Text)
                Ssql = Ssql & ", balance_amount =  isnull(balance_amount,0)  + " & Val(Amount.Text) - Val(txtReceiptAmt.Text)
                Ssql = Ssql & " WHERE company_id = " & clsVariables.CompnyId & " and Member_Id = " & Val(txtPartyId.Text)
                Ssql = Ssql & " and Year_id=" & aq(clsVariables.WorkingYear)
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))
            Else
                Ssql = "INSERT INTO  Final_Party_Balance(Company_id,Account_Id,Member_Id,Credit_Amount,Debit_Amount,Balance_Amount,Year_id)"
                Ssql = Ssql & " VALUES(" & clsVariables.CompnyId & "," & Val(txtAccountId.Text) & "," & Val(txtPartyId.Text)
                Ssql = Ssql & "," & Val(txtReceiptAmt.Text) & "," & Val(Amount.Text)
                Ssql = Ssql & " ," & Val(Amount.Text) - Val(txtReceiptAmt.Text)
                Ssql = Ssql & "," & aq(clsVariables.WorkingYear)
                Ssql = Ssql & ")"
                ob.Execute(Ssql, ob.getconnection(ob.Getconn))
            End If
            rst.Clear()
            rst.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub Insertbackup()
        Try
            Dim sqlIcommand As New SqlClient.SqlCommand
            Ssql = "Insert into  Final_Rojmal_Data(Company_id,Year_id,Doc_type,Doc_no,Doc_DAte,Book_Id,Account_Id,Member_Id,Remarks,Receipt_Amt,payment_Amt,"
            Ssql = Ssql & "Add_Date,User_NAme,Edit_User_Name,GSTRCM,Taxable_Amt,CGST_Amt,SGST_Amt,IGST_Amt,CGST_Per,SGST_Per,IGST_Per)values("
            Ssql = Ssql & "@Company_id,@Year_id,@Doc_type,@Doc_no,@Doc_DAte,@Book_Id,@Account_Id,@Member_Id,@Remarks,@receipt_Amt,@payment_Amt,"
            Ssql = Ssql & "@Add_Date,@User_Name,@EditUserName,@GSTRCM,@Taxable_Amt,@CGST_Amt,@SGST_Amt,@IGST_Amt,@CGST_Per,@SGST_Per,@IGST_Per) "
            sqlIcommand.Connection = ob.getconnection(ob.Getconn(BackDbname))
            sqlIcommand.CommandText = Ssql
            sqlIcommand.Parameters.AddWithValue("@Company_Id", Val(clsVariables.CompnyId))
            sqlIcommand.Parameters.AddWithValue("@Year_Id", Trim(clsVariables.WorkingYear))
            sqlIcommand.Parameters.AddWithValue("@Doc_Type", Val(cmbtype.SelectedValue))
            sqlIcommand.Parameters.AddWithValue("@Doc_no", Val(Docno.Text))
            sqlIcommand.Parameters.AddWithValue("@Doc_Date", sFunction.DateConversion(Ddate.Text))
            sqlIcommand.Parameters.AddWithValue("@Book_id", Val(txtBookId.Text))
            sqlIcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
            sqlIcommand.Parameters.AddWithValue("@Member_Id", Val(txtPartyId.Text))
            sqlIcommand.Parameters.AddWithValue("@Remarks", Trim(Remarks.Text))
            sqlIcommand.Parameters.AddWithValue("@Receipt_Amt", Val(txtReceiptAmt.Text))
            sqlIcommand.Parameters.AddWithValue("@payment_Amt", Val(Amount.Text))
            sqlIcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlIcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlIcommand.Parameters.AddWithValue("@EditUserName", New_Entry)
            sqlIcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlIcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlIcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
            sqlIcommand.Parameters.AddWithValue("@GSTRCM", (CheckBox1.Checked.ToString))
            sqlIcommand.Parameters.AddWithValue("@Taxable_Amt", Val(txtTaxableamt.Text))
            sqlIcommand.Parameters.AddWithValue("@CGST_Amt", Val(txtcgstamt.Text))
            sqlIcommand.Parameters.AddWithValue("@SGST_Amt", Val(txtsgstamt.Text))
            sqlIcommand.Parameters.AddWithValue("@IGST_Amt", Val(txtigstamt.Text))
            sqlIcommand.Parameters.AddWithValue("@CGST_Per", Val(txtcgstper.Text))
            sqlIcommand.Parameters.AddWithValue("@SGST_Per", Val(txtsgstper.Text))
            sqlIcommand.Parameters.AddWithValue("@IGST_Per", Val(txtigstper.Text))
            sqlIcommand.ExecuteNonQuery()
            sqlIcommand.Parameters.Clear()
            Ssql = " Company_id=" & clsVariables.CompnyId & " and Year_Id=" & aq(clsVariables.WorkingYear)
            Ssql = Ssql & " and Doc_Type=" & Val(cmbtype.SelectedValue)
            Ssql = Ssql & " and Doc_no=" & Val(Docno.Text)
            ob.UpdateIdmach("Final_Rojmal_Data", Ssql, ob.getconnection(ob.Getconn(BackDbname)))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        Try
            If Val(Docno.Text) = 0 Or Len(cmbtype.Text) = 0 Then
                MessageBox.Show("Nothing To Print", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If MessageBox.Show("Do You Want To Print ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Ssql = "Select * from Final_Rojmal_Data"
                    Ssql = Ssql & " where Company_Id = " & clsVariables.CompnyId
                    Ssql = Ssql & " And Year_Id = " & aq(clsVariables.WorkingYear)
                    Ssql = Ssql & " and Doc_Type=" & Val(cmbtype.SelectedValue)
                    Ssql = Ssql & " and Doc_No = " & Val(Docno.Text)
                    Dim dset As New DataSet
                    dset = ob.ReturnDataset(Ssql, ob.getconnection(), "Final_Rojmal_Data")
                    Dim report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
                    report.Load(clsVariables.RptLocation + "CashReceiptPrinting.rpt", CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
                    Dim crtableLogoninfos As New TableLogOnInfos()
                    Dim crtableLogoninfo As New TableLogOnInfo()
                    Dim crConnectionInfo As New ConnectionInfo()
                    Dim CrTables As Tables
                    Dim CrTable As Table
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
                    report.SetDataSource(dset)
                    report.SetParameterValue("@CompanyName", clsVariables.CompnyName)
                    report.SetParameterValue("@NumtoWord", ob.Num_To_Guj_Word(Math.Abs(Val(txtReceiptAmt.Text) - Val(Amount.Text))))
                    report.PrintOptions.PrinterName = cboInstalledPrinters.Text
                    If Val(txtNoofPrint.Text) = 0 Then
                        report.PrintToPrinter(1, False, 0, 0)
                    Else
                        report.PrintToPrinter(Val(txtNoofPrint.Text), False, 0, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtcgstamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgstamt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtcgstper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgstper.GotFocus
        txtcgstamt.Text = Format(Val((Val(txtTaxableamt.Text) * Val(txtcgstper.Text)) / 100), g3Dec)
        Textactive(sender)
    End Sub

    Private Sub txtcgstamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcgstamt.KeyPress
        'txtGST.Text = Format(Val(txtAmount.Text) + Val(txtcgstamt.Text), g3Dec)
        tabkey(sender, e)
    End Sub

    Private Sub txtcgstamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgstamt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtcgstper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcgstper.KeyPress
        txtcgstamt.Text = Format(Val((Val(txtTaxableamt.Text) * Val(txtcgstper.Text)) / 100), g3Dec)
        tabkey(sender, e)
    End Sub

    Private Sub txtcgstper_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgstper.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtigstamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigstamt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtigstamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtigstamt.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtigstamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigstamt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtigstper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigstper.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtigstper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtigstper.KeyPress
        txtigstamt.Text = Format(Val((Val(txtTaxableamt.Text) * Val(txtigstper.Text)) / 100), g3Dec)
        tabkey(sender, e)
    End Sub

    Private Sub txtigstper_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigstper.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtsgstamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgstamt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtsgstamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsgstamt.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtsgstamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgstamt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtsgstper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgstper.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtsgstper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsgstper.KeyPress
        txtsgstamt.Text = Format(Val((Val(txtTaxableamt.Text) * Val(txtsgstper.Text)) / 100), g3Dec)
        tabkey(sender, e)
    End Sub

    Private Sub txtsgstper_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgstper.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtTaxableamt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxableamt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtTaxableamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTaxableamt.KeyPress
        tabkey(sender, e)
        Comman.Amount(sender, e)
    End Sub

    Private Sub txtTaxableamt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxableamt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
    End Sub

    Private Sub txtAccountName_Validated(sender As Object, e As EventArgs) Handles txtAccountName.Validated
        If txtAccountName.Text <> "" Then
            txtAccountName.Tag = ob.FindOneString("Select Account_id From Account_Master Where Account_Name=N'" & Trim(txtAccountName.Text) & "' or Account_id=" & Val(txtAccountName.Text) & "", ob.getconnection())
            If Val(txtAccountName.Tag) <> 0 Then
                txtAccountName.Text = ob.FindOneString("Select Account_Name From Account_Master Where  Account_id=" & Val(txtAccountName.Tag) & "", ob.getconnection())

                ' chaln()
            Else
                If Val(txtAccountName.Tag) = 0 Then
                    clsVariables.HelpId = "Account_id"
                    clsVariables.HelpName = "Account_Name"
                    clsVariables.TbName = "Account_Master"
                    HelpWin.scodename = "Name"
                    HelpWin.sorderby = " order by Account_Name"
                    HelpWin.tsql = "Select Account_id,Account_Name from Account_Master where Account_Name Like N'" & Trim(txtAccountName.Text) & "%'"
                    HelpWin.ShowDialog()
                    If clsVariables.RtnHelpId <> "" Then
                        txtAccountName.Tag = clsVariables.RtnHelpId
                        txtAccountName.Text = clsVariables.RtnHelpName

                    End If
                End If
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
        Drac.Tag = 9941
        Drac.Text = ob.FindOneString("select Account_name from Account_Master where Account_id=" & Val(Drac.Tag) & "", ob.getconnection())
        'InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(0)

    End Sub

    Private Sub sname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sname.Validating
        If sname.Text <> "" Then
            sname.Tag = ob.FindOneString("Select Member_Id From Member_Master Where Member_Name=N'" & Trim(sname.Text) & "' or Member_Id=" & Val(sname.Text) & "", ob.getconnection())
            If Val(sname.Tag) <> 0 Then
                sname.Text = ob.FindOneString("Select Member_Name From Member_Master Where  Member_Id=" & Val(sname.Tag) & "", ob.getconnection())

                ' chaln()
            Else
                If Val(sname.Tag) = 0 Then
                    clsVariables.HelpId = "Member_id"
                    clsVariables.HelpName = "Member_Name"
                    clsVariables.TbName = "Member_Master"
                    HelpWin.scodename = "Name"
                    HelpWin.sorderby = " order by Member_Name"
                    HelpWin.tsql = "Select Member_Id,Member_Name from Member_Master where  Member_name Like N'" & Trim(sname.Text) & "%'"
                    HelpWin.ShowDialog()
                    If clsVariables.RtnHelpId <> "" Then
                        sname.Tag = clsVariables.RtnHelpId
                        sname.Text = clsVariables.RtnHelpName

                    End If
                End If
            End If
            ' adharno.Text = ob.FindOneString("Select Vat_No From Member_Master Where Member_Id=" & Val(Cname.Tag) & "", ob.getconnection())

        End If
    End Sub

    Private Sub txtAccountName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccountName.KeyPress, sname.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtAccountName_Enter(sender As Object, e As EventArgs) Handles txtAccountName.Enter
        'InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(2)

    End Sub

    Private Sub Ddate_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Ddate_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Ddate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Ddate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Ddate.Validating
        ob.validdate(sender, Ddate.Text, True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clsVariables.Findqueri = "select docno,docdate,ACid,Acname,Remarks,dramt,cramt from acdata where  acid<>9941 and ptype='" & cmbtype.Text & "' and year_id='" & clsVariables.WorkingYear & "' order by docno"
        clsVariables.findtablename = "Acmain"
        FrmFind.ShowDialog()
        Docno.Text = clsVariables.HelpId
        txtDocNo_Validated(Nothing, Nothing)
        'filldata(Val(Billno.Text))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class
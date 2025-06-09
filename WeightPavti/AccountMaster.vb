Imports WeightPavti.CLS

Public Class AccountMaster

    Dim Isadd, fn As Boolean
    Dim ssql As String
    Dim ds As New DataSet
    Dim sDeptID As String
    'Dim ob As New AdoFunc

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
        txtAccountId.Enabled = False
        txtAccoutName.Enabled = False
        DgDoc_Column.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        txtEngName.Enabled = False
        txtAddres.Enabled = False
        txtGroupId.Enabled = False
        txtGroupName.Enabled = False
        txtExpenceId.Enabled = False
        txtGstNo.Enabled = False
        txtCStno.Enabled = False
        txtpanno.Enabled = False
        CmbBookAccount.Enabled = False
        txttGroupId.Enabled = False
        txtTGroupName.Enabled = False
        TXtdepartmentId.Enabled = False
        txtDepartmentName.Enabled = False
        chkGstExpr.Enabled = False
        loadg()
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
        txtAccountId.Enabled = True
        txtAccoutName.Enabled = True
        DgDoc_Column.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        txtEngName.Enabled = True
        txtAddres.Enabled = True
        txtGroupId.Enabled = True
        txtGroupName.Enabled = True
        txtExpenceId.Enabled = True
        txtGstNo.Enabled = True
        txtCStno.Enabled = True
        txtpanno.Enabled = True
        CmbBookAccount.Enabled = True
        txttGroupId.Enabled = True
        txtTGroupName.Enabled = True
        chkGstExpr.Enabled = True
        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    TXtdepartmentId.Enabled = True
        '    txtDepartmentName.Enabled = True
        'Else
        '    TXtdepartmentId.Enabled = True
        '    txtDepartmentName.Enabled = True
        'End If
    End Sub

    Private Sub txtCompId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub

    Private Sub txtCompId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtCompId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub

    Private Sub txtCStno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCStno.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtCStno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCStno.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtpanno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpanno.GotFocus
        Textreset(sender)
    End Sub

    Private Sub txtpanno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpanno.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub AccountGroupMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, txtEngName.KeyUp, txtExpenceId.KeyUp, txtAccountId.KeyUp, txtAccoutName.KeyUp, txtAddres.KeyUp, txtCStno.KeyUp, txtGstNo.KeyUp, txtpanno.KeyUp, BuExit.KeyUp, ButAdd.KeyUp, ButCAncel.KeyUp, ButDelete.KeyUp, ButEdit.KeyUp, ButFind.KeyUp, ButFirst.KeyUp, ButLast.KeyUp, ButNExt.KeyUp, BUtPrev.KeyUp, ButSave.KeyUp, ButPrint.KeyUp, txttGroupId.KeyUp, txtTGroupName.KeyUp
        If e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub

    Private Sub AccountGroupMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        'Me.BackgroundImage = MdiMain.PicMaster.Image
        DgDoc_Column.DefaultCellStyle.ForeColor = Color.Black
        cmbSearchby.SelectedIndex = 0
        CmbBookAccount.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        loadg()
        DgDoc_Column.Columns(0).HeaderText = "Id"
        DgDoc_Column.Columns(0).Width = 60
        DgDoc_Column.Columns(1).Width = 250
        DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Bold)
        DgDoc_Column.Columns(2).Width = 150
    End Sub

    Public Function DocNo_AutoID(ByVal Account_Id As String, ByVal sTable As String) As Integer
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select max(" & Account_Id & ")+1 as Account_Id from  Account_Master where Company_Id=" & Val(clsVariables.CompnyId)
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Account_Id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtAccountId.Text = DocNo_AutoID
            Return DocNo_AutoID
        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtAccountId.Text = DocNo_AutoID
        End Try
    End Function

    Public Sub cleartext()
        txtAccountId.Text = ""
        txtAccoutName.Text = ""
        txtEngName.Clear()
        txtAddres.Clear()
        CmbBookAccount.SelectedIndex = 0
        txtGroupId.Clear()
        txtGroupName.Clear()
        txtExpenceId.Clear()
        txtGstNo.Clear()
        txtCStno.Clear()
        txtpanno.Clear()
        txttGroupId.Clear()
        txtTGroupName.Clear()
        chkGstExpr.Checked = False
        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    TXtdepartmentId.Text = MdiMain.ComboDept.SelectedValue
        '    txtDepartmentName.Text = MdiMain.ComboDept.Text
        'Else
        '    TXtdepartmentId.Clear()
        '    txtDepartmentName.Clear()
        'End If
    End Sub

    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        'Dim a As Integer
        'a = ObjAcces.CheckAddRights("Column Master")
        'If a = True Then
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            butstyle1()
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        butstyle2()
        cleartext()
        Isadd = True
        Call DocNo_AutoID("Account_Id", "Account_Master")
        txtAccoutName.Focus()
        'Else
        'butstyle1()
        'End If
    End Sub

    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Column.Rows.Count > 0 Then
                i = DgDoc_Column.CurrentRow.Index
                txtAccountId.Text = DgDoc_Column.Rows(i).Cells(0).Value.ToString()
                txtAccoutName.Text = DgDoc_Column.Rows(i).Cells(1).Value.ToString()
                filltext(Val(clsVariables.CompnyId), Val(txtAccountId.Text))
            End If
            'Butstyle1()
            'PanelEntry.Enabled = False
            'btnEdit.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        'Dim a As Integer
        'a = ObjAcces.CheckEditRights("Column Master")
        'If a = True Then
        If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.ChangeMode)
            butstyle1()
            Exit Sub
        End If
        If Len(txtAccountId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            txtAccountId.Enabled = False
            txtAccoutName.Focus()
        End If
        'Else
        'butstyle1()
        'End If
    End Sub

    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & clsVariables.sDeptID
                sql = sql & " Order by Company_Id,Account_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Account_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Account_Id>" & Val(txtAccountId.Text)
                sql = sql & clsVariables.sDeptID
                sql = sql & " Order by Company_Id ,Account_Id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Account_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Account_Id<" & Val(txtAccountId.Text)
                sql = sql & clsVariables.sDeptID
                sql = sql & " Order by Company_Id desc,Account_Id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & clsVariables.sDeptID
                sql = sql & " Order by Company_Id desc,Account_Id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Account_Id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Sub loadg()
        ssql = "Select Account_Id,Account_Name ,Eng_Account_Name as 'English Name' from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
        ssql = ssql & clsVariables.sDeptID
        ssql = ssql & "  order by Company_Id,Account_Id"
        DgDoc_Column.DataSource = ob.Returntable(ssql, ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
    End Sub

    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            ssql = "Select * from Account_Master where Company_id=" & Val(Comp_id) & " and Account_Id=" & Val(vill_id) & ""
            ssql = ssql & clsVariables.sDeptID
            dt = ob.Returntable(ssql, ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtAccountId.Text = IIf(IsDBNull(dt.Rows(0).Item("Account_Id")), "", dt.Rows(0).Item("Account_Id"))
                txtAccoutName.Text = IIf(IsDBNull(dt.Rows(0).Item("Account_Name")), "", dt.Rows(0).Item("Account_Name"))
                txtEngName.Text = IIf(IsDBNull(dt.Rows(0).Item("Eng_Account_Name")), "", dt.Rows(0).Item("Eng_Account_Name"))
                txtAddres.Text = IIf(IsDBNull(dt.Rows(0).Item("address")), "", dt.Rows(0).Item("Address"))
                txtGroupId.Text = IIf(IsDBNull(dt.Rows(0).Item("Group_id")), "", dt.Rows(0).Item("Group_id"))
                txtGroupName.Text = ob.FindOneString("Select Group_name from Account_Group_Master where Group_id=" & Val(txtGroupId.Text) & " and Company_id=" & clsVariables.CompnyId, ob.getconnection(ob.Getconn()))
                txtExpenceId.Text = IIf(IsDBNull(dt.Rows(0).Item("Expense_Group_id")), "", dt.Rows(0).Item("Expense_Group_id"))
                txtGstNo.Text = IIf(IsDBNull(dt.Rows(0).Item("TIn_Gst_no")), "", dt.Rows(0).Item("Tin_Gst_No"))
                txtCStno.Text = IIf(IsDBNull(dt.Rows(0).Item("TIn_cst_no")), "", dt.Rows(0).Item("Tin_Cst_No"))
                txtpanno.Text = IIf(IsDBNull(dt.Rows(0).Item("Pan_no")), "", dt.Rows(0).Item("Pan_No"))
                CmbBookAccount.Text = IIf(IsDBNull(dt.Rows(0).Item("Book_Account")), "", dt.Rows(0).Item("Book_Account"))
                txttGroupId.Text = IIf(IsDBNull(dt.Rows(0).Item("Trading_Group_id")), "", dt.Rows(0).Item("Trading_Group_id"))
                txtTGroupName.Text = ob.FindOneString("Select Group_name from Account_Group_Master where Group_id=" & Val(txttGroupId.Text) & " and Company_id=" & clsVariables.CompnyId, ob.getconnection(ob.Getconn()))
                TXtdepartmentId.Text = ob.IfNullThen(dt.Rows(0).Item("Department_id"), 0)
                ' txtDepartmentName.Text = ob.FindOneString("Select Department_name from Department_Master where Department_id=" & Val(TXtdepartmentId.Text) & " and Company_id=" & clsVariables.CompnyId, ob.getconnection(ob.Getconn()))
                chkGstExpr.Checked = IIf(IsDBNull(dt.Rows(0).Item("GST_Expence")), False, dt.Rows(0).Item("GST_Expence"))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            'If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            '    messageright(AccessMode.DeleteMode)
            '    butstyle1()
            '    Exit Sub
            'End If
            'Dim a As Integer
            'a = ObjAcces.CheckDeleteRights("Column Master")
            'If a = True Then
           
            If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ob.Execute("Delete from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Account_Id=" & Val(txtAccountId.Text), ob.getconnection(ob.Getconn()))
                ' ob.UpdateEditUser("Account_Master", "Company_id=" & Val(clsVariables.CompnyId) & " and Account_Id=" & Val(txtAccountId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                'MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
                If Entry_Move("next") = False Then
                    If Entry_Move("prev") = False Then
                        cleartext()
                    End If
                End If
                loadg()
            End If

            'Else
            'butstyle1()
            'End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        filltext(Val(clsVariables.CompnyId), Val(txtAccountId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        txtAccountId.Focus()
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
            If Val(txtAccountId.Text) = 0 Then
                MessageBox.Show("Please Enter Account Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAccountId.Focus()
                Exit Sub
            ElseIf Len(txtAccoutName.Text) = 0 Then
                MessageBox.Show("Please Enter Accoun Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAccoutName.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Account_Id=" & Val(txtAccountId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Account Id=" & (txtAccountId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtAccountId.Focus()
                        GoTo p
                    End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Insert into Account_Master (Company_id,Account_Id,Account_Name,Eng_Account_Name,Address,Group_id,Expense_Group_id,"
                    sql = sql & "Tin_GST_No,Tin_CST_NO,Pan_no,Book_Account,Trading_group_id,"
                    sql = sql & "Add_Date,User_NAme,Edit_DAte,Edit_User_Name,Department_id,GST_Expence)values"
                    sql = sql & " (@Company_Id,@Account_Id,@Account_Name,@Eng_Account_Name,@Address,@Group_id,@Expense_Group_Id,"
                    sql = sql & "@TIn_Gst_No,@Tin_CSt_no,@Pan_no,@Book_Account,@Trading_group_id,"
                    sql = sql & "@Add_Date,@User_Name,"
                    sql = sql & " @EditDate,@EditUserName," & Val(TXtdepartmentId.Text) & ",@GST_Expence)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
                    sqlcommand.Parameters.AddWithValue("@Account_Name", Trim(txtAccoutName.Text))
                    sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
                    sqlcommand.Parameters.AddWithValue("@Group_id", Val(txtGroupId.Text))
                    sqlcommand.Parameters.AddWithValue("@Tin_Gst_no", Trim(txtGstNo.Text))
                    sqlcommand.Parameters.AddWithValue("@Tin_Cst_no", Trim(txtCStno.Text))
                    sqlcommand.Parameters.AddWithValue("@Pan_no", Trim(txtpanno.Text))
                    sqlcommand.Parameters.AddWithValue("@Book_Account", Trim(CmbBookAccount.Text))
                    sqlcommand.Parameters.AddWithValue("@Trading_group_id", Val(txtGroupId.Text))
                    sqlcommand.Parameters.AddWithValue("@Expense_Group_id", Val(txtExpenceId.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Account_Name", Trim(txtEngName.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@GST_Expence", chkGstExpr.Checked.ToString)
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Account_Id=" & Val(txtAccountId.Text)
                    ob.UpdateIdmach("Account_Master", ssql, ob.getconnection, Isadd)
                    'insert()
                    loadg()
                Else
                    'ob.UpdateEditUser("Account_Master", "Company_Id=" & clsVariables.CompnyId & " and Account_Id=" & Val(txtAccountId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Update Account_Master SET Account_Name=@Account_Name,Eng_Account_Name=@Eng_Account_Name,Trading_group_id=@Trading_group_id,"
                    sql = sql & " Address=@Address,Group_id=@Group_id,Expense_Group_id=@Expense_Group_id,TIn_Gst_no=@TIn_gst_no,"
                    sql = sql & " TIn_Cst_no=@TIn_Cst_no,Pan_no=@Pan_no,Book_Account=@Book_Account,"
                    sql = sql & " Edit_User_Name=@Edit_User_Name,Edit_Date=@Edit_Date,Revision=isnull(revision,0)+1,GST_Expence = @GST_Expence,"
                    sql = sql & "Department_id=" & Val(TXtdepartmentId.Text)
                    sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Account_Id=" & txtAccountId.Text & ""
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Account_Name", Trim(txtAccoutName.Text))
                    sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
                    sqlcommand.Parameters.AddWithValue("@Group_id", Val(txtGroupId.Text))
                    sqlcommand.Parameters.AddWithValue("@Tin_Gst_no", Trim(txtGstNo.Text))
                    sqlcommand.Parameters.AddWithValue("@Tin_Cst_no", Trim(txtCStno.Text))
                    sqlcommand.Parameters.AddWithValue("@Pan_no", Trim(txtpanno.Text))
                    sqlcommand.Parameters.AddWithValue("@Book_Account", Trim(CmbBookAccount.Text))
                    sqlcommand.Parameters.AddWithValue("@Trading_group_id", Val(txtGroupId.Text))
                    sqlcommand.Parameters.AddWithValue("@Expense_Group_id", Val(txtExpenceId.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Account_Name", Trim(txtEngName.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@GST_Expence", chkGstExpr.Checked.ToString)
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Account_Id=" & Val(txtAccountId.Text)
                    ob.UpdateIdmach("Account_Master", ssql, ob.getconnection, Isadd)
                    'insert()
                    loadg()
                End If
                ButAdd_Click(e, e)
            End If
p:
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Public Sub insert()
        Try
            Dim sql As String
            Dim sqlcommand As New SqlClient.SqlCommand
            sqlcommand.Connection = ob.getconnection(ob.Getconn(BackDbname))
            sql = "Insert into Account_Master (Company_id,Account_Id,Account_Name,Eng_Account_Name,Address,Group_id,Expense_Group_id,"
            sql = sql & "Tin_GST_No,Tin_CST_NO,Pan_no,Book_Account,Trading_group_id,"
            sql = sql & "Add_Date,User_NAme,Edit_DAte,Edit_User_Name,Department_id,ip_Address,Mach_Name,GST_Expence)values"
            sql = sql & " (@Company_Id,@Account_Id,@Account_Name,@Eng_Account_Name,@Address,@Group_id,@Expense_Group_Id,"
            sql = sql & "@TIn_Gst_No,@Tin_CSt_no,@Pan_no,@Book_Account,@Trading_group_id,"
            sql = sql & "@Add_Date,@User_Name,"
            sql = sql & " @EditDate,@EditUserName," & Val(TXtdepartmentId.Text) & "," & aq(IPAddress) & "," & aq(MachineName) & ",@GST_Expence)"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
            sqlcommand.Parameters.AddWithValue("@Account_Name", Trim(txtAccoutName.Text))
            sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
            sqlcommand.Parameters.AddWithValue("@Group_id", Val(txtGroupId.Text))
            sqlcommand.Parameters.AddWithValue("@Tin_Gst_no", Trim(txtGstNo.Text))
            sqlcommand.Parameters.AddWithValue("@Tin_Cst_no", Trim(txtCStno.Text))
            sqlcommand.Parameters.AddWithValue("@Pan_no", Trim(txtpanno.Text))
            sqlcommand.Parameters.AddWithValue("@Book_Account", Trim(CmbBookAccount.Text))
            sqlcommand.Parameters.AddWithValue("@Trading_group_id", Val(txttGroupId.Text))
            sqlcommand.Parameters.AddWithValue("@Expense_Group_id", Val(txtExpenceId.Text))
            sqlcommand.Parameters.AddWithValue("@Eng_Account_Name", Trim(txtEngName.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@GST_Expence", chkGstExpr.Checked.ToString)
            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountId.TextChanged
    End Sub

    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccoutName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccoutName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccoutName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccoutName.TextChanged
    End Sub

    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.Validated
        'If fn = True Then
        Dim dt As New DataTable
        If ButAdd.Enabled = False Then
            ssql = "Select * from Account_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Account_Id=" & Val(txtAccountId.Text) & ""
            ssql = ssql & clsVariables.sDeptID
            dt = ob.Returntable(ssql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Account_Id"))
                'MessageBox.Show("Entry Is Found", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'butstyle1()
                Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
                If result1 = 6 Then
                    ButEdit_Click(e, e)
                Else
                    ButAdd_Click(e, e)
                End If
            Else
                'MessageBox.Show("Entry Is Not Found", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'cleartext()
                'butstyle1()
            End If
        End If
        'fn = False
        'End If
    End Sub

    Private Sub txtsearch_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsearch.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtsearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsearch.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtsearch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsearch.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            Dim searchby As String
            Dim ssql As String
            ssql = ""
            searchby = ""
            searchby = cmbSearchby.SelectedItem.ToString
            If txtsearch.Text <> "" Then
                If searchby = "Account Id" Then
                    searchby = "Account_Id"
                    ssql = "Select Account_Id,Account_Name ,Eng_Account_Name as 'English Name' from Account_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                    ssql = ssql & clsVariables.sDeptID
                ElseIf searchby = "Account Name" Then
                    searchby = "Account_Name"
                    ssql = "Select Account_Id,Account_Name ,Eng_Account_Name as 'English Name'  from Account_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
                    ssql = ssql & clsVariables.sDeptID
                End If
                Dim ds As New DataSet
                objconnec.GetConnection()
                objDataTrns.OpenCn()
                ds = objDataTrns.fillgrid(ssql)
                DgDoc_Column.DataSource = ds.Tables(0)
                LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
                objDataTrns.CloseCn()
            Else
                txtsearch.Focus()
                loadg()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DgDoc_Column_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgDoc_Column.RowHeaderMouseClick
        RowDisplay()
    End Sub

    Private Sub DgDoc_Column_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Column.CellClick
        RowDisplay()
    End Sub

    Private Sub DgDoc_Column_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDoc_Column.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            RowDisplay()
        End If
    End Sub

    Private Sub DgDoc_Column_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Column.CellContentClick
    End Sub

    Private Sub cmbSearchby_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchby.Validated
        If cmbSearchby.Text = "Account Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)
        Else
            txtsearch.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        End If
    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged
    End Sub

    Private Sub CmbFinalReportType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub

    Private Sub CmbFinalReportType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        tabkey(sender, e)
    End Sub

    Private Sub CmbFinalReportType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub

    Private Sub CmbFinalReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub txtEngName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEngName.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtEngName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEngName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtEngName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEngName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtEngName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEngName.TextChanged
    End Sub

    Private Sub txtAddres_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddres.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtAddres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddres.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtAddres_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAddres.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtAddres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAddres.TextChanged
    End Sub

    Private Sub txtGroupId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtGroupId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGroupId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtGroupId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGroupId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Group_id"
            clsVariables.HelpName = "Group_Name"
            clsVariables.TbName = "Account_Group_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Group_Name"
            HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where  Company_id=" & Val(clsVariables.CompnyId)
            'HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where Status='true' and Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtGroupId.Text = clsVariables.RtnHelpId
                txtGroupName.Text = clsVariables.RtnHelpName
                txtExpenceId.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Group_id"
            clsVariables.HelpName = "Group_Name"
            clsVariables.TbName = "Account_Group_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Group_id"
            HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where  Company_id=" & Val(clsVariables.CompnyId)
            'HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where Status='true' and Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtGroupId.Text = clsVariables.RtnHelpId
                txtGroupName.Text = clsVariables.RtnHelpName
                txtExpenceId.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub

    Private Sub txtGroupId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtGroupId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroupId.TextChanged
    End Sub

    Private Sub txtGroupId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupId.Validated
        Try
            If Val(txtGroupId.Text) <> 0 Then
                ssql = "Select Group_Name from Account_Group_Master where  Group_id= " & Val(txtGroupId.Text) & " and Company_Id=" & clsVariables.CompnyId
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtGroupName.Text = dt.Rows(0).Item(0).ToString
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Group Id")
                        txtGroupName.Text = ""
                        txtGroupId.Focus()
                    End If
                End If
            Else
                txtGroupName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtExpenceId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpenceId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtExpenceId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExpenceId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtExpenceId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpenceId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtExpenceId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpenceId.TextChanged
    End Sub

    Private Sub txtGstNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGstNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtGstNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGstNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtGstNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGstNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtGstNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGstNo.TextChanged
    End Sub

    Private Sub cmbLoanOverDue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBookAccount.GotFocus
        Textactive(sender)
    End Sub

    Private Sub cmbLoanOverDue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbBookAccount.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub cmbLoanOverDue_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBookAccount.LostFocus
        Textreset(sender)
    End Sub

    Private Sub cmbLoanOverDue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBookAccount.SelectedIndexChanged
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try
            clsVariables.ReportName = "RptAccountMaster.rpt"
            clsVariables.ReportSql = "{Account_Master.Company_id}=" & clsVariables.CompnyId
            clsVariables.RptTable = "Account_Master"
            clsVariables.Repheader = "Account Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txttGroupId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttGroupId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txttGroupId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttGroupId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txttGroupId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txttGroupId.KeyUp
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Group_id"
            clsVariables.HelpName = "Group_Name"
            clsVariables.TbName = "Account_Group_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Group_Name"
            HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where  Company_id=" & Val(clsVariables.CompnyId)
            'HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where Status='true' and Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txttGroupId.Text = clsVariables.RtnHelpId
                txtTGroupName.Text = clsVariables.RtnHelpName
                ButSave.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Group_id"
            clsVariables.HelpName = "Group_Name"
            clsVariables.TbName = "Account_Group_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Group_id"
            HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where  Company_id=" & Val(clsVariables.CompnyId)
            'HelpWin.tsql = "Select Group_Id,Group_Name from Account_Group_Master where Status='true' and Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txttGroupId.Text = clsVariables.RtnHelpId
                txtTGroupName.Text = clsVariables.RtnHelpName
                ButSave.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub

    Private Sub txttGroupId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttGroupId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txttGroupId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttGroupId.TextChanged
    End Sub

    Private Sub txttGroupId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttGroupId.Validated
        Try
            If Val(txttGroupId.Text) <> 0 Then
                ssql = "Select Group_Name from Account_Group_Master where  Group_id= " & Val(txttGroupId.Text) & " and Company_Id=" & clsVariables.CompnyId
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtTGroupName.Text = dt.Rows(0).Item(0).ToString
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Trading Group Id")
                        txtTGroupName.Text = ""
                        txttGroupId.Focus()
                    End If
                End If
            Else
                txtTGroupName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtCStno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCStno.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtCStno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCStno.TextChanged
    End Sub

    Private Sub txtpanno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpanno.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtpanno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpanno.TextChanged
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
                ButSave.Focus()
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
                ButSave.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub

    Private Sub TXtdepartmentId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtdepartmentId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtdepartmentId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtdepartmentId.Validated
        Try
            If Val(TXtdepartmentId.Text) <> 0 Then
                ssql = "Select Department_Name from Department_Master where Department_id= " & Val(TXtdepartmentId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                ssql = ssql & clsVariables.sDeptID
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtDepartmentName.Text = dt.Rows(0).Item(0).ToString
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Department Id")
                        txtDepartmentName.Text = ""
                        TXtdepartmentId.Focus()
                    End If
                End If
            Else
                TXtdepartmentId.Text = ""
                txtDepartmentName.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
Imports WeightPavti.CLS
Public Class Columnmaster
    Dim Isadd, fn As Boolean
    Dim ssql As String
    Dim ds As New DataSet
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

        txtColumnId.Enabled = False
        txtColumnName.Enabled = False
        ComboStatus.Enabled = False
        DgDoc_Column.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        txtlimit.Enabled = False
        ComboDept.Enabled = False
        txtAccountId.Enabled = False
        txtAccountName.Enabled = False

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
        txtColumnId.Enabled = True
        txtColumnName.Enabled = True
        ComboStatus.Enabled = True
        DgDoc_Column.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        txtlimit.Enabled = True
        ComboDept.Enabled = True
        txtAccountId.Enabled = True
        txtAccountName.Enabled = True
    End Sub

    Private Sub ComboDept_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboDept.GotFocus
        Textactive(sender)
    End Sub

    Private Sub ComboDept_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboDept.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub Columnmaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        sdepartment = ""
    End Sub

    Private Sub ColumnMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, txtlimit.KeyUp, ButPrint.KeyUp, ComboDept.KeyUp, txtAccountId.KeyUp
        If e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub

    Private Sub ColumnMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        Me.BackgroundImage = MdiMain.PicMaster.Image
        cmbSearchby.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        ComboDept.Text = UCase(sdepartment)
        loadg()
        'Column_Id, Column_name, Limit, Status, Department_name, Account_Id, Account_Name 
        '0          1            2      3       4                5           6
        DgDoc_Column.Columns(0).HeaderText = "Id"
        DgDoc_Column.Columns(0).Width = 50
        DgDoc_Column.Columns(1).Width = 200
        DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        DgDoc_Column.Columns(2).Width = 70
        DgDoc_Column.Columns(2).HeaderText = "Limit"
        DgDoc_Column.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DgDoc_Column.Columns(3).Width = 50
        DgDoc_Column.Columns(3).HeaderText = "Status"
        DgDoc_Column.Columns(3).Visible = False
        DgDoc_Column.Columns(4).Width = 100
        DgDoc_Column.Columns(4).HeaderText = "Department"
        DgDoc_Column.Columns(5).Width = 50
        DgDoc_Column.Columns(5).HeaderText = "Acct. Id"
        DgDoc_Column.Columns(6).Width = 200
        DgDoc_Column.Columns(6).HeaderText = "Account Name"
        DgDoc_Column.Columns(6).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
    End Sub

    Private Sub ComboStatus_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStatus.Enter
        ComboStatus.DroppedDown = True
    End Sub

    Private Sub ComboStatus_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStatus.GotFocus
        Textactive(sender)
    End Sub

    Private Sub ComboStatus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboStatus.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub ComboStatus_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStatus.LostFocus
        Textreset(sender)
    End Sub

    Private Sub ComboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboStatus.SelectedIndexChanged

    End Sub
    Public Function DocNo_AutoID(ByVal Column_id As String, ByVal sTable As String) As Integer
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select max(" & Column_id & ")+1 as Column_id from  Column_Master where Company_Id=" & Val(clsVariables.CompnyId)
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Column_id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtColumnId.Text = DocNo_AutoID
            Return DocNo_AutoID

        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtColumnId.Text = DocNo_AutoID
        End Try
    End Function
    Public Sub cleartext()
        txtColumnId.Text = ""
        txtColumnName.Text = ""
        ComboStatus.Text = "YES"
        txtlimit.Clear()
        txtAccountId.Clear()
        txtAccountName.Clear()
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
        Call DocNo_AutoID("Column_id", "Column_Master")
        txtColumnName.Focus()
        'Else
        'butstyle1()
        'End If
    End Sub
    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Column.Rows.Count > 0 Then
                i = DgDoc_Column.CurrentRow.Index
                txtColumnId.Text = DgDoc_Column.Rows(i).Cells(0).Value.ToString()
                txtColumnName.Text = DgDoc_Column.Rows(i).Cells(1).Value.ToString()

                ComboStatus.Text = DgDoc_Column.Rows(i).Cells(3).Value.ToString()
                txtlimit.Text = DgDoc_Column.Rows(i).Cells(2).Value.ToString()
                filltext(clsVariables.CompnyId, Val(txtColumnId.Text))
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
        If Len(txtColumnId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            txtColumnId.Enabled = False
            txtColumnName.Focus()
        End If
        'Else
        'butstyle1()
        'End If

    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Column_Master where Company_id=" & Val(clsVariables.CompnyId) & " Order by Company_Id,Column_id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Column_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Column_id>" & Val(txtColumnId.Text)
                sql = sql & " Order by Company_Id ,Column_id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Column_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Column_id<" & Val(txtColumnId.Text)
                sql = sql & " Order by Company_Id desc,Column_id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Column_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " Order by Company_Id desc,Column_id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Column_id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub loadg()
        DgDoc_Column.DataSource = ob.Returntable("Select Column_Id,Column_name ,Limit,(CASE WHEN isnull(a.Status, '0') = '0' THEN 'NO' ELSE 'YES' END) as Status,Department_name as 'Department Name',a.Account_Id,Account_Name from Column_Master as a left outer join  Account_Master as b on  a.Company_id = b.Company_id and a.Account_Id = b.Account_Id where   a.Company_id=" & Val(clsVariables.CompnyId) & " order by a.Company_Id,Column_id", ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
    End Sub
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Column_Master where Company_id=" & Val(Comp_id) & " and Column_id=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtColumnId.Text = IIf(IsDBNull(dt.Rows(0).Item("Column_id")), "", dt.Rows(0).Item("Column_id"))
                txtColumnName.Text = IIf(IsDBNull(dt.Rows(0).Item("Column_name")), "", dt.Rows(0).Item("Column_Name"))
                txtlimit.Text = IIf(IsDBNull(dt.Rows(0).Item("limit")), "", dt.Rows(0).Item("limit"))
                If ((IIf(IsDBNull(dt.Rows(0).Item("Status")), False, dt.Rows(0).Item("Status")))) = True Then
                    ComboStatus.SelectedIndex = 0
                Else
                    ComboStatus.SelectedIndex = 1
                End If
                ComboDept.Text = ob.IfNullThen(dt.Rows(0).Item("Department_name"), "")
                txtAccountId.Text = IIf(IsDBNull(dt.Rows(0).Item("Account_Id")), "", dt.Rows(0).Item("Account_Id"))
                txtAccountName.Text = ob.FindOneString("Select Account_name from Account_Master where Company_id=" & clsVariables.CompnyId & " and Account_id=" & Val(txtAccountId.Text), ob.getconnection(ob.Getconn))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            'Dim a As Integer
            'a = ObjAcces.CheckDeleteRights("Column Master")
            'If a = True Then
            If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.DeleteMode)
                butstyle1()
                Exit Sub
            End If
            If Len(txtColumnId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If ob.CheckColumnMaster(Val(txtColumnId.Text), ob.getconnection) = True Then
                    MessageBox.Show("Entry can't be Deleted Because Effectd Another Data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from Column_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Column_Id=" & Val(txtColumnId.Text), ob.getconnection(ob.Getconn()))
                    ob.UpdateEditUser("Column_Master", "Company_Id=" & clsVariables.CompnyId & " and Column_Id=" & aq(txtColumnId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
                    MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
                    If Entry_Move("next") = False Then
                        If Entry_Move("prev") = False Then
                            cleartext()
                        End If
                    End If
                    loadg()
                End If
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
        filltext(Val(clsVariables.CompnyId), Val(txtColumnId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        txtColumnId.Focus()
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
            If Val(txtColumnId.Text) = 0 Then
                MessageBox.Show("Please Enter Column Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtColumnId.Focus()
                Exit Sub
            ElseIf Len(txtColumnName.Text) = 0 Then
                MessageBox.Show("Please Enter Column Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtColumnName.Focus()
            ElseIf Len(ComboStatus.Text) = 0 Then
                MessageBox.Show("Select Status", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ComboStatus.Focus()
            ElseIf Val(txtAccountId.Text) = 0 Then
                MessageBox.Show("Please Enter Account Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtColumnId.Focus()
                Exit Sub
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Column_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Column_id=" & Val(txtColumnId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Column Id=" & Val(txtColumnId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtColumnId.Focus()
                        GoTo p
                    End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Insert into Column_Master (Company_id,Column_Id,Column_Name,limit,"
                    sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name,department_name,Account_Id)values"
                    sql = sql & " (@Company_Id,@Column_Id,@Column_Name,@limit,@Status,@Add_Date,@User_Name,"
                    sql = sql & " @EditDate,@EditUserName,@Department_name,@Account_Id)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    sqlcommand.Parameters.AddWithValue("@Column_id", Trim(txtColumnId.Text))
                    sqlcommand.Parameters.AddWithValue("@Column_Name", Trim(txtColumnName.Text))
                    sqlcommand.Parameters.AddWithValue("@limit", Val(txtlimit.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Department_name", ComboDept.Text)
                    sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Column_id=" & Val(txtColumnId.Text)
                    ob.UpdateIdmach("Column_Master", ssql, ob.getconnection, Isadd)
                    ' insert()
                    'insert()
                    loadg()
                    ''''''MessageBox.Show("Entry Is Saved Successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'If MessageBox.Show("Do You Want To Add Onther Entry..?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                    'ButAdd_Click(e, e)
                    'GoTo p
                    'End If
                Else
                    'Dim result1 As DialogResult = MessageBox.Show("Do You Want to Edit?", "Important Question", MessageBoxButtons.YesNo)
                    'If result1 = 6 Then
                    'ob.UpdateEditUser("Column_Master", "Company_Id=" & clsVariables.CompnyId & " and Column_Id=" & aq(txtColumnId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Update Column_Master SET Column_Name=@Column_Name,limit=@limit,Department_name=@Department_name,"
                    sql = sql & " Edit_User_Name=@Edit_User_Name,Edit_Date=@Edit_Date,Edit_Dta_time=@Edit_Dta_time,Revision=isnull(revision,0)+1,Status=@Status,"
                    sql = sql & " Account_Id = @Account_Id Where Company_Id=" & clsVariables.CompnyId & " and Column_Id=" & txtColumnId.Text & ""
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Column_Name", Trim(txtColumnName.Text))
                    sqlcommand.Parameters.AddWithValue("@limit", Val(txtlimit.Text))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Edit_Dta_time", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Department_name", ComboDept.Text)
                    sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Column_id=" & Val(txtColumnId.Text)
                    'ob.UpdateIdmach("Column_Master", ssql, ob.getconnection, Isadd)
                    'insert()
                    '   insert()
                    loadg()
                    MessageBox.Show("Entry Is Update Successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'End If
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
            sql = "Insert into Column_Master (Company_id,Column_Id,Column_Name,limit,"
            sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name,department_name,Account_Id,ip_Address,Mach_Name)values"
            sql = sql & " (@Company_Id,@Column_Id,@Column_Name,@limit,@Status,@Add_Date,@User_Name,"
            sql = sql & " @EditDate,@EditUserName,@Department_name,@Account_Id," & aq(IPAddress) & "," & Val(MachineName) & ")"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Column_id", Trim(txtColumnId.Text))
            sqlcommand.Parameters.AddWithValue("@Column_Name", Trim(txtColumnName.Text))
            sqlcommand.Parameters.AddWithValue("@limit", Val(txtlimit.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
            sqlcommand.Parameters.AddWithValue("@Department_name", ComboDept.Text)
            sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtAccountId.Text))
            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColumnId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColumnId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColumnId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColumnName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtColumnName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColumnName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtColumnName.TextChanged

    End Sub

    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtColumnId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Column_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Column_Id=" & Val(txtColumnId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Column_id"))
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
                If searchby = "Column Id" Then
                    searchby = "Column_id"
                    ssql = "Select Column_Id,Column_name ,Limit,(case when isnull(Status,'0')='0' then 'NO' else 'YES' end) as Status,Department_name as 'Department Name',Account_Id from Column_Master where Department_name=" & aq(UCase(sdepartment)) & " and Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                ElseIf searchby = "Column Name" Then
                    searchby = "Column_Name"
                    ssql = "Select Column_Id,Column_name ,Limit,(case when isnull(Status,'0')='0' then 'NO' else 'YES' end) as Status,Department_name as 'Department Name',Account_Id from Column_Master where Department_name=" & aq(UCase(sdepartment)) & " and Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
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

    Private Sub cmbSearchby_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchby.Validated
        If cmbSearchby.Text = "Column Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)
        Else
            txtsearch.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtlimit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlimit.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtlimit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlimit.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub txtlimit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtlimit.LostFocus
        Textreset(sender)
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try

            clsVariables.ReportName = "RptColumnMaster.rpt"
            clsVariables.ReportSql = "{Column_Master.Company_Id}=" & Val(clsVariables.CompnyId)
            clsVariables.RptTable = "Column_Master"
            clsVariables.Repheader = "Column Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ComboDept_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboDept.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtAccountId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtAccountId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
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
                ButSave.Focus()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Account_Id"
            clsVariables.HelpName = "Account_name"
            clsVariables.TbName = "Account_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Account_Id"
            HelpWin.tsql = "Select Account_Id,Account_name from Account_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtAccountId.Text = clsVariables.RtnHelpId
                txtAccountName.Text = clsVariables.RtnHelpName
                ButSave.Focus()
            End If
        End If
    End Sub
    Private Sub txtAccountId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountId.Validated
        Try
            If txtAccountId.Text <> "" Then
                ssql = "Select Account_Name from Account_Master where Account_Id= " & Val(txtAccountId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtAccountName.Text = dt.Rows(0).Item(0).ToString
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

End Class
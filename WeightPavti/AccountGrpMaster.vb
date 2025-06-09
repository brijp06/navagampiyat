Imports WeightPavti.CLS

Public Class AccountGrpMaster

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

        txtAccountgroupId.Enabled = False
        txtAccoutGroupName.Enabled = False
        ComboStatus.Enabled = False
        DgDoc_Column.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        CmbFinalReportType.Enabled = False
        txtEngName.Enabled = False
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
        txtAccountgroupId.Enabled = True
        txtAccoutGroupName.Enabled = True
        ComboStatus.Enabled = True
        DgDoc_Column.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        CmbFinalReportType.Enabled = True
        txtEngName.Enabled = True
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

    Private Sub txtCompId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub AccountGroupMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, ButPrint.KeyUp
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
        CmbFinalReportType.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        loadg()
        DgDoc_Column.Columns(0).HeaderText = "Id"
        DgDoc_Column.Columns(0).Width = 50
        DgDoc_Column.Columns(1).Width = 200
        DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Bold)
        DgDoc_Column.Columns(2).Width = 100
        'DgDoc_Column.Columns(3).Width = 50
        DgDoc_Column.Columns(4).Visible = False
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

    Public Function DocNo_AutoID(ByVal Group_id As String, ByVal sTable As String) As Integer
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select max(" & Group_id & ")+1 as Group_id from  Account_Group_Master where Company_Id=" & Val(clsVariables.CompnyId)
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Group_id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtAccountgroupId.Text = DocNo_AutoID
            Return DocNo_AutoID
        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtAccountgroupId.Text = DocNo_AutoID
        End Try
    End Function

    Public Sub cleartext()
        txtAccountgroupId.Text = ""
        txtAccoutGroupName.Text = ""
        ComboStatus.Text = "YES"
        txtEngName.Clear()
        CmbFinalReportType.SelectedIndex = 0
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
        Call DocNo_AutoID("Group_id", "Account_Group_Master")
        txtAccoutGroupName.Focus()
        'Else
        'butstyle1()
        'End If
    End Sub

    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Column.Rows.Count > 0 Then
                i = DgDoc_Column.CurrentRow.Index
                txtAccountgroupId.Text = DgDoc_Column.Rows(i).Cells(0).Value.ToString()
                txtAccoutGroupName.Text = DgDoc_Column.Rows(i).Cells(1).Value.ToString()
                CmbFinalReportType.Text = DgDoc_Column.Rows(i).Cells(2).Value.ToString()
                txtEngName.Text = DgDoc_Column.Rows(i).Cells(3).Value.ToString()
                ComboStatus.Text = DgDoc_Column.Rows(i).Cells(4).Value.ToString()
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
        If Len(txtAccountgroupId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            txtAccountgroupId.Enabled = False
            txtAccoutGroupName.Focus()
        End If
        'Else
        'butstyle1()
        'End If
    End Sub

    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId) & " Order by Company_Id,Group_id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Account_Group_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Group_id>" & Val(txtAccountgroupId.Text)
                sql = sql & " Order by Company_Id ,Group_id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Account_Group_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Group_id<" & Val(txtAccountgroupId.Text)
                sql = sql & " Order by Company_Id desc,Group_id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " Order by Company_Id desc,Group_id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Group_id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function

    Public Sub loadg()
        DgDoc_Column.DataSource = ob.Returntable("Select Group_id,Group_Name ,final_report_type as 'Final Report Type',Eng_Group_name as 'English Name',(CASE WHEN isnull(Status, '0') = '0' THEN 'NO' ELSE 'YES' END) as Status from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId) & " order by Company_Id,Group_id", ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
    End Sub

    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Account_Group_Master where Company_id=" & Val(Comp_id) & " and Group_id=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtAccountgroupId.Text = IIf(IsDBNull(dt.Rows(0).Item("Group_id")), "", dt.Rows(0).Item("Group_id"))
                txtAccoutGroupName.Text = IIf(IsDBNull(dt.Rows(0).Item("Group_Name")), "", dt.Rows(0).Item("Group_Name"))
                txtEngName.Text = IIf(IsDBNull(dt.Rows(0).Item("Eng_Group_Name")), "", dt.Rows(0).Item("Eng_Group_Name"))
                CmbFinalReportType.Text = IIf(IsDBNull(dt.Rows(0).Item("Final_report_Type")), "", dt.Rows(0).Item("Final_report_Type"))
                If ((IIf(IsDBNull(dt.Rows(0).Item("Status")), False, dt.Rows(0).Item("Status")))) = True Then
                    ComboStatus.SelectedIndex = 0
                Else
                    ComboStatus.SelectedIndex = 1
                End If
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
            
            If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ob.Execute("Delete from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Group_id=" & Val(txtAccountgroupId.Text), ob.getconnection(ob.Getconn()))
                ' ob.UpdateEditUser("Account_Group_Master", "Company_id=" & Val(clsVariables.CompnyId) & " and Group_id=" & Val(txtAccountgroupId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
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
        filltext(Val(clsVariables.CompnyId), Val(txtAccountgroupId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        txtAccountgroupId.Focus()
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
            If Val(txtAccountgroupId.Text) = 0 Then
                MessageBox.Show("Please Enter Account Group Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAccountgroupId.Focus()
                Exit Sub
            ElseIf Len(txtAccoutGroupName.Text) = 0 Then
                MessageBox.Show("Please Enter Accoun Group Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtAccoutGroupName.Focus()
            ElseIf Len(ComboStatus.Text) = 0 Then
                MessageBox.Show("Select Status", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ComboStatus.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Group_id=" & Val(txtAccountgroupId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Account Group Id=" & Val(txtAccountgroupId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtAccountgroupId.Focus()
                        GoTo p
                    End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Insert into Account_Group_Master (Company_id,Group_id,Group_Name,Final_Report_Type,Eng_Group_name,"
                    sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name)values"
                    sql = sql & " (@Company_Id,@Group_id,@Group_Name,@Final_Report_Type,@Eng_Group_name,@Status,@Add_Date,@User_Name,"
                    sql = sql & " @EditDate,@EditUserName)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    sqlcommand.Parameters.AddWithValue("@Group_id", Trim(txtAccountgroupId.Text))
                    sqlcommand.Parameters.AddWithValue("@Group_Name", Trim(txtAccoutGroupName.Text))
                    sqlcommand.Parameters.AddWithValue("@Final_Report_Type", Trim(CmbFinalReportType.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Group_name", Trim(txtEngName.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Group_id=" & Val(txtAccountgroupId.Text)
                    ob.UpdateIdmach("Account_Group_Master", ssql, ob.getconnection, Isadd)
                    ' insert()
                    loadg()
                Else
                    '  ob.UpdateEditUser("Account_Group_Master", "Company_id=" & Val(clsVariables.CompnyId) & " and Group_id=" & Val(txtAccountgroupId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Update Account_Group_Master SET Group_Name=@Group_Name,Final_report_type=@Final_Report_Type,Eng_Group_name=@Eng_Group_name,"
                    sql = sql & " Edit_User_Name=@Edit_User_Name,Edit_Date=@Edit_Date,Edit_Dta_time=@Edit_Dta_time,Revision=isnull(revision,0)+1,Status=@Status"
                    sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Group_id=" & txtAccountgroupId.Text & ""
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Group_Name", Trim(txtAccoutGroupName.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Group_name", Trim(txtEngName.Text))
                    sqlcommand.Parameters.AddWithValue("@Final_Report_Type", Trim(CmbFinalReportType.Text))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Edit_Dta_time", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and Group_id=" & Val(txtAccountgroupId.Text)
                    ob.UpdateIdmach("Account_Group_Master", ssql, ob.getconnection, Isadd)
                    ' insert()
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
            sql = "Insert into Account_Group_Master (Company_id,Group_id,Group_Name,Final_Report_Type,Eng_Group_name,"
            sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name)values"
            sql = sql & " (@Company_Id,@Group_id,@Group_Name,@Final_Report_Type,@Eng_Group_name,@Status,@Add_Date,@User_Name,"
            sql = sql & " @EditDate,@EditUserName)"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Group_id", Trim(txtAccountgroupId.Text))
            sqlcommand.Parameters.AddWithValue("@Group_Name", Trim(txtAccoutGroupName.Text))
            sqlcommand.Parameters.AddWithValue("@Final_Report_Type", Trim(CmbFinalReportType.Text))
            sqlcommand.Parameters.AddWithValue("@Eng_Group_name", Trim(txtEngName.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountgroupId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccountgroupId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountgroupId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccountgroupId.TextChanged
    End Sub

    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccoutGroupName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccoutGroupName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccoutGroupName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccoutGroupName.TextChanged
    End Sub

    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccountgroupId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Account_Group_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Group_id=" & Val(txtAccountgroupId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Group_id"))
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
                If searchby = "Account Group Id" Then
                    searchby = "Group_id"
                    ssql = "Select Group_id,Group_Name ,final_report_type as 'Final Report Type',Eng_Group_name as 'English Name',(case when isnull(Status,'0')='0' then 'NO' else 'YES' end) as Status from Account_Group_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                ElseIf searchby = "Account Group Name" Then
                    searchby = "Group_Name"
                    ssql = "Select Group_id,Group_Name ,final_report_type as 'Final Report Type',Eng_Group_name as 'English Name',(case when isnull(Status,'0')='0' then 'NO' else 'YES' end) as Status  from Account_Group_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
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
        If cmbSearchby.Text = "Account Group Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)
        Else
            txtsearch.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        End If
    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged
    End Sub

    Private Sub CmbFinalReportType_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbFinalReportType.GotFocus
        Textactive(sender)
    End Sub

    Private Sub CmbFinalReportType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbFinalReportType.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub CmbFinalReportType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbFinalReportType.LostFocus
        Textreset(sender)
    End Sub

    Private Sub CmbFinalReportType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFinalReportType.SelectedIndexChanged
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

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try
            clsVariables.ReportName = "RptAccountGroupMaster.rpt"
            clsVariables.ReportSql = "{Account_group_Master.Company_id}=" & Val(clsVariables.CompnyId)
            clsVariables.RptTable = "Account_group_Master"
            clsVariables.Repheader = "Account Group Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception
        End Try
    End Sub
End Class
Imports WeightPavti.CLS
Public Class VillageMst
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
        txttalukaName.Enabled = False
        txtDistrictName.Enabled = False
        txtVillageId.Enabled = False
        txtVillagename.Enabled = False
        ComboStatus.Enabled = False
        DgDoc_Village.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        TXtVibhagId.Enabled = False
        TxtVibhagName.Enabled = False
        TxtEngName.Enabled = False
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
        txtDistrictName.Enabled = True
        txttalukaName.Enabled = True
        txtVillageId.Enabled = True
        txtVillagename.Enabled = True
        ComboStatus.Enabled = True
        DgDoc_Village.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        TXtVibhagId.Enabled = True
        TxtVibhagName.Enabled = True
        TxtEngName.Enabled = True
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

    Private Sub VillageMst_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, ButPrint.KeyUp
        If e.KeyCode = Keys.F3 Then
            DgDoc_Village.Focus()
        End If
    End Sub

    Private Sub VillageMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        'Me.BackgroundImage = MdiMain.PicMaster.Image
        cmbSearchby.SelectedIndex = 0
        ComboStatus.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        DgDoc_Village.DefaultCellStyle.ForeColor = Color.Black
        DgDoc_Village.Columns(0).HeaderText = "Id"
        DgDoc_Village.Columns(0).Width = 70
        DgDoc_Village.Columns(1).Width = 120
        DgDoc_Village.Columns(1).HeaderText = "Name"
        DgDoc_Village.Columns(1).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        DgDoc_Village.Columns(3).HeaderText = "Taluka Name"
        DgDoc_Village.Columns(3).Width = 120
        DgDoc_Village.Columns(3).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        DgDoc_Village.Columns(2).HeaderText = "Vibhag Name"
        DgDoc_Village.Columns(2).Width = 120
        DgDoc_Village.Columns(2).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        DgDoc_Village.Columns(4).HeaderText = "District Name"
        DgDoc_Village.Columns(4).Width = 120
        DgDoc_Village.Columns(4).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        DgDoc_Village.Columns(5).Width = 50
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
    Public Function DocNo_AutoID(ByVal Village_id As String, ByVal sTable As String) As Integer
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select max(" & Village_id & ")+1 as Village_id from  Village_Master where Company_Id=" & Val(clsVariables.CompnyId)
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Village_id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtVillageId.Text = DocNo_AutoID
            Return DocNo_AutoID


        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtVillageId.Text = DocNo_AutoID
        End Try
    End Function
    Public Sub cleartext()
        txtDistrictName.Text = ""
        txttalukaName.Text = ""
        txtVillageId.Text = ""
        txtVillagename.Text = ""
        TXtVibhagId.Clear()
        TxtVibhagName.Clear()
        ComboStatus.Text = "YES"
        TxtEngName.Clear()
        loadg()
    End Sub
    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        'Dim a As Integer
        'a = ObjAcces.CheckAddRights("Village Master")
        'If a = True Then
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            butstyle1()
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        butstyle2()
        cleartext()
        Isadd = True
        Call DocNo_AutoID("Village_id", "Village_Master")
        txtVillagename.Focus()
        'Else
        'butstyle1()
        'End If
    End Sub
    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Village.Rows.Count > 0 Then
                i = DgDoc_Village.CurrentRow.Index
                txtVillageId.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Village_id"), 0)
                txtVillagename.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Village_Name"), "")
                txttalukaName.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Taluka_Name"), "")
                txtDistrictName.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("District_Name"), "")
                ComboStatus.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Status"), "NO")
                TXtVibhagId.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Vibhag_Id"), 0)
                TxtVibhagName.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Vibhag_Name"), "")
                TxtEngName.Text = ob.IfNullThen(DgDoc_Village.Rows(i).DataBoundItem("Eng_Village_name"), "")
            End If
            'Butstyle1()
            'PanelEntry.Enabled = False
            'btnEdit.Enabled = True
        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        'Dim a As Integer
        'a = ObjAcces.CheckEditRights("Village Master")
        'If a = True Then
        If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.ChangeMode)
            butstyle1()
            Exit Sub
        End If
        If Len(txtVillageId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            txtVillageId.Enabled = False
            txtVillagename.Focus()
        End If
        'Else
        'butstyle1()
        'End If

    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Village_Master where Company_id=" & Val(clsVariables.CompnyId) & " Order by Company_Id,Village_id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Village_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Village_id>" & Val(txtVillageId.Text)
                sql = sql & " Order by Company_Id ,Village_id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Village_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Village_id<" & Val(txtVillageId.Text)
                sql = sql & " Order by Company_Id desc,Village_id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Village_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " Order by Company_Id desc,Village_id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Village_id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub loadg()
        DgDoc_Village.DataSource = ob.Returntable("Select Vm.Village_Id,Vm.Village_name ,VBM.Vibhag_Name,Vm.Taluka_name ,Vm.District_Name , (CASE WHEN isnull(Vm.Status, '0') = '0' THEN 'NO' ELSE 'YES' END) as Status,Vm.VIbhag_id,vm.Eng_Village_name from Village_Master as Vm Left Outer join Vibhag_master as VBM on Vm.Company_id=Vbm.Company_id and Vm.Vibhag_Id=VBm.Vibhag_id where Vm.Company_id=" & Val(clsVariables.CompnyId) & " order by Vm.Company_Id,Vm.Village_id", ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Village.Rows.Count)

    End Sub
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Village_Master where Company_id=" & Val(Comp_id) & " and Village_id=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtVillageId.Text = IIf(IsDBNull(dt.Rows(0).Item("Village_id")), "", dt.Rows(0).Item("Village_id"))

                txtVillagename.Text = IIf(IsDBNull(dt.Rows(0).Item("Village_name")), "", dt.Rows(0).Item("Village_Name"))

                If ((IIf(IsDBNull(dt.Rows(0).Item("Status")), False, dt.Rows(0).Item("Status")))) = True Then
                    ComboStatus.SelectedIndex = 0
                Else
                    ComboStatus.SelectedIndex = 1
                End If
                txttalukaName.Text = IIf(IsDBNull(dt.Rows(0).Item("Taluka_name")), "", dt.Rows(0).Item("Taluka_name"))
                txtDistrictName.Text = IIf(IsDBNull(dt.Rows(0).Item("District_Name")), "", dt.Rows(0).Item("District_Name"))
                TXtVibhagId.Text = ob.IfNullThen(dt.Rows(0).Item("Vibhag_id"), 0)
                TxtEngName.Text = ob.IfNullThen(dt.Rows(0).Item("Eng_Village_name"), "")
                TxtVibhagName.Text = ob.FindOneString("Select Vibhag_Name From Vibhag_master where Company_id=" & clsVariables.CompnyId & " and Vibhag_id=" & Val(TXtVibhagId.Text), ob.getconnection)
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            'Dim a As Integer
            'a = ObjAcces.CheckDeleteRights("Village Master")
            'If a = True Then
            If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.DeleteMode)
                butstyle1()
                Exit Sub
            End If
            If Len(txtVillageId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If ob.CheckVillageMaster(Val(txtVillageId.Text), ob.getconnection) = True Then
                    MessageBox.Show("Entry Can't Be Deleted Because Effected by Another Data", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from Village_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Village_Id=" & Val(txtVillageId.Text), ob.getconnection(ob.Getconn()))
                    ' ob.UpdateEditUser("Village_Master", "Company_Id=" & clsVariables.CompnyId & " and Village_Id=" & Val(txtVillageId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
                    'MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
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
        filltext(Val(clsVariables.CompnyId), Val(txtVillageId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        txtVillageId.Focus()
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
        TXtVibhagId.Text = 0
        Try
            If Val(txtVillageId.Text) = 0 Then
                MessageBox.Show("Please Enter Village Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtVillageId.Focus()
                Exit Sub
            ElseIf Len(txtVillagename.Text) = 0 Then
                MessageBox.Show("Please Enter Village Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtVillagename.Focus()
            ElseIf Len(ComboStatus.Text) = 0 Then
                MessageBox.Show("Select Status", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ComboStatus.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Village_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Village_id=" & Val(txtVillageId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Village Id=" & Val(txtVillageId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtVillageId.Focus()
                        GoTo p
                    End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    'sql = "Insert into Village_Master (Company_id,Village_Id,Village_Name,Taluka_name,District_Name,Status,)values (@Company_Id,@Village_Id,@Village_Name,@Taluka_Name,@District_Name,@User_Name,@Add_Date,@EditUserName,@EditDate)"
                    sql = "Insert into Village_Master (Company_id,Village_Id,Village_Name,Taluka_name,District_Name,"
                    sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name,Vibhag_Id,Eng_Village_name)values"
                    sql = sql & " (@Company_Id,@Village_Id,@Village_Name,@Taluka_Name,@District_Name,@Status,@Add_Date,@User_Name,"
                    sql = sql & " @EditDate,@EditUserName,@Vibhag_Id,@Eng_Village_name)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    sqlcommand.Parameters.AddWithValue("@Village_id", Trim(txtVillageId.Text))
                    sqlcommand.Parameters.AddWithValue("@Village_Name", Trim(txtVillagename.Text))
                    sqlcommand.Parameters.AddWithValue("@Taluka_Name", Trim(txttalukaName.Text))
                    sqlcommand.Parameters.AddWithValue("@District_Name", Trim(txtDistrictName.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@EditUserName", New_Entry)
                    sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Vibhag_id", Val(TXtVibhagId.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Village_name", (TxtEngName.Text))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    sql = " Company_Id=" & clsVariables.CompnyId
                    sql = sql & " and Village_id=" & Val(txtVillageId.Text)
                    ob.UpdateIdmach("Village_Master", sql, ob.getconnection, Isadd)
                    ' insert()
                    loadg()
                    MessageBox.Show("Entry Is Saved Successfully", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ob.UpdateEditUser("Village_Master", "Company_Id=" & clsVariables.CompnyId & " and Village_Id=" & Val(txtVillageId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    sql = "Update Village_Master SET Village_Name=@Village_Name,Taluka_Name=@Taluka_Name,District_Name=@District_Name,"
                    sql = sql & " Edit_User_Name=@Edit_User_Name,Edit_Date=@Edit_Date,Edit_Dta_time=@Edit_Dta_time,Revision=isnull(revision,0)+1,Status=@Status,Vibhag_id=@Vibhag_Id,Eng_Village_name=@Eng_Village_name"
                    sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Village_Id=" & txtVillageId.Text & ""
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Village_Name", Trim(txtVillagename.Text))
                    sqlcommand.Parameters.AddWithValue("@Taluka_Name", Trim(txttalukaName.Text))
                    sqlcommand.Parameters.AddWithValue("@District_Name", Trim(txtDistrictName.Text))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    sqlcommand.Parameters.AddWithValue("@Edit_Dta_time", Now.ToShortTimeString)
                    sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Vibhag_id", Val(TXtVibhagId.Text))
                    sqlcommand.Parameters.AddWithValue("@Eng_Village_name", (TxtEngName.Text))
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    sql = " Company_Id=" & clsVariables.CompnyId
                    sql = sql & " and Village_id=" & Val(txtVillageId.Text)
                    ob.UpdateIdmach("Village_Master", sql, ob.getconnection, Isadd)
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
            sql = "Insert into Village_Master (Company_id,Village_Id,Village_Name,Taluka_name,District_Name,"
            sql = sql & "Status,Add_Date,User_NAme,Edit_DAte,Edit_User_Name,Vibhag_Id,Eng_Village_name,ip_Address,Mach_Name)values"
            sql = sql & " (@Company_Id,@Village_Id,@Village_Name,@Taluka_Name,@District_Name,@Status,@Add_Date,@User_Name,"
            sql = sql & " @EditDate,@EditUserName,@Vibhag_Id,@Eng_Village_name," & aq(IPAddress) & "," & aq(MachineName) & ")"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Village_id", Trim(txtVillageId.Text))
            sqlcommand.Parameters.AddWithValue("@Village_Name", Trim(txtVillagename.Text))
            sqlcommand.Parameters.AddWithValue("@Taluka_Name", Trim(txttalukaName.Text))
            sqlcommand.Parameters.AddWithValue("@District_Name", Trim(txtDistrictName.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@EditUserName", New_Entry)
            sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@Status", IIf(ComboStatus.Text = "YES", 1, 0))
            sqlcommand.Parameters.AddWithValue("@Vibhag_id", Val(TXtVibhagId.Text))
            sqlcommand.Parameters.AddWithValue("@Eng_Village_name", (TxtEngName.Text))
            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtVillageId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtVillageId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVillageId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtVillageId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtVillageId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVillageId.TextChanged

    End Sub

    Private Sub txtVillagename_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillagename.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtVillagename_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVillagename.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtVillagename_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillagename.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtVillagename_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVillagename.TextChanged

    End Sub

    Private Sub txtVillageId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then

            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Village_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Village_Id=" & Val(txtVillageId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("village_id"))
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
            'fn = False
        End If
    End Sub

    Private Sub txttalukaName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttalukaName.GotFocus, txtDistrictName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txttalukaName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttalukaName.KeyPress, txtDistrictName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txttalukaName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttalukaName.LostFocus, txtDistrictName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txttalukaName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttalukaName.TextChanged

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
                If searchby = "Village Id" Then
                    searchby = "Vm.Village_id"
                    ssql = "Select Vm.Village_Id,Vm.Village_name ,VBM.Vibhag_Name,Vm.Taluka_name ,Vm.District_Name , (CASE WHEN isnull(Vm.Status, '0') = '0' THEN 'NO' ELSE 'YES' END) as Status,Vm.VIbhag_id,vm.Eng_Village_name from Village_Master as Vm Left Outer join Vibhag_master as VBM on Vm.Company_id=Vbm.Company_id and Vm.Vibhag_Id=VBm.Vibhag_id where Vm.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                ElseIf searchby = "Village Name" Then
                    searchby = "Vm.Village_Name"
                    ssql = "Select Vm.Village_Id,Vm.Village_name ,VBM.Vibhag_Name,Vm.Taluka_name ,Vm.District_Name , (CASE WHEN isnull(Vm.Status, '0') = '0' THEN 'NO' ELSE 'YES' END) as Status,Vm.VIbhag_id,vm.Eng_Village_name from Village_Master as Vm Left Outer join Vibhag_master as VBM on Vm.Company_id=Vbm.Company_id and Vm.Vibhag_Id=VBm.Vibhag_id where Vm.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
                End If


                Dim ds As New DataSet
                objconnec.GetConnection()
                objDataTrns.OpenCn()
                ds = objDataTrns.fillgrid(ssql)
                DgDoc_Village.DataSource = ds.Tables(0)
                LBrec.Text = "Total : " & Trim(DgDoc_Village.Rows.Count)
                objDataTrns.CloseCn()
            Else
                txtsearch.Focus()
                loadg()
            End If




        Catch ex As Exception

        End Try
    End Sub




    Private Sub DgDoc_Village_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgDoc_Village.RowHeaderMouseClick
        RowDisplay()
    End Sub


    Private Sub DgDoc_Village_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Village.CellClick
        RowDisplay()
    End Sub

    Private Sub DgDoc_Village_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDoc_Village.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            RowDisplay()
        End If
    End Sub

    Private Sub DgDoc_Village_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Village.CellContentClick

    End Sub

    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged

    End Sub

    Private Sub cmbSearchby_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchby.Validated
        If cmbSearchby.Text = "Village Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)

        Else
            txtsearch.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Regular)
        End If


    End Sub

    Private Sub txtDistrictName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDistrictName.TextChanged

    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try

            clsVariables.ReportName = "RptVillageMaster.rpt"
            clsVariables.ReportSql = "{Village_Master.Company_id}=" & Val(clsVariables.CompnyId)
            clsVariables.RptTable = "Village_Master"
            clsVariables.Repheader = "Village Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtEngName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEngName.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtEngName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEngName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtEngName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtEngName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtEngName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtEngName.TextChanged

    End Sub

    Private Sub TXtVibhagId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtVibhagId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TXtVibhagId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXtVibhagId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TXtVibhagId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXtVibhagId.KeyUp
        If e.KeyCode = Keys.F2 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Vibhag_id"
            clsVariables.HelpName = "Vibhag_Name"
            clsVariables.TbName = "Vibhag_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Vibhag_Name"
            HelpWin.tsql = "Select Vibhag_id,Vibhag_Name from Vibhag_Master where company_id=" & Val(clsFunctions.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                TXtVibhagId.Text = clsVariables.RtnHelpId
                TxtVibhagName.Text = clsVariables.RtnHelpName
                txttalukaName.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Vibhag_id"
            clsVariables.HelpName = "Vibhag_Name"
            clsVariables.TbName = "Vibhag_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Vibhag_Id"
            HelpWin.tsql = "Select Vibhag_id,Vibhag_Name from Vibhag_Master where company_id=" & Val(clsFunctions.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtVillageId.Text = clsVariables.RtnHelpId
                TxtVibhagName.Text = clsVariables.RtnHelpName
                txttalukaName.Focus()
            End If

        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Village.Focus()
        End If
    End Sub

    Private Sub TXtVibhagId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtVibhagId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TXtVibhagId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXtVibhagId.TextChanged

    End Sub

    Private Sub TXtVibhagId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXtVibhagId.Validated
        Try

            If Val(TXtVibhagId.Text) <> 0 Then
                ssql = "Select Vibhag_Name from Vibhag_Master where Vibhag_id= " & Val(TXtVibhagId.Text) & " and Company_Id=" & Val(clsVariables.CompnyId) & ""
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    TxtVibhagName.Text = dt.Rows(0).Item(0).ToString
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Vibhag Id")
                        TxtVibhagName.Text = ""
                        TXtVibhagId.Focus()
                    End If

                End If
            Else
                TxtVibhagName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
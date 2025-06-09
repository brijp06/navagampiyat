Imports WeightPavti.CLS
Public Class PartyMaster



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

        txtpartyId.Enabled = False
        txtpartyName.Enabled = False

        DgDoc_Column.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True

        txtmobileno.Enabled = False
        'txtgstno.Enabled = False
        'txtAccountId.Enabled = False
        'txtAccountName.Enabled = False
        'txtVillageId.Enabled = False
        'txtVillageName.Enabled = False
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
        txtpartyId.Enabled = True
        txtpartyName.Enabled = True
        DgDoc_Column.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        txtmobileno.Enabled = True
        'txtgstno.Enabled = True
        'txtAccountId.Enabled = True
        'txtAccountName.Enabled = True
        'txtVillageId.Enabled = True
        'txtVillageName.Enabled = True
    End Sub
    Private Sub AccountGroupMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, txtpartyId.KeyUp, txtpartyName.KeyUp, BuExit.KeyUp, ButAdd.KeyUp, ButCAncel.KeyUp, ButDelete.KeyUp, ButEdit.KeyUp, ButFind.KeyUp, ButFirst.KeyUp, ButLast.KeyUp, ButNExt.KeyUp, BUtPrev.KeyUp, ButSave.KeyUp, ButPrint.KeyUp
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
        cmbSearchby.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        loadg()
        DgDoc_Column.Columns(0).HeaderText = "Id"
        DgDoc_Column.Columns(0).Width = 50
        DgDoc_Column.Columns(1).Width = 250
        'DgDoc_Column.Columns(1).HeaderText = "Name"
        DgDoc_Column.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Bold)
        'DgDoc_Column.Columns(2).DefaultCellStyle.Font = New Font("Cambria", 12, FontStyle.Bold)
        'DgDoc_Column.Columns(3).DefaultCellStyle.Font = New Font("Cambria", 12, FontStyle.Bold)
        'DgDoc_Column.Columns(2).Width = 0
        'dghouse.Columns.Add("", "")

    End Sub

    Public Function DocNo_AutoID(ByVal Party_Id As String, ByVal sTable As String) As Integer
        Try
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select max(code)+1 as Party_Id from  ItemGroup "
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Party_Id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtpartyId.Text = DocNo_AutoID
            Return DocNo_AutoID


        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtpartyId.Text = DocNo_AutoID
        End Try
    End Function
    Public Sub cleartext()
        txtpartyId.Text = ""
        txtpartyName.Text = ""
        txtmobileno.Text = ""
        
        'txtAccountId.Clear()
        'txtAccountName.Clear()
        'txtVillageId.Clear()
        'txtVillageName.Clear()
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
        Call DocNo_AutoID("code", "ItemGroup")
        txtpartyName.Focus()
        'Else
        'butstyle1()
        'End If
    End Sub
    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Column.Rows.Count > 0 Then
                i = DgDoc_Column.CurrentRow.Index
                txtpartyId.Text = DgDoc_Column.Rows(i).Cells(0).Value.ToString()
                txtpartyName.Text = DgDoc_Column.Rows(i).Cells(1).Value.ToString()
                'txtAccountId.Text = ob.IfNullThen(DgDoc_Column.Rows(i).DataBoundItem("Account_Id"), "")
                filltext(Val(clsVariables.CompnyId), Val(txtpartyId.Text))

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
        If Len(txtpartyId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            txtpartyId.Enabled = False
            txtpartyName.Focus()
        End If
        'Else
        'butstyle1()
        'End If

    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Party_Master where Company_id=" & Val(clsVariables.CompnyId) & " Order by Company_Id,Party_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Party_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Party_Id>" & aq(txtpartyId.Text)
                sql = sql & " Order by Company_Id ,Party_Id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Party_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Party_Id<" & aq(txtpartyId.Text)
                sql = sql & " Order by Company_Id desc,Party_Id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Party_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " Order by Company_Id desc,Party_Id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Party_Id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub loadg()
        Dim sql As String
        sql = "SELECT code,name from ItemGroup  order by code"
        'sql = sql & " FROM VILLAGE_MASTER RIGHT OUTER JOIN"
        'sql = sql & " PARTY_MASTER ON VILLAGE_MASTER.Village_Id = PARTY_MASTER.Village_Id AND "
        'sql = sql & " VILLAGE_MASTER.Company_Id = PARTY_MASTER.Company_Id LEFT OUTER JOIN"
        'sql = sql & " ACCOUNT_MASTER ON PARTY_MASTER.Company_Id = ACCOUNT_MASTER.Company_Id AND PARTY_MASTER.Account_Id = ACCOUNT_MASTER.Account_Id order by PARTY_MASTER.Company_Id,PARTY_MASTER.Party_Id"
        DgDoc_Column.DataSource = ob.Returntable(sql, ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
    End Sub
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from ItemGroup where  code=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtpartyId.Text = IIf(IsDBNull(dt.Rows(0).Item("code")), "", dt.Rows(0).Item("code"))
                txtpartyName.Text = IIf(IsDBNull(dt.Rows(0).Item("Name")), "", dt.Rows(0).Item("Name"))
                'txtmobileno.Text = IIf(IsDBNull(dt.Rows(0).Item("Mobileno")), "", dt.Rows(0).Item("Mobileno"))
                'txtgstno.Text = IIf(IsDBNull(dt.Rows(0).Item("gstno")), "", dt.Rows(0).Item("Gstno"))
                'If dghouse.Rows.Count > 0 Then
                '    dghouse.Rows.Clear()
                'End If
                'For i As Integer = 0 To dt.Rows.Count - 1
                '    dghouse.Rows.Add()
                '    dghouse.Rows(dghouse.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Gstno")
                'Next
                'txtAccountId.Text = IIf(IsDBNull(dt.Rows(0).Item("Account_Id")), "", dt.Rows(0).Item("Account_Id"))
                'txtAccountName.Text = ob.FindOneString("Select Account_name from Account_Master where Account_Id=" & Val(txtAccountId.Text) & " and Company_id=" & Val(clsVariables.CompnyId), ob.getconnection(ob.Getconn()))
                'txtVillageId.Text = IIf(IsDBNull(dt.Rows(0).Item("Village_Id")), "", dt.Rows(0).Item("Village_Id"))
                'txtVillageName.Text = ob.FindOneString("Select Village_name from Village_Master where Village_Id=" & Val(txtVillageId.Text) & " and Company_id=" & Val(clsVariables.CompnyId), ob.getconnection(ob.Getconn()))
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
            'If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            '    messageright(AccessMode.DeleteMode)
            '    butstyle1()
            '    Exit Sub
            'End If
            If Len(txtpartyId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                'If ob.CheckpartyMaster(Val(txtpartyId.Text), ob.getconnection) = True Then
                '    MessageBox.Show("Entry Can't Be Deleted Because Effected By Another Data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Exit Sub
                'End If
                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from ItemGroup where  code=" & Val(txtpartyId.Text), ob.getconnection(ob.Getconn()))
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
        filltext(Val(clsVariables.CompnyId), Val(txtpartyId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        txtpartyId.Focus()
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
            If Val(txtpartyId.Text) = 0 Then
                MessageBox.Show("Please Enter Party Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtpartyId.Focus()
                Exit Sub
            ElseIf Len(txtpartyName.Text) = 0 Then
                MessageBox.Show("Please Enter Party Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtpartyName.Focus()
                'ElseIf Len(txtAccountId.Text) = 0 Then
                '    MessageBox.Show("Please Enter Account Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txtAccountId.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    'If ob.FindOneinteger("Select Count(*) from Party_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Party_Id=" & Val(txtpartyId.Text), ob.getconnection()) > 0 Then
                    '    MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Party Id=" & (txtpartyId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    txtpartyId.Focus()
                    '    GoTo p
                    ob.Execute("delete from ItemGroup where code=" & txtpartyId.Text & "", ob.getconnection())
                    'End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)

                    sql = "Insert into ItemGroup (code,name"
                    sql = sql & ")values"
                    sql = sql & " (@Company_Id,@Party_Id)"
                    'sql = sql & "@Add_Date,@User_Name,"
                    'sql = sql & " @EditDate,@EditUserName)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", Val(txtpartyId.Text))
                    sqlcommand.Parameters.AddWithValue("@Party_Id", Trim(txtpartyName.Text))



                    'sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    'sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    'sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
                    'sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    'sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    'sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)

                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_Id=" & clsVariables.CompnyId
                    ssql = ssql & " and code=" & Val(txtpartyId.Text)
                    'ob.UpdateIdmach("Party_master", ssql, ob.getconnection, Isadd)
                    ' insertleg()

                    loadg()
                Else
                    'Dim sqlcommand As New SqlClient.SqlCommand
                    'sqlcommand.Connection = ob.getconnection(ob.Getconn)
                    'sql = "Update Party_Master SET Party_Name=@Party_Name,"
                    'sql = sql & " Mobileno=@Account_Id,gstno=@gstno"
                    ''sql = sql & " Edit_User_Name=@Edit_User_Name,Edit_Date=@Edit_Date,Revision=isnull(revision,0)+1"
                    'sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Party_Id=" & Val(txtpartyId.Text) & ""
                    'sqlcommand.CommandText = sql
                    'sqlcommand.Parameters.AddWithValue("@Party_Name", Trim(txtpartyName.Text))
                    'sqlcommand.Parameters.AddWithValue("@Account_Id", txtmobileno.Text)
                    'sqlcommand.Parameters.AddWithValue("@gstno", txtgstno.Text)
                    ''sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    ''sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    ''sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    ''sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    ''sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    ''sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)
                    'sqlcommand.ExecuteNonQuery()
                    'sqlcommand.Parameters.Clear()
                    'ssql = " Company_Id=" & clsVariables.CompnyId
                    'ssql = ssql & " and Party_id=" & Val(txtpartyId.Text)
                    'ob.UpdateIdmach("Party_master", ssql, ob.getconnection, Isadd)
                    'loadg()
                    ob.Execute("delete from ItemGroup where code=" & txtpartyId.Text & "", ob.getconnection())
                    'End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn)

                    sql = "Insert into ItemGroup (code,name"
                    sql = sql & ")values"
                    sql = sql & " (@Company_Id,@Party_Id)"
                    'sql = sql & "@Add_Date,@User_Name,"
                    'sql = sql & " @EditDate,@EditUserName)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", Val(txtpartyId.Text))
                    sqlcommand.Parameters.AddWithValue("@Party_Id", Trim(txtpartyName.Text))


                    'sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    'sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    'sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
                    'sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
                    'sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
                    'sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)

                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_Id=" & clsVariables.CompnyId
                    ssql = ssql & " and Party_id=" & Val(txtpartyId.Text)
                    'ob.UpdateIdmach("Party_master", ssql, ob.getconnection, Isadd)
                    ' insertleg()

                    loadg()
                End If
                ButAdd_Click(e, e)
            End If
p:
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub insertleg()
        For i = 1 To 12
            ob.Execute("insert into party_detail(Doc_no, Party_id, Month_id, Amount, pen) values (0," & txtpartyId.Text & "," & i & ",0,0)", ob.getconnection())
        Next
    End Sub
    Public Sub insert()
        Try
            Dim sql As String
            Dim sqlcommand As New SqlClient.SqlCommand
            sqlcommand.Connection = ob.getconnection(ob.Getconn)
            sql = "Insert into Party_Master (Company_id,Party_Id,Party_Name,mobileno,gstno,"
            sql = sql & "Add_Date,User_NAme,Edit_DAte,Edit_User_Name)values"
            sql = sql & " (@Company_Id,@Party_Id,@Party_Name,@Account_Id,@Village_id,"
            sql = sql & "@Add_Date,@User_Name,"
            sql = sql & " @EditDate,@EditUserName)"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Party_Id", Val(txtpartyId.Text))
            sqlcommand.Parameters.AddWithValue("@Party_Name", Trim(txtpartyName.Text))
            sqlcommand.Parameters.AddWithValue("@Account_Id", Val(txtmobileno.Text))
            'sqlcommand.Parameters.AddWithValue("@Village_Id", aq(txtgstno.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@EditUserName", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@EditDate", Format(Now, "MM/dd/yyyy HH:mm:ss tt"))
            sqlcommand.Parameters.AddWithValue("@Dtatime", Now.ToShortTimeString)
            sqlcommand.Parameters.AddWithValue("@EditDtatime", Now.ToShortTimeString)

            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartyId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartyId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartyId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartyId.TextChanged

    End Sub

    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartyName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartyName.KeyPress, txtmobileno.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartyName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartyName.TextChanged

    End Sub

    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpartyId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from ItemGroup where  code=" & Val(txtpartyId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("pid"))
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
            ssql = "SELECT party_id,party_name from party_master"
            'ssql = ssql & " FROM VILLAGE_MASTER RIGHT OUTER JOIN"
            'ssql = ssql & " PARTY_MASTER ON VILLAGE_MASTER.Village_Id = PARTY_MASTER.Village_Id AND "
            'ssql = ssql & " VILLAGE_MASTER.Company_Id = PARTY_MASTER.Company_Id LEFT OUTER JOIN"
            'ssql = ssql & " ACCOUNT_MASTER ON PARTY_MASTER.Company_Id = ACCOUNT_MASTER.Company_Id AND PARTY_MASTER.Account_Id = ACCOUNT_MASTER.Account_Id"
            searchby = ""
            searchby = cmbSearchby.SelectedItem.ToString
            If txtsearch.Text <> "" Then
                If searchby = "Party Id" Then
                    searchby = "PARTY_MASTER.Party_Id"
                    ssql = ssql & "  where PARTY_MASTER.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                ElseIf searchby = "Party Name" Then
                    searchby = "PARTY_MASTER.Party_Name"
                    ssql = ssql & "  where PARTY_MASTER.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
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
        If cmbSearchby.Text = "Party Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)

        Else
            txtsearch.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Regular)
        End If


    End Sub
    Private Sub txtGroupId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub

    Private Sub txtGroupId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        tabkey(sender, e)
    End Sub

    
    Private Sub txtGroupId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub

    Private Sub txtGroupId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtVillageId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textactive(sender)
    End Sub

    Private Sub txtVillageId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        tabkey(sender, e)
    End Sub

    
    Private Sub txtVillageId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Textreset(sender)
    End Sub

    Private Sub txtVillageId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    
    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try

            clsVariables.ReportName = "RptPartyMaster.rpt"
            clsVariables.ReportSql = "{Party_master.Company_id}=" & Val(clsVariables.CompnyId)
            clsVariables.RptTable = "VpartyMaster"
            clsVariables.Repheader = "Party Master List"
            Dim frm As New Reportformnew
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtgstno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        
    End Sub
End Class
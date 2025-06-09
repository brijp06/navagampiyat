Imports WeightPavti.CLS
Public Class ProductMst
    Dim Isadd, fn As Boolean
    Dim ssql As String
    Dim sprodID As String
    Dim ds As New DataSet
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
        TxtProductId.Enabled = False
        TxtProductName.Enabled = False
        DgDoc_Column.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
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
        TxtProductId.Enabled = True
        TxtProductName.Enabled = True
        DgDoc_Column.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
    End Sub
    Private Sub ColumnMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, ButPrint.KeyUp, TxtProductId.KeyUp, TxtProductName.KeyUp, BuExit.KeyUp, ButAdd.KeyUp, ButCAncel.KeyUp, ButDelete.KeyUp, ButEdit.KeyUp, ButFind.KeyUp, ButFirst.KeyUp, ButLast.KeyUp, ButNExt.KeyUp, BUtPrev.KeyUp, ButPrint.KeyUp, ButSave.KeyUp
        If e.KeyCode = Keys.F3 Then
            DgDoc_Column.Focus()
        End If
    End Sub
    Private Sub ProductMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If

        cmbSearchby.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        FindproductID()
        loadg()
        DgDoc_Column.DefaultCellStyle.ForeColor = Color.Black
        DgDoc_Column.DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 11, FontStyle.Regular)
        DgDoc_Column.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        DgDoc_Column.Columns(0).HeaderText = "Id"
        DgDoc_Column.Columns(0).Width = 50
        DgDoc_Column.Columns(1).Width = 220
        DgDoc_Column.Columns(1).HeaderText = "Name"

    End Sub
    Public Sub FindproductID()
        ssql = " Select p.Product_Id from Product_Master as P Inner Join Quality_Master as Q On P.Product_ID =Q.Product_Id where p.Company_id=" & Val(clsVariables.CompnyId) & " "
        ssql = ssql & clsVariables.sDeptID
        sprodID = ssql
    End Sub
    Public Function DocNo_AutoID(ByVal Product_Id As String, ByVal sTable As String) As Integer
        Try
            ssql = "select max(" & Product_Id & ") as Product_Id from  Product_Master where Company_Id=" & Val(clsVariables.CompnyId)
            
            DocNo_AutoID = ob.FindOneinteger(ssql, ob.getconnection) + 1
            TxtProductId.Text = DocNo_AutoID
            Return DocNo_AutoID
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub cleartext()
        TxtProductId.Text = ""
        TxtProductName.Text = ""
        TxtProductName.Tag = 0
        TxtProductName.Text = ""
    End Sub
    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            butstyle1()
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        butstyle2()
        cleartext()
        Isadd = True
        Call DocNo_AutoID("Product_Id", "Product_Master")
        TxtProductName.Focus()
    End Sub
    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Column.Rows.Count > 0 Then
                i = DgDoc_Column.CurrentRow.Index
                TxtProductId.Text = DgDoc_Column.Rows(i).Cells(0).Value.ToString()
                TxtProductName.Text = DgDoc_Column.Rows(i).Cells(1).Value.ToString()
                Dim dt As DataTable = ob.Returntable("Select * from Product_Master where Company_id=" & Val(1) & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection(ob.Getconn()))
                If dt.Rows.Count > 0 Then
                    TxtProductId.Text = IIf(IsDBNull(dt.Rows(0).Item("Product_Id")), "", dt.Rows(0).Item("Product_Id"))
                    TxtProductName.Text = IIf(IsDBNull(dt.Rows(0).Item("Product_Name")), "", dt.Rows(0).Item("Product_Name"))
                    txtgroup_name.Tag = IIf(IsDBNull(dt.Rows(0).Item("group_id")), "", dt.Rows(0).Item("group_id"))
                    txtgroup_name.Text = ob.FindOneString("select Group_name from group_master where group_id=" & Val(txtgroup_name.Tag) & "", ob.getconnection())
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            messageright(AccessMode.ChangeMode)
            butstyle1()
            Exit Sub
        End If
        If Len(TxtProductId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            TxtProductId.Enabled = False
            TxtProductName.Focus()
        End If
    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " Order by Company_Id,Product_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Product_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Product_Id>" & Val(TxtProductId.Text)
                sql = sql & " Order by Company_Id ,Product_Id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Product_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Product_Id<" & Val(TxtProductId.Text)
                sql = sql & " Order by Company_Id desc,Product_Id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " Order by Company_Id desc,Product_Id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Product_Id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub loadg()
        'DgDoc_Column.DataSource = ob.Returntable("Select Product_Id,Product_Name  from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Product_Id in  (" & sprodID & ") order by Company_Id,Product_Id ", ob.getconnection())
        DgDoc_Column.DataSource = ob.Returntable("Select Product_Id,Product_Name  from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " order by Company_Id,Product_Id ", ob.getconnection())
        LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
    End Sub
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable
            'dt = ob.Returntable("Select * from Product_Master where Company_id=" & Val(Comp_id) & " and Product_Id=" & Val(vill_id) & " and Product_Id in (" & sprodID & ")", ob.getconnection(ob.Getconn()))
            dt = ob.Returntable("Select * from Product_Master where Company_id=" & Val(Comp_id) & " and Product_Id=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                TxtProductId.Text = IIf(IsDBNull(dt.Rows(0).Item("Product_Id")), "", dt.Rows(0).Item("Product_Id"))
                TxtProductName.Text = IIf(IsDBNull(dt.Rows(0).Item("Product_Name")), "", dt.Rows(0).Item("Product_Name"))
                txtgroup_name.Tag = IIf(IsDBNull(dt.Rows(0).Item("group_id")), "", dt.Rows(0).Item("group_id"))
                txtgroup_name.Text = ob.FindOneString("select Group_name from group_master where group_id=" & Val(txtgroup_name.Tag) & "", ob.getconnection())
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ButDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDelete.Click
        Try
            If ob.AuthorizedTo(AccessMode.DeleteMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
                messageright(AccessMode.DeleteMode)
                butstyle1()
                Exit Sub
            End If
            If Len(TxtProductId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection(ob.Getconn()))
                    'ob.UpdateEditUser("Product_Master", "Company_Id=" & clsVariables.CompnyId & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
                    'MsgBox("Entry Is Successfully Deleted", MsgBoxStyle.Critical, Application.ProductName)
                    If Entry_Move("next") = False Then
                        If Entry_Move("prev") = False Then
                            cleartext()
                        End If
                    End If
                    loadg()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        filltext(Val(clsVariables.CompnyId), Val(TxtProductId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        TxtProductId.Focus()
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
            If Val(TxtProductId.Text) = 0 Then
                MessageBox.Show("Please Enter Product Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtProductId.Focus()
                Exit Sub
            ElseIf Len(TxtProductName.Text) = 0 Then
                MessageBox.Show("Please Enter Product Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtProductName.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Product Id=" & Val(TxtProductId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtProductId.Focus()
                        GoTo p
                    End If
                    insert(dbname)
                    'insert(BackDbname)
                    loadg()
                Else
                    'ob.UpdateEditUser("Product_Master", "Company_Id=" & clsVariables.CompnyId & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                    sql = "Update Product_Master SET Product_Name=N" & aq(TxtProductName.Text)
                    sql = sql & " ,group_id=" & Val(txtgroup_name.Tag) & ",Edit_User_Name=" & aq(clsVariables.UserName)
                    sql = sql & " ,Edit_Date=" & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt"))
                    sql = sql & " ,Revision=revision+1"
                    sql = sql & " ,ip_Address=" & aq(IPAddress)
                    sql = sql & ",Mach_Name=" & aq(MachineName)
                    sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Product_Id=" & TxtProductId.Text & ""
                    ob.Execute(sql, ob.getconnection)
                    'insert(BackDbname)
                    loadg()
                End If
                ButAdd_Click(e, e)
            End If
p:
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub insert(ByVal dbnm As String)
        Try
            Dim sql As String
            Sql = "Insert into Product_Master (Company_id,Product_Id,Product_Name,"
            sql = sql & "group_id,Add_Date,User_NAme,Edit_User_Name,ip_Address,Mach_Name)values("
            sql = Sql & clsVariables.CompnyId & ","
            Sql = Sql & Val(TxtProductId.Text) & ","
            sql = sql & aq(TxtProductName.Text) & ","
            sql = sql & Val(txtgroup_name.Tag) & ","
            sql = Sql & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt")) & ","
            Sql = Sql & aq(clsVariables.UserName) & ","
            Sql = Sql & aq(New_Entry) & ","
            Sql = Sql & aq(IPAddress) & ","
            Sql = Sql & aq(MachineName) & ")"
            ob.Execute(sql, ob.getconnection(ob.Getconn(dbnm)))
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProductId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductId.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtColumnId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProductId.TextChanged

    End Sub
    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductName.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtProductName.KeyPress, txtgroup_name.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductName.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProductName.TextChanged

    End Sub
    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProductId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Product_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Product_Id=" & Val(TxtProductId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Product_Id"))
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
        Textactive(sender)
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
                If searchby = "Product Id" Then
                    searchby = "Product_Id"
                    ssql = "Select Product_Id,Product_Name from Product_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                    'ssql = ssql & " and Product_Id in (" & sprodID & ")"
                ElseIf searchby = "Product Name" Then
                    searchby = "Product_Name"
                    ssql = "Select Product_Id,Product_Name from Product_Master where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
                    'ssql = ssql & " and Product_Id in (" & sprodID & ")"
                End If

                Dim ds As New DataTable
                ds = ob.Returntable(ssql, ob.getconnection)
                DgDoc_Column.DataSource = ds
                LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)
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
    End Sub
    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged

    End Sub

    Private Sub txtgroup_name_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtgroup_name.Validating
        txtgroup_name.Tag = ob.FindOneString("select Group_id from Group_Master Where Group_id=" & Val(txtgroup_name.Text) & " or Group_Name=N'" & Trim(txtgroup_name.Text) & "'", ob.getconnection())
        If Val(txtgroup_name.Tag) <> 0 Then
            txtgroup_name.Text = ob.FindOneString("select Group_Name from Group_Master Where Group_id=" & txtgroup_name.Tag & " ", ob.getconnection())
        End If
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try

            clsVariables.ReportName = "ProductMaster.rpt"
            clsVariables.ReportSql = "{Product_Master.Company_id}=" & clsVariables.CompnyId
            clsVariables.Repheader = "Product Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class
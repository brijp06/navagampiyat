Imports WeightPavti.CLS
Public Class ItemMst
    Dim Isadd, fn As Boolean
    Dim ssql As String
    Dim ds As New DataSet
    Dim sItem As String
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

        TxtItemId.Enabled = False
        TxtItemName.Enabled = False
        txtpurchaseid.Enabled = False
        Txtsalesid.Enabled = False
        Dg.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        TxtPkgUnit.Enabled = False
        TxtPadtRate.Enabled = False
        TxtsaleRate.Enabled = False
        TxtDiscPer.Enabled = False
        Cmbproduct.Enabled = False
        TxtHelpAmt.Enabled = False
        TxtCommAmt.Enabled = False
        TxtOldItemId.Enabled = False
        TxtBharti.Enabled = False
        TxtHSNCODE.Enabled = False
        txtBarCode.Enabled = False
        TxtVatper.Enabled = False
        TxtAddvatPer.Enabled = False
        TxtPacking.Enabled = False
        txtcgst.Enabled = False
        txtsgst.Enabled = False
        txtigst.Enabled = False
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
        TxtItemId.Enabled = True
        TxtItemName.Enabled = True
        Dg.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        txtpurchaseid.Enabled = True
        Txtsalesid.Enabled = True
        TxtPkgUnit.Enabled = True
        TxtPadtRate.Enabled = True
        TxtsaleRate.Enabled = True
        TxtDiscPer.Enabled = True

        Cmbproduct.Enabled = True
        TxtHelpAmt.Enabled = True
        TxtCommAmt.Enabled = True
        TxtOldItemId.Enabled = True
        TxtBharti.Enabled = True
        TxtHSNCODE.Enabled = True
        txtBarCode.Enabled = True
        TxtVatper.Enabled = True
        TxtAddvatPer.Enabled = True
        TxtPacking.Enabled = True
        txtcgst.Enabled = True
        txtsgst.Enabled = True
        txtigst.Enabled = True
    End Sub
    Public Sub FindItemId()
        ssql = "Select i.item_Id From Item_MAster as I  where I.Company_Id = " & clsVariables.CompnyId & ""
        'If Len(MdiMain.ComboDept.Text) <> 0 Then
        '    ssql = ssql & " and  Department_Id =" & (MdiMain.ComboDept.SelectedValue) & ""
        'End If
        sItem = ssql
    End Sub
    Private Sub ColumnMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButAdd.KeyUp, cmbSearchby.KeyUp, txtsearch.KeyUp, ButPrint.KeyUp, TxtItemId.KeyUp, TxtItemName.KeyUp, BuExit.KeyUp, ButAdd.KeyUp, ButCAncel.KeyUp, ButDelete.KeyUp, ButEdit.KeyUp, ButFind.KeyUp, ButFirst.KeyUp, ButLast.KeyUp, ButNExt.KeyUp, BUtPrev.KeyUp, ButPrint.KeyUp, ButSave.KeyUp, TxtPadtRate.KeyUp, TxtsaleRate.KeyUp, TxtDiscPer.KeyUp
        If e.KeyCode = Keys.F3 Then
            Dg.Focus()
        End If
    End Sub
    Private Sub ItemMst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Text = Me.Tag
        'If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
        '    Me.Hide()
        '    messageright(AccessMode.ViewMode)
        '    Me.Close()
        '    Exit Sub
        'End If
        'Me.BackgroundImage = MdiMain.PicMaster.Image

        cmbSearchby.SelectedIndex = 0
        Cmbdepatment.SelectedIndex = 0
        Me.MdiParent = MdiMain
        ButAdd_Click(e, e)
        FindItemId()
        Dg.Columns.Add("Id", "Id")
        Dg.Columns.Add("Name", "Name")
        Dg.DefaultCellStyle.ForeColor = Color.Black
        'DgDoc_Column.DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 11, FontStyle.Regular)
        'DgDoc_Column.ColumnHeadersDefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Bold)
        'DgDoc_Column.Columns(0).HeaderText = "Id"
        Dg.Columns(0).Width = 80
        Dg.Columns(1).Width = 300
        'Dim dt As DataTable = ob.Returntable("select Product_id,Product_Name from Product_Master", ob.getconnection())
        'If dt.Rows.Count > 0 Then
        '    Cmbproduct.DataSource = dt
        '    Cmbproduct.ValueMember = "Product_id"
        '    Cmbproduct.DisplayMember = "Product_Name"
        'End If
        loadg()

        auto()
        autos()
        autogroup()
        'DgDoc_Column.Columns(1).HeaderText = "Name"
    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_name from Account_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_name"))
        Next
        txtpurchaseid.AutoCompleteMode = AutoCompleteMode.Suggest
        txtpurchaseid.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtpurchaseid.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autogroup()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Product_id,Product_Name from Product_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Product_Name"))
        Next
        groupname.AutoCompleteMode = AutoCompleteMode.Suggest
        groupname.AutoCompleteSource = AutoCompleteSource.CustomSource
        groupname.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Sub autos()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Account_name from Account_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Account_name"))
        Next
        Txtsalesid.AutoCompleteMode = AutoCompleteMode.Suggest
        Txtsalesid.AutoCompleteSource = AutoCompleteSource.CustomSource
        Txtsalesid.AutoCompleteCustomSource = AutoComp
    End Sub
    Public Function DocNo_AutoID(ByVal Item_Id As String, ByVal sTable As String) As Integer
        Try
            ssql = "select max(" & Item_Id & ") as Item_Id from  Item_Master as IM  where Im.Company_Id=" & Val(clsVariables.CompnyId)
            'If Len(MdiMain.ComboDept.Text) <> 0 Then

            '    Select Case MdiMain.ComboDept.SelectedValue
            '        Case 1
            '            ssql = ssql & " and Item_Id Between 60000 and 69999"
            '        Case 2
            '            ssql = ssql & " and Item_Id Between 1 and 9999"
            '        Case 3
            '            ssql = ssql & " and Item_Id Between 10001 and 19999"
            '        Case 4
            '            ssql = ssql & " and Item_Id Between 20000 and 29999"
            '        Case 5
            '            ssql = ssql & " and Item_Id Between 30000 and 39999"
            '        Case 6
            '            ssql = ssql & " and Item_Id Between 40000 and 59999"
            '        Case 7
            '            ssql = ssql & " and Item_Id Between 60000 and 69999"
            '        Case 8
            '            ssql = ssql & " and Item_Id Between 70000 and 79999"
            '    End Select

            'End If
            DocNo_AutoID = ob.FindOneinteger(ssql, ob.getconnection) + 1
            TxtItemId.Text = DocNo_AutoID
            Return DocNo_AutoID
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Function DocNo_AutoID1(ByVal Item_Id As String, ByVal sTable As String) As Integer
        Try
            ssql = "select max(" & Item_Id & ") as Item_Id from  Item_Master where Company_Id=" & Val(clsVariables.CompnyId)
            DocNo_AutoID1 = ob.FindOneinteger(ssql, ob.getconnection) + 1
            TxtItemId.Text = DocNo_AutoID1
            Return DocNo_AutoID1
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub cleartext()
        TxtItemId.Text = ""
        TxtItemName.Text = ""
        txtpurchaseid.Clear()
        Txtsalesid.Clear()
        TxtPkgUnit.Clear()
        TxtPadtRate.Clear()
        TxtsaleRate.Clear()
        TxtDiscPer.Clear()
        TxtHelpAmt.Clear()
        TxtCommAmt.Clear()
        TxtOldItemId.Clear()
        TxtBharti.Clear()
        TxtHSNCODE.Clear()
        txtBarCode.Clear()
        TxtVatper.Clear()
        TxtAddvatPer.Clear()
        TxtPacking.Clear()
        txtcgst.Clear()
        txtsgst.Clear()
        txtigst.Clear()
        txtbagkg.Clear()
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
        Call DocNo_AutoID("Item_Id", "Item_Master")
        Cmbdepatment.Focus()
    End Sub
    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If Dg.Rows.Count > 0 Then
                i = Dg.CurrentRow.Index
                TxtItemId.Text = Dg.Rows(i).Cells(0).Value.ToString()
                TxtItemName.Text = Dg.Rows(i).Cells(1).Value.ToString()
                'txtpurchaseid.Text = ob.IfNullThen(Dg.Rows(i).Cells(3).Value.ToString(), 0)
                'Txtsalesid.Text = ob.IfNullThen(Dg.Rows(i).Cells(2).Value.ToString(), "")
                filltext(clsVariables.CompnyId, Val(TxtItemId.Text))
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub ButEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
        'If ob.AuthorizedTo(AccessMode.ChangeMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
        '    messageright(AccessMode.ChangeMode)
        '    butstyle1()
        '    Exit Sub
        'End If
        If Len(TxtItemId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            Isadd = False
            TxtItemId.Enabled = False
            TxtItemName.Focus()
        End If
    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from Item_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " and Item_Id = " & sItem & ""
                sql = sql & "  Order by Company_Id,Item_Id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from Item_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Item_Id>" & Val(TxtItemId.Text)
                sql = sql & " and Item_Id = " & sItem & ""
                sql = sql & " Order by Company_Id ,Item_Id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from Item_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Item_Id<" & Val(TxtItemId.Text)
                sql = sql & " and Item_Id = " & sItem & ""
                sql = sql & " Order by Company_Id desc,Item_Id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from Item_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                sql = sql & " and Item_Id = " & sItem & ""
                sql = sql & " Order by Company_Id desc,Item_Id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Item_Id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub loadg()
        'ssql = "Select I.Item_Id,I.Item_Name,Q.Quality_Name,I.Quality_Id  from Item_Master as i LEFT OUTER JOIN Quality_Master Q On I.Company_id=Q.Company_id and I.Quality_Id=Q.Quality_Id where I.Company_id=" & Val(clsVariables.CompnyId)
        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    ssql = ssql & " and Q.Department_ID=" & Val(MdiMain.ComboDept.SelectedValue)
        'End If
        'ssql = ssql & " order by I.Company_Id,I.Item_Id"
        'DgDoc_Column.DataSource = ob.Returntable(ssql, ob.getconnection())
        'LBrec.Text = "Total : " & Trim(DgDoc_Column.Rows.Count)

        Dim dt As DataTable = ob.Returntable("select Item_id,Item_Name from Item_master where Department='" & Cmbdepatment.Text & "'  Order By Item_id", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dg.Rows.Count > 0 Then
                Dg.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dg.Rows.Add()
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Item_id")
                Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Item_Name")

            Next
        End If
    End Sub
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Integer)
        Try
            cleartext()
            Dim dt As New DataTable

            dt = ob.Returntable("Select * from Item_Master where Company_id=" & Val(Comp_id) & " and Item_Id=" & Val(vill_id) & " and Item_Id in (" & sItem & ") ", ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                TxtItemId.Text = IIf(IsDBNull(dt.Rows(0).Item("Item_Id")), "", dt.Rows(0).Item("Item_Id"))
                TxtItemName.Text = IIf(IsDBNull(dt.Rows(0).Item("Item_Name")), "", dt.Rows(0).Item("Item_Name"))
                txtpurchaseid.Tag = ob.IfNullThen(dt.Rows(0).Item("pid"), "")
                Txtsalesid.Tag = ob.IfNullThen(dt.Rows(0).Item("sid"), "")
                txtpurchaseid.Text = ob.FindOneString("select Account_name from Account_Master Where Account_id=" & txtpurchaseid.Tag & " ", ob.getconnection())
                Txtsalesid.Text = ob.FindOneString("select Account_name from Account_Master Where Account_id=" & Txtsalesid.Tag & " ", ob.getconnection())
                Cmbdepatment.Text = ob.IfNullThen(dt.Rows(0).Item("Department"), "")
                'Txtsalesid.Text = ob.FindOneString("Select Quality_Name from Quality_Master where Company_Id=" & clsVariables.CompnyId & " and Quality_Id=" & Val(txtpurchaseid.Text), ob.getconnection)
                Cmbproduct.Text = ob.IfNullThen(dt.Rows(0).Item("Unit"), "")
                TxtPacking.Text = ob.IfNullThen(dt.Rows(0).Item("Packing"), 0)
                TxtPkgUnit.Text = ob.IfNullThen(dt.Rows(0).Item("Packing_Unit"), "")
                TxtPadtRate.Text = ob.IfNullThen(dt.Rows(0).Item("Padt_Rate"), 0)
                TxtsaleRate.Text = ob.IfNullThen(dt.Rows(0).Item("Sell_Rate"), 0)
                TxtDiscPer.Text = ob.IfNullThen(dt.Rows(0).Item("Disc_Per"), 0)
                TxtHelpAmt.Text = ob.IfNullThen(dt.Rows(0).Item("Help_Amt"), 0)
                TxtCommAmt.Text = ob.IfNullThen(dt.Rows(0).Item("Comm_Amt"), 0)
                TxtOldItemId.Text = ob.IfNullThen(dt.Rows(0).Item("Old_Item_Id"), 0)
                TxtBharti.Text = ob.IfNullThen(dt.Rows(0).Item("Bharti"), 0)
                TxtHSNCODE.Text = ob.IfNullThen(dt.Rows(0).Item("HSN_Code"), "")
                txtBarCode.Text = ob.IfNullThen(dt.Rows(0).Item("Bar_Code"), "")
                TxtVatper.Text = ob.IfNullThen(dt.Rows(0).Item("Vat_Per"), "")
                TxtAddvatPer.Text = ob.IfNullThen(dt.Rows(0).Item("Add_Vat_Per"), "")
                txtcgst.Text = ob.IfNullThen(dt.Rows(0).Item("CGST_Per"), "")
                txtsgst.Text = ob.IfNullThen(dt.Rows(0).Item("SGST_Per"), "")
                txtigst.Text = ob.IfNullThen(dt.Rows(0).Item("IGST_Per"), "")
                groupname.Tag = ob.IfNullThen(dt.Rows(0).Item("Quality_id"), "0")
                txtbagkg.Text = ob.IfNullThen(dt.Rows(0).Item("bag"), "0")
                If Val(groupname.Tag) <> 0 Then
                    groupname.Text = ob.FindOneString("select Product_name from Product_Master Where Product_id=" & groupname.Tag & " ", ob.getconnection())
                Else
                    groupname.Text = ""
                End If

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
            If Len(TxtItemId.Text) = 0 Then
                MessageBox.Show("Nothing For Delete", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else

                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from Item_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Item_Id=" & Val(TxtItemId.Text), ob.getconnection(ob.Getconn()))
                    ob.UpdateEditUser("Item_Master", "Company_Id=" & clsVariables.CompnyId & " and Item_Id=" & Val(TxtItemId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
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
        filltext(Val(clsVariables.CompnyId), Val(TxtItemId.Text))
        ButAdd.Focus()
    End Sub
    Private Sub ButFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFind.Click
        fn = True
        butstyle2()
        TxtItemId.Focus()
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
            If Val(TxtItemId.Text) = 0 Then
                MessageBox.Show("Please Enter Item Id", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtItemId.Focus()
                Exit Sub
            ElseIf Len(TxtItemName.Text) = 0 Then
                MessageBox.Show("Please Enter Item Name", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                TxtItemName.Focus()
                'ElseIf Len(txtBarCode.Text) = 0 Then
                '    MessageBox.Show("Please Enter Barcode", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    txtBarCode.Focus()
            Else
                Dim sql As String
                If Isadd = True Then
                    If ob.FindOneinteger("Select Count(*) from Item_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Item_Id=" & Val(TxtItemId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Company Id=" & Val(clsVariables.CompnyId) & " and Item Id=" & Val(TxtItemId.Text), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        TxtItemId.Focus()
                        GoTo p
                    End If
                    Insert(dbname)
                    'Insert(BackDbname)
                    loadg()
                Else
                    'ob.UpdateEditUser("Item_Master", "Company_Id=" & clsVariables.CompnyId & " and Item_Id=" & Val(TxtItemId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                    sql = "Update Item_Master SET Item_Name=N" & aq(TxtItemName.Text)
                    sql = sql & " ,Quality_Id=" & Val(groupname.Tag)
                    sql = sql & " ,Unit=" & aq(Cmbproduct.Text)
                    sql = sql & ",packing=" & Val(TxtPacking.Text)
                    sql = sql & " ,packing_Unit=" & aq(TxtPkgUnit.Text)
                    sql = sql & " ,Padt_rate=" & Val(TxtPadtRate.Text)
                    sql = sql & " ,Sell_Rate=" & Val(TxtsaleRate.Text)
                    sql = sql & " ,Disc_Per=" & Val(TxtDiscPer.Text)
                    sql = sql & ",Help_Amt=" & Val(TxtHelpAmt.Text)
                    sql = sql & ",Comm_Amt=" & Val(TxtCommAmt.Text)
                    sql = sql & ",Old_Item_Id=" & Val(TxtOldItemId.Text)
                    sql = sql & ",Bharti=" & Val(TxtBharti.Text)
                    sql = sql & ",HSN_Code=" & aq(TxtHSNCODE.Text)
                    sql = sql & ",Bar_Code = " & aq(txtBarCode.Text)
                    sql = sql & ",Vat_Per=" & Val(TxtVatper.Text)
                    sql = sql & ",Add_Vat_Per=" & Val(TxtAddvatPer.Text)
                    sql = sql & ",CGST_Per=" & Val(txtcgst.Text)
                    sql = sql & ",SGST_Per=" & Val(txtsgst.Text)
                    sql = sql & ",IGST_Per=" & Val(txtigst.Text)
                    sql = sql & " ,Edit_User_Name=" & aq(clsVariables.UserName)
                    sql = sql & " ,Edit_Date=" & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt"))
                    sql = sql & " ,Revision=revision+1"
                    sql = sql & " ,ip_Address=" & aq(IPAddress)
                    sql = sql & ",Mach_Name=" & aq(MachineName)
                    sql = sql & ",Department=" & aq(Cmbdepatment.Text)
                    sql = sql & ",pid=" & Val(txtpurchaseid.Tag)
                    sql = sql & ",sid=" & Val(Txtsalesid.Tag)
                    sql = sql & ",bag=" & Val(txtbagkg.Text)
                    sql = sql & " Where Company_Id=" & clsVariables.CompnyId & " and Item_Id=" & Val(TxtItemId.Text) & ""
                    ob.Execute(sql, ob.getconnection)
                    '            Insert(BackDbname)
                    loadg()
                End If
                ButAdd_Click(e, e)
            End If
p:
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Public Sub Insert(ByVal dbnm As String)
        Dim sql As String
        Try
            sql = "Insert into Item_Master (Company_id,Item_Id,Item_Name,Quality_Id,Unit,Packing,Packing_unit,Padt_Rate,Sell_Rate,Disc_per,Help_Amt,Comm_Amt,Old_Item_Id,Bharti,HSN_Code,Vat_Per,Add_Vat_Per,CGST_Per,SGST_Per,IGST_Per,"
            sql = sql & "Add_Date,User_NAme,Edit_User_Name,ip_Address,Mach_Name,Bar_Code,Department,Pid,Sid,bag)values("
            sql = sql & clsVariables.CompnyId & ","
            sql = sql & Val(TxtItemId.Text) & ","
            sql = sql & "N" & aq(TxtItemName.Text) & ","
            sql = sql & Val(groupname.Tag) & ","
            sql = sql & aq(Cmbproduct.Text) & ","
            sql = sql & Val(TxtPacking.Text) & ","
            sql = sql & aq(TxtPkgUnit.Text) & ","
            sql = sql & Val(TxtPadtRate.Text) & ","
            sql = sql & Val(TxtsaleRate.Text) & ","
            sql = sql & Val(TxtDiscPer.Text) & ","
            sql = sql & Val(TxtHelpAmt.Text) & ","
            sql = sql & Val(TxtCommAmt.Text) & ","
            sql = sql & Val(TxtOldItemId.Text) & ","
            sql = sql & Val(TxtBharti.Text) & ","
            sql = sql & aq(TxtHSNCODE.Text) & ","
            sql = sql & Val(TxtVatper.Text) & ","
            sql = sql & Val(TxtAddvatPer.Text) & ","
            sql = sql & Val(txtcgst.Text) & ","
            sql = sql & Val(txtsgst.Text) & ","
            sql = sql & Val(txtigst.Text) & ","

            sql = sql & aq(Format(Now, "MM/dd/yyyy hh:mm:ss tt")) & ","
            sql = sql & aq(clsVariables.UserName) & ","
            sql = sql & aq(New_Entry) & ","
            sql = sql & aq(IPAddress) & ","
            sql = sql & aq(MachineName) & ","
            sql = sql & aq(txtBarCode.Text) & ","
            sql = sql & aq(Cmbdepatment.Text) & ","
            sql = sql & aq(txtpurchaseid.Tag) & ","
            sql = sql & aq(Txtsalesid.Tag) & ","
            sql = sql & Val(txtbagkg.Tag) & ")"

            ob.Execute(sql, ob.getconnection())
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Private Sub txtColumnId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItemId.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtColumnId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtItemId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub
    Private Sub txtColumnId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItemId.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtColumnname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItemName.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtColumnname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtItemName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtColumnname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItemName.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtColumnname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtItemName.TextChanged

    End Sub
    Private Sub txtColumnId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtItemId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then


            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Item_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Item_Id=" & Val(TxtItemId.Text) & " and Item_Id in (" & sItem & ") ", ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Item_Id"))
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
                If searchby = "Item Id" Then
                    searchby = "Item_Id"
                    ssql = "Select Item_Id,Item_Name  from Item_Master  where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "

                ElseIf searchby = "Item Name" Then
                    searchby = "Item_Name"
                    ssql = "Select Item_Id,Item_Name  from Item_Master  where Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like N'" & txtsearch.Text & "%' "
                End If

                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    ssql = ssql & " and Q.Department_ID=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If

                Dim ds As New DataTable
                ds = ob.Returntable(ssql, ob.getconnection)
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                    ' Dg.Columns.Clear()
                End If
                For i As Integer = 0 To ds.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = ds.Rows(i).Item("Item_id")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = ds.Rows(i).Item("Item_Name")

                Next
                ' Dg.DataSource = ds
                LBrec.Text = "Total : " & Trim(Dg.Rows.Count)
            Else
                txtsearch.Focus()
                loadg()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgDoc_Column_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dg.RowHeaderMouseClick
        RowDisplay()
    End Sub
    Private Sub DgDoc_Column_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg.CellClick
        RowDisplay()
    End Sub

    Private Sub DgDoc_Column_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            RowDisplay()
        End If
    End Sub

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try
            'Slab1 = Val(MdiMain
            clsVariables.ReportName = "ItemMaster.rpt"
            clsVariables.ReportSql = "{Item_Master.Company_id}=" & clsVariables.CompnyId
            ' clsVariables.ReportSql = clsVariables.ReportSql & " and {Quality_Master.Department_id}=" & Val(MdiMain.ComboDept.SelectedValue)
            clsVariables.Repheader = "Item Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtProductId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpurchaseid.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtProductId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpurchaseid.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtProductId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F2 Then
            clsVariables.HelpId = "Quality_Id"
            clsVariables.HelpName = "Quality_Name"
            clsVariables.TbName = "Quality_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Quality_Name"
            HelpWin.tsql = "Select Quality_Id,Quality_Name from Quality_Master where  Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtpurchaseid.Text = clsVariables.RtnHelpId
                Txtsalesid.Text = clsVariables.RtnHelpName
                TxtPkgUnit.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then
            clsVariables.HelpId = "Quality_Id"
            clsVariables.HelpName = "Quality_Name"
            clsVariables.TbName = "Quality_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Quality_Id"
            HelpWin.tsql = "Select Quality_Id,Quality_Name from Quality_Master where  Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtpurchaseid.Text = clsVariables.RtnHelpId
                Txtsalesid.Text = clsVariables.RtnHelpName
                TxtPkgUnit.Focus()
            End If
        ElseIf e.KeyCode = Keys.F3 Then
            Dg.Focus()
        End If
    End Sub

    Private Sub TxtProductId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpurchaseid.LostFocus
        Textreset(sender)
    End Sub
    Private Sub TxtProductId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpurchaseid.Validated
        txtpurchaseid.Tag = ob.FindOneString("select Account_id from Account_Master Where Account_id=" & Val(txtpurchaseid.Text) & " or Account_name=N'" & Trim(txtpurchaseid.Text) & "'", ob.getconnection())
        If Val(txtpurchaseid.Tag) <> 0 Then
            txtpurchaseid.Text = ob.FindOneString("select Account_name from Account_Master Where Account_id=" & txtpurchaseid.Tag & " ", ob.getconnection())

        End If
        'Try

        '    If Val(txtpurchaseid.Text) <> 0 Then
        '        ssql = "Select Quality_Name from Quality_Master where  Quality_Id= " & Val(txtpurchaseid.Text) & " and Company_Id=" & clsVariables.CompnyId
        '        Dim dt As New DataTable
        '        dt = ob.Returntable(ssql, ob.getconnection())
        '        If dt.Rows.Count <> 0 Then
        '            Txtsalesid.Text = dt.Rows(0).Item(0).ToString
        '        Else
        '            If ButAdd.Enabled = False Then
        '                MsgBox("Invalid Product Id")
        '                Txtsalesid.Text = ""
        '                txtpurchaseid.Focus()
        '            End If

        '        End If
        '    Else
        '        Txtsalesid.Text = ""
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub

    Private Sub TxtUnit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPkgUnit.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPkgUnit.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtUnit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPkgUnit.LostFocus
        Textreset(sender)
    End Sub
    Private Sub TxtPadtRate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPadtRate.GotFocus, TxtsaleRate.GotFocus, TxtDiscPer.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPadtRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPadtRate.KeyPress, TxtsaleRate.KeyPress, TxtDiscPer.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtPadtRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPadtRate.LostFocus, TxtsaleRate.LostFocus, TxtDiscPer.LostFocus
        Textreset(sender)
    End Sub
    Private Sub TxtPadtRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPadtRate.Validating
        If CheckNumeric(sender, e) = True Then
        End If
    End Sub

    Private Sub TxtsaleRate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtsaleRate.Validating
        If CheckNumeric(sender, e) = True Then
        End If
    End Sub

    Private Sub Txtrebate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDiscPer.Validating
        If CheckNumeric(sender, e) = True Then
        End If
    End Sub

    Private Sub TxtHelpAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHelpAmt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtHelpAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHelpAmt.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtHelpAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHelpAmt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtCommAmt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCommAmt.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtCommAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCommAmt.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtCommAmt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCommAmt.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtOldItemId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOldItemId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtOldItemId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOldItemId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub TxtOldItemId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOldItemId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtBharti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBharti.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtBharti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBharti.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub

    Private Sub TxtBharti_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBharti.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtHSNCODE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHSNCODE.GotFocus, txtBarCode.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtHSNCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHSNCODE.KeyPress, txtBarCode.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtHSNCODE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtHSNCODE.LostFocus, txtBarCode.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtVatper_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVatper.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtVatper_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVatper.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtVatper_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVatper.LostFocus
        Textreset(sender)
    End Sub


    Private Sub TxtAddvatPer_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddvatPer.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtAddvatPer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAddvatPer.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtAddvatPer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAddvatPer.LostFocus
        Textreset(sender)
    End Sub

    Private Sub ComboUnit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbproduct.Enter
        If ButAdd.Enabled = False Then
            '  ComboUnit = ob.returncombo(sender, "Select Distinct Unit from Item_master where Company_id=" & clsVariables.CompnyId, ob.getconnection)
        End If
    End Sub

    Private Sub ComboUnit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmbproduct.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub TxtPacking_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPacking.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtPacking_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPacking.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub TxtPacking_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPacking.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtHelpAmt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtHelpAmt.Validating
        CheckNumeric(sender, e)
    End Sub

    Private Sub TxtCommAmt_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCommAmt.Validating
        CheckNumeric(sender, e)
    End Sub

    Private Sub TxtVatper_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtVatper.Validating
        CheckNumeric(sender, e)
    End Sub

    Private Sub TxtAddvatPer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAddvatPer.Validating
        CheckNumeric(sender, e)
    End Sub



    Private Sub txtcgst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgst.GotFocus
        Textactive(sender)

    End Sub

    Private Sub txtcgst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcgst.KeyPress
        tabkey(sender, e)
        Amount(sender, e)

    End Sub

    Private Sub txtcgst_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcgst.LostFocus
        Textreset(sender)

    End Sub

    Private Sub txtsgst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgst.GotFocus
        Textactive(sender)

    End Sub

    Private Sub txtsgst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsgst.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub txtsgst_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtsgst.LostFocus
        Textreset(sender)

    End Sub

    Private Sub txtigst_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigst.GotFocus
        Textactive(sender)

    End Sub

    Private Sub txtigst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtigst.KeyPress
        tabkey(sender, e)
        Amount(sender, e)
    End Sub

    Private Sub Cmbdepatment_Keydown(sender As Object, e As KeyEventArgs) Handles Txtsalesid.KeyDown, txtpurchaseid.KeyDown, Cmbdepatment.KeyDown
        ' tabkey(sender, e)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Txtsalesid_Validated(sender As Object, e As EventArgs) Handles Txtsalesid.Validated
        Txtsalesid.Tag = ob.FindOneString("select Account_id from Account_Master Where Account_id=" & Val(Txtsalesid.Text) & " or Account_name=N'" & Trim(Txtsalesid.Text) & "'", ob.getconnection())
        If Val(Txtsalesid.Tag) <> 0 Then
            Txtsalesid.Text = ob.FindOneString("select Account_name from Account_Master Where Account_id=" & Txtsalesid.Tag & " ", ob.getconnection())

        End If
    End Sub

    Private Sub Cmbdepatment_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Cmbdepatment.Validating

    End Sub

    Private Sub groupname_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles groupname.Validating
        groupname.Tag = ob.FindOneString("select Product_Id from Product_Master Where Product_Id=" & Val(groupname.Text) & " or Product_Name=N'" & Trim(groupname.Text) & "'", ob.getconnection())
        If Val(groupname.Tag) <> 0 Then
            groupname.Text = ob.FindOneString("select Product_Name from Product_Master Where Product_Id=" & groupname.Tag & " ", ob.getconnection())

        End If
    End Sub

    Private Sub txtigst_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtigst.LostFocus
        Textreset(sender)

    End Sub
End Class
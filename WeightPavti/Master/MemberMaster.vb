Imports WeightPavti.CLS
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text.RegularExpressions

'Imports RustemSoft.DataGridViewColumns


Public Class MemberMaster
    Dim isadd As Boolean
    Dim imgPic As String = "NoImage.JPG"
    Dim imgSign As String = "NoImage.JPG"
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
        DgDoc_Village.Enabled = True
        cmbSearchby.Enabled = True
        txtsearch.Enabled = True
        txtAddres.Enabled = False
        txtDOB.Enabled = False
        txtEngmemName.Enabled = False
        txtGujmemname.Enabled = False
        txtMemberId.Enabled = False
        txtNominee.Enabled = False
        txtNomineeAddress.Enabled = False
        txtPhoneNo.Enabled = False
        txtVillageId.Enabled = False
        txtVillageName.Enabled = False
        Cmdgender.Enabled = False
        cmbRelationNominee.Enabled = False
        btnLoadPhoto.Enabled = False
        btnLoadSignature.Enabled = False
        txtMobileNO.Enabled = False
        txtjoinDate.Enabled = False
        CmbCurrant.Enabled = False
        txtFamilyId.Enabled = False
        txtFamilyName.Enabled = False
        txtsavingAccountId.Enabled = False
        cmbLoanOverDue.Enabled = False
        ComboCaste.Enabled = False
        ComboSubCaste.Enabled = False
        txtSurName.Enabled = False
        TxtSecondName.Enabled = False
        TxtThirdame.Enabled = False
        ComboMemberType.Enabled = False
        TxtVatNo.Enabled = False
        TXtdepartmentId.Enabled = False
        txtDepartmentName.Enabled = False
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
        DgDoc_Village.Enabled = False
        cmbSearchby.Enabled = False
        txtsearch.Enabled = False
        txtAddres.Enabled = True
        txtDOB.Enabled = True
        txtEngmemName.Enabled = True
        txtGujmemname.Enabled = True
        txtMemberId.Enabled = True
        txtNominee.Enabled = True
        txtNomineeAddress.Enabled = True
        txtPhoneNo.Enabled = True
        txtVillageId.Enabled = True
        txtVillageName.Enabled = True
        Cmdgender.Enabled = True
        cmbRelationNominee.Enabled = True
        btnLoadPhoto.Enabled = True
        btnLoadSignature.Enabled = True
        txtMobileNO.Enabled = True
        cmbLoanOverDue.Enabled = True
        txtFamilyId.Enabled = True
        txtFamilyName.Enabled = True
        CmbCurrant.Enabled = True
        txtsavingAccountId.Enabled = True
        txtjoinDate.Enabled = True
        ComboCaste.Enabled = True
        ComboSubCaste.Enabled = True
        txtSurName.Enabled = True
        TxtSecondName.Enabled = True
        TxtThirdame.Enabled = True
        ComboMemberType.Enabled = True
        TxtVatNo.Enabled = True
        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    TXtdepartmentId.Enabled = False
        '    txtDepartmentName.Enabled = False
        'Else
        '    TXtdepartmentId.Enabled = True
        '    txtDepartmentName.Enabled = True
        'End If
    End Sub
    Public Sub cleartext()
        txtVillageId.Clear()
        txtVillageName.Clear()

        txtAddres.Clear()
        txtDOB.Text = Now.Date
        txtEngmemName.Clear()
        txtGujmemname.Clear()
        txtMemberId.Clear()
        txtNominee.Clear()
        txtNomineeAddress.Clear()
        txtPhoneNo.Clear()
        cmbSearchby.SelectedIndex = 0
        Cmdgender.SelectedIndex = 0
        cmbRelationNominee.SelectedIndex = 0
        cmbSearchby.SelectedIndex = 0
        txtMobileNO.Clear()
        ComboSubCaste.SelectedIndex = 3
        ComboCaste.SelectedIndex = 4
        CmbCurrant.SelectedIndex = 0
        txtsavingAccountId.Clear()
        txtjoinDate.Text = Format(Now.Date, "dd/MM/yyyy")
        txtDOB.Text = Format(Now.Date, "dd/MM/yyyy")
        cmbLoanOverDue.SelectedIndex = 1
        lblPhoto.Text = "Nothing Image"
        LblSign.Text = "Nothing Image"
        txtPhotopath.Text = ImagePath & "Member\P"
        txtSignPath.Text = ImagePath & "Member\S"
        txtFamilyId.Clear()
        txtFamilyName.Clear()
        ImgPhoto.Image = Nothing
        ImgSignature.Image = Nothing
        ComboCaste.Text = ""
        ComboSubCaste.Text = ""
        TxtSecondName.Clear()
        TxtThirdame.Clear()
        TxtVatNo.Clear()
        txtgstno.Text = "24"
        txtEmailID.Clear()
        'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    TXtdepartmentId.Text = MdiMain.ComboDept.SelectedValue
        '    txtDepartmentName.Text = MdiMain.ComboDept.Text
        'Else
        '    TXtdepartmentId.Clear()
        '    txtDepartmentName.Clear()
        'End If
    End Sub
    Public Sub loadg()
        'Try
        '    Dim sql As String
        '    sql = "Select a.Member_Id,a.member_Name,B.Village_Name,a.Address, English_member_name"
        '    'sql = sql & ",a.Birth_Date,a.Male_Female,a.Currant,a.Loan_Over_Due,a.Join_Date,a.Savings_Account_id,a.Phone_NO,a.Mobile_No, "
        '    'sql = sql & "a.Member_Nominal,a.Member_Nominal_Address,a.Nominee,a.Image_path,a.Sign_path "
        '    sql = sql & " from Member_master a LEFT OUTER JOIN Village_Master b"
        '    sql = sql & "  on a.company_Id=b.company_Id and a.village_id=b.Village_id "
        '    sql = sql & " Where a.company_Id=" & clsVariables.CompnyId
        '    'If Len(MdiMain.ComboDept.Text) > 0 Then
        '    '    sql = sql & " and a.Department_ID in " & clsVariables.sdepartment
        '    'End If

        '    sql = sql & " order by Member_id"
        '    DgDoc_Village.DataSource = ob.Returntable(sql, ob.getconnection())
        '    LBrec.Text = "Total : " & Trim(DgDoc_Village.Rows.Count)
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try
        Dim dt As DataTable = ob.Returntable("select Member_id,Member_Name from Member_master  Order By Member_id", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dg.Rows.Count > 0 Then
                Dg.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dg.Rows.Add()
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Member_id")
                Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Member_Name")

            Next
        End If
    End Sub
    Private Sub txtNominee_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNominee.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtNomineeAddress_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomineeAddress.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub MemberMaster_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, btnLoadPhoto.KeyUp, btnLoadSignature.KeyUp, BuExit.KeyUp, ButAdd.KeyUp, ButCAncel.KeyUp, ButDelete.KeyUp, ButEdit.KeyUp, ButFind.KeyUp, ButFirst.KeyUp, butlast.KeyUp, ButNExt.KeyUp, BUtPrev.KeyUp, ButSave.KeyUp, txtAddres.KeyUp, txtDOB.KeyUp, txtEngmemName.KeyUp, txtFamilyName.KeyUp, txtGujmemname.KeyUp, txtjoinDate.KeyUp, txtMemberId.KeyUp, txtMobileNO.KeyUp, txtNominee.KeyUp, txtNomineeAddress.KeyUp, txtPhoneNo.KeyUp, txtPhotopath.KeyUp, txtsavingAccountId.KeyUp, txtsearch.KeyUp, txtSignPath.KeyUp, txtVillageName.KeyUp, ButPrint.KeyUp, ComboCaste.KeyUp, ComboSubCaste.KeyUp, txtSurName.KeyUp, TxtSecondName.KeyUp, TxtThirdame.KeyUp
        If e.KeyCode = Keys.F3 Then
            DgDoc_Village.Focus()
        End If
    End Sub
    Public Sub FillMemberType()
        'Try
        '    ssql = "Select Type_Id,Type_Name from Member_Type_Master where Company_Id=" & clsVariables.CompnyId
        '    ComboMemberType.DataSource = ob.Returntable(ssql, ob.getconnection())
        '    ComboMemberType.ValueMember = "Type_Id"
        '    ComboMemberType.DisplayMember = "Type_Name"
        '    If ComboMemberType.Items.Count > 0 Then
        '        ComboMemberType.SelectedIndex = 0
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message.ToString)
        'End Try
    End Sub
    Private Sub MemberMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Me.Tag
        If ob.AuthorizedTo(AccessMode.ViewMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            Me.Hide()
            messageright(AccessMode.ViewMode)
            Me.Close()
            Exit Sub
        End If
        'Me.BackgroundImage = MdiMain.PicMaster.Image
        DgDoc_Village.DefaultCellStyle.ForeColor = Color.Black
        Me.MdiParent = MdiMain
        txtDOB.Text = Format(Now.Date, "dd/MM/yyyy")
        txtjoinDate.Text = Format(Now.Date, "dd/MM/yyyy")
        FillMemberType()
        ButAdd_Click(e, e)
        Dg.Columns.Add("Id", "Id")
        Dg.Columns.Add("Name", "Name")
        Dg.Columns(0).Width = 60
        Dg.Columns(1).Width = 250
        ComboMemberType.SelectedValue = 1

        loadg()
        'DgDoc_Village.Columns(0).HeaderText = "Id"
        'DgDoc_Village.Columns(0).Width = 60
        'DgDoc_Village.Columns(1).Width = 250
        'DgDoc_Village.Columns(1).HeaderText = "Name"
        'DgDoc_Village.Columns(1).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        'DgDoc_Village.Columns(2).HeaderText = "Village Name"
        'DgDoc_Village.Columns(2).Width = 120
        'DgDoc_Village.Columns(2).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)
        'DgDoc_Village.Columns(3).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Bold)

        auto()

    End Sub
    Public Sub auto()
        Dim AutoComp As New AutoCompleteStringCollection()
        Dim dt As DataTable
        Dim i As Integer
        dt = ob.Returntable("select Village_Name from Village_Master", ob.getconnection())
        For i = 0 To dt.Rows.Count - 1
            AutoComp.Add(dt.Rows(i).Item("Village_Name"))
        Next
        txtVillageName.AutoCompleteMode = AutoCompleteMode.Suggest
        txtVillageName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtVillageName.AutoCompleteCustomSource = AutoComp
    End Sub
    Private Sub BuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuExit.Click
        Me.Close()
    End Sub
    Private Sub ButAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
        If ob.AuthorizedTo(AccessMode.AddMode, Me.Tag, ob.getconnection(ob.Getconn)) = False Then
            butstyle1()
            messageright(AccessMode.AddMode)
            Exit Sub
        End If
        butstyle2()
        cleartext()
        isadd = True
        Call DocNo_AutoID("Member_Id", "Member_Master")
        ComboMemberType.Focus()
    End Sub
    Public Function DocNo_AutoID(ByVal Member_Id As String, ByVal sTable As String) As Integer
        Try
            Dim ds As New DataSet
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ssql = "select isnull(max(" & Member_Id & "),0)+1 as Member_Id from  Member_Master where Company_Id=" & Val(clsVariables.CompnyId)
            'If Len(MdiMain.ComboDept.Text) > 0 Then
            '    ssql = ssql & " and Department_ID=" & Val(MdiMain.ComboDept.SelectedValue)
            'End If
            ssql = ssql & " AND mEMBER_iD<>999999"
            sCommands.setsqlCommand(ds, clsVariables.sqlDataAdapter, ssql, sTable)
            Dim sDataRow As DataRow = ds.Tables(0).Rows(0)
            DocNo_AutoID = sDataRow("Member_Id")
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            txtMemberId.Text = DocNo_AutoID
            Return DocNo_AutoID
        Catch ex As Exception
            sCommands.setCommandDatasetClose(sVariables.sDataSet, clsVariables.sqlDataAdapter)
            DocNo_AutoID = 1
            txtMemberId.Text = DocNo_AutoID
        End Try
    End Function
    Private Sub btnLoadPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto.Click
        Try
            'Dim dlgImage As FileDialog = New OpenFileDialog()
            Dim dlgImagePhoto As FileDialog = New OpenFileDialog()
            'dlgImagePhoto.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
            dlgImagePhoto.Filter = "Image File (*.jpg)|*.jpg"
            If dlgImagePhoto.ShowDialog() = DialogResult.OK Then
                imgPic = dlgImagePhoto.FileName
                'imgPic = "\" + txtMemberId.Text + "Ph.jpg"
                txtPhotopath.Text = imgPic
                Dim fPhoto As New FileInfo(imgPic)
                lblPhoto.Text = fPhoto.Name
                Dim newimg As New Bitmap(imgPic)
                ImgPhoto.SizeMode = PictureBoxSizeMode.StretchImage
                ImgPhoto.Image = DirectCast(newimg, Image)
            End If
            dlgImagePhoto = Nothing
        Catch ae As System.ArgumentException
            imgPic = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub btnLoadSignature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSignature.Click
        Try
            'Dim dlgImage As FileDialog = New OpenFileDialog()
            Dim dlgImageSign As FileDialog = New OpenFileDialog()
            ' dlgImageSign.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
            dlgImageSign.Filter = "Image File (*.jpg)|*.jpg"
            If dlgImageSign.ShowDialog() = DialogResult.OK Then
                imgSign = dlgImageSign.FileName
                txtSignPath.Text = imgSign
                'imgSign = "\" + txtMemberId.Text + "Sig.jpg"
                Dim fSign As New FileInfo(imgSign)
                LblSign.Text = fSign.Name
                Dim newimg As New Bitmap(imgSign)
                ImgSignature.SizeMode = PictureBoxSizeMode.StretchImage
                ImgSignature.Image = DirectCast(newimg, Image)
            End If
            dlgImageSign = Nothing
        Catch ae As System.ArgumentException
            imgSign = " "
            MessageBox.Show(ae.Message.ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString())
        End Try
    End Sub
    Private Sub txtMemberId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberId.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtMemberId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemberId.KeyPress
        tabkey(sender, e)
        Digit(sender, e)
    End Sub
    Private Sub txtMemberId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberId.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtGujmemname_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGujmemname.GotFocus
        Textactiveg(sender)
    End Sub
    Private Sub txtGujmemname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGujmemname.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtGujmemname_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGujmemname.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtEngmemName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEngmemName.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtEngmemName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEngmemName.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtEngmemName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEngmemName.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtDOB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOB.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtDOB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDOB.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtDOB_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOB.LostFocus
        Textreset(sender)
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
    Private Sub txtPhoneNo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhoneNo.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtPhoneNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhoneNo.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtPhoneNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhoneNo.LostFocus
        Textreset(sender)
    End Sub
    Private Sub Cmdgender_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmdgender.Enter
        Cmdgender.DroppedDown = True
    End Sub
    Private Sub cmbRelationNominee_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRelationNominee.Enter
        cmbRelationNominee.DroppedDown = True
    End Sub
    Private Sub cmbCategory_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRelationNominee.GotFocus, cmbSearchby.GotFocus, txtPhoneNo.GotFocus, txtsearch.GotFocus, Cmdgender.GotFocus
        Textactiveg(sender)
    End Sub
    Private Sub cmbCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRelationNominee.KeyPress, cmbSearchby.KeyPress, txtNominee.KeyPress, txtNomineeAddress.KeyPress, txtsearch.KeyPress, Cmdgender.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtFamilyId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamilyId.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtFamilyId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFamilyId.KeyUp
        If e.KeyCode = Keys.F2 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Member_id"
            clsVariables.HelpName = "Member_Name"
            clsVariables.TbName = "member_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Member_Name"
            HelpWin.tsql = "Select Member_Id,Member_Name from member_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtFamilyId.Text = clsVariables.RtnHelpId
                txtFamilyName.Text = clsVariables.RtnHelpName
                txtMobileNO.Focus()
            End If

            'cmbCast.Focus()

        ElseIf e.KeyCode = Keys.F4 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Member_id"
            clsVariables.HelpName = "Member_Name"
            clsVariables.TbName = "member_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Member_Id"
            HelpWin.tsql = "Select Member_Id,Member_Name from member_Master where Company_id=" & Val(clsVariables.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtFamilyId.Text = clsVariables.RtnHelpId
                txtFamilyName.Text = clsVariables.RtnHelpName
                txtMobileNO.Focus()
            End If

        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Village.Focus()
        End If
    End Sub
    Private Sub cmbCategory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRelationNominee.LostFocus, cmbSearchby.LostFocus, txtNominee.LostFocus, txtNomineeAddress.LostFocus, txtPhoneNo.LostFocus, txtsearch.LostFocus, Cmdgender.LostFocus
        Textreset(sender)
    End Sub
    Private Sub txtVillageId_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.GotFocus
        Textactive(sender)
    End Sub
    Private Sub txtVillageId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVillageId.KeyPress
        tabkey(sender, e)
    End Sub
    Private Sub txtVillageId_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVillageId.KeyUp
        If e.KeyCode = Keys.F2 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Village_id"
            clsVariables.HelpName = "Village_Name"
            clsVariables.TbName = "Village_Master"
            HelpWin.scodename = "Name"
            HelpWin.sorderby = " order by Village_Name"
            HelpWin.tsql = "Select Village_id,Village_Name from Village_Master where company_id=" & Val(clsFunctions.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtVillageId.Text = clsVariables.RtnHelpId

                txtVillageName.Text = clsVariables.RtnHelpName
                txtFamilyId.Focus()
            End If

        ElseIf e.KeyCode = Keys.F4 Then
            'txtAccountId.Clear()
            'MsgBox("Help!!!")
            clsVariables.HelpId = "Village_id"
            clsVariables.HelpName = "Village_Name"
            clsVariables.TbName = "Village_Master"
            HelpWin.scodename = "Code"
            HelpWin.sorderby = " order by Village_Id"
            HelpWin.tsql = "Select Village_id,Village_Name from Village_Master where company_id=" & Val(clsFunctions.CompnyId)
            HelpWin.ShowDialog()
            If clsVariables.RtnHelpId <> "" Then
                txtVillageId.Text = clsVariables.RtnHelpId
                txtVillageName.Text = clsVariables.RtnHelpName
                txtFamilyId.Focus()
            End If

        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Village.Focus()
        End If
    End Sub

    Private Sub txtVillageId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtVillageId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVillageId.TextChanged

    End Sub
    Dim ssql As String
    Private Sub txtVillageId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVillageId.Validated
        txtVillageName.Focus()
        'Try

        '    If txtVillageId.Text <> "" Then
        '        ssql = "Select Village_Name from Village_Master where Village_id= " & Val(txtVillageId.Text) & " and Company_Id=" & Val(clsVariables.CompnyId) & ""
        '        Dim dt As New DataTable
        '        dt = ob.Returntable(ssql, ob.getconnection())
        '        If dt.Rows.Count <> 0 Then
        '            txtVillageName.Text = dt.Rows(0).Item(0).ToString
        '        Else
        '            If ButAdd.Enabled = False Then
        '                MsgBox("Invalid Village Id")
        '                txtVillageName.Text = ""
        '                txtVillageId.Focus()
        '            End If

        '        End If
        '    Else
        '        txtVillageName.Text = ""
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Private Sub txtFamilyId_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamilyId.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtFamilyId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFamilyId.Validated
        Try
            If Val(txtFamilyId.Text) <> 0 Then
                ssql = "Select Member_Name from member_Master where member_id= " & Val(txtFamilyId.Text) & " and Company_id=" & Val(clsVariables.CompnyId)
                Dim dt As New DataTable
                dt = ob.Returntable(ssql, ob.getconnection())
                If dt.Rows.Count <> 0 Then
                    txtFamilyName.Text = dt.Rows(0).Item(0).ToString
                Else
                    If ButAdd.Enabled = False Then
                        MsgBox("Invalid Village Id")
                        txtFamilyName.Text = ""
                        txtFamilyId.Focus()
                    End If

                End If
            Else
                txtFamilyName.Text = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtMobileNO_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMobileNO.GotFocus, txtjoinDate.GotFocus, txtsavingAccountId.GotFocus
        Textactive(sender)
    End Sub

    Private Sub txtMobileNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMobileNO.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtMobileNO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMobileNO.LostFocus, txtsavingAccountId.LostFocus, txtjoinDate.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtMobileNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMobileNO.TextChanged

    End Sub



    Private Sub txtFamilyId_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFamilyId.TextChanged

    End Sub

    Private Sub txtjoinDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtjoinDate.KeyPress, txtsavingAccountId.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtjoinDate_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtjoinDate.MaskInputRejected

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
        If Len(txtMemberId.Text) = 0 Then
            MessageBox.Show("Nothing For Edit", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            butstyle2()
            isadd = False
            txtMemberId.Enabled = False
            txtGujmemname.Focus()
        End If
        'Else
        'butstyle1()
        'End If
    End Sub
    Public Function Entry_Move(ByVal str As String) As Boolean
        Try
            Dim sql As String = ""
            If LCase(str) = "first" Then
                sql = "Select Top 1 * from member_Master where Company_id=" & Val(clsVariables.CompnyId)
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    sql = sql & " and Department_id=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If
                sql = sql & " Order by Company_Id,Member_id"
            ElseIf LCase(str) = "next" Then
                sql = "Select Top 1 * from member_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and member_id>" & Val(txtMemberId.Text)
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    sql = sql & " and Department_id=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If
                sql = sql & " Order by Company_Id ,member_id "
            ElseIf LCase(str) = "prev" Then
                sql = "Select Top 1 * from member_Master "
                sql = sql & " where company_id=" & Val(clsVariables.CompnyId)
                sql = sql & " and Member_id<" & Val(txtMemberId.Text)
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    sql = sql & " and Department_id=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If
                sql = sql & " Order by Company_Id desc,member_id desc"
            ElseIf LCase(str) = "last" Then
                sql = "Select Top 1 * from member_Master where Company_id=" & Val(clsVariables.CompnyId) & " "
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    sql = sql & " and Department_id=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If
                sql = sql & " Order by Company_Id desc,member_id desc"
            End If
            Dim dt As New DataTable
            dt = ob.Returntable(sql, ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("member_id"))
                Entry_Move = True
            Else
                Entry_Move = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Function
    Public Sub filltext(ByVal Comp_id As Integer, ByVal vill_id As Long)
        Try
            cleartext()
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from member_Master where Company_id=" & Val(Comp_id) & " and member_id=" & Val(vill_id), ob.getconnection(ob.Getconn()))
            If dt.Rows.Count > 0 Then
                txtMemberId.Text = IIf(IsDBNull(dt.Rows(0).Item("member_id")), "", dt.Rows(0).Item("member_id"))
                txtGujmemname.Text = IIf(IsDBNull(dt.Rows(0).Item("member_Name")), "", dt.Rows(0).Item("member_Name"))
                txtEngmemName.Text = IIf(IsDBNull(dt.Rows(0).Item("English_member_Name")), "", dt.Rows(0).Item("English_member_Name"))
                txtAddres.Text = IIf(IsDBNull(dt.Rows(0).Item("Address")), "", dt.Rows(0).Item("Address"))
                txtVillageId.Text = IIf(IsDBNull(dt.Rows(0).Item("Village_id")), "", dt.Rows(0).Item("Village_id"))
                txtVillageName.Text = ob.FindOneString("Select Village_name from Village_master where Village_id=" & Val(txtVillageId.Text) & " and Company_Id=" & Val(clsVariables.CompnyId), ob.getconnection())
                txtFamilyId.Text = IIf(IsDBNull(dt.Rows(0).Item("family_id")), "", dt.Rows(0).Item("family_id"))
                txtFamilyName.Text = ob.FindOneString("Select member_name from member_master where Member_id=" & Val(txtFamilyId.Text) & " and Company_id=" & Val(clsVariables.CompnyId), ob.getconnection())
                txtDOB.Text = Format(CDate(IIf(IsDBNull(dt.Rows(0).Item("Birth_date")), Now.Date, dt.Rows(0).Item("Birth_date"))), "dd/MM/yyyy")
                If IIf(IsDBNull(dt.Rows(0).Item("male_Female")), "", dt.Rows(0).Item("male_female")) = "M" Then
                    Cmdgender.SelectedIndex = 0
                ElseIf IIf(IsDBNull(dt.Rows(0).Item("male_Female")), "", dt.Rows(0).Item("male_female")) = "F" Then
                    Cmdgender.SelectedIndex = 1
                End If
                If (IIf(IsDBNull(dt.Rows(0).Item("Currant")), False, dt.Rows(0).Item("Currant"))) = True Then
                    CmbCurrant.SelectedIndex = 0
                Else
                    CmbCurrant.SelectedIndex = 1
                End If
                txtjoinDate.Text = Format(CDate(IIf(IsDBNull(dt.Rows(0).Item("join_Date")), Now.Date, dt.Rows(0).Item("Join_Date"))), "dd/MM/yyyy")
                txtsavingAccountId.Text = IIf(IsDBNull(dt.Rows(0).Item("Savings_Account_id")), "", dt.Rows(0).Item("Savings_Account_id"))
                txtPhoneNo.Text = IIf(IsDBNull(dt.Rows(0).Item("Phone_no")), "", dt.Rows(0).Item("Phone_no"))
                txtMobileNO.Text = IIf(IsDBNull(dt.Rows(0).Item("Mobile_no")), "", dt.Rows(0).Item("Mobile_no"))
                txtNominee.Text = IIf(IsDBNull(dt.Rows(0).Item("Member_Nominal")), "", dt.Rows(0).Item("Member_Nominal"))
                txtNomineeAddress.Text = IIf(IsDBNull(dt.Rows(0).Item("Member_Nominal_Address")), "", dt.Rows(0).Item("Member_Nominal_Address"))
                cmbRelationNominee.Text = IIf(IsDBNull(dt.Rows(0).Item("Nominee")), "", dt.Rows(0).Item("Nominee"))
                txtPhotopath.Text = txtPhotopath.Text & Trim(txtMemberId.Text) & ".JPG"
                txtSignPath.Text = txtSignPath.Text & Trim(txtMemberId.Text) & ".JPG"
                'txtPhotopath.Text = IIf(IsDBNull(dt.Rows(0).Item("Image_path")), "", dt.Rows(0).Item("Image_path"))
                'txtSignPath.Text = IIf(IsDBNull(dt.Rows(0).Item("Sign_path")), "", dt.Rows(0).Item("Sign_path"))
                If (IIf(IsDBNull(dt.Rows(0).Item("Loan_Over_Due")), False, dt.Rows(0).Item("Loan_Over_Due"))) = True Then
                    cmbLoanOverDue.SelectedIndex = 0
                Else
                    cmbLoanOverDue.SelectedIndex = 1
                End If

                If FileIO.FileSystem.FileExists(txtPhotopath.Text) = True Then
                    Dim newimg As New Bitmap(txtPhotopath.Text)
                    Dim fPhoto As New FileInfo(txtPhotopath.Text)
                    lblPhoto.Text = fPhoto.Name
                    ImgPhoto.SizeMode = PictureBoxSizeMode.StretchImage
                    ImgPhoto.Image = DirectCast(newimg, Image)
                Else
                    ImgPhoto.Image = Nothing
                    lblPhoto.Text = "Nothing"
                End If
                If FileIO.FileSystem.FileExists(txtSignPath.Text) = True Then
                    Dim newimg As New Bitmap(txtSignPath.Text)
                    Dim fPhoto As New FileInfo(txtSignPath.Text)
                    LblSign.Text = fPhoto.Name
                    ImgSignature.SizeMode = PictureBoxSizeMode.StretchImage
                    ImgSignature.Image = DirectCast(newimg, Image)
                Else
                    ImgSignature.Image = Nothing
                    LblSign.Text = "Nothing"
                End If
                ComboCaste.Text = ob.IfNullThen(dt.Rows(0).Item("Caste"), "")
                ComboSubCaste.Text = ob.IfNullThen(dt.Rows(0).Item("Sub_Caste"), "")
                txtSurName.Text = ob.IfNullThen(dt.Rows(0).Item("Surname"), "")
                TxtSecondName.Text = ob.IfNullThen(dt.Rows(0).Item("Second_name"), "")
                TxtThirdame.Text = ob.IfNullThen(dt.Rows(0).Item("Third_Name"), "")
                ComboMemberType.Text = ob.IfNullThen(dt.Rows(0).Item("Member_Type"), 0)
                TxtVatNo.Text = ob.IfNullThen(dt.Rows(0).Item("Vat_No"), "")
                ' TXtdepartmentId.Text = ob.IfNullThen(dt.Rows(0).Item("Department_id"), 0)
                txtgstno.Text = ob.IfNullThen(dt.Rows(0).Item("GST_No"), 0)
                txtEmailID.Text = ob.IfNullThen(dt.Rows(0).Item("Email_Id"), 0)
                'txtDepartmentName.Text = ob.FindOneString("Select Department_name from Department_Master where Department_id=" & Val(TXtdepartmentId.Text) & " and Company_id=" & clsVariables.CompnyId, ob.getconnection(ob.Getconn()))
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
                If ob.CheckMemberMaster(Val(txtMemberId.Text), ob.getconnection) = True Then
                    MessageBox.Show("Entry Can't Be Deleted Because Effected By Another Data.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If MessageBox.Show("Do You Want To Delete This Entry...?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ob.Execute("Delete from member_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Member_Id=" & Val(txtMemberId.Text), ob.getconnection(ob.Getconn()))
                    ob.UpdateEditUser("member_Master", "Company_Id=" & clsVariables.CompnyId & " and Member_Id=" & Val(txtMemberId.Text), ob.getconnection(ob.Getconn(BackDbname)), True)
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

    Private Sub ButFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButFirst.Click
        Entry_Move("first")
    End Sub

    Private Sub ButNExt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButNExt.Click
        Entry_Move("next")
    End Sub

    Private Sub BUtPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtPrev.Click
        Entry_Move("prev")
    End Sub

    Private Sub ButLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butlast.Click
        Entry_Move("last")
    End Sub

    Private Sub ButCAncel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCAncel.Click
        butstyle1()
        filltext(Val(clsVariables.CompnyId), Val(txtMemberId.Text))
        ButAdd.Focus()
    End Sub

    Private Sub ButSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
        Try
            If Val(txtMemberId.Text) = 0 Then
                MessageBox.Show("Please Enter Member id", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtMemberId.Focus()
            ElseIf Len(txtGujmemname.Text) = 0 Then
                MessageBox.Show("Please Enter Member Name", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtGujmemname.Focus()
            ElseIf Len(txtEngmemName.Text) = 0 Then
                MessageBox.Show("Enetr Member Name", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtEngmemName.Focus()
            ElseIf ob.checkdate(txtDOB.Text) = True Then
                MessageBox.Show("Please Enter Birth Date", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDOB.Focus()
            ElseIf ob.checkdate(txtjoinDate.Text) = True Then
                MessageBox.Show("Please Enter Join Date", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtjoinDate.Focus()

            Else
                Dim sql As String
                If isadd Then
                    If ob.FindOneinteger("Select Count(*) from member_master where Company_id=" & Val(clsVariables.CompnyId) & " and Member_id=" & Val(txtMemberId.Text), ob.getconnection()) > 0 Then
                        MessageBox.Show("Entry Already Exists For Member Id=" & txtMemberId.Text, "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtMemberId.Focus()
                        GoTo p
                    End If
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection(ob.Getconn())
                    sql = "Insert into Member_Master (Company_id,Member_Id,member_Name,English_member_name,Address,Village_id,Family_Id,"
                    sql = sql & "Birth_Date,"
                    sql = sql & "Male_Female, Currant, "
                    sql = sql & " Loan_Over_Due, Join_Date,"
                    sql = sql & " Savings_Account_id, Phone_NO, Mobile_No, "
                    sql = sql & "Member_Nominal,Member_Nominal_Address,Nominee,Image_path,Sign_path,Surname,Caste,Sub_Caste,"
                    sql = sql & "Add_Date,"
                    sql = sql & " User_NAme,"
                    sql = sql & " Edit_DAte,"
                    sql = sql & " Edit_User_Name,Second_Name,Third_Name,Member_Type,vat_No,Department_Id,GST_No,Email_Id)values"
                    sql = sql & "(@Company_id,@Member_Id,@member_Name,@English_member_name,@Address,@Village_id,@Family_Id,"
                    sql = sql & "@Birth_Date,"
                    sql = sql & " @Male_Female,@Currant,"
                    sql = sql & " @Loan_Over_Due,@Join_Date,"
                    sql = sql & " @Savings_Account_id,@Phone_NO,@Mobile_No, "
                    sql = sql & "@Member_Nominal,@Member_Nominal_Address,@Nominee,@Image_path,@Sign_path,@Surname,@Caste,@Sub_Caste,"
                    sql = sql & "@Add_Date,"
                    sql = sql & "@User_NAme,"
                    sql = sql & " @Edit_DAte,"
                    sql = sql & "@Edit_User_Name,@Second_Name,@Third_Name,@Member_Type,@vat_no," & Val(TXtdepartmentId.Text) & ",@GST_No,@Email_Id)"
                    sqlcommand.CommandText = sql
                    sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    sqlcommand.Parameters.AddWithValue("@Member_Id", Trim(txtMemberId.Text))
                    sqlcommand.Parameters.AddWithValue("@member_Name", Trim(txtGujmemname.Text))
                    sqlcommand.Parameters.AddWithValue("@English_member_name", Trim(txtEngmemName.Text))
                    sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
                    sqlcommand.Parameters.AddWithValue("@Village_id", Trim(txtVillageId.Text))
                    sqlcommand.Parameters.AddWithValue("@Family_Id", Trim(txtFamilyId.Text))
                    sqlcommand.Parameters.AddWithValue("@Birth_Date", sFunction.DateConversion(txtDOB.Text))
                    sqlcommand.Parameters.AddWithValue("@Join_Date", sFunction.DateConversion(txtjoinDate.Text))
                    sqlcommand.Parameters.AddWithValue("@Male_Female", Trim(Mid(Cmdgender.Text, 1, 1)))
                    sqlcommand.Parameters.AddWithValue("@Currant", IIf(CmbCurrant.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Loan_Over_Due", IIf(cmbLoanOverDue.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Savings_Account_id", Trim(txtsavingAccountId.Text))
                    sqlcommand.Parameters.AddWithValue("@Phone_NO", Trim(txtPhoneNo.Text))
                    sqlcommand.Parameters.AddWithValue("@Mobile_No", Trim(txtMobileNO.Text))
                    sqlcommand.Parameters.AddWithValue("@Member_Nominal", Trim(txtNominee.Text))
                    sqlcommand.Parameters.AddWithValue("@Member_Nominal_Address", Trim(txtNomineeAddress.Text))
                    sqlcommand.Parameters.AddWithValue("@Nominee", Trim(cmbRelationNominee.Text))
                    sqlcommand.Parameters.AddWithValue("@Image_path", Trim(txtPhotopath.Text & txtMemberId.Text))
                    sqlcommand.Parameters.AddWithValue("@Sign_path", Trim(txtSignPath.Text & txtMemberId.Text))
                    sqlcommand.Parameters.AddWithValue("@Surname", Trim(txtSurName.Text))
                    sqlcommand.Parameters.AddWithValue("@Caste", Trim(ComboCaste.Text))
                    sqlcommand.Parameters.AddWithValue("@Sub_Caste", Trim(ComboSubCaste.Text))
                    sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
                    sqlcommand.Parameters.AddWithValue("@Second_Name", (Trim(TxtSecondName.Text)))
                    sqlcommand.Parameters.AddWithValue("@Third_Name", (Trim(TxtThirdame.Text)))
                    sqlcommand.Parameters.AddWithValue("@member_Type", Trim(ComboMemberType.Text))
                    sqlcommand.Parameters.AddWithValue("@Vat_No", TxtVatNo.Text)
                    sqlcommand.Parameters.AddWithValue("@GST_No", txtgstno.Text)
                    sqlcommand.Parameters.AddWithValue("@Email_ID", txtEmailID.Text)
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and member_Id=" & Val(txtMemberId.Text)
                    ob.UpdateIdmach("Member_Master", ssql, ob.getconnection, isadd)
                    ' insert()
                    loadg()
                Else
                    '       ob.UpdateEditUser("member_Master", "Company_Id=" & clsVariables.CompnyId & " and Member_Id=" & Val(txtMemberId.Text), ob.getconnection(ob.Getconn(BackDbname)))
                    Dim sqlcommand As New SqlClient.SqlCommand
                    sqlcommand.Connection = ob.getconnection()
                    sql = "Update Member_Master set member_Name=@member_Name,English_member_name=@English_member_name,Address=@Address"
                    sql = sql & " ,Village_id=@Village_id,Family_Id=@Family_Id,"
                    sql = sql & "Birth_Date=@Birth_Date,Surname=@Surname,Caste=@Caste,Sub_Caste=@Sub_Caste,"
                    sql = sql & "Male_Female=@Male_Female, Currant=@Currant, "
                    sql = sql & "Loan_Over_Due=@Loan_Over_Due,Join_Date=@Join_Date,"
                    sql = sql & "Savings_Account_id=@Savings_Account_id,Phone_NO=@Phone_NO,Mobile_No=@Mobile_No, "
                    sql = sql & "Member_Nominal=@Member_Nominal,Member_Nominal_Address=@Member_Nominal_Address,Nominee=@Nominee,"
                    sql = sql & "Image_path=@Image_path,Sign_path=@Sign_path,member_Type=@member_Type,"
                    sql = sql & "Edit_DAte=@Edit_DAte,"
                    sql = sql & "Edit_User_Name=@Edit_User_Name,Vat_no=@vat_no"
                    sql = sql & ",revision=isnull(revision,0)+1,Second_Name=@Second_Name,Third_Name=@Third_Name,GST_No=@GST_No,Email_Id = @Email_Id,"
                    sql = sql & "Department_id=" & Val(TXtdepartmentId.Text)
                    sql = sql & " where Company_id=" & Val(clsVariables.CompnyId)
                    sql = sql & " and member_id=" & Val(txtMemberId.Text)
                    sqlcommand.CommandText = sql
                    'sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
                    'sqlcommand.Parameters.AddWithValue("@Member_Id", Trim(txtMemberId.Text))
                    sqlcommand.Parameters.AddWithValue("@member_Name", Trim(txtGujmemname.Text))
                    sqlcommand.Parameters.AddWithValue("@English_member_name", Trim(txtEngmemName.Text))
                    sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
                    sqlcommand.Parameters.AddWithValue("@Village_id", Trim(txtVillageId.Text))
                    sqlcommand.Parameters.AddWithValue("@Family_Id", Trim(txtFamilyId.Text))
                    sqlcommand.Parameters.AddWithValue("@Birth_Date", sFunction.DateConversion(txtDOB.Text))
                    sqlcommand.Parameters.AddWithValue("@Join_Date", sFunction.DateConversion(txtjoinDate.Text))
                    sqlcommand.Parameters.AddWithValue("@Male_Female", Trim(Mid(Cmdgender.Text, 1, 1)))
                    sqlcommand.Parameters.AddWithValue("@Currant", IIf(CmbCurrant.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Loan_Over_Due", IIf(cmbLoanOverDue.Text = "YES", 1, 0))
                    sqlcommand.Parameters.AddWithValue("@Surname", Trim(txtSurName.Text))
                    sqlcommand.Parameters.AddWithValue("@Caste", Trim(ComboCaste.Text))
                    sqlcommand.Parameters.AddWithValue("@Sub_Caste", Trim(ComboSubCaste.Text))
                    sqlcommand.Parameters.AddWithValue("@Savings_Account_id", Trim(txtsavingAccountId.Text))
                    sqlcommand.Parameters.AddWithValue("@Phone_NO", Trim(txtPhoneNo.Text))
                    sqlcommand.Parameters.AddWithValue("@Mobile_No", Trim(txtMobileNO.Text))
                    sqlcommand.Parameters.AddWithValue("@Member_Nominal", Trim(txtNominee.Text))
                    sqlcommand.Parameters.AddWithValue("@Member_Nominal_Address", Trim(txtNomineeAddress.Text))
                    sqlcommand.Parameters.AddWithValue("@Nominee", Trim(cmbRelationNominee.Text))
                    sqlcommand.Parameters.AddWithValue("@Image_path", Trim(txtPhotopath.Text & txtMemberId.Text))
                    sqlcommand.Parameters.AddWithValue("@Sign_path", Trim(txtSignPath.Text & txtMemberId.Text))
                    'sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
                    'sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
                    sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
                    sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
                    sqlcommand.Parameters.AddWithValue("@Second_Name", (Trim(TxtSecondName.Text)))
                    sqlcommand.Parameters.AddWithValue("@Third_Name", (Trim(TxtThirdame.Text)))
                    sqlcommand.Parameters.AddWithValue("@member_Type", Trim(ComboMemberType.Text))
                    sqlcommand.Parameters.AddWithValue("@Vat_No", TxtVatNo.Text)
                    sqlcommand.Parameters.AddWithValue("@GST_No", txtgstno.Text)
                    sqlcommand.Parameters.AddWithValue("@Email_Id", txtEmailID.Text)
                    sqlcommand.ExecuteNonQuery()
                    sqlcommand.Parameters.Clear()
                    ssql = " Company_id=" & clsVariables.CompnyId
                    ssql = ssql & " and member_Id=" & Val(txtMemberId.Text)
                    ob.UpdateIdmach("Member_Master", ssql, ob.getconnection, isadd)
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
            sql = "Insert into Member_Master (Company_id,Member_Id,member_Name,English_member_name,Address,Village_id,Family_Id,"
            sql = sql & "Birth_Date,"
            sql = sql & "Male_Female, Currant, "
            sql = sql & " Loan_Over_Due, Join_Date,"
            sql = sql & " Savings_Account_id, Phone_NO, Mobile_No, "
            sql = sql & "Member_Nominal,Member_Nominal_Address,Nominee,Image_path,Sign_path,Surname,Caste,Sub_Caste,"
            sql = sql & "Add_Date,"
            sql = sql & " User_NAme,"
            sql = sql & " Edit_DAte,"
            sql = sql & " Edit_User_Name,Second_Name,Third_Name,Member_Type,vat_No,Department_Id,ip_Address,Mach_Name,GST_No,Email_Id)values"
            sql = sql & "(@Company_id,@Member_Id,@member_Name,@English_member_name,@Address,@Village_id,@Family_Id,"
            sql = sql & "@Birth_Date,"
            sql = sql & " @Male_Female,@Currant,"
            sql = sql & " @Loan_Over_Due,@Join_Date,"
            sql = sql & " @Savings_Account_id,@Phone_NO,@Mobile_No, "
            sql = sql & "@Member_Nominal,@Member_Nominal_Address,@Nominee,@Image_path,@Sign_path,@Surname,@Caste,@Sub_Caste,"
            sql = sql & "@Add_Date,"
            sql = sql & "@User_NAme,"
            sql = sql & " @Edit_DAte,"
            sql = sql & "@Edit_User_Name,@Second_Name,@Third_Name,@Member_Type,@vat_no," & Val(TXtdepartmentId.Text) & "," & aq(IPAddress) & "," & aq(MachineName) & ",@GST_No,@Email_Id)"
            sqlcommand.CommandText = sql
            sqlcommand.Parameters.AddWithValue("@Company_Id", clsVariables.CompnyId)
            sqlcommand.Parameters.AddWithValue("@Member_Id", Trim(txtMemberId.Text))
            sqlcommand.Parameters.AddWithValue("@member_Name", Trim(txtGujmemname.Text))
            sqlcommand.Parameters.AddWithValue("@English_member_name", Trim(txtEngmemName.Text))
            sqlcommand.Parameters.AddWithValue("@Address", Trim(txtAddres.Text))
            sqlcommand.Parameters.AddWithValue("@Village_id", Trim(txtVillageId.Text))
            sqlcommand.Parameters.AddWithValue("@Family_Id", Trim(txtFamilyId.Text))
            sqlcommand.Parameters.AddWithValue("@Birth_Date", sFunction.DateConversion(txtDOB.Text))
            sqlcommand.Parameters.AddWithValue("@Join_Date", sFunction.DateConversion(txtjoinDate.Text))
            sqlcommand.Parameters.AddWithValue("@Male_Female", Trim(Mid(Cmdgender.Text, 1, 1)))
            sqlcommand.Parameters.AddWithValue("@Currant", IIf(CmbCurrant.Text = "YES", 1, 0))
            sqlcommand.Parameters.AddWithValue("@Loan_Over_Due", IIf(cmbLoanOverDue.Text = "YES", 1, 0))
            sqlcommand.Parameters.AddWithValue("@Savings_Account_id", Trim(txtsavingAccountId.Text))
            sqlcommand.Parameters.AddWithValue("@Phone_NO", Trim(txtPhoneNo.Text))
            sqlcommand.Parameters.AddWithValue("@Mobile_No", Trim(txtMobileNO.Text))
            sqlcommand.Parameters.AddWithValue("@Member_Nominal", Trim(txtNominee.Text))
            sqlcommand.Parameters.AddWithValue("@Member_Nominal_Address", Trim(txtNomineeAddress.Text))
            sqlcommand.Parameters.AddWithValue("@Nominee", Trim(cmbRelationNominee.Text))
            sqlcommand.Parameters.AddWithValue("@Image_path", Trim(txtPhotopath.Text & txtMemberId.Text))
            sqlcommand.Parameters.AddWithValue("@Sign_path", Trim(txtSignPath.Text & txtMemberId.Text))
            sqlcommand.Parameters.AddWithValue("@Surname", Trim(txtSurName.Text))
            sqlcommand.Parameters.AddWithValue("@Caste", Trim(ComboCaste.Text))
            sqlcommand.Parameters.AddWithValue("@Sub_Caste", Trim(ComboSubCaste.Text))
            sqlcommand.Parameters.AddWithValue("@User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Add_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
            sqlcommand.Parameters.AddWithValue("@Edit_User_Name", Trim(CLS.clsVariables.UserName))
            sqlcommand.Parameters.AddWithValue("@Edit_Date", Format(Now, "MM/dd/yyyy HH:mm:ss"))
            sqlcommand.Parameters.AddWithValue("@Second_Name", (Trim(TxtSecondName.Text)))
            sqlcommand.Parameters.AddWithValue("@Third_Name", (Trim(TxtThirdame.Text)))
            sqlcommand.Parameters.AddWithValue("@member_Type", Val(ComboMemberType.SelectedValue))
            sqlcommand.Parameters.AddWithValue("@Vat_No", TxtVatNo.Text)
            sqlcommand.Parameters.AddWithValue("@GST_No", txtgstno.Text)
            sqlcommand.Parameters.AddWithValue("@Email_Id", txtEmailID.Text)
            sqlcommand.ExecuteNonQuery()
            sqlcommand.Parameters.Clear()
        Catch ex As Exception
            MsgBox(ex.Message.ToArray)
        End Try
    End Sub
    Private Sub txtDOB_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOB.Validated
        ob.validdate(sender, txtDOB.Text)
    End Sub

    Private Sub txtjoinDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtjoinDate.Validated
        ob.validdate(sender, txtjoinDate.Text)
    End Sub
    Private Sub cmbSearchby_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchby.Validated
        If cmbSearchby.Text = "Member Id" Then
            txtsearch.Font = New Font("Cambria", 9.75, FontStyle.Regular)

        Else
            txtsearch.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Regular)
        End If
    End Sub

    Public Sub RowDisplay()
        Try
            Dim i As Integer
            If DgDoc_Village.Rows.Count > 0 Then
                i = DgDoc_Village.CurrentRow.Index
                txtMemberId.Text = DgDoc_Village.Rows(i).Cells(0).Value.ToString()
                filltext(clsVariables.CompnyId, Val(txtMemberId.Text))
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgDoc_Village_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Village.CellClick
        RowDisplay()
    End Sub


    Private Sub DgDoc_Village_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Village.CellContentClick

    End Sub

    Private Sub DgDoc_Village_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDoc_Village.KeyUp
        If e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            RowDisplay()
        End If
    End Sub

    Private Sub DgDoc_Village_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgDoc_Village.RowHeaderMouseClick
        RowDisplay()
    End Sub

    Private Sub CmbCurrant_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCurrant.Enter
        CmbCurrant.DroppedDown = True
    End Sub

    Private Sub CmbCurrant_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCurrant.GotFocus
        Textactive(sender)
    End Sub

    Private Sub CmbCurrant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCurrant.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub CmbCurrant_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCurrant.LostFocus
        Textreset(sender)
    End Sub

    Private Sub CmbCurrant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCurrant.SelectedIndexChanged

    End Sub

    Private Sub cmbRelationNominee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRelationNominee.SelectedIndexChanged

    End Sub

    Private Sub txtsearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsearch.TextChanged
        Try
            Dim searchby As String
            Dim ssql As String
            ssql = ""
            searchby = ""
            searchby = cmbSearchby.SelectedItem.ToString
            If txtsearch.Text <> "" Then
                If searchby = "Member Id" Then

                    searchby = "a.Member_id"
                    ssql = "Select a.Member_Id,a.member_Name,B.Village_Name,a.Address, English_member_name  from Member_master a LEFT OUTER JOIN Village_Master b  on a.company_Id=b.company_Id and a.village_id=b.Village_id where a.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & Val(txtsearch.Text) & "%' "
                ElseIf searchby = "Member Name" Then
                    searchby = "a.Member_Name"
                    ssql = "Select a.Member_Id,a.member_Name,B.Village_Name,a.Address, English_member_name  from Member_master a LEFT OUTER JOIN Village_Master b  on a.company_Id=b.company_Id and a.village_id=b.Village_id where a.Company_Id=" & clsVariables.CompnyId & "  and " & searchby & " like '" & txtsearch.Text & "%' "
                End If
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    ssql = ssql & " and a.Department_ID in " & clsVariables.sdepartment
                'End If

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

    Private Sub cmbSearchby_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSearchby.SelectedIndexChanged

    End Sub

    Private Sub txtMemberId_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberId.Validated
        'If fn = True Then
        If ButAdd.Enabled = False Then
            Dim dt As New DataTable
            dt = ob.Returntable("Select * from Member_Master where Company_id=" & Val(clsVariables.CompnyId) & " and Member_Id=" & Val(txtMemberId.Text), ob.getconnection())
            If dt.Rows.Count > 0 Then
                filltext(dt.Rows(0).Item("Company_id"), dt.Rows(0).Item("Member_Id"))
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

    Private Sub ButPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButPrint.Click
        Try
            clsVariables.ReportName = "RptMemberMaster.rpt"
            clsVariables.ReportSql = "{Member_Master.Company_id}=" & Val(clsVariables.CompnyId)
            'If Len(MdiMain.ComboDept.Text) <> 0 Then
            '    clsVariables.ReportSql = clsVariables.ReportSql & " and {Member_Master.Department_id}=" & Val(MdiMain.ComboDept.SelectedValue)
            'End If
            clsVariables.RptTable = "VMemberMaster"
            clsVariables.Repheader = "Member Master List"
            Dim frm As New Reportform
            frm.Show()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub


    Private Sub txtNominee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNominee.TextChanged

    End Sub

    Private Sub txtNomineeAddress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomineeAddress.TextChanged

    End Sub

    Private Sub txtFamilyId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFamilyId.KeyPress
        tabkey(sender, e)
    End Sub



    Private Sub txtSurName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurName.GotFocus
        Textactiveg(sender)
    End Sub

    Private Sub txtSurName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSurName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub txtSurName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSurName.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtSurName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSurName.TextChanged

    End Sub

    Private Sub ComboCaste_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCaste.Enter
        ComboCaste.DroppedDown = True
    End Sub

    Private Sub ComboCaste_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCaste.GotFocus
        Textactive(sender)
    End Sub

    Private Sub ComboCaste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCaste.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub ComboCaste_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCaste.LostFocus
        Textreset(sender)
    End Sub

    Private Sub ComboCaste_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCaste.SelectedIndexChanged

    End Sub

    Private Sub ComboSubCaste_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSubCaste.Enter
        ComboSubCaste.DroppedDown = True
    End Sub

    Private Sub ComboSubCaste_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSubCaste.GotFocus
        Textactive(sender)
    End Sub

    Private Sub ComboSubCaste_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSubCaste.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub ComboSubCaste_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSubCaste.LostFocus
        Textreset(sender)
    End Sub

    Private Sub ComboSubCaste_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSubCaste.SelectedIndexChanged

    End Sub

    Private Sub TxtSecondName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSecondName.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtSecondName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSecondName.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtSecondName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSecondName.LostFocus
        Textreset(sender)
    End Sub


    Private Sub TxtSecondName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSecondName.TextChanged

    End Sub

    Private Sub TxtThirdame_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtThirdame.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TxtThirdame_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtThirdame.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TxtThirdame_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtThirdame.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TxtThirdame_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtThirdame.TextChanged

    End Sub

    Private Sub ComboMemberType_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboMemberType.Enter
        ComboMemberType.DroppedDown = True
    End Sub

    Private Sub ComboMemberType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboMemberType.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub ComboMemberType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMemberType.SelectedIndexChanged

    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVatNo.GotFocus
        Textactive(sender)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVatNo.KeyPress
        tabkey(sender, e)
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVatNo.LostFocus
        Textreset(sender)
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVatNo.TextChanged

    End Sub
    Private Sub txtgstno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgstno.GotFocus, txtEmailID.GotFocus
        Textactive(sender)

    End Sub

    Private Sub txtgstno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgstno.KeyPress, txtEmailID.KeyPress
        tabkey(sender, e)

    End Sub

    Private Sub txtgstno_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgstno.LostFocus, txtEmailID.LostFocus
        Textreset(sender)
    End Sub

    Private Sub txtEmailID_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmailID.Validated
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})") '"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        If email.IsMatch(txtEmailID.Text) Or txtEmailID.Text = "" Then
        Else
            MessageBox.Show("Please Enter Valid Email ID", "System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmailID.Focus()
        End If
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub txtVillageName_Validated(sender As Object, e As EventArgs) Handles txtVillageName.Validated
        If txtVillageName.Text <> "" Then
            txtVillageId.Text = ob.FindOneString("select Village_id from Village_Master Where Village_Name=N'" & txtVillageName.Text & "'", ob.getconnection())
        Else
            MessageBox.Show("Place Enter Village Name")
            txtVillageName.Focus()
        End If
    End Sub

    Private Sub ComboMemberType_Validated(sender As Object, e As EventArgs) Handles ComboMemberType.Validated
        If Trim(ComboMemberType.Text) <> "" Then
            Dim dt As DataTable = ob.Returntable("select Member_id,Member_Name from Member_master where Member_Type='" & Val(ComboMemberType.Text) & "' Order By Member_id", ob.getconnection())
            If dt.Rows.Count > 0 Then
                If Dg.Rows.Count > 0 Then
                    Dg.Rows.Clear()
                End If
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dg.Rows.Add()
                    Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Member_id")
                    Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Member_Name")

                Next
            End If
        Else
            MessageBox.Show("Place Select Any Member Type")
            ComboMemberType.Focus()
        End If
    End Sub

    Private Sub txtserch_TextChanged(sender As Object, e As EventArgs) Handles txtbserch.TextChanged
        Dim dt As DataTable = ob.Returntable("select Member_id,Member_Name from Member_master where Member_Name like N'" & Trim(txtbserch.Text) & "%'  Order By Member_id", ob.getconnection())
        If dt.Rows.Count > 0 Then
            If Dg.Rows.Count > 0 Then
                Dg.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                Dg.Rows.Add()
                Dg.Rows(Dg.Rows.Count - 1).Cells(0).Value = dt.Rows(i).Item("Member_id")
                Dg.Rows(Dg.Rows.Count - 1).Cells(1).Value = dt.Rows(i).Item("Member_Name")

            Next
        End If
    End Sub
End Class
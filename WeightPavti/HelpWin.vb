Imports WeightPavti.CLS
Public Class HelpWin
    Dim objconnec As New clsConnection
    Dim objDataTrns As New clsDataTrans
    Dim gdt As New DataTable
    Dim ds As New DataSet
    Private conn As System.Data.SqlClient.SqlConnection
    Dim sSql As String
    Dim SqlCommand As New SqlClient.SqlCommand
    Dim sCommands As New clsCommands
    Dim sVariables As New clsVariables
    Dim Modd As String
    Public tsql As String
    Public sorderby As String
    Dim strLike As String
    Public scodename As String

    'Fill the Help Grid
    Public Sub HelpGrid(ByVal HelpId As String, ByVal HelpName As String, ByVal TbName As String, ByVal GvName As DataGridView)
        Try
            Dim ds As New DataSet
            Dim iSql As String
            'objconnec.GetConnection()
            If LCase(clsVariables.TbName) = "Member_master" Then
                Select Case sdepartment
                    Case "saving"
                        tsql = tsql & " and Member_Id<=100000"
                    Case "monthly"
                        tsql = tsql & " and Member_Id>100000 and Member_Id<=200000"
                    Case "daily"
                        tsql = tsql & " and Member_Id>200000 and Member_Id<=300000"
                    Case "locker"
                        tsql = tsql & " and Member_Id>300000 and Member_Id<=400000 "
                    Case "fixd"
                        tsql = tsql & " and Member_Id>4600000 "
                    Case "gram-laxmi"
                        tsql = tsql & " and Member_Id>400000 and Member_Id<=500000"
                    Case "kamdhenu"
                        tsql = tsql & " and Member_Id>500000 and Member_Id<=600000"
                    Case "investment"
                        tsql = tsql & " and Member_Id>600000 and Member_Id<=900000"
                End Select

            ElseIf LCase(clsVariables.TbName) = "item_master" Then
                'tsql = "Select IM.Item_id,Im.Item_name,Sell_Rate,Dm.Department_Name"
                'tsql = tsql & " from Item_master as Im inner join Quality_master as Qm on"
                'tsql = tsql & " im.Company_Id=Qm.Company_id and im.Quality_id=Qm.Quality_id"
                'tsql = tsql & " inner Join department_master as Dm  on"
                'tsql = tsql & " Qm.Company_id=dm.Company_id and Qm.department_id=Dm.department_id"
                'tsql = tsql & " and Im.Company_Id=" & clsVariables.CompnyId
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    tsql = tsql & " and Qm.department_id=" & Val(MdiMain.ComboDept.SelectedValue)
                'End If

            ElseIf LCase(clsVariables.TbName) = "member_master" Then
                tsql = "Select MM.Member_ID,MM.Member_name,Vm.Village_Name" ',Dm.Department_Name"
                tsql = tsql & " from Member_master as MM "
                'tsql = tsql & " Inner Join department_master as Dm  on"
                'tsql = tsql & " Mm.Company_id=dm.Company_id and Mm.department_id=Dm.department_id"
                tsql = tsql & " Inner join Village_Master Vm on Vm.Village_id=MM.Village_Id  "

                tsql = tsql & " and Mm.Company_Id=" & clsVariables.CompnyId

                'If Val(MdiMain.ComboDept.SelectedValue) = 10 Then
                '    tsql = tsql & " and MM.Department_Id in (10) and Member_Id<>0"
                'ElseIf Val(MdiMain.ComboDept.SelectedValue) = 11 Then
                '    tsql = tsql & " and MM.Department_Id in (11) and Member_Id<>0"
                'ElseIf Val(MdiMain.ComboDept.SelectedValue) = 12 Then
                '    tsql = tsql & " and MM.Department_Id in (12) and Member_Id<>0"
                '    ' ElseIf Val(MdiMain.ComboDept.SelectedValue) = 1 Then
                '    'tsql = tsql & " and MM.Department_Id in (1,9) and Member_Id<>0"
                'Else
                '    tsql = tsql & " and MM.Department_Id in " & clsVariables.sdepartment & " and Member_Id<>0"
                'End If

                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    tsql = tsql & " and Mm.department_id in " & clsVariables.sdepartment
                'End If

            End If

            If LCase(clsVariables.TbName) = LCase("Account_Master") Or LCase(clsVariables.TbName) = LCase("Department_Master") Then
                'If Len(MdiMain.ComboDept.Text) > 0 Then
                '    If Val(MdiMain.ComboDept.SelectedValue) = 10 Then
                '        tsql = tsql & " and Department_Id in (1,10) and Account_id<>0"
                '    ElseIf Val(MdiMain.ComboDept.SelectedValue) = 9 Then
                '        tsql = tsql & " and Department_Id in (1,9) and Account_id<>0"
                '    ElseIf Val(MdiMain.ComboDept.SelectedValue) = 11 Then
                '        tsql = tsql & " and Department_Id in (1,11) and Account_id<>0"
                '    ElseIf Val(MdiMain.ComboDept.SelectedValue) = 12 Then
                '        tsql = tsql & " and Department_Id in (1,12) and Account_id<>0"
                '    Else
                '        tsql = tsql & " and Department_Id in " & clsVariables.sdepartment & " and Account_id<>0"
                '    End If

            End If
            '


            If LCase(clsVariables.TbName) = LCase("Department_Master") Then
                tsql = tsql & clsVariables.sDeptID
            End If





            If Len(Trim(txtSrch.Text)) > 0 Then
                iSql = tsql & strLike & sorderby
            Else
                iSql = tsql & sorderby
            End If


            'iSql = tsql ' "Select " & HelpId & "," & HelpName & " from " & TbName
            objconnec.GetConnection()
            objDataTrns.OpenCn()
            ds = objDataTrns.fillgrid(iSql)
            GvName.DataSource = ds.Tables(0)
            GvName.Columns(0).HeaderText = "Id"
            If LCase(TbName) <> LCase("DESCRIPTION_MASTER") Then
                If LCase(TbName) <> LCase("Pump_master") And LCase(TbName) <> LCase("Tank_master") And LCase(TbName) <> LCase("Leave_master") And LCase(TbName) <> LCase("Form_Info") And LCase(TbName) <> LCase("Denomination_Master") And LCase(TbName) <> LCase("Currancy_Master") And LCase(TbName) <> LCase("Locker_DAta") And LCase(clsVariables.TbName) <> LCase("SEason_master") And LCase(clsVariables.TbName) <> LCase("Wb_Transport_Master") And LCase(clsVariables.TbName) <> LCase("Wb_Type_Master") And LCase(clsVariables.TbName) <> LCase("month") Then
                    GvName.Columns(1).DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
                Else
                    GvName.Columns(1).DefaultCellStyle.Font = New Font("CAMBRIA", 10, FontStyle.Regular)
                End If
                GvName.Columns(1).HeaderText = "Name"
                GvName.Columns(0).Width = 100
                GvName.Columns(1).Width = 350
            End If
            If LCase(TbName) = LCase("item_MASTER") Then
                GvName.Columns(0).Width = 100
                GvName.Columns(1).Width = 280
                GvName.Columns(2).HeaderText = "Rate"
                GvName.Columns(2).Width = 120
                GvName.Columns(3).HeaderText = "Dept Name"
                GvName.Columns(3).Width = 120
            ElseIf LCase(TbName) = LCase("DESCRIPTION_MASTER") Then
                GvName.Columns(0).HeaderText = "Remarks"
                GvName.Columns(0).Width = 350
                GvName.Columns(0).DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 12, FontStyle.Regular)
            ElseIf LCase(TbName) = LCase("Locker_DAta") Then
                GvName.Columns(0).HeaderText = "Locker No"
                GvName.Columns(0).Width = 80
                GvName.Columns(1).HeaderText = "Key No"
                GvName.Columns(1).Width = 70
                GvName.Columns(2).HeaderText = "UpTo Date"
                GvName.Columns(2).Width = 100
                GvName.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
                GvName.Columns(3).Width = 95
                GvName.Columns(3).HeaderText = "Deposite"
                GvName.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GvName.Columns(3).DefaultCellStyle.Format = g2Dec
                GvName.Columns(4).Width = 90
                GvName.Columns(4).HeaderText = "Rent"
                GvName.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                GvName.Columns(4).DefaultCellStyle.Format = g2Dec
            ElseIf LCase(TbName) = LCase("Loan_balance") Then
                GvName.Columns(0).HeaderText = "Loan No"
                GvName.Columns(0).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Regular)
                GvName.Columns(0).Width = 80
                GvName.Columns(1).HeaderText = "Date"
                GvName.Columns(1).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Regular)
                GvName.Columns(1).Width = 85
                GvName.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
                GvName.Columns(2).HeaderText = "Ext"
                GvName.Columns(2).Width = 30
                GvName.Columns(3).HeaderText = "Member Name"
                GvName.Columns(3).DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 12, FontStyle.Regular)
                GvName.Columns(3).Width = 220
                GvName.Columns(4).HeaderText = "Amount"
                GvName.Columns(4).Width = 90
                GvName.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
                GvName.Columns(4).DefaultCellStyle.Format = g2Dec
                GvName.Columns(5).HeaderText = "Balance"
                GvName.Columns(5).Width = 90
                GvName.Columns(5).DefaultCellStyle.Format = g2Dec
                GvName.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            ElseIf LCase("Add_Ded_master") = LCase(TbName) Then
                GvName.Columns(0).DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Regular)
            End If
            objDataTrns.CloseCn()
            LbTotal.Text = "Total Record : " & Trim(ds.Tables(0).Rows.Count)
            LBSelecetedrecord.Text = "Select Record : " & Trim(ds.Tables(0).Rows.Count)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButCancel.Click
        clsVariables.RtnHelpId = ""
        clsVariables.RtnHelpName = ""
        Me.Close()
    End Sub
    Private Sub txtSrch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSrch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If DgDoc_Help.Rows.Count > 0 Then
                RowDisplay()
                Me.Close()
            End If
        End If
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSrch.TextChanged
        If Len(Trim(txtSrch.Text)) > 0 Then
            If scodename = "Name" Then

                strLike = " and  " & clsVariables.HelpName & " Like '" & Trim(txtSrch.Text) & "%'"
            Else
                strLike = " and " & clsVariables.HelpId & " Like '" & Trim(txtSrch.Text) & "%'"

            End If
        End If
        HelpSearch(clsVariables.HelpId, clsVariables.HelpName, clsVariables.TbName, DgDoc_Help)
    End Sub
    Public Sub RowDisplay()
        Dim i As Integer
        If DgDoc_Help.Rows.Count > 0 Then
            i = DgDoc_Help.CurrentRow.Index
            clsVariables.RtnHelpId = DgDoc_Help.Rows(i).Cells(0).Value.ToString()
            'If LCase(clsVariables.TbName) <> LCase("DESCRIPTION_MASTER") Then
            clsVariables.RtnHelpName = DgDoc_Help.Rows(i).Cells(1).Value.ToString()
            'End If

        End If
    End Sub
    Private Sub DgDoc_Help_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DgDoc_Help.KeyPress
        ' i = Asc(e.KeyChar)
        If Asc(e.KeyChar) <> 13 And Asc(e.KeyChar) <> 8 Then
            txtSrch.Text = txtSrch.Text & e.KeyChar
        ElseIf Asc(e.KeyChar) = 8 Then
            If Len(txtSrch.Text) >= 1 Then
                txtSrch.Text = Mid(txtSrch.Text, 1, Len(txtSrch.Text) - 1)
            End If
        End If
    End Sub

    Private Sub HelpWin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, ButCancel.KeyUp, DgDoc_Help.KeyUp, txtSrch.KeyUp
        If e.KeyCode = Keys.Escape Then
            ButCancel_Click(e, e)
        ElseIf e.KeyCode = Keys.F3 Then
            DgDoc_Help.Focus()
        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            DgDoc_Help.Focus()
        End If
    End Sub
    Private Sub HelpWin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSrch.Text = ""

        'Me.BackgroundImage = MdiMain.PicMaster.Image
        
        If UCase(clsVariables.TbName) = UCase("loan_balance") Then
            DgDoc_Help.DefaultCellStyle.Font = New Font("cambria", 10, FontStyle.Regular)
            Me.Width = 542 + 150
            GroupBox1.Width = 524 + 150
            txtSrch.Width = 506 + 150
            DgDoc_Help.Width = 506 + 150
            DgDoc_Help.AllowUserToResizeColumns = True
            Me.StartPosition = FormStartPosition.CenterParent
        End If

        HelpGrid(clsVariables.HelpId, clsVariables.HelpName, clsVariables.TbName, DgDoc_Help)

        If LCase(clsVariables.TbName) <> LCase("Leave_master") And LCase(clsVariables.TbName) <> LCase("Form_Info") And LCase(clsVariables.TbName) <> LCase("Wb_Transport_Master") And LCase(clsVariables.TbName) <> LCase("Locker_Data") And LCase(clsVariables.TbName) <> LCase("SEason_master") And LCase(clsVariables.TbName) <> LCase("Wb_Type_Master") Then
            txtSrch.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
            DgDoc_Help.DefaultCellStyle.Font = New Font("HARIKRISHNA", 12, FontStyle.Regular)
        Else
            txtSrch.Font = New Font("Cambria", 10, FontStyle.Regular)
            DgDoc_Help.DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Regular)
        End If
        DgDoc_Help.Columns(0).HeaderText = "Id"
        DgDoc_Help.Columns(1).HeaderText = "Name"
        'If LCase(clsVariables.TbName) <> LCase("DESCRIPTION_MASTER") And LCase(clsVariables.TbName) <> LCase("Leave_master") And LCase(clsVariables.TbName) <> LCase("Book_master") And LCase(clsVariables.TbName) <> LCase("Form_Info") And LCase(clsVariables.TbName) <> LCase("Locker_Data") Then
        '    DgDoc_Help.Columns(1).DefaultCellStyle.Font = New Font("SHREE-Guj-0768-S02", 12, FontStyle.Regular)
        'Else
        '    DgDoc_Help.Columns(1).DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Regular)
        'End If
        DgDoc_Help.Columns(0).Width = 100
        DgDoc_Help.Columns(1).Width = 350
        If LCase(clsVariables.TbName) = LCase("Locker_DAta") Then
            DgDoc_Help.Columns(0).HeaderText = "Locker No"
            DgDoc_Help.Columns(0).Width = 80
            DgDoc_Help.Columns(1).HeaderText = "Key No"
            DgDoc_Help.Columns(1).Width = 70
            DgDoc_Help.Columns(2).HeaderText = "UpTo Date"
            DgDoc_Help.Columns(2).Width = 100
            DgDoc_Help.Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
            DgDoc_Help.Columns(3).Width = 95
            DgDoc_Help.Columns(3).HeaderText = "Deposite"
            DgDoc_Help.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgDoc_Help.Columns(3).DefaultCellStyle.Format = g2Dec
            DgDoc_Help.Columns(4).Width = 90
            DgDoc_Help.Columns(4).HeaderText = "Rent"
            DgDoc_Help.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DgDoc_Help.Columns(4).DefaultCellStyle.Format = g2Dec
        ElseIf LCase(clsVariables.TbName) = LCase("Loan_balance") Then
            DgDoc_Help.Columns(0).HeaderText = "Loan No"
            DgDoc_Help.Columns(0).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Regular)
            DgDoc_Help.Columns(0).Width = 80
            DgDoc_Help.Columns(1).HeaderText = "Date"
            DgDoc_Help.Columns(1).DefaultCellStyle.Font = New Font("Cambria", 9, FontStyle.Regular)
            DgDoc_Help.Columns(1).Width = 85
            DgDoc_Help.Columns(1).DefaultCellStyle.Format = "dd/MM/yyyy"
            DgDoc_Help.Columns(2).HeaderText = "Ext"
            DgDoc_Help.Columns(2).Width = 30
            DgDoc_Help.Columns(3).HeaderText = "Member Name"
            DgDoc_Help.Columns(3).DefaultCellStyle.Font = New Font("Shree-guj-0768-s02", 12, FontStyle.Regular)
            DgDoc_Help.Columns(3).Width = 220
            DgDoc_Help.Columns(4).HeaderText = "Amount"
            DgDoc_Help.Columns(4).Width = 90
            DgDoc_Help.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
            DgDoc_Help.Columns(4).DefaultCellStyle.Format = g2Dec
            DgDoc_Help.Columns(5).HeaderText = "Balance"
            DgDoc_Help.Columns(5).Width = 90
            DgDoc_Help.Columns(5).DefaultCellStyle.Format = g2Dec
            DgDoc_Help.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight
        ElseIf LCase(clsVariables.TbName) = LCase("DESCRIPTION_MASTER") Then
            DgDoc_Help.Columns(0).Visible = False
            DgDoc_Help.Columns(1).Width = 450
        ElseIf LCase("Add_Ded_master") = LCase(clsVariables.TbName) Then
            DgDoc_Help.Columns(0).DefaultCellStyle.Font = New Font("Cambria", 10, FontStyle.Regular)
        End If
        txtSrch.Focus()
    End Sub
    Private Sub DgDoc_Help_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DgDoc_Help.DoubleClick
        If DgDoc_Help.Rows.Count > 0 Then
            RowDisplay()
            Me.Close()
        End If
    End Sub

    Private Sub DgDoc_Help_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DgDoc_Help.KeyDown
        If e.KeyCode = Keys.Enter Then
            If DgDoc_Help.Rows.Count > 0 Then
                RowDisplay()
                Me.Close()
            End If
        End If
    End Sub


    Private Sub DgDoc_Help_RowHeaderMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgDoc_Help.RowHeaderMouseDoubleClick
        If DgDoc_Help.Rows.Count > 0 Then
            RowDisplay()
            Me.Close()
        End If
        
    End Sub

    Public Sub HelpSearch(ByVal HelpId As String, ByVal HelpName As String, ByVal TbName As String, ByVal GvName As DataGridView)
        Try

            Dim ssql As String
            ssql = ""
            'If txtSrch.Text <> "" Then
            '    ssql = "Select " & HelpId & "," & HelpName & " from " & TbName & " where Company_Id=" & clsVariables.CompnyId & "  and " & HelpName & " like '" & Val(txtSrch.Text) & "%' "
            'Else

            '    HelpGrid(clsVariables.HelpId, clsVariables.HelpName, clsVariables.TbName, DgDoc_Help)
            'End If

            If Len(Trim(txtSrch.Text)) > 0 Then
                ssql = tsql & strLike & sorderby
            Else
                ssql = tsql & sorderby
            End If
            DgDoc_Help.DataSource = ob.Returntable(ssql, ob.getconnection(ob.Getconn()))
           
            txtSrch.Focus()
            LBSelecetedrecord.Text = "Select Record : " & DgDoc_Help.Rows.Count

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DgDoc_Help_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDoc_Help.CellContentClick

    End Sub
End Class
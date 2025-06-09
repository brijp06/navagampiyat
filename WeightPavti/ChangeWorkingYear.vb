Imports WeightPavti.CLS
Public Class ChangeWorkingYear

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub ChangeWorkingYear_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, BUtOk.KeyUp, Button1.KeyUp, Dg.KeyUp
        If e.KeyCode = Keys.F3 Then
            Dg.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ChangeWorkingYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = MdiMain
        'Me.BackgroundImage = MdiMain.PicMaster.Image
        Me.BackgroundImageLayout = ImageLayout.Stretch
        Dg.DataSource = ob.Returntable("Select Year_Id,Year_Name ,convert(nvarchar(50),Co_Start_Date,103) as 'Start Date',convert(nvarchar(50),Co_End_Date,103) as 'End Date' from Year_Master where Company_id=" & Val(clsVariables.CompnyId) & " order by Company_Id,Year_Id desc", ob.getconnection())
        Dg.Columns(0).HeaderText = "Id"
        Dg.Columns(0).Width = 80
        Dg.Columns(1).Width = 170
        Dg.Columns(1).HeaderText = "Name"
        Dg.Columns(2).Width = 100
        Dg.Columns(3).Width = 100
    End Sub

    Private Sub DgDoc_Village_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg.CellContentClick

    End Sub

    Private Sub DgDoc_Village_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dg.CellDoubleClick
        If Dg.Rows.Count > 0 Then
            clsVariables.WorkingYear = Dg.Rows(Dg.CurrentRow.Index).Cells(0).Value
            MdiMain.Lbyear.Text = clsVariables.WorkingYear
            ob.LoadFinYear()
            Me.Close()
        End If
    End Sub

    Private Sub DgDoc_Village_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dg.KeyDown

        If e.KeyCode = Keys.Enter Then
            If Dg.Rows.Count > 0 Then
                clsVariables.WorkingYear = Dg.Rows(Dg.CurrentRow.Index).Cells(0).Value
                MdiMain.Lbyear.Text = clsVariables.WorkingYear
                ob.LoadFinYear()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BUtOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUtOk.Click
        If Dg.Rows.Count > 0 Then
            clsVariables.WorkingYear = Dg.Rows(Dg.CurrentRow.Index).Cells(0).Value
            MdiMain.Lbyear.Text = clsVariables.WorkingYear
            ob.LoadFinYear()
            Me.Close()
        End If
    End Sub

    Private Sub DgDoc_Village_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dg.RowHeaderMouseClick
        If Dg.Rows.Count > 0 Then
            clsVariables.WorkingYear = Dg.Rows(Dg.CurrentRow.Index).Cells(0).Value
            MdiMain.Lbyear.Text = clsVariables.WorkingYear
            ob.LoadFinYear()
            Me.Close()
        End If
    End Sub
End Class
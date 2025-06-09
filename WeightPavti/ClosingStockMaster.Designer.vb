<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClosingStockMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Dg)
        Me.GroupBox1.Location = New System.Drawing.Point(5, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 253)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(462, 257)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(171, 69)
        Me.GroupBox4.TabIndex = 58
        Me.GroupBox4.TabStop = False
        '
        'ButSave
        '
        Me.ButSave.ForeColor = System.Drawing.Color.Black
        Me.ButSave.Image = Global.WeightPavti.My.Resources.Resources.save
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.Location = New System.Drawing.Point(6, 10)
        Me.ButSave.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(77, 28)
        Me.ButSave.TabIndex = 54
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButCAncel
        '
        Me.ButCAncel.ForeColor = System.Drawing.Color.Black
        Me.ButCAncel.Image = Global.WeightPavti.My.Resources.Resources.Cancel
        Me.ButCAncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCAncel.Location = New System.Drawing.Point(89, 38)
        Me.ButCAncel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButCAncel.Name = "ButCAncel"
        Me.ButCAncel.Size = New System.Drawing.Size(77, 28)
        Me.ButCAncel.TabIndex = 55
        Me.ButCAncel.Text = "&Cancel"
        Me.ButCAncel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButCAncel.UseVisualStyleBackColor = True
        '
        'ButPrint
        '
        Me.ButPrint.ForeColor = System.Drawing.Color.Black
        Me.ButPrint.Image = Global.WeightPavti.My.Resources.Resources.print
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(89, 10)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(77, 28)
        Me.ButPrint.TabIndex = 56
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButPrint.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.ForeColor = System.Drawing.Color.Black
        Me.ButDelete.Image = Global.WeightPavti.My.Resources.Resources.delete
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(6, 38)
        Me.ButDelete.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(77, 28)
        Me.ButDelete.TabIndex = 53
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.BackgroundColor = System.Drawing.Color.White
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.cc})
        Me.Dg.Location = New System.Drawing.Point(5, 14)
        Me.Dg.Name = "Dg"
        Me.Dg.RowHeadersVisible = False
        Me.Dg.Size = New System.Drawing.Size(618, 233)
        Me.Dg.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "OpId"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "OpacName"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "ClId"
        Me.Column3.Name = "Column3"
        '
        'cc
        '
        Me.cc.HeaderText = "ClAcName"
        Me.cc.Name = "cc"
        Me.cc.Width = 200
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.WeightPavti.My.Resources.Resources.save
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(10, 257)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 38)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Add New Row"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ClosingStockMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(640, 335)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ClosingStockMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClosingStockMaster"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Dg As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cc As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButSave As Button
    Friend WithEvents ButCAncel As Button
    Friend WithEvents ButPrint As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents Button1 As Button
End Class

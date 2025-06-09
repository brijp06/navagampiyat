<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpWin
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpWin))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LBSelecetedrecord = New System.Windows.Forms.Label
        Me.LbTotal = New System.Windows.Forms.Label
        Me.ButCancel = New System.Windows.Forms.Button
        Me.DgDoc_Help = New System.Windows.Forms.DataGridView
        Me.txtSrch = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgDoc_Help, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.LBSelecetedrecord)
        Me.GroupBox1.Controls.Add(Me.LbTotal)
        Me.GroupBox1.Controls.Add(Me.ButCancel)
        Me.GroupBox1.Controls.Add(Me.DgDoc_Help)
        Me.GroupBox1.Controls.Add(Me.txtSrch)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 415)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'LBSelecetedrecord
        '
        Me.LBSelecetedrecord.AutoSize = True
        Me.LBSelecetedrecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBSelecetedrecord.Location = New System.Drawing.Point(181, 389)
        Me.LBSelecetedrecord.Name = "LBSelecetedrecord"
        Me.LBSelecetedrecord.Size = New System.Drawing.Size(51, 15)
        Me.LBSelecetedrecord.TabIndex = 4
        Me.LBSelecetedrecord.Text = "Label1"
        '
        'LbTotal
        '
        Me.LbTotal.AutoSize = True
        Me.LbTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTotal.Location = New System.Drawing.Point(15, 388)
        Me.LbTotal.Name = "LbTotal"
        Me.LbTotal.Size = New System.Drawing.Size(51, 15)
        Me.LbTotal.TabIndex = 3
        Me.LbTotal.Text = "Label1"
        '
        'ButCancel
        '
        Me.ButCancel.Image = Global.WeightPavti.My.Resources.Resources.Cancel
        Me.ButCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCancel.Location = New System.Drawing.Point(502, 385)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButCancel.TabIndex = 100
        Me.ButCancel.Text = "&Cancel"
        Me.ButCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'DgDoc_Help
        '
        Me.DgDoc_Help.AllowUserToAddRows = False
        Me.DgDoc_Help.AllowUserToDeleteRows = False
        Me.DgDoc_Help.AllowUserToOrderColumns = True
        Me.DgDoc_Help.AllowUserToResizeColumns = False
        Me.DgDoc_Help.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DgDoc_Help.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgDoc_Help.BackgroundColor = System.Drawing.Color.White
        Me.DgDoc_Help.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDoc_Help.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDoc_Help.DefaultCellStyle = DataGridViewCellStyle2
        Me.DgDoc_Help.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgDoc_Help.Location = New System.Drawing.Point(9, 48)
        Me.DgDoc_Help.MultiSelect = False
        Me.DgDoc_Help.Name = "DgDoc_Help"
        Me.DgDoc_Help.ReadOnly = True
        Me.DgDoc_Help.RowHeadersWidth = 25
        Me.DgDoc_Help.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgDoc_Help.Size = New System.Drawing.Size(568, 331)
        Me.DgDoc_Help.StandardTab = True
        Me.DgDoc_Help.TabIndex = 1
        '
        'txtSrch
        '
        Me.txtSrch.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrch.Location = New System.Drawing.Point(9, 16)
        Me.txtSrch.Name = "txtSrch"
        Me.txtSrch.Size = New System.Drawing.Size(568, 25)
        Me.txtSrch.TabIndex = 0
        '
        'HelpWin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(603, 431)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "HelpWin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Help Wondow"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgDoc_Help, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSrch As System.Windows.Forms.TextBox
    Friend WithEvents DgDoc_Help As System.Windows.Forms.DataGridView
    Friend WithEvents ButCancel As System.Windows.Forms.Button
    Friend WithEvents LbTotal As System.Windows.Forms.Label
    Friend WithEvents LBSelecetedrecord As System.Windows.Forms.Label
End Class

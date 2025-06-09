<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthlyPosting
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
        Me.Billno = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ddate = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tshre = New System.Windows.Forms.TextBox()
        Me.tfixd = New System.Windows.Forms.TextBox()
        Me.tk = New System.Windows.Forms.TextBox()
        Me.total = New System.Windows.Forms.TextBox()
        Me.ComboMemberType = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.txtint = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Billno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ddate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(944, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Billno
        '
        Me.Billno.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Billno.Location = New System.Drawing.Point(95, 17)
        Me.Billno.Name = "Billno"
        Me.Billno.Size = New System.Drawing.Size(99, 25)
        Me.Billno.TabIndex = 179
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(42, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 178
        Me.Label3.Text = "Doc No :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(235, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(227, 46)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(427, 23)
        Me.ProgressBar1.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(449, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 29)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(366, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Show"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ddate
        '
        Me.ddate.Font = New System.Drawing.Font("HARIKRISHNA", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ddate.Location = New System.Drawing.Point(260, 15)
        Me.ddate.Mask = "00/00/0000"
        Me.ddate.Name = "ddate"
        Me.ddate.Size = New System.Drawing.Size(100, 24)
        Me.ddate.TabIndex = 1
        Me.ddate.ValidatingType = GetType(Date)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "tir)K:-"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Dg)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(944, 415)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.BackgroundColor = System.Drawing.Color.White
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column8, Me.Column9, Me.Column10, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.Dg.Location = New System.Drawing.Point(7, 12)
        Me.Dg.Name = "Dg"
        Me.Dg.RowHeadersVisible = False
        Me.Dg.Size = New System.Drawing.Size(933, 397)
        Me.Dg.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "k|m"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "nim"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 300
        '
        'Column8
        '
        Me.Column8.HeaderText = "bik) li[n rkm"
        Me.Column8.Name = "Column8"
        '
        'Column9
        '
        Me.Column9.HeaderText = "rkm"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 70
        '
        'Column10
        '
        Me.Column10.HeaderText = "Äyij "
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "S[r kpit"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "YipN kpit"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "kÃyiN (n(G f>D kpit"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "k&l kpit"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 50
        '
        'Column7
        '
        Me.Column7.HeaderText = ""
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 40
        '
        'tshre
        '
        Me.tshre.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tshre.ForeColor = System.Drawing.Color.Red
        Me.tshre.Location = New System.Drawing.Point(592, 508)
        Me.tshre.Name = "tshre"
        Me.tshre.Size = New System.Drawing.Size(80, 22)
        Me.tshre.TabIndex = 2
        '
        'tfixd
        '
        Me.tfixd.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tfixd.ForeColor = System.Drawing.Color.Red
        Me.tfixd.Location = New System.Drawing.Point(678, 508)
        Me.tfixd.Name = "tfixd"
        Me.tfixd.Size = New System.Drawing.Size(80, 22)
        Me.tfixd.TabIndex = 3
        '
        'tk
        '
        Me.tk.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tk.ForeColor = System.Drawing.Color.Red
        Me.tk.Location = New System.Drawing.Point(764, 508)
        Me.tk.Name = "tk"
        Me.tk.Size = New System.Drawing.Size(80, 22)
        Me.tk.TabIndex = 4
        '
        'total
        '
        Me.total.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total.ForeColor = System.Drawing.Color.Red
        Me.total.Location = New System.Drawing.Point(849, 508)
        Me.total.Name = "total"
        Me.total.Size = New System.Drawing.Size(80, 22)
        Me.total.TabIndex = 5
        '
        'ComboMemberType
        '
        Me.ComboMemberType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMemberType.Font = New System.Drawing.Font("Cambria", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMemberType.FormattingEnabled = True
        Me.ComboMemberType.Items.AddRange(New Object() {"HELTH", "TALUKAPANCHAYAT", "ICDS", "MKN", "IRD"})
        Me.ComboMemberType.Location = New System.Drawing.Point(99, 48)
        Me.ComboMemberType.Name = "ComboMemberType"
        Me.ComboMemberType.Size = New System.Drawing.Size(125, 25)
        Me.ComboMemberType.TabIndex = 175
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(6, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(90, 15)
        Me.Label16.TabIndex = 176
        Me.Label16.Text = "Member Type :"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(231, 507)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 29)
        Me.Button3.TabIndex = 177
        Me.Button3.Text = "Cal"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtamount
        '
        Me.txtamount.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.ForeColor = System.Drawing.Color.Red
        Me.txtamount.Location = New System.Drawing.Point(463, 508)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(76, 22)
        Me.txtamount.TabIndex = 178
        '
        'txtint
        '
        Me.txtint.Font = New System.Drawing.Font("HARIKRISHNA", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtint.ForeColor = System.Drawing.Color.Red
        Me.txtint.Location = New System.Drawing.Point(542, 508)
        Me.txtint.Name = "txtint"
        Me.txtint.Size = New System.Drawing.Size(49, 22)
        Me.txtint.TabIndex = 179
        '
        'MonthlyPosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Pink
        Me.ClientSize = New System.Drawing.Size(955, 542)
        Me.Controls.Add(Me.txtint)
        Me.Controls.Add(Me.txtamount)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ComboMemberType)
        Me.Controls.Add(Me.total)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.tk)
        Me.Controls.Add(Me.tfixd)
        Me.Controls.Add(Me.tshre)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MonthlyPosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MonthlyPosting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ddate As MaskedTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Dg As DataGridView
    Friend WithEvents tshre As TextBox
    Friend WithEvents tfixd As TextBox
    Friend WithEvents tk As TextBox
    Friend WithEvents total As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboMemberType As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Billno As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewCheckBoxColumn
    Friend WithEvents txtamount As TextBox
    Friend WithEvents txtint As TextBox
End Class

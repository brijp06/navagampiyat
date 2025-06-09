<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MemberOpeningEntry
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
        Me.lblmember = New System.Windows.Forms.Label()
        Me.Acname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Docdate = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Docno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Credit = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Billdate = New System.Windows.Forms.MaskedTextBox()
        Me.Cmbdepartment = New System.Windows.Forms.ComboBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debit = New System.Windows.Forms.TextBox()
        Me.BillNo = New System.Windows.Forms.TextBox()
        Me.Sname = New System.Windows.Forms.TextBox()
        Me.No = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButLast = New System.Windows.Forms.Button()
        Me.BUtPrev = New System.Windows.Forms.Button()
        Me.ButNExt = New System.Windows.Forms.Button()
        Me.ButFirst = New System.Windows.Forms.Button()
        Me.ButFind = New System.Windows.Forms.Button()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblmember)
        Me.GroupBox1.Controls.Add(Me.Acname)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Docdate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Docno)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(885, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblmember
        '
        Me.lblmember.AutoSize = True
        Me.lblmember.Location = New System.Drawing.Point(412, 41)
        Me.lblmember.Name = "lblmember"
        Me.lblmember.Size = New System.Drawing.Size(48, 15)
        Me.lblmember.TabIndex = 5
        Me.lblmember.Text = "Label6"
        '
        'Acname
        '
        Me.Acname.Location = New System.Drawing.Point(113, 41)
        Me.Acname.Name = "Acname"
        Me.Acname.Size = New System.Drawing.Size(281, 23)
        Me.Acname.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Account Name:-"
        '
        'Docdate
        '
        Me.Docdate.Location = New System.Drawing.Point(294, 13)
        Me.Docdate.Mask = "00/00/0000"
        Me.Docdate.Name = "Docdate"
        Me.Docdate.Size = New System.Drawing.Size(100, 23)
        Me.Docdate.TabIndex = 1
        Me.Docdate.ValidatingType = GetType(Date)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Doc Date:-"
        '
        'Docno
        '
        Me.Docno.Location = New System.Drawing.Point(113, 13)
        Me.Docno.Name = "Docno"
        Me.Docno.Size = New System.Drawing.Size(100, 23)
        Me.Docno.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Doc No:-"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Credit)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Billdate)
        Me.GroupBox2.Controls.Add(Me.Cmbdepartment)
        Me.GroupBox2.Controls.Add(Me.DG)
        Me.GroupBox2.Controls.Add(Me.Debit)
        Me.GroupBox2.Controls.Add(Me.BillNo)
        Me.GroupBox2.Controls.Add(Me.Sname)
        Me.GroupBox2.Controls.Add(Me.No)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(884, 307)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Credit
        '
        Me.Credit.Location = New System.Drawing.Point(760, 37)
        Me.Credit.Name = "Credit"
        Me.Credit.Size = New System.Drawing.Size(97, 23)
        Me.Credit.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(785, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 15)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Credit"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(584, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 15)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Bill No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(482, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 15)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Bill Date"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(338, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 15)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Bill Type"
        '
        'Billdate
        '
        Me.Billdate.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Billdate.Location = New System.Drawing.Point(459, 35)
        Me.Billdate.Mask = "00/00/0000"
        Me.Billdate.Name = "Billdate"
        Me.Billdate.Size = New System.Drawing.Size(100, 25)
        Me.Billdate.TabIndex = 6
        Me.Billdate.ValidatingType = GetType(Date)
        '
        'Cmbdepartment
        '
        Me.Cmbdepartment.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmbdepartment.FormattingEnabled = True
        Me.Cmbdepartment.Items.AddRange(New Object() {"KHATAR", "BHANDAR", "FATAKDA"})
        Me.Cmbdepartment.Location = New System.Drawing.Point(313, 37)
        Me.Cmbdepartment.Name = "Cmbdepartment"
        Me.Cmbdepartment.Size = New System.Drawing.Size(133, 23)
        Me.Cmbdepartment.TabIndex = 5
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7})
        Me.DG.Location = New System.Drawing.Point(6, 66)
        Me.DG.Name = "DG"
        Me.DG.RowHeadersVisible = False
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(862, 235)
        Me.DG.TabIndex = 28
        '
        'Column1
        '
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 250
        '
        'Column3
        '
        Me.Column3.HeaderText = "BillType"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Bill Date"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "Bill No"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Debit"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Credit"
        Me.Column7.Name = "Column7"
        '
        'Debit
        '
        Me.Debit.Location = New System.Drawing.Point(657, 37)
        Me.Debit.Name = "Debit"
        Me.Debit.Size = New System.Drawing.Size(97, 23)
        Me.Debit.TabIndex = 9
        '
        'BillNo
        '
        Me.BillNo.Location = New System.Drawing.Point(567, 37)
        Me.BillNo.Name = "BillNo"
        Me.BillNo.Size = New System.Drawing.Size(78, 23)
        Me.BillNo.TabIndex = 7
        '
        'Sname
        '
        Me.Sname.Location = New System.Drawing.Point(58, 37)
        Me.Sname.Name = "Sname"
        Me.Sname.Size = New System.Drawing.Size(249, 23)
        Me.Sname.TabIndex = 4
        '
        'No
        '
        Me.No.Location = New System.Drawing.Point(4, 37)
        Me.No.Name = "No"
        Me.No.Size = New System.Drawing.Size(46, 23)
        Me.No.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(112, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(103, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Sabhasad Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Location = New System.Drawing.Point(682, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 15)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "Debit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(12, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 15)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Nos"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ButLast)
        Me.GroupBox3.Controls.Add(Me.BUtPrev)
        Me.GroupBox3.Controls.Add(Me.ButNExt)
        Me.GroupBox3.Controls.Add(Me.ButFirst)
        Me.GroupBox3.Controls.Add(Me.ButFind)
        Me.GroupBox3.Controls.Add(Me.ButSave)
        Me.GroupBox3.Controls.Add(Me.ButDelete)
        Me.GroupBox3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(368, 380)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(163, 52)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'ButLast
        '
        Me.ButLast.Location = New System.Drawing.Point(133, 236)
        Me.ButLast.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButLast.Name = "ButLast"
        Me.ButLast.Size = New System.Drawing.Size(87, 28)
        Me.ButLast.TabIndex = 9
        Me.ButLast.Text = "&Last"
        Me.ButLast.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButLast.UseVisualStyleBackColor = True
        Me.ButLast.Visible = False
        '
        'BUtPrev
        '
        Me.BUtPrev.Location = New System.Drawing.Point(133, 201)
        Me.BUtPrev.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BUtPrev.Name = "BUtPrev"
        Me.BUtPrev.Size = New System.Drawing.Size(87, 28)
        Me.BUtPrev.TabIndex = 8
        Me.BUtPrev.Text = "Pre&v"
        Me.BUtPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUtPrev.UseVisualStyleBackColor = True
        Me.BUtPrev.Visible = False
        '
        'ButNExt
        '
        Me.ButNExt.Location = New System.Drawing.Point(133, 165)
        Me.ButNExt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButNExt.Name = "ButNExt"
        Me.ButNExt.Size = New System.Drawing.Size(87, 28)
        Me.ButNExt.TabIndex = 7
        Me.ButNExt.Text = "&Next"
        Me.ButNExt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButNExt.UseVisualStyleBackColor = True
        Me.ButNExt.Visible = False
        '
        'ButFirst
        '
        Me.ButFirst.Location = New System.Drawing.Point(133, 129)
        Me.ButFirst.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButFirst.Name = "ButFirst"
        Me.ButFirst.Size = New System.Drawing.Size(87, 28)
        Me.ButFirst.TabIndex = 6
        Me.ButFirst.Text = "Fi&rst"
        Me.ButFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButFirst.UseVisualStyleBackColor = True
        Me.ButFirst.Visible = False
        '
        'ButFind
        '
        Me.ButFind.Location = New System.Drawing.Point(133, 94)
        Me.ButFind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButFind.Name = "ButFind"
        Me.ButFind.Size = New System.Drawing.Size(87, 28)
        Me.ButFind.TabIndex = 5
        Me.ButFind.Text = "&Find"
        Me.ButFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButFind.UseVisualStyleBackColor = True
        Me.ButFind.Visible = False
        '
        'ButSave
        '
        Me.ButSave.Image = Global.WeightPavti.My.Resources.Resources.save
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.Location = New System.Drawing.Point(5, 15)
        Me.ButSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(73, 28)
        Me.ButSave.TabIndex = 0
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.Image = Global.WeightPavti.My.Resources.Resources.delete
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(84, 15)
        Me.ButDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(73, 28)
        Me.ButDelete.TabIndex = 1
        Me.ButDelete.TabStop = False
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(667, 385)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 18)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(780, 385)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 18)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Label11"
        '
        'MemberOpeningEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightPink
        Me.ClientSize = New System.Drawing.Size(902, 439)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MemberOpeningEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MemberOpeningEntry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Docdate As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Docno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Acname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DG As DataGridView
    Friend WithEvents Debit As TextBox
    Friend WithEvents BillNo As TextBox
    Friend WithEvents Sname As TextBox
    Friend WithEvents No As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ButLast As Button
    Friend WithEvents BUtPrev As Button
    Friend WithEvents ButNExt As Button
    Friend WithEvents ButFirst As Button
    Friend WithEvents ButFind As Button
    Friend WithEvents ButSave As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents lblmember As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Billdate As MaskedTextBox
    Friend WithEvents Cmbdepartment As ComboBox
    Friend WithEvents Credit As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
End Class

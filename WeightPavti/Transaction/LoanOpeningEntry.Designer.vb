<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoanOpeningEntry
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Billno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.billDt = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sname = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Netamt = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Columnname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Jamin1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.percent = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Period = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.duedt = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Loanno = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Jamin2 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.intamt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(72, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "DocNo"
        '
        'Billno
        '
        Me.Billno.Location = New System.Drawing.Point(132, 18)
        Me.Billno.Name = "Billno"
        Me.Billno.Size = New System.Drawing.Size(100, 26)
        Me.Billno.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(330, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date"
        '
        'billDt
        '
        Me.billDt.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.billDt.Location = New System.Drawing.Point(377, 15)
        Me.billDt.Mask = "00/00/0000"
        Me.billDt.Name = "billDt"
        Me.billDt.Size = New System.Drawing.Size(92, 25)
        Me.billDt.TabIndex = 1
        Me.billDt.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Sabhasad Name"
        '
        'sname
        '
        Me.sname.Location = New System.Drawing.Point(132, 50)
        Me.sname.Name = "sname"
        Me.sname.Size = New System.Drawing.Size(337, 26)
        Me.sname.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 19)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "NetAmount"
        '
        'Netamt
        '
        Me.Netamt.Location = New System.Drawing.Point(132, 173)
        Me.Netamt.Name = "Netamt"
        Me.Netamt.Size = New System.Drawing.Size(100, 26)
        Me.Netamt.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(305, 192)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(171, 69)
        Me.GroupBox4.TabIndex = 12
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
        Me.ButSave.TabIndex = 0
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "Column Name"
        '
        'Columnname
        '
        Me.Columnname.Location = New System.Drawing.Point(132, 79)
        Me.Columnname.Name = "Columnname"
        Me.Columnname.Size = New System.Drawing.Size(336, 26)
        Me.Columnname.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 19)
        Me.Label6.TabIndex = 278
        Me.Label6.Text = "Jamin 1"
        '
        'Jamin1
        '
        Me.Jamin1.Location = New System.Drawing.Point(105, 272)
        Me.Jamin1.Name = "Jamin1"
        Me.Jamin1.Size = New System.Drawing.Size(336, 26)
        Me.Jamin1.TabIndex = 4
        Me.Jamin1.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(48, 113)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 19)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "Percnt(%)"
        '
        'percent
        '
        Me.percent.Location = New System.Drawing.Point(132, 110)
        Me.percent.Name = "percent"
        Me.percent.Size = New System.Drawing.Size(100, 26)
        Me.percent.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(310, 113)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 19)
        Me.Label12.TabIndex = 3023
        Me.Label12.Text = "Period"
        '
        'Period
        '
        Me.Period.Location = New System.Drawing.Point(369, 109)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(100, 26)
        Me.Period.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(55, 144)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 19)
        Me.Label13.TabIndex = 3026
        Me.Label13.Text = "Due Date"
        '
        'duedt
        '
        Me.duedt.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duedt.Location = New System.Drawing.Point(132, 141)
        Me.duedt.Mask = "00/00/0000"
        Me.duedt.Name = "duedt"
        Me.duedt.Size = New System.Drawing.Size(99, 25)
        Me.duedt.TabIndex = 8
        Me.duedt.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(301, 144)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 19)
        Me.Label9.TabIndex = 3028
        Me.Label9.Text = "LoanNo"
        '
        'Loanno
        '
        Me.Loanno.Location = New System.Drawing.Point(369, 140)
        Me.Loanno.Name = "Loanno"
        Me.Loanno.Size = New System.Drawing.Size(100, 26)
        Me.Loanno.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(40, 306)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 19)
        Me.Label11.TabIndex = 3030
        Me.Label11.Text = "Jamin 2"
        '
        'Jamin2
        '
        Me.Jamin2.Location = New System.Drawing.Point(105, 303)
        Me.Jamin2.Name = "Jamin2"
        Me.Jamin2.Size = New System.Drawing.Size(336, 26)
        Me.Jamin2.TabIndex = 3029
        Me.Jamin2.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.intamt)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Jamin2)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Loanno)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.duedt)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Period)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.percent)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Jamin1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Columnname)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Netamt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.sname)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.billDt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Billno)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 336)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'intamt
        '
        Me.intamt.Location = New System.Drawing.Point(369, 172)
        Me.intamt.Name = "intamt"
        Me.intamt.Size = New System.Drawing.Size(100, 26)
        Me.intamt.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(241, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 19)
        Me.Label4.TabIndex = 3031
        Me.Label4.Text = "Interest Amt"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Dg)
        Me.GroupBox2.Location = New System.Drawing.Point(492, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(371, 326)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.BackgroundColor = System.Drawing.Color.White
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.Dg.Location = New System.Drawing.Point(6, 9)
        Me.Dg.Name = "Dg"
        Me.Dg.RowHeadersVisible = False
        Me.Dg.Size = New System.Drawing.Size(363, 311)
        Me.Dg.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Sr No"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.HeaderText = "Due Date"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Due Amount"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Int Amount"
        Me.Column4.Name = "Column4"
        '
        'LoanOpeningEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(865, 338)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LoanOpeningEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Opening Entry"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Billno As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents billDt As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents sname As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Netamt As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButSave As Button
    Friend WithEvents ButCAncel As Button
    Friend WithEvents ButPrint As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Columnname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Jamin1 As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents percent As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Period As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents duedt As MaskedTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Loanno As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Jamin2 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Dg As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents intamt As TextBox
End Class

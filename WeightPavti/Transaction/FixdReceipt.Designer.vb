<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FixdReceipt
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
        Me.Columnname = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Fixno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.duedt = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Period = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.percent = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.payac = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.acname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.Netamt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txtremark = New System.Windows.Forms.TextBox()
        Me.sname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.billDt = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Billno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Columnname)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Fixno)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.duedt)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Period)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.percent)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.payac)
        Me.GroupBox1.Controls.Add(Me.cmbtype)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.acname)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.Netamt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txtremark)
        Me.GroupBox1.Controls.Add(Me.sname)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.billDt)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Billno)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(483, 338)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Columnname
        '
        Me.Columnname.Location = New System.Drawing.Point(132, 79)
        Me.Columnname.Name = "Columnname"
        Me.Columnname.Size = New System.Drawing.Size(336, 26)
        Me.Columnname.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 19)
        Me.Label9.TabIndex = 3030
        Me.Label9.Text = "Column Name"
        '
        'Fixno
        '
        Me.Fixno.Location = New System.Drawing.Point(369, 205)
        Me.Fixno.Name = "Fixno"
        Me.Fixno.Size = New System.Drawing.Size(100, 26)
        Me.Fixno.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(310, 209)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 19)
        Me.Label7.TabIndex = 3028
        Me.Label7.Text = "Fixdno"
        '
        'duedt
        '
        Me.duedt.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.duedt.Location = New System.Drawing.Point(132, 206)
        Me.duedt.Mask = "00/00/0000"
        Me.duedt.Name = "duedt"
        Me.duedt.Size = New System.Drawing.Size(99, 25)
        Me.duedt.TabIndex = 8
        Me.duedt.ValidatingType = GetType(Date)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(55, 209)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 19)
        Me.Label13.TabIndex = 3026
        Me.Label13.Text = "Due Date"
        '
        'Period
        '
        Me.Period.Location = New System.Drawing.Point(369, 174)
        Me.Period.Name = "Period"
        Me.Period.Size = New System.Drawing.Size(100, 26)
        Me.Period.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(310, 178)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 19)
        Me.Label12.TabIndex = 3023
        Me.Label12.Text = "Period"
        '
        'percent
        '
        Me.percent.Location = New System.Drawing.Point(132, 175)
        Me.percent.Name = "percent"
        Me.percent.Size = New System.Drawing.Size(100, 26)
        Me.percent.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(48, 178)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 19)
        Me.Label10.TabIndex = 283
        Me.Label10.Text = "Percnt(%)"
        '
        'payac
        '
        Me.payac.BackColor = System.Drawing.Color.White
        Me.payac.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.payac.Location = New System.Drawing.Point(238, 143)
        Me.payac.MaxLength = 500
        Me.payac.Name = "payac"
        Me.payac.Size = New System.Drawing.Size(231, 26)
        Me.payac.TabIndex = 282
        '
        'cmbtype
        '
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"CASH", "BANK"})
        Me.cmbtype.Location = New System.Drawing.Point(132, 142)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(99, 27)
        Me.cmbtype.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(64, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 19)
        Me.Label8.TabIndex = 280
        Me.Label8.Text = "Paytype"
        '
        'acname
        '
        Me.acname.Location = New System.Drawing.Point(132, 108)
        Me.acname.Name = "acname"
        Me.acname.Size = New System.Drawing.Size(336, 26)
        Me.acname.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 19)
        Me.Label6.TabIndex = 278
        Me.Label6.Text = "Ac Name"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(297, 263)
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
        'Netamt
        '
        Me.Netamt.Location = New System.Drawing.Point(132, 272)
        Me.Netamt.Name = "Netamt"
        Me.Netamt.Size = New System.Drawing.Size(100, 26)
        Me.Netamt.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 275)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 19)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "NetAmount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 241)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Remarks"
        '
        'Txtremark
        '
        Me.Txtremark.BackColor = System.Drawing.Color.White
        Me.Txtremark.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtremark.Location = New System.Drawing.Point(132, 236)
        Me.Txtremark.MaxLength = 500
        Me.Txtremark.Name = "Txtremark"
        Me.Txtremark.Size = New System.Drawing.Size(337, 26)
        Me.Txtremark.TabIndex = 10
        '
        'sname
        '
        Me.sname.Location = New System.Drawing.Point(132, 50)
        Me.sname.Name = "sname"
        Me.sname.Size = New System.Drawing.Size(337, 26)
        Me.sname.TabIndex = 2
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(330, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date"
        '
        'Billno
        '
        Me.Billno.Location = New System.Drawing.Point(132, 18)
        Me.Billno.Name = "Billno"
        Me.Billno.Size = New System.Drawing.Size(100, 26)
        Me.Billno.TabIndex = 0
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
        'FixdReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(493, 349)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FixdReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FixdReceipt"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txtremark As TextBox
    Friend WithEvents sname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents billDt As MaskedTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Billno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Netamt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButSave As Button
    Friend WithEvents ButCAncel As Button
    Friend WithEvents ButPrint As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents acname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents payac As TextBox
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents duedt As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Period As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents percent As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Fixno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Columnname As TextBox
    Friend WithEvents Label9 As Label
End Class

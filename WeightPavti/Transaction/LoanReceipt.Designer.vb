<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoanReceipt
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.intrest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Creditint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dgflat = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pac = New System.Windows.Forms.TextBox()
        Me.intac = New System.Windows.Forms.TextBox()
        Me.pamt = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.intamt = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.amount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Loanno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.percent = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.payac = New System.Windows.Forms.TextBox()
        Me.cmbtype = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.acname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Columnname = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgflat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DG)
        Me.GroupBox1.Controls.Add(Me.Dgflat)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.pac)
        Me.GroupBox1.Controls.Add(Me.intac)
        Me.GroupBox1.Controls.Add(Me.pamt)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.intamt)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.amount)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Loanno)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.percent)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.payac)
        Me.GroupBox1.Controls.Add(Me.cmbtype)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.acname)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Columnname)
        Me.GroupBox1.Controls.Add(Me.Label7)
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
        Me.GroupBox1.Size = New System.Drawing.Size(870, 473)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.intrest, Me.Creditint, Me.dDays, Me.tr})
        Me.DG.GridColor = System.Drawing.Color.LightGray
        Me.DG.Location = New System.Drawing.Point(0, 274)
        Me.DG.Name = "DG"
        Me.DG.RowHeadersVisible = False
        Me.DG.Size = New System.Drawing.Size(860, 193)
        Me.DG.TabIndex = 55570
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Date"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "No"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 50
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Debit"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Credit"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Balance"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'intrest
        '
        Me.intrest.HeaderText = "Debitint"
        Me.intrest.Name = "intrest"
        '
        'Creditint
        '
        Me.Creditint.HeaderText = "Creditint"
        Me.Creditint.Name = "Creditint"
        '
        'dDays
        '
        Me.dDays.HeaderText = "days"
        Me.dDays.Name = "dDays"
        Me.dDays.Width = 50
        '
        'tr
        '
        Me.tr.HeaderText = "transmode"
        Me.tr.Name = "tr"
        Me.tr.Width = 150
        '
        'Dgflat
        '
        Me.Dgflat.AllowUserToAddRows = False
        Me.Dgflat.BackgroundColor = System.Drawing.Color.White
        Me.Dgflat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgflat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.cc, Me.Column4, Me.Column6, Me.Column7})
        Me.Dgflat.Location = New System.Drawing.Point(6, 218)
        Me.Dgflat.Name = "Dgflat"
        Me.Dgflat.RowHeadersVisible = False
        Me.Dgflat.Size = New System.Drawing.Size(11, 12)
        Me.Dgflat.TabIndex = 55572
        Me.Dgflat.Visible = False
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
        'Column5
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Paid Amount"
        Me.Column5.Name = "Column5"
        '
        'Column3
        '
        Me.Column3.HeaderText = "Due Amount"
        Me.Column3.Name = "Column3"
        '
        'cc
        '
        Me.cc.HeaderText = "Loan Balance"
        Me.cc.Name = "cc"
        '
        'Column4
        '
        Me.Column4.HeaderText = "Due Int Amount"
        Me.Column4.Name = "Column4"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Paid Int Amount"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "Int Balance"
        Me.Column7.Name = "Column7"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(629, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 22)
        Me.Label16.TabIndex = 55571
        Me.Label16.Text = "0.00"
        Me.Label16.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(481, 174)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(146, 22)
        Me.Label17.TabIndex = 55570
        Me.Label17.Text = "sBisd bik) Äyij rkm"
        Me.Label17.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(629, 147)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(44, 22)
        Me.Label14.TabIndex = 281
        Me.Label14.Text = "0.00"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(481, 147)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(142, 22)
        Me.Label15.TabIndex = 280
        Me.Label15.Text = "sBisd bik) li[n rkm"
        '
        'pac
        '
        Me.pac.Enabled = False
        Me.pac.Location = New System.Drawing.Point(238, 208)
        Me.pac.Name = "pac"
        Me.pac.Size = New System.Drawing.Size(230, 26)
        Me.pac.TabIndex = 3036
        '
        'intac
        '
        Me.intac.Enabled = False
        Me.intac.Location = New System.Drawing.Point(238, 175)
        Me.intac.Name = "intac"
        Me.intac.Size = New System.Drawing.Size(230, 26)
        Me.intac.TabIndex = 3035
        '
        'pamt
        '
        Me.pamt.Location = New System.Drawing.Point(131, 208)
        Me.pamt.Name = "pamt"
        Me.pamt.Size = New System.Drawing.Size(100, 26)
        Me.pamt.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(36, 211)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 19)
        Me.Label13.TabIndex = 3033
        Me.Label13.Text = "Panelty Amt"
        '
        'intamt
        '
        Me.intamt.Location = New System.Drawing.Point(132, 175)
        Me.intamt.Name = "intamt"
        Me.intamt.Size = New System.Drawing.Size(100, 26)
        Me.intamt.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(65, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 19)
        Me.Label12.TabIndex = 3032
        Me.Label12.Text = "Interest"
        '
        'amount
        '
        Me.amount.Location = New System.Drawing.Point(132, 144)
        Me.amount.Name = "amount"
        Me.amount.Size = New System.Drawing.Size(100, 26)
        Me.amount.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(64, 147)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 19)
        Me.Label11.TabIndex = 3030
        Me.Label11.Text = "Amount"
        '
        'Loanno
        '
        Me.Loanno.Enabled = False
        Me.Loanno.Location = New System.Drawing.Point(368, 111)
        Me.Loanno.Name = "Loanno"
        Me.Loanno.Size = New System.Drawing.Size(100, 26)
        Me.Loanno.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(300, 114)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 19)
        Me.Label9.TabIndex = 3028
        Me.Label9.Text = "LoanNo"
        '
        'percent
        '
        Me.percent.Enabled = False
        Me.percent.Location = New System.Drawing.Point(132, 111)
        Me.percent.Name = "percent"
        Me.percent.Size = New System.Drawing.Size(100, 26)
        Me.percent.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(48, 114)
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
        Me.payac.Location = New System.Drawing.Point(238, 80)
        Me.payac.MaxLength = 500
        Me.payac.Name = "payac"
        Me.payac.Size = New System.Drawing.Size(231, 26)
        Me.payac.TabIndex = 282
        '
        'cmbtype
        '
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"CASH", "BANK"})
        Me.cmbtype.Location = New System.Drawing.Point(132, 79)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(99, 27)
        Me.cmbtype.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(64, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 19)
        Me.Label8.TabIndex = 280
        Me.Label8.Text = "Paytype"
        '
        'acname
        '
        Me.acname.Enabled = False
        Me.acname.Location = New System.Drawing.Point(585, 80)
        Me.acname.Name = "acname"
        Me.acname.Size = New System.Drawing.Size(225, 26)
        Me.acname.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(511, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 19)
        Me.Label6.TabIndex = 278
        Me.Label6.Text = "Ac Name"
        '
        'Columnname
        '
        Me.Columnname.Location = New System.Drawing.Point(585, 50)
        Me.Columnname.Name = "Columnname"
        Me.Columnname.Size = New System.Drawing.Size(225, 26)
        Me.Columnname.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(475, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 19)
        Me.Label7.TabIndex = 276
        Me.Label7.Text = "Column Name"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(479, 197)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(224, 69)
        Me.GroupBox4.TabIndex = 11
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
        Me.ButSave.Size = New System.Drawing.Size(96, 28)
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
        Me.ButCAncel.Location = New System.Drawing.Point(116, 38)
        Me.ButCAncel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButCAncel.Name = "ButCAncel"
        Me.ButCAncel.Size = New System.Drawing.Size(99, 28)
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
        Me.ButPrint.Location = New System.Drawing.Point(116, 10)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(99, 28)
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
        Me.ButDelete.Size = New System.Drawing.Size(96, 28)
        Me.ButDelete.TabIndex = 53
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'Netamt
        '
        Me.Netamt.Location = New System.Drawing.Point(131, 240)
        Me.Netamt.Name = "Netamt"
        Me.Netamt.Size = New System.Drawing.Size(100, 26)
        Me.Netamt.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 243)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 19)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "NetAmount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(511, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 19)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Remarks"
        '
        'Txtremark
        '
        Me.Txtremark.BackColor = System.Drawing.Color.White
        Me.Txtremark.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtremark.Location = New System.Drawing.Point(585, 111)
        Me.Txtremark.MaxLength = 500
        Me.Txtremark.Name = "Txtremark"
        Me.Txtremark.Size = New System.Drawing.Size(225, 26)
        Me.Txtremark.TabIndex = 6
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
        'LoanReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(879, 476)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LoanReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LoanReceipt"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgflat, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Columnname As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents payac As TextBox
    Friend WithEvents cmbtype As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents percent As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Loanno As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents pac As TextBox
    Friend WithEvents intac As TextBox
    Friend WithEvents pamt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents intamt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents amount As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Dgflat As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cc As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents DG As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents intrest As DataGridViewTextBoxColumn
    Friend WithEvents Creditint As DataGridViewTextBoxColumn
    Friend WithEvents dDays As DataGridViewTextBoxColumn
    Friend WithEvents tr As DataGridViewTextBoxColumn
End Class

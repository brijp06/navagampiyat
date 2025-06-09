<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReceiptEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtintrest = New System.Windows.Forms.TextBox()
        Me.txtdisamt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtdis = New System.Windows.Forms.TextBox()
        Me.txtvillageid = New System.Windows.Forms.TextBox()
        Me.txtcolumn = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.txtprint = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInt = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PayBill = New System.Windows.Forms.Label()
        Me.netamt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTAmt = New System.Windows.Forms.Label()
        Me.lblTBags = New System.Windows.Forms.Label()
        Me.intamt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Billamt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.acname = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbType = New System.Windows.Forms.ComboBox()
        Me.Remarks = New System.Windows.Forms.TextBox()
        Me.billDt = New System.Windows.Forms.MaskedTextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Cname = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Billno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmbdepartment = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.txtintrest)
        Me.GroupBox1.Controls.Add(Me.txtdisamt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtdis)
        Me.GroupBox1.Controls.Add(Me.txtvillageid)
        Me.GroupBox1.Controls.Add(Me.txtcolumn)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lbltotal)
        Me.GroupBox1.Controls.Add(Me.txtprint)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblInt)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.PayBill)
        Me.GroupBox1.Controls.Add(Me.netamt)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblTAmt)
        Me.GroupBox1.Controls.Add(Me.lblTBags)
        Me.GroupBox1.Controls.Add(Me.intamt)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Billamt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.acname)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.cmbType)
        Me.GroupBox1.Controls.Add(Me.Remarks)
        Me.GroupBox1.Controls.Add(Me.billDt)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Cname)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Billno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Cmbdepartment)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, -5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 285)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.Black
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(605, 14)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(85, 28)
        Me.Button4.TabIndex = 55592
        Me.Button4.Text = "&Find"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtintrest
        '
        Me.txtintrest.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtintrest.ForeColor = System.Drawing.Color.Red
        Me.txtintrest.Location = New System.Drawing.Point(103, 149)
        Me.txtintrest.Name = "txtintrest"
        Me.txtintrest.Size = New System.Drawing.Size(45, 29)
        Me.txtintrest.TabIndex = 9
        '
        'txtdisamt
        '
        Me.txtdisamt.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdisamt.ForeColor = System.Drawing.Color.Blue
        Me.txtdisamt.Location = New System.Drawing.Point(155, 114)
        Me.txtdisamt.Name = "txtdisamt"
        Me.txtdisamt.Size = New System.Drawing.Size(98, 29)
        Me.txtdisamt.TabIndex = 55590
        Me.txtdisamt.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 19)
        Me.Label8.TabIndex = 55591
        Me.Label8.Text = "Discount"
        '
        'txtdis
        '
        Me.txtdis.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdis.ForeColor = System.Drawing.Color.Red
        Me.txtdis.Location = New System.Drawing.Point(103, 115)
        Me.txtdis.Name = "txtdis"
        Me.txtdis.Size = New System.Drawing.Size(45, 29)
        Me.txtdis.TabIndex = 8
        '
        'txtvillageid
        '
        Me.txtvillageid.Location = New System.Drawing.Point(428, 48)
        Me.txtvillageid.Name = "txtvillageid"
        Me.txtvillageid.Size = New System.Drawing.Size(239, 26)
        Me.txtvillageid.TabIndex = 5
        '
        'txtcolumn
        '
        Me.txtcolumn.Location = New System.Drawing.Point(673, 48)
        Me.txtcolumn.Name = "txtcolumn"
        Me.txtcolumn.Size = New System.Drawing.Size(144, 26)
        Me.txtcolumn.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(260, 183)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 23)
        Me.Label11.TabIndex = 3039
        Me.Label11.Text = "T[iTl (lF[l rkm:-"
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.BackColor = System.Drawing.Color.Transparent
        Me.lbltotal.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.ForeColor = System.Drawing.Color.Red
        Me.lbltotal.Location = New System.Drawing.Point(398, 183)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(110, 23)
        Me.lbltotal.TabIndex = 3038
        Me.lbltotal.Text = "Total Pay"
        '
        'txtprint
        '
        Me.txtprint.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprint.Location = New System.Drawing.Point(771, 82)
        Me.txtprint.Name = "txtprint"
        Me.txtprint.Size = New System.Drawing.Size(47, 23)
        Me.txtprint.TabIndex = 55587
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button3.Location = New System.Drawing.Point(698, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(9, 15)
        Me.Button3.TabIndex = 295
        Me.Button3.TabStop = False
        Me.Button3.Text = "Get Receipt Data"
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(259, 146)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 23)
        Me.Label10.TabIndex = 3037
        Me.Label10.Text = "(lF[l Äyij:-"
        '
        'lblInt
        '
        Me.lblInt.AutoSize = True
        Me.lblInt.BackColor = System.Drawing.Color.Transparent
        Me.lblInt.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblInt.Location = New System.Drawing.Point(371, 146)
        Me.lblInt.Name = "lblInt"
        Me.lblInt.Size = New System.Drawing.Size(93, 23)
        Me.lblInt.TabIndex = 3035
        Me.lblInt.Text = "Interest"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(733, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 15)
        Me.Label12.TabIndex = 55588
        Me.Label12.Text = "Print"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(455, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 23)
        Me.Label9.TabIndex = 3036
        Me.Label9.Text = "(lF[l b)l:-"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Location = New System.Drawing.Point(434, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 30)
        Me.Button1.TabIndex = 294
        Me.Button1.TabStop = False
        Me.Button1.Text = "Select All"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'PayBill
        '
        Me.PayBill.AutoSize = True
        Me.PayBill.BackColor = System.Drawing.Color.Transparent
        Me.PayBill.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayBill.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PayBill.Location = New System.Drawing.Point(557, 114)
        Me.PayBill.Name = "PayBill"
        Me.PayBill.Size = New System.Drawing.Size(91, 23)
        Me.PayBill.TabIndex = 3034
        Me.PayBill.Text = "PayBill"
        '
        'netamt
        '
        Me.netamt.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.netamt.ForeColor = System.Drawing.Color.Blue
        Me.netamt.Location = New System.Drawing.Point(101, 182)
        Me.netamt.Name = "netamt"
        Me.netamt.Size = New System.Drawing.Size(151, 29)
        Me.netamt.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 19)
        Me.Label7.TabIndex = 293
        Me.Label7.Text = "Net Amount"
        '
        'lblTAmt
        '
        Me.lblTAmt.AutoSize = True
        Me.lblTAmt.BackColor = System.Drawing.Color.Transparent
        Me.lblTAmt.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAmt.ForeColor = System.Drawing.Color.Red
        Me.lblTAmt.Location = New System.Drawing.Point(258, 112)
        Me.lblTAmt.Name = "lblTAmt"
        Me.lblTAmt.Size = New System.Drawing.Size(96, 23)
        Me.lblTAmt.TabIndex = 3030
        Me.lblTAmt.Text = "Ti[Tl b)l:-"
        '
        'lblTBags
        '
        Me.lblTBags.AutoSize = True
        Me.lblTBags.BackColor = System.Drawing.Color.Transparent
        Me.lblTBags.Font = New System.Drawing.Font("HARIKRISHNA", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTBags.ForeColor = System.Drawing.Color.Blue
        Me.lblTBags.Location = New System.Drawing.Point(354, 114)
        Me.lblTBags.Name = "lblTBags"
        Me.lblTBags.Size = New System.Drawing.Size(95, 23)
        Me.lblTBags.TabIndex = 3029
        Me.lblTBags.Text = "TotalInt"
        '
        'intamt
        '
        Me.intamt.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.intamt.ForeColor = System.Drawing.Color.Blue
        Me.intamt.Location = New System.Drawing.Point(155, 148)
        Me.intamt.Name = "intamt"
        Me.intamt.Size = New System.Drawing.Size(98, 29)
        Me.intamt.TabIndex = 8
        Me.intamt.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 19)
        Me.Label6.TabIndex = 291
        Me.Label6.Text = "interest"
        '
        'Billamt
        '
        Me.Billamt.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Billamt.ForeColor = System.Drawing.Color.Blue
        Me.Billamt.Location = New System.Drawing.Point(101, 81)
        Me.Billamt.Name = "Billamt"
        Me.Billamt.Size = New System.Drawing.Size(151, 29)
        Me.Billamt.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 19)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Amount"
        '
        'acname
        '
        Me.acname.Location = New System.Drawing.Point(208, 219)
        Me.acname.Name = "acname"
        Me.acname.Size = New System.Drawing.Size(328, 26)
        Me.acname.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Location = New System.Drawing.Point(28, 220)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 19)
        Me.Label17.TabIndex = 286
        Me.Label17.Text = "Bill Type"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button2.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(584, 78)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 30)
        Me.Button2.TabIndex = 295
        Me.Button2.TabStop = False
        Me.Button2.Text = "Select Bill "
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmbType
        '
        Me.cmbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"Cash", "Bank"})
        Me.cmbType.Location = New System.Drawing.Point(101, 217)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(100, 28)
        Me.cmbType.TabIndex = 11
        '
        'Remarks
        '
        Me.Remarks.Location = New System.Drawing.Point(101, 250)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(435, 26)
        Me.Remarks.TabIndex = 13
        '
        'billDt
        '
        Me.billDt.Font = New System.Drawing.Font("HARIKRISHNA", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.billDt.Location = New System.Drawing.Point(494, 16)
        Me.billDt.Mask = "00/00/0000"
        Me.billDt.Name = "billDt"
        Me.billDt.Size = New System.Drawing.Size(85, 26)
        Me.billDt.TabIndex = 3
        Me.billDt.ValidatingType = GetType(Date)
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(28, 254)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(70, 19)
        Me.Label31.TabIndex = 284
        Me.Label31.Text = "Remarks"
        '
        'Cname
        '
        Me.Cname.Location = New System.Drawing.Point(101, 48)
        Me.Cname.Name = "Cname"
        Me.Cname.Size = New System.Drawing.Size(321, 26)
        Me.Cname.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 19)
        Me.Label4.TabIndex = 270
        Me.Label4.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(426, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 19)
        Me.Label3.TabIndex = 268
        Me.Label3.Text = "Bill Date"
        '
        'Billno
        '
        Me.Billno.Location = New System.Drawing.Point(317, 16)
        Me.Billno.Name = "Billno"
        Me.Billno.Size = New System.Drawing.Size(107, 26)
        Me.Billno.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(258, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Bill No"
        '
        'Cmbdepartment
        '
        Me.Cmbdepartment.FormattingEnabled = True
        Me.Cmbdepartment.Items.AddRange(New Object() {"MANGNARECEIPT"})
        Me.Cmbdepartment.Location = New System.Drawing.Point(101, 15)
        Me.Cmbdepartment.Name = "Cmbdepartment"
        Me.Cmbdepartment.Size = New System.Drawing.Size(151, 27)
        Me.Cmbdepartment.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Department"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dg)
        Me.GroupBox2.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 283)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(990, 254)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'dg
        '
        Me.dg.AllowUserToAddRows = False
        Me.dg.BackgroundColor = System.Drawing.Color.White
        Me.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column8, Me.Column10, Me.Column13, Me.Column2, Me.Column3, Me.Column11, Me.Column12, Me.Column14, Me.Column16, Me.Column17, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column9})
        Me.dg.Location = New System.Drawing.Point(-1, 13)
        Me.dg.Name = "dg"
        Me.dg.RowHeadersVisible = False
        Me.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg.Size = New System.Drawing.Size(981, 228)
        Me.dg.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "n>"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 30
        '
        'Column8
        '
        Me.Column8.HeaderText = "gim n&> nim"
        Me.Column8.Name = "Column8"
        '
        'Column10
        '
        Me.Column10.HeaderText = "ki[lm ki[D"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 60
        '
        'Column13
        '
        Me.Column13.HeaderText = "ki[lm nim"
        Me.Column13.Name = "Column13"
        '
        'Column2
        '
        Me.Column2.HeaderText = "¾li[k n>"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "sv[< n>"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 80
        '
        'Column11
        '
        Me.Column11.HeaderText = "a[.a[kr"
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 80
        '
        'Column12
        '
        Me.Column12.HeaderText = "a[..g&>qi"
        Me.Column12.Name = "Column12"
        Me.Column12.Width = 80
        '
        'Column14
        '
        Me.Column14.HeaderText = "rkm"
        Me.Column14.Name = "Column14"
        '
        'Column16
        '
        Me.Column16.HeaderText = "li[.rkm"
        Me.Column16.Name = "Column16"
        '
        'Column17
        '
        Me.Column17.HeaderText = "n[T rkm"
        Me.Column17.Name = "Column17"
        '
        'Column4
        '
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 40
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 5
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 5
        '
        'Column7
        '
        Me.Column7.HeaderText = "Column7"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 5
        '
        'Column9
        '
        Me.Column9.HeaderText = "Column9"
        Me.Column9.Name = "Column9"
        Me.Column9.Width = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(696, 543)
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
        'FrmReceiptEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightPink
        Me.ClientSize = New System.Drawing.Size(1001, 624)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReceiptEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReceiptEntry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Remarks As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents Cname As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents billDt As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Billno As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmbdepartment As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents acname As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButSave As Button
    Friend WithEvents ButCAncel As Button
    Friend WithEvents ButPrint As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents netamt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents intamt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Billamt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents lblTAmt As Label
    Friend WithEvents lblTBags As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblInt As Label
    Friend WithEvents PayBill As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lbltotal As Label
    Friend WithEvents txtprint As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents txtcolumn As TextBox
    Friend WithEvents txtvillageid As TextBox
    Friend WithEvents dg As DataGridView
    Friend WithEvents txtintrest As TextBox
    Friend WithEvents txtdisamt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtdis As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPackingEntry
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
        Me.tqty = New System.Windows.Forms.TextBox()
        Me.Itemid = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Sizename = New System.Windows.Forms.TextBox()
        Me.qty = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.itemname = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblstock = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.billDt = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Billno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmbdepartment = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.MRP = New System.Windows.Forms.TextBox()
        Me.padtrate = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtitemid = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsizename = New System.Windows.Forms.TextBox()
        Me.Dg = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtitemname = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.srno = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tqty)
        Me.GroupBox1.Controls.Add(Me.Itemid)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Barcode)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Sizename)
        Me.GroupBox1.Controls.Add(Me.qty)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.itemname)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblstock)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.billDt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Billno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Cmbdepartment)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(833, 120)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'tqty
        '
        Me.tqty.Enabled = False
        Me.tqty.Location = New System.Drawing.Point(390, 82)
        Me.tqty.Name = "tqty"
        Me.tqty.Size = New System.Drawing.Size(68, 26)
        Me.tqty.TabIndex = 329
        '
        'Itemid
        '
        Me.Itemid.Location = New System.Drawing.Point(327, 50)
        Me.Itemid.Name = "Itemid"
        Me.Itemid.Size = New System.Drawing.Size(99, 26)
        Me.Itemid.TabIndex = 320
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(265, 53)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(58, 19)
        Me.Label33.TabIndex = 327
        Me.Label33.Text = "Item Id"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 19)
        Me.Label12.TabIndex = 326
        Me.Label12.Text = "Barcode"
        '
        'Barcode
        '
        Me.Barcode.Location = New System.Drawing.Point(101, 48)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(158, 26)
        Me.Barcode.TabIndex = 318
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(18, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 19)
        Me.Label14.TabIndex = 325
        Me.Label14.Text = "Size Name"
        '
        'Sizename
        '
        Me.Sizename.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sizename.Location = New System.Drawing.Point(101, 80)
        Me.Sizename.Name = "Sizename"
        Me.Sizename.Size = New System.Drawing.Size(85, 23)
        Me.Sizename.TabIndex = 323
        '
        'qty
        '
        Me.qty.Location = New System.Drawing.Point(327, 82)
        Me.qty.Name = "qty"
        Me.qty.Size = New System.Drawing.Size(58, 26)
        Me.qty.TabIndex = 324
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Location = New System.Drawing.Point(282, 86)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 19)
        Me.Label18.TabIndex = 321
        Me.Label18.Text = "Qnty"
        '
        'itemname
        '
        Me.itemname.Location = New System.Drawing.Point(517, 53)
        Me.itemname.Name = "itemname"
        Me.itemname.Size = New System.Drawing.Size(151, 26)
        Me.itemname.TabIndex = 322
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(430, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 19)
        Me.Label15.TabIndex = 319
        Me.Label15.Text = "Item Name"
        '
        'lblstock
        '
        Me.lblstock.AutoSize = True
        Me.lblstock.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstock.ForeColor = System.Drawing.Color.Red
        Me.lblstock.Location = New System.Drawing.Point(593, 84)
        Me.lblstock.Name = "lblstock"
        Me.lblstock.Size = New System.Drawing.Size(44, 22)
        Me.lblstock.TabIndex = 283
        Me.lblstock.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(513, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 22)
        Me.Label13.TabIndex = 282
        Me.Label13.Text = "ATi[k b[l[ºs"
        '
        'billDt
        '
        Me.billDt.Font = New System.Drawing.Font("HARIKRISHNA", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.billDt.Location = New System.Drawing.Point(517, 20)
        Me.billDt.Mask = "00/00/0000"
        Me.billDt.Name = "billDt"
        Me.billDt.Size = New System.Drawing.Size(85, 26)
        Me.billDt.TabIndex = 269
        Me.billDt.ValidatingType = GetType(Date)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(447, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 19)
        Me.Label3.TabIndex = 268
        Me.Label3.Text = "Bill Date"
        '
        'Billno
        '
        Me.Billno.Location = New System.Drawing.Point(327, 18)
        Me.Billno.Name = "Billno"
        Me.Billno.Size = New System.Drawing.Size(100, 26)
        Me.Billno.TabIndex = 267
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(268, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 19)
        Me.Label2.TabIndex = 266
        Me.Label2.Text = "Bill No"
        '
        'Cmbdepartment
        '
        Me.Cmbdepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbdepartment.FormattingEnabled = True
        Me.Cmbdepartment.Items.AddRange(New Object() {"BHANDAR"})
        Me.Cmbdepartment.Location = New System.Drawing.Point(101, 15)
        Me.Cmbdepartment.Name = "Cmbdepartment"
        Me.Cmbdepartment.Size = New System.Drawing.Size(158, 27)
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
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.MRP)
        Me.GroupBox2.Controls.Add(Me.padtrate)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtitemid)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtbarcode)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtsizename)
        Me.GroupBox2.Controls.Add(Me.Dg)
        Me.GroupBox2.Controls.Add(Me.txtqty)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtitemname)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.srno)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 127)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(834, 288)
        Me.GroupBox2.TabIndex = 279
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(736, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 321
        Me.Label9.Text = "MRP"
        '
        'MRP
        '
        Me.MRP.Location = New System.Drawing.Point(713, 33)
        Me.MRP.Name = "MRP"
        Me.MRP.Size = New System.Drawing.Size(93, 23)
        Me.MRP.TabIndex = 297
        '
        'padtrate
        '
        Me.padtrate.Location = New System.Drawing.Point(625, 33)
        Me.padtrate.Name = "padtrate"
        Me.padtrate.Size = New System.Drawing.Size(82, 23)
        Me.padtrate.TabIndex = 296
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(635, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 15)
        Me.Label10.TabIndex = 318
        Me.Label10.Text = "PadtRate"
        '
        'txtitemid
        '
        Me.txtitemid.Location = New System.Drawing.Point(221, 33)
        Me.txtitemid.Name = "txtitemid"
        Me.txtitemid.Size = New System.Drawing.Size(65, 23)
        Me.txtitemid.TabIndex = 287
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 15)
        Me.Label4.TabIndex = 317
        Me.Label4.Text = "Item Id"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(98, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 308
        Me.Label5.Text = "Barcode"
        '
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(55, 34)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(158, 23)
        Me.txtbarcode.TabIndex = 286
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(470, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 306
        Me.Label6.Text = "Size Name"
        '
        'txtsizename
        '
        Me.txtsizename.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsizename.Location = New System.Drawing.Point(453, 34)
        Me.txtsizename.Name = "txtsizename"
        Me.txtsizename.Size = New System.Drawing.Size(85, 23)
        Me.txtsizename.TabIndex = 289
        '
        'Dg
        '
        Me.Dg.AllowUserToAddRows = False
        Me.Dg.BackgroundColor = System.Drawing.Color.White
        Me.Dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column19, Me.Column2, Me.Column18, Me.Column3, Me.Column4, Me.Column5})
        Me.Dg.Location = New System.Drawing.Point(6, 63)
        Me.Dg.Name = "Dg"
        Me.Dg.RowHeadersVisible = False
        Me.Dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dg.Size = New System.Drawing.Size(821, 219)
        Me.Dg.TabIndex = 304
        '
        'Column1
        '
        Me.Column1.HeaderText = "Srno"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column19
        '
        Me.Column19.HeaderText = "Barcode"
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 170
        '
        'Column2
        '
        Me.Column2.HeaderText = "Itemname"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 155
        '
        'Column18
        '
        Me.Column18.HeaderText = "SizeName"
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 155
        '
        'Column3
        '
        Me.Column3.HeaderText = "Qnty"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "PadtRate"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "MRP"
        Me.Column5.Name = "Column5"
        '
        'txtqty
        '
        Me.txtqty.Location = New System.Drawing.Point(544, 34)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(75, 23)
        Me.txtqty.TabIndex = 295
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(554, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 15)
        Me.Label7.TabIndex = 288
        Me.Label7.Text = "Qnty"
        '
        'txtitemname
        '
        Me.txtitemname.Location = New System.Drawing.Point(296, 34)
        Me.txtitemname.Name = "txtitemname"
        Me.txtitemname.Size = New System.Drawing.Size(151, 23)
        Me.txtitemname.TabIndex = 288
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(346, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 15)
        Me.Label8.TabIndex = 286
        Me.Label8.Text = "Item Name"
        '
        'srno
        '
        Me.srno.Location = New System.Drawing.Point(6, 34)
        Me.srno.Name = "srno"
        Me.srno.Size = New System.Drawing.Size(47, 23)
        Me.srno.TabIndex = 285
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(11, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 15)
        Me.Label32.TabIndex = 284
        Me.Label32.Text = "Sr No"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ButSave)
        Me.GroupBox4.Controls.Add(Me.ButCAncel)
        Me.GroupBox4.Controls.Add(Me.ButPrint)
        Me.GroupBox4.Controls.Add(Me.ButDelete)
        Me.GroupBox4.Location = New System.Drawing.Point(660, 423)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(177, 69)
        Me.GroupBox4.TabIndex = 280
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
        'FrmPackingEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(842, 504)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPackingEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPackingEntry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblstock As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents billDt As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Billno As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Cmbdepartment As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Itemid As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Barcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Sizename As TextBox
    Friend WithEvents qty As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents itemname As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtitemid As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsizename As TextBox
    Friend WithEvents Dg As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents txtqty As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtitemname As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents srno As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ButSave As Button
    Friend WithEvents ButCAncel As Button
    Friend WithEvents ButPrint As Button
    Friend WithEvents ButDelete As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents MRP As TextBox
    Friend WithEvents padtrate As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents tqty As TextBox
End Class

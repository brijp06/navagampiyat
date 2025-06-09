<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rate_Master
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtpenamt = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtamount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtmonthname = New System.Windows.Forms.TextBox
        Me.txtmonthid = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ButPrint = New System.Windows.Forms.Button
        Me.ButLast = New System.Windows.Forms.Button
        Me.BUtPrev = New System.Windows.Forms.Button
        Me.ButNExt = New System.Windows.Forms.Button
        Me.ButFirst = New System.Windows.Forms.Button
        Me.ButFind = New System.Windows.Forms.Button
        Me.ButSave = New System.Windows.Forms.Button
        Me.ButDelete = New System.Windows.Forms.Button
        Me.ButAdd = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LBrec = New System.Windows.Forms.Label
        Me.txtsearch = New System.Windows.Forms.TextBox
        Me.DgDoc_Column = New System.Windows.Forms.DataGridView
        Me.cmbSearchby = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtpenamt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtamount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtmonthname)
        Me.GroupBox1.Controls.Add(Me.txtmonthid)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(513, 4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(398, 346)
        Me.GroupBox1.TabIndex = 80
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rate Information"
        '
        'txtpenamt
        '
        Me.txtpenamt.BackColor = System.Drawing.Color.White
        Me.txtpenamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpenamt.Location = New System.Drawing.Point(89, 125)
        Me.txtpenamt.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpenamt.MaxLength = 100
        Me.txtpenamt.Name = "txtpenamt"
        Me.txtpenamt.Size = New System.Drawing.Size(301, 27)
        Me.txtpenamt.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(35, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Pen Amt:"
        '
        'txtamount
        '
        Me.txtamount.BackColor = System.Drawing.Color.White
        Me.txtamount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamount.Location = New System.Drawing.Point(89, 89)
        Me.txtamount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtamount.MaxLength = 100
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(301, 27)
        Me.txtamount.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(34, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Amount :"
        '
        'txtmonthname
        '
        Me.txtmonthname.BackColor = System.Drawing.Color.White
        Me.txtmonthname.Font = New System.Drawing.Font("HARIKRISHNA", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonthname.Location = New System.Drawing.Point(89, 54)
        Me.txtmonthname.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtmonthname.MaxLength = 100
        Me.txtmonthname.Name = "txtmonthname"
        Me.txtmonthname.Size = New System.Drawing.Size(301, 26)
        Me.txtmonthname.TabIndex = 6
        '
        'txtmonthid
        '
        Me.txtmonthid.BackColor = System.Drawing.Color.White
        Me.txtmonthid.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonthid.Location = New System.Drawing.Point(89, 23)
        Me.txtmonthid.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtmonthid.Name = "txtmonthid"
        Me.txtmonthid.Size = New System.Drawing.Size(116, 23)
        Me.txtmonthid.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(7, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Month Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Month Id :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ButPrint)
        Me.GroupBox2.Controls.Add(Me.ButLast)
        Me.GroupBox2.Controls.Add(Me.BUtPrev)
        Me.GroupBox2.Controls.Add(Me.ButNExt)
        Me.GroupBox2.Controls.Add(Me.ButFirst)
        Me.GroupBox2.Controls.Add(Me.ButFind)
        Me.GroupBox2.Controls.Add(Me.ButSave)
        Me.GroupBox2.Controls.Add(Me.ButDelete)
        Me.GroupBox2.Controls.Add(Me.ButAdd)
        Me.GroupBox2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(513, 350)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(398, 82)
        Me.GroupBox2.TabIndex = 81
        Me.GroupBox2.TabStop = False
        '
        'ButPrint
        '
        Me.ButPrint.Image = Global.WeightPavti.My.Resources.Resources.print
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(287, 14)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(73, 28)
        Me.ButPrint.TabIndex = 14
        Me.ButPrint.TabStop = False
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButPrint.UseVisualStyleBackColor = True
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
        Me.ButSave.Location = New System.Drawing.Point(208, 14)
        Me.ButSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(73, 28)
        Me.ButSave.TabIndex = 9
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.Image = Global.WeightPavti.My.Resources.Resources.delete
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(129, 14)
        Me.ButDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(73, 28)
        Me.ButDelete.TabIndex = 2
        Me.ButDelete.TabStop = False
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'ButAdd
        '
        Me.ButAdd.Image = Global.WeightPavti.My.Resources.Resources.Add
        Me.ButAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButAdd.Location = New System.Drawing.Point(51, 14)
        Me.ButAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButAdd.Name = "ButAdd"
        Me.ButAdd.Size = New System.Drawing.Size(73, 28)
        Me.ButAdd.TabIndex = 0
        Me.ButAdd.TabStop = False
        Me.ButAdd.Text = "&Add"
        Me.ButAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.LBrec)
        Me.GroupBox3.Controls.Add(Me.txtsearch)
        Me.GroupBox3.Controls.Add(Me.DgDoc_Column)
        Me.GroupBox3.Controls.Add(Me.cmbSearchby)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(505, 429)
        Me.GroupBox3.TabIndex = 82
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search"
        '
        'LBrec
        '
        Me.LBrec.AutoSize = True
        Me.LBrec.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBrec.ForeColor = System.Drawing.Color.Black
        Me.LBrec.Location = New System.Drawing.Point(22, 408)
        Me.LBrec.Name = "LBrec"
        Me.LBrec.Size = New System.Drawing.Size(49, 15)
        Me.LBrec.TabIndex = 65
        Me.LBrec.Text = "Search :"
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(190, 18)
        Me.txtsearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(141, 23)
        Me.txtsearch.TabIndex = 63
        '
        'DgDoc_Column
        '
        Me.DgDoc_Column.AllowUserToAddRows = False
        Me.DgDoc_Column.AllowUserToDeleteRows = False
        Me.DgDoc_Column.AllowUserToOrderColumns = True
        Me.DgDoc_Column.AllowUserToResizeRows = False
        Me.DgDoc_Column.BackgroundColor = System.Drawing.Color.Ivory
        Me.DgDoc_Column.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDoc_Column.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgDoc_Column.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgDoc_Column.Location = New System.Drawing.Point(2, 48)
        Me.DgDoc_Column.Margin = New System.Windows.Forms.Padding(5)
        Me.DgDoc_Column.MultiSelect = False
        Me.DgDoc_Column.Name = "DgDoc_Column"
        Me.DgDoc_Column.ReadOnly = True
        Me.DgDoc_Column.RowHeadersWidth = 30
        Me.DgDoc_Column.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDoc_Column.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgDoc_Column.Size = New System.Drawing.Size(496, 352)
        Me.DgDoc_Column.StandardTab = True
        Me.DgDoc_Column.TabIndex = 56
        '
        'cmbSearchby
        '
        Me.cmbSearchby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchby.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSearchby.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchby.FormattingEnabled = True
        Me.cmbSearchby.Items.AddRange(New Object() {"Party Id", "Party Name"})
        Me.cmbSearchby.Location = New System.Drawing.Point(61, 18)
        Me.cmbSearchby.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSearchby.Name = "cmbSearchby"
        Me.cmbSearchby.Size = New System.Drawing.Size(125, 23)
        Me.cmbSearchby.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search :"
        '
        'Rate_Master
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(918, 433)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Rate_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rate_Master"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpenamt As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtamount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtmonthname As System.Windows.Forms.TextBox
    Friend WithEvents txtmonthid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButPrint As System.Windows.Forms.Button
    Friend WithEvents ButLast As System.Windows.Forms.Button
    Friend WithEvents BUtPrev As System.Windows.Forms.Button
    Friend WithEvents ButNExt As System.Windows.Forms.Button
    Friend WithEvents ButFirst As System.Windows.Forms.Button
    Friend WithEvents ButFind As System.Windows.Forms.Button
    Friend WithEvents ButSave As System.Windows.Forms.Button
    Friend WithEvents ButDelete As System.Windows.Forms.Button
    Friend WithEvents ButAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LBrec As System.Windows.Forms.Label
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents DgDoc_Column As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class

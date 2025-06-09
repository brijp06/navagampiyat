<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PartyMaster
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PartyMaster))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LBrec = New System.Windows.Forms.Label()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.DgDoc_Column = New System.Windows.Forms.DataGridView()
        Me.cmbSearchby = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BuExit = New System.Windows.Forms.Button()
        Me.ButLast = New System.Windows.Forms.Button()
        Me.BUtPrev = New System.Windows.Forms.Button()
        Me.ButNExt = New System.Windows.Forms.Button()
        Me.ButFirst = New System.Windows.Forms.Button()
        Me.ButFind = New System.Windows.Forms.Button()
        Me.ButEdit = New System.Windows.Forms.Button()
        Me.ButAdd = New System.Windows.Forms.Button()
        Me.ButDelete = New System.Windows.Forms.Button()
        Me.ButSave = New System.Windows.Forms.Button()
        Me.ButCAncel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtmobileno = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtpartyName = New System.Windows.Forms.TextBox()
        Me.txtpartyId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GroupBox3.Location = New System.Drawing.Point(6, -2)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(339, 429)
        Me.GroupBox3.TabIndex = 78
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
        Me.DgDoc_Column.Size = New System.Drawing.Size(332, 352)
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
        'BuExit
        '
        Me.BuExit.Image = Global.WeightPavti.My.Resources.Resources.close
        Me.BuExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BuExit.Location = New System.Drawing.Point(159, 48)
        Me.BuExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BuExit.Name = "BuExit"
        Me.BuExit.Size = New System.Drawing.Size(73, 28)
        Me.BuExit.TabIndex = 10
        Me.BuExit.Text = "E&xit"
        Me.BuExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BuExit, "Close Window")
        Me.BuExit.UseVisualStyleBackColor = True
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
        Me.ToolTip1.SetToolTip(Me.ButLast, "Go To Last Entry")
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
        Me.ToolTip1.SetToolTip(Me.BUtPrev, "Go To Previous Entry")
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
        Me.ToolTip1.SetToolTip(Me.ButNExt, "Go To Next Entry")
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
        Me.ToolTip1.SetToolTip(Me.ButFirst, "Go To First Entry")
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
        Me.ToolTip1.SetToolTip(Me.ButFind, "Find Entry")
        Me.ButFind.UseVisualStyleBackColor = True
        Me.ButFind.Visible = False
        '
        'ButEdit
        '
        Me.ButEdit.Image = Global.WeightPavti.My.Resources.Resources.edit
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.Location = New System.Drawing.Point(127, 14)
        Me.ButEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(73, 28)
        Me.ButEdit.TabIndex = 1
        Me.ButEdit.Text = "&Edit"
        Me.ButEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButEdit, "Edit Selected Entry")
        Me.ButEdit.UseVisualStyleBackColor = True
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
        Me.ButAdd.Text = "&Add"
        Me.ButAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButAdd, "Add New Entry")
        Me.ButAdd.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.Image = Global.WeightPavti.My.Resources.Resources.delete
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(203, 14)
        Me.ButDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(73, 28)
        Me.ButDelete.TabIndex = 2
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButDelete, "Delete Selected Entry")
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'ButSave
        '
        Me.ButSave.Image = Global.WeightPavti.My.Resources.Resources.save
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.Location = New System.Drawing.Point(279, 14)
        Me.ButSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(73, 28)
        Me.ButSave.TabIndex = 3
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButSave, "Entry Save")
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButCAncel
        '
        Me.ButCAncel.Image = Global.WeightPavti.My.Resources.Resources.Cancel
        Me.ButCAncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCAncel.Location = New System.Drawing.Point(83, 48)
        Me.ButCAncel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButCAncel.Name = "ButCAncel"
        Me.ButCAncel.Size = New System.Drawing.Size(73, 28)
        Me.ButCAncel.TabIndex = 4
        Me.ButCAncel.Text = "&Cancel"
        Me.ButCAncel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButCAncel, "Cancel Entry")
        Me.ButCAncel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.ButPrint)
        Me.GroupBox2.Controls.Add(Me.BuExit)
        Me.GroupBox2.Controls.Add(Me.ButLast)
        Me.GroupBox2.Controls.Add(Me.BUtPrev)
        Me.GroupBox2.Controls.Add(Me.ButNExt)
        Me.GroupBox2.Controls.Add(Me.ButFirst)
        Me.GroupBox2.Controls.Add(Me.ButFind)
        Me.GroupBox2.Controls.Add(Me.ButCAncel)
        Me.GroupBox2.Controls.Add(Me.ButSave)
        Me.GroupBox2.Controls.Add(Me.ButDelete)
        Me.GroupBox2.Controls.Add(Me.ButEdit)
        Me.GroupBox2.Controls.Add(Me.ButAdd)
        Me.GroupBox2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(350, 345)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(398, 82)
        Me.GroupBox2.TabIndex = 80
        Me.GroupBox2.TabStop = False
        '
        'ButPrint
        '
        Me.ButPrint.Image = Global.WeightPavti.My.Resources.Resources.print
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(235, 48)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(73, 28)
        Me.ButPrint.TabIndex = 14
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButPrint, "Print Account Group Master List")
        Me.ButPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txtmobileno)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtpartyName)
        Me.GroupBox1.Controls.Add(Me.txtpartyId)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(350, -2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(398, 345)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sizan Information"
        '
        'txtmobileno
        '
        Me.txtmobileno.BackColor = System.Drawing.Color.White
        Me.txtmobileno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmobileno.Location = New System.Drawing.Point(89, 89)
        Me.txtmobileno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtmobileno.MaxLength = 100
        Me.txtmobileno.Name = "txtmobileno"
        Me.txtmobileno.Size = New System.Drawing.Size(301, 27)
        Me.txtmobileno.TabIndex = 7
        Me.txtmobileno.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(13, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Mobile No :"
        Me.Label4.Visible = False
        '
        'txtpartyName
        '
        Me.txtpartyName.BackColor = System.Drawing.Color.White
        Me.txtpartyName.Font = New System.Drawing.Font("HARIKRISHNA", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpartyName.Location = New System.Drawing.Point(89, 54)
        Me.txtpartyName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpartyName.MaxLength = 100
        Me.txtpartyName.Name = "txtpartyName"
        Me.txtpartyName.Size = New System.Drawing.Size(301, 26)
        Me.txtpartyName.TabIndex = 6
        '
        'txtpartyId
        '
        Me.txtpartyId.BackColor = System.Drawing.Color.White
        Me.txtpartyId.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpartyId.Location = New System.Drawing.Point(89, 23)
        Me.txtpartyId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpartyId.Name = "txtpartyId"
        Me.txtpartyId.Size = New System.Drawing.Size(116, 23)
        Me.txtpartyId.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(38, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(59, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Id :"
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Party Entry"
        '
        'PartyMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(753, 435)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PartyMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sizen Master"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LBrec As System.Windows.Forms.Label
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents DgDoc_Column As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BuExit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ButLast As System.Windows.Forms.Button
    Friend WithEvents BUtPrev As System.Windows.Forms.Button
    Friend WithEvents ButNExt As System.Windows.Forms.Button
    Friend WithEvents ButFirst As System.Windows.Forms.Button
    Friend WithEvents ButFind As System.Windows.Forms.Button
    Friend WithEvents ButEdit As System.Windows.Forms.Button
    Friend WithEvents ButAdd As System.Windows.Forms.Button
    Friend WithEvents ButDelete As System.Windows.Forms.Button
    Friend WithEvents ButSave As System.Windows.Forms.Button
    Friend WithEvents ButCAncel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtpartyName As System.Windows.Forms.TextBox
    Friend WithEvents txtpartyId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButPrint As System.Windows.Forms.Button
    Friend WithEvents txtmobileno As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class

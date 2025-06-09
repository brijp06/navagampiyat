<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinalAccountOpeningEntryBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FinalAccountOpeningEntryBrowser))
        Me.ButPrint = New System.Windows.Forms.Button()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butClear = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.Butreferesh = New System.Windows.Forms.Button()
        Me.BUtDelete = New System.Windows.Forms.Button()
        Me.ButEdit = New System.Windows.Forms.Button()
        Me.BUtAdd = New System.Windows.Forms.Button()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtAccountName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXtAccountId = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDepartmentName = New System.Windows.Forms.TextBox()
        Me.TXtdepartmentId = New System.Windows.Forms.TextBox()
        Me.lblcr = New System.Windows.Forms.Label()
        Me.lbldr = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButPrint
        '
        Me.ButPrint.Image = Global.WeightPavti.My.Resources.Resources.print
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(728, 15)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(82, 28)
        Me.ButPrint.TabIndex = 7
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButPrint, "Print Report")
        Me.ButPrint.UseVisualStyleBackColor = True
        '
        'lbTotal
        '
        Me.lbTotal.AutoSize = True
        Me.lbTotal.Location = New System.Drawing.Point(6, 21)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(44, 15)
        Me.lbTotal.TabIndex = 6
        Me.lbTotal.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.butClear)
        Me.GroupBox1.Controls.Add(Me.ButPrint)
        Me.GroupBox1.Controls.Add(Me.lbTotal)
        Me.GroupBox1.Controls.Add(Me.butExit)
        Me.GroupBox1.Controls.Add(Me.Butreferesh)
        Me.GroupBox1.Controls.Add(Me.BUtDelete)
        Me.GroupBox1.Controls.Add(Me.ButEdit)
        Me.GroupBox1.Controls.Add(Me.BUtAdd)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 478)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(826, 55)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'butClear
        '
        Me.butClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butClear.Location = New System.Drawing.Point(552, 15)
        Me.butClear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.butClear.Name = "butClear"
        Me.butClear.Size = New System.Drawing.Size(82, 28)
        Me.butClear.TabIndex = 8
        Me.butClear.Text = "&Clear"
        Me.butClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.butClear, "Clear Text")
        Me.butClear.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Image = Global.WeightPavti.My.Resources.Resources.close
        Me.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butExit.Location = New System.Drawing.Point(640, 15)
        Me.butExit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(82, 28)
        Me.butExit.TabIndex = 5
        Me.butExit.Text = "E&xit"
        Me.butExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.butExit, "Cloase Window")
        Me.butExit.UseVisualStyleBackColor = True
        '
        'Butreferesh
        '
        Me.Butreferesh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Butreferesh.Location = New System.Drawing.Point(464, 15)
        Me.Butreferesh.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Butreferesh.Name = "Butreferesh"
        Me.Butreferesh.Size = New System.Drawing.Size(82, 28)
        Me.Butreferesh.TabIndex = 3
        Me.Butreferesh.Text = "&Referesh (F5)"
        Me.Butreferesh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Butreferesh, "Referesh Record")
        Me.Butreferesh.UseVisualStyleBackColor = True
        '
        'BUtDelete
        '
        Me.BUtDelete.Image = Global.WeightPavti.My.Resources.Resources.delete
        Me.BUtDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUtDelete.Location = New System.Drawing.Point(376, 15)
        Me.BUtDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BUtDelete.Name = "BUtDelete"
        Me.BUtDelete.Size = New System.Drawing.Size(82, 28)
        Me.BUtDelete.TabIndex = 2
        Me.BUtDelete.Text = "&Delete"
        Me.BUtDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BUtDelete, "Delete Selected Entry")
        Me.BUtDelete.UseVisualStyleBackColor = True
        '
        'ButEdit
        '
        Me.ButEdit.Image = Global.WeightPavti.My.Resources.Resources.edit
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.Location = New System.Drawing.Point(288, 15)
        Me.ButEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(82, 28)
        Me.ButEdit.TabIndex = 1
        Me.ButEdit.Text = "&Edit"
        Me.ButEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButEdit, "Edit Selected Entry")
        Me.ButEdit.UseVisualStyleBackColor = True
        '
        'BUtAdd
        '
        Me.BUtAdd.Image = Global.WeightPavti.My.Resources.Resources.Add
        Me.BUtAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUtAdd.Location = New System.Drawing.Point(200, 15)
        Me.BUtAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BUtAdd.Name = "BUtAdd"
        Me.BUtAdd.Size = New System.Drawing.Size(82, 28)
        Me.BUtAdd.TabIndex = 0
        Me.BUtAdd.Text = "&Add"
        Me.BUtAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BUtAdd, "Add New Entry")
        Me.BUtAdd.UseVisualStyleBackColor = True
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        Me.DG.AllowUserToOrderColumns = True
        Me.DG.AllowUserToResizeRows = False
        Me.DG.BackgroundColor = System.Drawing.Color.White
        Me.DG.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DG.Location = New System.Drawing.Point(8, 10)
        Me.DG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RowHeadersWidth = 25
        Me.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DG.Size = New System.Drawing.Size(826, 380)
        Me.DG.StandardTab = True
        Me.DG.TabIndex = 4
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipTitle = "Account Opening Balance Entry"
        '
        'TxtAccountName
        '
        Me.TxtAccountName.BackColor = System.Drawing.Color.White
        Me.TxtAccountName.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccountName.Location = New System.Drawing.Point(162, 45)
        Me.TxtAccountName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TxtAccountName.MaxLength = 50
        Me.TxtAccountName.Name = "TxtAccountName"
        Me.TxtAccountName.Size = New System.Drawing.Size(238, 24)
        Me.TxtAccountName.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account id :"
        '
        'TXtAccountId
        '
        Me.TXtAccountId.BackColor = System.Drawing.Color.White
        Me.TXtAccountId.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtAccountId.Location = New System.Drawing.Point(86, 45)
        Me.TXtAccountId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXtAccountId.Name = "TXtAccountId"
        Me.TXtAccountId.Size = New System.Drawing.Size(70, 23)
        Me.TXtAccountId.TabIndex = 80
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.lbldr)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.lblcr)
        Me.GroupBox2.Controls.Add(Me.txtDepartmentName)
        Me.GroupBox2.Controls.Add(Me.TXtdepartmentId)
        Me.GroupBox2.Controls.Add(Me.TxtAccountName)
        Me.GroupBox2.Controls.Add(Me.TXtAccountId)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 388)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(826, 76)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(404, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 15)
        Me.Label10.TabIndex = 116
        Me.Label10.Text = "Department Id :"
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.BackColor = System.Drawing.Color.White
        Me.txtDepartmentName.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(574, 45)
        Me.txtDepartmentName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDepartmentName.MaxLength = 100
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.ReadOnly = True
        Me.txtDepartmentName.Size = New System.Drawing.Size(238, 24)
        Me.txtDepartmentName.TabIndex = 115
        Me.txtDepartmentName.TabStop = False
        '
        'TXtdepartmentId
        '
        Me.TXtdepartmentId.BackColor = System.Drawing.Color.White
        Me.TXtdepartmentId.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtdepartmentId.Location = New System.Drawing.Point(498, 45)
        Me.TXtdepartmentId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXtdepartmentId.MaxLength = 20
        Me.TXtdepartmentId.Name = "TXtdepartmentId"
        Me.TXtdepartmentId.Size = New System.Drawing.Size(70, 23)
        Me.TXtdepartmentId.TabIndex = 114
        '
        'lblcr
        '
        Me.lblcr.AutoSize = True
        Me.lblcr.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcr.ForeColor = System.Drawing.Color.Red
        Me.lblcr.Location = New System.Drawing.Point(500, 19)
        Me.lblcr.Name = "lblcr"
        Me.lblcr.Size = New System.Drawing.Size(72, 22)
        Me.lblcr.TabIndex = 9
        Me.lblcr.Text = "Label1"
        '
        'lbldr
        '
        Me.lbldr.AutoSize = True
        Me.lbldr.Font = New System.Drawing.Font("HARIKRISHNA", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldr.ForeColor = System.Drawing.Color.Red
        Me.lbldr.Location = New System.Drawing.Point(671, 19)
        Me.lbldr.Name = "lbldr"
        Me.lbldr.Size = New System.Drawing.Size(72, 22)
        Me.lbldr.TabIndex = 10
        Me.lbldr.Text = "Label1"
        '
        'FinalAccountOpeningEntryBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(839, 537)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FinalAccountOpeningEntryBrowser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FinalAccountOpeningEntryBrowser"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButPrint As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lbTotal As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butClear As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents Butreferesh As System.Windows.Forms.Button
    Friend WithEvents BUtDelete As System.Windows.Forms.Button
    Friend WithEvents ButEdit As System.Windows.Forms.Button
    Friend WithEvents BUtAdd As System.Windows.Forms.Button
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents TxtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXtAccountId As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents TXtdepartmentId As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcr As Label
    Friend WithEvents lbldr As Label
End Class

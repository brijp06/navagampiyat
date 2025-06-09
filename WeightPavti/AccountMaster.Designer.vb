<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountMaster
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountMaster))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LBrec = New System.Windows.Forms.Label
        Me.txtsearch = New System.Windows.Forms.TextBox
        Me.DgDoc_Column = New System.Windows.Forms.DataGridView
        Me.cmbSearchby = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkGstExpr = New System.Windows.Forms.CheckBox
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.TXtdepartmentId = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTGroupName = New System.Windows.Forms.TextBox
        Me.txttGroupId = New System.Windows.Forms.TextBox
        Me.CmbBookAccount = New System.Windows.Forms.ComboBox
        Me.txtpanno = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtCStno = New System.Windows.Forms.TextBox
        Me.txtGstNo = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtExpenceId = New System.Windows.Forms.TextBox
        Me.txtGroupName = New System.Windows.Forms.TextBox
        Me.txtGroupId = New System.Windows.Forms.TextBox
        Me.txtAddres = New System.Windows.Forms.TextBox
        Me.txtEngName = New System.Windows.Forms.TextBox
        Me.txtAccoutName = New System.Windows.Forms.TextBox
        Me.txtAccountId = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ButPrint = New System.Windows.Forms.Button
        Me.BuExit = New System.Windows.Forms.Button
        Me.ButLast = New System.Windows.Forms.Button
        Me.BUtPrev = New System.Windows.Forms.Button
        Me.ButNExt = New System.Windows.Forms.Button
        Me.ButFirst = New System.Windows.Forms.Button
        Me.ButFind = New System.Windows.Forms.Button
        Me.ButCAncel = New System.Windows.Forms.Button
        Me.ButSave = New System.Windows.Forms.Button
        Me.ButDelete = New System.Windows.Forms.Button
        Me.ButEdit = New System.Windows.Forms.Button
        Me.ButAdd = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3.SuspendLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(4, -4)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(353, 427)
        Me.GroupBox3.TabIndex = 74
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search"
        '
        'LBrec
        '
        Me.LBrec.AutoSize = True
        Me.LBrec.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBrec.ForeColor = System.Drawing.Color.White
        Me.LBrec.Location = New System.Drawing.Point(4, 403)
        Me.LBrec.Name = "LBrec"
        Me.LBrec.Size = New System.Drawing.Size(55, 15)
        Me.LBrec.TabIndex = 65
        Me.LBrec.Text = "Search :"
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.Location = New System.Drawing.Point(193, 18)
        Me.txtsearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(154, 23)
        Me.txtsearch.TabIndex = 63
        '
        'DgDoc_Column
        '
        Me.DgDoc_Column.AllowUserToAddRows = False
        Me.DgDoc_Column.AllowUserToDeleteRows = False
        Me.DgDoc_Column.AllowUserToOrderColumns = True
        Me.DgDoc_Column.AllowUserToResizeRows = False
        Me.DgDoc_Column.BackgroundColor = System.Drawing.Color.LightSlateGray
        Me.DgDoc_Column.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgDoc_Column.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgDoc_Column.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgDoc_Column.Location = New System.Drawing.Point(6, 48)
        Me.DgDoc_Column.Margin = New System.Windows.Forms.Padding(5)
        Me.DgDoc_Column.MultiSelect = False
        Me.DgDoc_Column.Name = "DgDoc_Column"
        Me.DgDoc_Column.ReadOnly = True
        Me.DgDoc_Column.RowHeadersWidth = 30
        Me.DgDoc_Column.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDoc_Column.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgDoc_Column.Size = New System.Drawing.Size(341, 352)
        Me.DgDoc_Column.StandardTab = True
        Me.DgDoc_Column.TabIndex = 56
        '
        'cmbSearchby
        '
        Me.cmbSearchby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchby.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSearchby.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSearchby.FormattingEnabled = True
        Me.cmbSearchby.Items.AddRange(New Object() {"Account Id", "Account Name"})
        Me.cmbSearchby.Location = New System.Drawing.Point(67, 18)
        Me.cmbSearchby.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSearchby.Name = "cmbSearchby"
        Me.cmbSearchby.Size = New System.Drawing.Size(120, 23)
        Me.cmbSearchby.TabIndex = 62
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(4, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search :"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.chkGstExpr)
        Me.GroupBox1.Controls.Add(Me.txtDepartmentName)
        Me.GroupBox1.Controls.Add(Me.TXtdepartmentId)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtTGroupName)
        Me.GroupBox1.Controls.Add(Me.txttGroupId)
        Me.GroupBox1.Controls.Add(Me.CmbBookAccount)
        Me.GroupBox1.Controls.Add(Me.txtpanno)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtCStno)
        Me.GroupBox1.Controls.Add(Me.txtGstNo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtExpenceId)
        Me.GroupBox1.Controls.Add(Me.txtGroupName)
        Me.GroupBox1.Controls.Add(Me.txtGroupId)
        Me.GroupBox1.Controls.Add(Me.txtAddres)
        Me.GroupBox1.Controls.Add(Me.txtEngName)
        Me.GroupBox1.Controls.Add(Me.txtAccoutName)
        Me.GroupBox1.Controls.Add(Me.txtAccountId)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(361, -4)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(494, 345)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account Information"
        '
        'chkGstExpr
        '
        Me.chkGstExpr.AutoSize = True
        Me.chkGstExpr.Location = New System.Drawing.Point(372, 243)
        Me.chkGstExpr.Name = "chkGstExpr"
        Me.chkGstExpr.Size = New System.Drawing.Size(96, 19)
        Me.chkGstExpr.TabIndex = 170
        Me.chkGstExpr.Text = "GST Expence"
        Me.chkGstExpr.UseVisualStyleBackColor = True
        Me.chkGstExpr.Visible = False
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.BackColor = System.Drawing.Color.White
        Me.txtDepartmentName.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(227, 302)
        Me.txtDepartmentName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDepartmentName.MaxLength = 100
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.ReadOnly = True
        Me.txtDepartmentName.Size = New System.Drawing.Size(261, 24)
        Me.txtDepartmentName.TabIndex = 168
        Me.txtDepartmentName.TabStop = False
        Me.txtDepartmentName.Visible = False
        '
        'TXtdepartmentId
        '
        Me.TXtdepartmentId.BackColor = System.Drawing.Color.White
        Me.TXtdepartmentId.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtdepartmentId.Location = New System.Drawing.Point(151, 301)
        Me.TXtdepartmentId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TXtdepartmentId.MaxLength = 20
        Me.TXtdepartmentId.Name = "TXtdepartmentId"
        Me.TXtdepartmentId.Size = New System.Drawing.Size(70, 23)
        Me.TXtdepartmentId.TabIndex = 167
        Me.TXtdepartmentId.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(52, 305)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 15)
        Me.Label13.TabIndex = 169
        Me.Label13.Text = "Department Id :"
        Me.Label13.Visible = False
        '
        'txtTGroupName
        '
        Me.txtTGroupName.BackColor = System.Drawing.Color.White
        Me.txtTGroupName.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTGroupName.Location = New System.Drawing.Point(227, 270)
        Me.txtTGroupName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTGroupName.MaxLength = 50
        Me.txtTGroupName.Name = "txtTGroupName"
        Me.txtTGroupName.ReadOnly = True
        Me.txtTGroupName.Size = New System.Drawing.Size(261, 23)
        Me.txtTGroupName.TabIndex = 166
        Me.txtTGroupName.TabStop = False
        Me.txtTGroupName.Visible = False
        '
        'txttGroupId
        '
        Me.txttGroupId.BackColor = System.Drawing.Color.White
        Me.txttGroupId.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttGroupId.Location = New System.Drawing.Point(151, 270)
        Me.txttGroupId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txttGroupId.Name = "txttGroupId"
        Me.txttGroupId.Size = New System.Drawing.Size(70, 23)
        Me.txttGroupId.TabIndex = 165
        Me.txttGroupId.Visible = False
        '
        'CmbBookAccount
        '
        Me.CmbBookAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbBookAccount.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbBookAccount.FormattingEnabled = True
        Me.CmbBookAccount.Items.AddRange(New Object() {"Account", "Cash", "Bank", "Journal"})
        Me.CmbBookAccount.Location = New System.Drawing.Point(151, 239)
        Me.CmbBookAccount.Name = "CmbBookAccount"
        Me.CmbBookAccount.Size = New System.Drawing.Size(154, 23)
        Me.CmbBookAccount.TabIndex = 163
        Me.CmbBookAccount.Visible = False
        '
        'txtpanno
        '
        Me.txtpanno.BackColor = System.Drawing.Color.White
        Me.txtpanno.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpanno.Location = New System.Drawing.Point(372, 209)
        Me.txtpanno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtpanno.MaxLength = 50
        Me.txtpanno.Name = "txtpanno"
        Me.txtpanno.Size = New System.Drawing.Size(116, 23)
        Me.txtpanno.TabIndex = 84
        Me.txtpanno.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(309, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Pan No :"
        Me.Label10.Visible = False
        '
        'txtCStno
        '
        Me.txtCStno.BackColor = System.Drawing.Color.White
        Me.txtCStno.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCStno.Location = New System.Drawing.Point(151, 209)
        Me.txtCStno.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCStno.MaxLength = 50
        Me.txtCStno.Name = "txtCStno"
        Me.txtCStno.Size = New System.Drawing.Size(116, 23)
        Me.txtCStno.TabIndex = 82
        Me.txtCStno.Visible = False
        '
        'txtGstNo
        '
        Me.txtGstNo.BackColor = System.Drawing.Color.White
        Me.txtGstNo.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGstNo.Location = New System.Drawing.Point(372, 179)
        Me.txtGstNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGstNo.MaxLength = 50
        Me.txtGstNo.Name = "txtGstNo"
        Me.txtGstNo.Size = New System.Drawing.Size(116, 23)
        Me.txtGstNo.TabIndex = 80
        Me.txtGstNo.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(277, 182)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 15)
        Me.Label8.TabIndex = 79
        Me.Label8.Text = "Tin G.S.T. No :"
        Me.Label8.Visible = False
        '
        'txtExpenceId
        '
        Me.txtExpenceId.BackColor = System.Drawing.Color.White
        Me.txtExpenceId.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpenceId.Location = New System.Drawing.Point(151, 178)
        Me.txtExpenceId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtExpenceId.Name = "txtExpenceId"
        Me.txtExpenceId.Size = New System.Drawing.Size(116, 23)
        Me.txtExpenceId.TabIndex = 78
        Me.txtExpenceId.Visible = False
        '
        'txtGroupName
        '
        Me.txtGroupName.BackColor = System.Drawing.Color.White
        Me.txtGroupName.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupName.Location = New System.Drawing.Point(227, 114)
        Me.txtGroupName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGroupName.MaxLength = 50
        Me.txtGroupName.Name = "txtGroupName"
        Me.txtGroupName.ReadOnly = True
        Me.txtGroupName.Size = New System.Drawing.Size(261, 25)
        Me.txtGroupName.TabIndex = 76
        Me.txtGroupName.TabStop = False
        '
        'txtGroupId
        '
        Me.txtGroupId.BackColor = System.Drawing.Color.White
        Me.txtGroupId.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroupId.Location = New System.Drawing.Point(151, 114)
        Me.txtGroupId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtGroupId.Name = "txtGroupId"
        Me.txtGroupId.Size = New System.Drawing.Size(70, 25)
        Me.txtGroupId.TabIndex = 75
        '
        'txtAddres
        '
        Me.txtAddres.BackColor = System.Drawing.Color.White
        Me.txtAddres.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddres.Location = New System.Drawing.Point(148, 194)
        Me.txtAddres.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAddres.MaxLength = 250
        Me.txtAddres.Name = "txtAddres"
        Me.txtAddres.Size = New System.Drawing.Size(337, 23)
        Me.txtAddres.TabIndex = 72
        Me.txtAddres.Visible = False
        '
        'txtEngName
        '
        Me.txtEngName.BackColor = System.Drawing.Color.White
        Me.txtEngName.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEngName.Location = New System.Drawing.Point(151, 85)
        Me.txtEngName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtEngName.MaxLength = 100
        Me.txtEngName.Name = "txtEngName"
        Me.txtEngName.Size = New System.Drawing.Size(337, 23)
        Me.txtEngName.TabIndex = 7
        '
        'txtAccoutName
        '
        Me.txtAccoutName.BackColor = System.Drawing.Color.White
        Me.txtAccoutName.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccoutName.Location = New System.Drawing.Point(151, 54)
        Me.txtAccoutName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAccoutName.MaxLength = 100
        Me.txtAccoutName.Name = "txtAccoutName"
        Me.txtAccoutName.Size = New System.Drawing.Size(337, 25)
        Me.txtAccoutName.TabIndex = 6
        '
        'txtAccountId
        '
        Me.txtAccountId.BackColor = System.Drawing.Color.White
        Me.txtAccountId.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountId.Location = New System.Drawing.Point(151, 23)
        Me.txtAccountId.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtAccountId.Name = "txtAccountId"
        Me.txtAccountId.Size = New System.Drawing.Size(116, 25)
        Me.txtAccountId.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(37, 274)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(107, 15)
        Me.Label12.TabIndex = 164
        Me.Label12.Text = "Trading Group Id :"
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(54, 243)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 15)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "Book Account :"
        Me.Label11.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(61, 212)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 15)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Tin C.S.T. No :"
        Me.Label9.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(71, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Index Code :"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(83, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Group Id :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(83, 197)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 73
        Me.Label4.Text = "Address :"
        Me.Label4.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(4, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Account  English Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(51, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Account Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(72, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Account Id :"
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
        Me.GroupBox2.Location = New System.Drawing.Point(361, 340)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(494, 83)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        '
        'ButPrint
        '
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(285, 49)
        Me.ButPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(73, 28)
        Me.ButPrint.TabIndex = 12
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButPrint, "Print Account Group Master List")
        Me.ButPrint.UseVisualStyleBackColor = True
        '
        'BuExit
        '
        Me.BuExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BuExit.Location = New System.Drawing.Point(209, 49)
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
        'ButCAncel
        '
        Me.ButCAncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCAncel.Location = New System.Drawing.Point(133, 49)
        Me.ButCAncel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButCAncel.Name = "ButCAncel"
        Me.ButCAncel.Size = New System.Drawing.Size(73, 28)
        Me.ButCAncel.TabIndex = 4
        Me.ButCAncel.Text = "&Cancel"
        Me.ButCAncel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButCAncel, "Cancel Entry")
        Me.ButCAncel.UseVisualStyleBackColor = True
        '
        'ButSave
        '
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.Location = New System.Drawing.Point(325, 17)
        Me.ButSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(73, 28)
        Me.ButSave.TabIndex = 3
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButSave, "Entry Save")
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(249, 17)
        Me.ButDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(73, 28)
        Me.ButDelete.TabIndex = 2
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButDelete, "Delete Selected Entry")
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'ButEdit
        '
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.Location = New System.Drawing.Point(173, 17)
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
        Me.ButAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButAdd.Location = New System.Drawing.Point(97, 17)
        Me.ButAdd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ButAdd.Name = "ButAdd"
        Me.ButAdd.Size = New System.Drawing.Size(73, 28)
        Me.ButAdd.TabIndex = 0
        Me.ButAdd.Text = "&Add"
        Me.ButAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButAdd, "Add New Entry")
        Me.ButAdd.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Account Entry"
        '
        'AccountMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSlateGray
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(859, 429)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Cambria", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AccountMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Master"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DgDoc_Column, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents DgDoc_Column As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSearchby As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtEngName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAccoutName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccountId As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BuExit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ButLast As System.Windows.Forms.Button
    Friend WithEvents BUtPrev As System.Windows.Forms.Button
    Friend WithEvents ButNExt As System.Windows.Forms.Button
    Friend WithEvents ButFirst As System.Windows.Forms.Button
    Friend WithEvents ButFind As System.Windows.Forms.Button
    Friend WithEvents ButCAncel As System.Windows.Forms.Button
    Friend WithEvents ButSave As System.Windows.Forms.Button
    Friend WithEvents ButDelete As System.Windows.Forms.Button
    Friend WithEvents ButEdit As System.Windows.Forms.Button
    Friend WithEvents ButAdd As System.Windows.Forms.Button
    Friend WithEvents txtAddres As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txtGroupId As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtExpenceId As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGstNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtpanno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCStno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CmbBookAccount As System.Windows.Forms.ComboBox
    Friend WithEvents LBrec As System.Windows.Forms.Label
    Friend WithEvents ButPrint As System.Windows.Forms.Button
    Friend WithEvents txtTGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txttGroupId As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents TXtdepartmentId As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkGstExpr As System.Windows.Forms.CheckBox
End Class

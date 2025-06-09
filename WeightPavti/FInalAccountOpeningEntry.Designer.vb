<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FInalAccountOpeningEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FInalAccountOpeningEntry))
        Me.BuExit = New System.Windows.Forms.Button
        Me.ButLast = New System.Windows.Forms.Button
        Me.BUtPrev = New System.Windows.Forms.Button
        Me.ButNExt = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtDebit = New System.Windows.Forms.TextBox
        Me.TxtCredit = New System.Windows.Forms.TextBox
        Me.TXtAccountName = New System.Windows.Forms.TextBox
        Me.TxtAccountId = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButFirst = New System.Windows.Forms.Button
        Me.ButPrint = New System.Windows.Forms.Button
        Me.ButCAncel = New System.Windows.Forms.Button
        Me.ButSave = New System.Windows.Forms.Button
        Me.ButDelete = New System.Windows.Forms.Button
        Me.ButEdit = New System.Windows.Forms.Button
        Me.ButAdd = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BuExit
        '
        Me.BuExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BuExit.Location = New System.Drawing.Point(6, 282)
        Me.BuExit.Name = "BuExit"
        Me.BuExit.Size = New System.Drawing.Size(94, 30)
        Me.BuExit.TabIndex = 10
        Me.BuExit.Text = "E&xit"
        Me.BuExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BuExit, "Close Window")
        Me.BuExit.UseVisualStyleBackColor = True
        '
        'ButLast
        '
        Me.ButLast.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButLast.Location = New System.Drawing.Point(6, 252)
        Me.ButLast.Name = "ButLast"
        Me.ButLast.Size = New System.Drawing.Size(94, 30)
        Me.ButLast.TabIndex = 9
        Me.ButLast.Text = "&Last"
        Me.ButLast.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButLast, "Go To Last Entry")
        Me.ButLast.UseVisualStyleBackColor = True
        '
        'BUtPrev
        '
        Me.BUtPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUtPrev.Location = New System.Drawing.Point(6, 221)
        Me.BUtPrev.Name = "BUtPrev"
        Me.BUtPrev.Size = New System.Drawing.Size(94, 30)
        Me.BUtPrev.TabIndex = 8
        Me.BUtPrev.Text = "Pre&v"
        Me.BUtPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BUtPrev, "Go To Previous Entry")
        Me.BUtPrev.UseVisualStyleBackColor = True
        '
        'ButNExt
        '
        Me.ButNExt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButNExt.Location = New System.Drawing.Point(6, 191)
        Me.ButNExt.Name = "ButNExt"
        Me.ButNExt.Size = New System.Drawing.Size(94, 30)
        Me.ButNExt.TabIndex = 7
        Me.ButNExt.Text = "&Next"
        Me.ButNExt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButNExt, "Go To Next Entry")
        Me.ButNExt.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.TxtDebit)
        Me.GroupBox1.Controls.Add(Me.TxtCredit)
        Me.GroupBox1.Controls.Add(Me.TXtAccountName)
        Me.GroupBox1.Controls.Add(Me.TxtAccountId)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(540, 348)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'TxtDebit
        '
        Me.TxtDebit.BackColor = System.Drawing.Color.White
        Me.TxtDebit.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDebit.Location = New System.Drawing.Point(99, 76)
        Me.TxtDebit.Name = "TxtDebit"
        Me.TxtDebit.Size = New System.Drawing.Size(167, 23)
        Me.TxtDebit.TabIndex = 7
        Me.TxtDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtCredit
        '
        Me.TxtCredit.BackColor = System.Drawing.Color.White
        Me.TxtCredit.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCredit.Location = New System.Drawing.Point(99, 46)
        Me.TxtCredit.Name = "TxtCredit"
        Me.TxtCredit.Size = New System.Drawing.Size(167, 23)
        Me.TxtCredit.TabIndex = 6
        Me.TxtCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXtAccountName
        '
        Me.TXtAccountName.BackColor = System.Drawing.Color.White
        Me.TXtAccountName.Font = New System.Drawing.Font("HARIKRISHNA", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtAccountName.Location = New System.Drawing.Point(220, 17)
        Me.TXtAccountName.Name = "TXtAccountName"
        Me.TXtAccountName.ReadOnly = True
        Me.TXtAccountName.Size = New System.Drawing.Size(309, 25)
        Me.TXtAccountName.TabIndex = 3
        Me.TXtAccountName.TabStop = False
        '
        'TxtAccountId
        '
        Me.TxtAccountId.BackColor = System.Drawing.Color.White
        Me.TxtAccountId.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccountId.Location = New System.Drawing.Point(99, 16)
        Me.TxtAccountId.Name = "TxtAccountId"
        Me.TxtAccountId.Size = New System.Drawing.Size(115, 23)
        Me.TxtAccountId.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Dr Opening :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cr Opening :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account Id :"
        '
        'ButFirst
        '
        Me.ButFirst.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButFirst.Location = New System.Drawing.Point(6, 161)
        Me.ButFirst.Name = "ButFirst"
        Me.ButFirst.Size = New System.Drawing.Size(94, 30)
        Me.ButFirst.TabIndex = 6
        Me.ButFirst.Text = "Fi&rst"
        Me.ButFirst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButFirst, "Go To First Entry")
        Me.ButFirst.UseVisualStyleBackColor = True
        '
        'ButPrint
        '
        Me.ButPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPrint.Location = New System.Drawing.Point(6, 312)
        Me.ButPrint.Name = "ButPrint"
        Me.ButPrint.Size = New System.Drawing.Size(94, 30)
        Me.ButPrint.TabIndex = 11
        Me.ButPrint.Text = "&Print"
        Me.ButPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButPrint, "Print Entry")
        Me.ButPrint.UseVisualStyleBackColor = True
        '
        'ButCAncel
        '
        Me.ButCAncel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCAncel.Location = New System.Drawing.Point(6, 131)
        Me.ButCAncel.Name = "ButCAncel"
        Me.ButCAncel.Size = New System.Drawing.Size(94, 30)
        Me.ButCAncel.TabIndex = 4
        Me.ButCAncel.Text = "&Cancel"
        Me.ButCAncel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButCAncel, "Cancel Entry")
        Me.ButCAncel.UseVisualStyleBackColor = True
        '
        'ButSave
        '
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.Location = New System.Drawing.Point(6, 100)
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(94, 30)
        Me.ButSave.TabIndex = 3
        Me.ButSave.Text = "&Save"
        Me.ButSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButSave, "Entry Save")
        Me.ButSave.UseVisualStyleBackColor = True
        '
        'ButDelete
        '
        Me.ButDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButDelete.Location = New System.Drawing.Point(6, 70)
        Me.ButDelete.Name = "ButDelete"
        Me.ButDelete.Size = New System.Drawing.Size(94, 30)
        Me.ButDelete.TabIndex = 2
        Me.ButDelete.Text = "&Delete"
        Me.ButDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButDelete, "Delete Selected Entry")
        Me.ButDelete.UseVisualStyleBackColor = True
        '
        'ButEdit
        '
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.Location = New System.Drawing.Point(6, 40)
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(94, 30)
        Me.ButEdit.TabIndex = 1
        Me.ButEdit.Text = "&Edit"
        Me.ButEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.ButEdit, "Edit Selected Entry")
        Me.ButEdit.UseVisualStyleBackColor = True
        '
        'ButAdd
        '
        Me.ButAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButAdd.Location = New System.Drawing.Point(6, 10)
        Me.ButAdd.Name = "ButAdd"
        Me.ButAdd.Size = New System.Drawing.Size(94, 30)
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
        Me.ToolTip1.ToolTipTitle = "Member Opening Balance Entry"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.BuExit)
        Me.GroupBox3.Controls.Add(Me.ButLast)
        Me.GroupBox3.Controls.Add(Me.BUtPrev)
        Me.GroupBox3.Controls.Add(Me.ButNExt)
        Me.GroupBox3.Controls.Add(Me.ButFirst)
        Me.GroupBox3.Controls.Add(Me.ButPrint)
        Me.GroupBox3.Controls.Add(Me.ButCAncel)
        Me.GroupBox3.Controls.Add(Me.ButSave)
        Me.GroupBox3.Controls.Add(Me.ButDelete)
        Me.GroupBox3.Controls.Add(Me.ButEdit)
        Me.GroupBox3.Controls.Add(Me.ButAdd)
        Me.GroupBox3.Location = New System.Drawing.Point(551, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(107, 348)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'FInalAccountOpeningEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Thistle
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(666, 359)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FInalAccountOpeningEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FInalAccountOpeningEntry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BuExit As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ButLast As System.Windows.Forms.Button
    Friend WithEvents BUtPrev As System.Windows.Forms.Button
    Friend WithEvents ButNExt As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDebit As System.Windows.Forms.TextBox
    Friend WithEvents TxtCredit As System.Windows.Forms.TextBox
    Friend WithEvents TXtAccountName As System.Windows.Forms.TextBox
    Friend WithEvents TxtAccountId As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButFirst As System.Windows.Forms.Button
    Friend WithEvents ButPrint As System.Windows.Forms.Button
    Friend WithEvents ButCAncel As System.Windows.Forms.Button
    Friend WithEvents ButSave As System.Windows.Forms.Button
    Friend WithEvents ButDelete As System.Windows.Forms.Button
    Friend WithEvents ButEdit As System.Windows.Forms.Button
    Friend WithEvents ButAdd As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
End Class

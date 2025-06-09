<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RatePosting
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
        Me.Prate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Sizename = New System.Windows.Forms.TextBox()
        Me.itemname = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Barcode = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Prate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.rate)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Sizename)
        Me.GroupBox1.Controls.Add(Me.itemname)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Barcode)
        Me.GroupBox1.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Prate
        '
        Me.Prate.Location = New System.Drawing.Point(323, 115)
        Me.Prate.Name = "Prate"
        Me.Prate.Size = New System.Drawing.Size(158, 26)
        Me.Prate.TabIndex = 319
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(261, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 19)
        Me.Label1.TabIndex = 318
        Me.Label1.Text = "P Rate"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(97, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 43)
        Me.Button1.TabIndex = 317
        Me.Button1.Text = "Update"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rate
        '
        Me.rate.Location = New System.Drawing.Point(97, 115)
        Me.rate.Name = "rate"
        Me.rate.Size = New System.Drawing.Size(158, 26)
        Me.rate.TabIndex = 316
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Location = New System.Drawing.Point(48, 118)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 19)
        Me.Label16.TabIndex = 315
        Me.Label16.Text = "Rate"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 19)
        Me.Label14.TabIndex = 314
        Me.Label14.Text = "Size Name"
        '
        'Sizename
        '
        Me.Sizename.Font = New System.Drawing.Font("SHREE-GUJ-0768-S02", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sizename.Location = New System.Drawing.Point(97, 86)
        Me.Sizename.Name = "Sizename"
        Me.Sizename.Size = New System.Drawing.Size(302, 23)
        Me.Sizename.TabIndex = 313
        '
        'itemname
        '
        Me.itemname.Location = New System.Drawing.Point(97, 54)
        Me.itemname.Name = "itemname"
        Me.itemname.Size = New System.Drawing.Size(302, 26)
        Me.itemname.TabIndex = 312
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 56)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 19)
        Me.Label15.TabIndex = 311
        Me.Label15.Text = "Item Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 19)
        Me.Label12.TabIndex = 310
        Me.Label12.Text = "Barcode"
        '
        'Barcode
        '
        Me.Barcode.Location = New System.Drawing.Point(97, 21)
        Me.Barcode.Name = "Barcode"
        Me.Barcode.Size = New System.Drawing.Size(173, 26)
        Me.Barcode.TabIndex = 309
        '
        'RatePosting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(625, 207)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RatePosting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RatePosting"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Barcode As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Sizename As TextBox
    Friend WithEvents itemname As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents rate As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Prate As TextBox
    Friend WithEvents Label1 As Label
End Class

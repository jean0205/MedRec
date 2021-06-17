<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Medications
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Medications))
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.txtDuration = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ibtnSave = New FontAwesome.Sharp.IconButton()
        Me.txtDosis = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.txtReason)
        Me.gbInfo.Controls.Add(Me.Label3)
        Me.gbInfo.Controls.Add(Me.chkActive)
        Me.gbInfo.Controls.Add(Me.txtDuration)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.ibtnSave)
        Me.gbInfo.Controls.Add(Me.txtDosis)
        Me.gbInfo.Controls.Add(Me.txtName)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label8)
        Me.gbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInfo.ForeColor = System.Drawing.Color.White
        Me.gbInfo.Location = New System.Drawing.Point(5, 5)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Size = New System.Drawing.Size(776, 234)
        Me.gbInfo.TabIndex = 82
        Me.gbInfo.TabStop = False
        Me.gbInfo.Text = "Medications:"
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.ForeColor = System.Drawing.Color.Black
        Me.txtReason.Location = New System.Drawing.Point(142, 123)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(375, 28)
        Me.txtReason.TabIndex = 263
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(76, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 21)
        Me.Label3.TabIndex = 262
        Me.Label3.Text = "Dosis:"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.BackColor = System.Drawing.Color.CadetBlue
        Me.chkActive.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkActive.FlatAppearance.BorderSize = 2
        Me.chkActive.Font = New System.Drawing.Font("NewsGoth Lt BT", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(650, 78)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(85, 28)
        Me.chkActive.TabIndex = 261
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = False
        '
        'txtDuration
        '
        Me.txtDuration.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuration.ForeColor = System.Drawing.Color.Black
        Me.txtDuration.Location = New System.Drawing.Point(142, 165)
        Me.txtDuration.Name = "txtDuration"
        Me.txtDuration.Size = New System.Drawing.Size(375, 28)
        Me.txtDuration.TabIndex = 251
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(49, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 21)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "Duration:"
        '
        'ibtnSave
        '
        Me.ibtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.ibtnSave.FlatAppearance.BorderSize = 2
        Me.ibtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnSave.IconChar = FontAwesome.Sharp.IconChar.Database
        Me.ibtnSave.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnSave.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnSave.IconSize = 35
        Me.ibtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnSave.Location = New System.Drawing.Point(621, 184)
        Me.ibtnSave.Name = "ibtnSave"
        Me.ibtnSave.Size = New System.Drawing.Size(139, 42)
        Me.ibtnSave.TabIndex = 85
        Me.ibtnSave.Text = "Save"
        Me.ibtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ibtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSave.UseVisualStyleBackColor = False
        '
        'txtDosis
        '
        Me.txtDosis.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDosis.ForeColor = System.Drawing.Color.Black
        Me.txtDosis.Location = New System.Drawing.Point(142, 81)
        Me.txtDosis.Name = "txtDosis"
        Me.txtDosis.Size = New System.Drawing.Size(375, 28)
        Me.txtDosis.TabIndex = 249
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(142, 39)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(375, 28)
        Me.txtName.TabIndex = 248
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(60, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 21)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "Reason:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(29, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 21)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Medication:"
        '
        'Frm_Medications
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(788, 246)
        Me.Controls.Add(Me.gbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Medications"
        Me.Text = "Medication"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbInfo As GroupBox
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtDuration As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ibtnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents txtDosis As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtReason As TextBox
    Friend WithEvents Label3 As Label
End Class

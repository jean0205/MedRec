<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Allergy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Allergy))
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.cmbReaction = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ibtnSave = New FontAwesome.Sharp.IconButton()
        Me.gbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.cmbReaction)
        Me.gbInfo.Controls.Add(Me.ibtnSave)
        Me.gbInfo.Controls.Add(Me.txtName)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label8)
        Me.gbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInfo.ForeColor = System.Drawing.Color.White
        Me.gbInfo.Location = New System.Drawing.Point(2, 2)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Size = New System.Drawing.Size(776, 169)
        Me.gbInfo.TabIndex = 82
        Me.gbInfo.TabStop = False
        Me.gbInfo.Text = "Allergies:"
        '
        'cmbReaction
        '
        Me.cmbReaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReaction.FormattingEnabled = True
        Me.cmbReaction.Items.AddRange(New Object() {"LIGHT", "MODERATE", "SEVERE"})
        Me.cmbReaction.Location = New System.Drawing.Point(229, 80)
        Me.cmbReaction.Name = "cmbReaction"
        Me.cmbReaction.Size = New System.Drawing.Size(204, 28)
        Me.cmbReaction.TabIndex = 251
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(229, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(369, 28)
        Me.txtName.TabIndex = 248
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(45, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(178, 21)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "Nature Of Reaction:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(7, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(223, 21)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Medicine/Food/Cosmetic:"
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
        Me.ibtnSave.Location = New System.Drawing.Point(630, 118)
        Me.ibtnSave.Name = "ibtnSave"
        Me.ibtnSave.Size = New System.Drawing.Size(139, 42)
        Me.ibtnSave.TabIndex = 85
        Me.ibtnSave.Text = "Save"
        Me.ibtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ibtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSave.UseVisualStyleBackColor = False
        '
        'Frm_Allergy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(785, 174)
        Me.Controls.Add(Me.gbInfo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Allergy"
        Me.Text = "Frm_Allergy"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbInfo As GroupBox
    Friend WithEvents ibtnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbReaction As ComboBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MedicalProblems
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
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.chkGynec = New System.Windows.Forms.CheckBox()
        Me.dtpProblem = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ibtnSave = New FontAwesome.Sharp.IconButton()
        Me.txtReason = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.chkGynec)
        Me.gbInfo.Controls.Add(Me.dtpProblem)
        Me.gbInfo.Controls.Add(Me.Label2)
        Me.gbInfo.Controls.Add(Me.txtComments)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.ibtnSave)
        Me.gbInfo.Controls.Add(Me.txtReason)
        Me.gbInfo.Controls.Add(Me.txtName)
        Me.gbInfo.Controls.Add(Me.Label7)
        Me.gbInfo.Controls.Add(Me.Label8)
        Me.gbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInfo.ForeColor = System.Drawing.Color.White
        Me.gbInfo.Location = New System.Drawing.Point(4, 3)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Size = New System.Drawing.Size(776, 234)
        Me.gbInfo.TabIndex = 81
        Me.gbInfo.TabStop = False
        Me.gbInfo.Text = "Current or Pass Medical Problem/Ilness:"
        '
        'chkGynec
        '
        Me.chkGynec.AutoSize = True
        Me.chkGynec.BackColor = System.Drawing.Color.CadetBlue
        Me.chkGynec.Enabled = False
        Me.chkGynec.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkGynec.FlatAppearance.BorderSize = 2
        Me.chkGynec.Font = New System.Drawing.Font("NewsGoth Lt BT", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGynec.Location = New System.Drawing.Point(607, 92)
        Me.chkGynec.Name = "chkGynec"
        Me.chkGynec.Size = New System.Drawing.Size(158, 28)
        Me.chkGynec.TabIndex = 261
        Me.chkGynec.Text = "Gynecological"
        Me.chkGynec.UseVisualStyleBackColor = False
        '
        'dtpProblem
        '
        Me.dtpProblem.CalendarMonthBackground = System.Drawing.Color.Honeydew
        Me.dtpProblem.CustomFormat = "dd-MMM-yyyy"
        Me.dtpProblem.Enabled = False
        Me.dtpProblem.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpProblem.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpProblem.Location = New System.Drawing.Point(607, 33)
        Me.dtpProblem.Name = "dtpProblem"
        Me.dtpProblem.Size = New System.Drawing.Size(156, 28)
        Me.dtpProblem.TabIndex = 253
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(549, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 21)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Date:"
        '
        'txtComments
        '
        Me.txtComments.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComments.ForeColor = System.Drawing.Color.Black
        Me.txtComments.Location = New System.Drawing.Point(224, 120)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(305, 70)
        Me.txtComments.TabIndex = 251
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(116, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 21)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "Comments:"
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
        Me.ibtnSave.Location = New System.Drawing.Point(624, 184)
        Me.ibtnSave.Name = "ibtnSave"
        Me.ibtnSave.Size = New System.Drawing.Size(139, 42)
        Me.ibtnSave.TabIndex = 85
        Me.ibtnSave.Text = "Save"
        Me.ibtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ibtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSave.UseVisualStyleBackColor = False
        '
        'txtReason
        '
        Me.txtReason.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReason.ForeColor = System.Drawing.Color.Black
        Me.txtReason.Location = New System.Drawing.Point(224, 80)
        Me.txtReason.Name = "txtReason"
        Me.txtReason.Size = New System.Drawing.Size(305, 28)
        Me.txtReason.TabIndex = 249
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Black
        Me.txtName.Location = New System.Drawing.Point(224, 40)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(305, 28)
        Me.txtName.TabIndex = 248
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("NewsGoth Lt BT", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(144, 83)
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
        Me.Label8.Location = New System.Drawing.Point(7, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 21)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "Ilness/Medical Problem:"
        '
        'Frm_MedicalProblems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(785, 244)
        Me.Controls.Add(Me.gbInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Frm_MedicalProblems"
        Me.Text = "Frm_MedicalProblems"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbInfo As GroupBox
    Friend WithEvents ibtnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents txtReason As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpProblem As DateTimePicker
    Friend WithEvents chkGynec As CheckBox
End Class

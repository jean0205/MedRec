<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pregnancy
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbtnMisscarriage = New System.Windows.Forms.RadioButton()
        Me.rbtnCsection = New System.Windows.Forms.RadioButton()
        Me.rbtnNormal = New System.Windows.Forms.RadioButton()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ibtnSave = New FontAwesome.Sharp.IconButton()
        Me.gbInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbInfo
        '
        Me.gbInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gbInfo.Controls.Add(Me.GroupBox1)
        Me.gbInfo.Controls.Add(Me.dtpDate)
        Me.gbInfo.Controls.Add(Me.Label3)
        Me.gbInfo.Controls.Add(Me.ibtnSave)
        Me.gbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInfo.ForeColor = System.Drawing.Color.White
        Me.gbInfo.Location = New System.Drawing.Point(6, 4)
        Me.gbInfo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbInfo.Size = New System.Drawing.Size(558, 278)
        Me.gbInfo.TabIndex = 84
        Me.gbInfo.TabStop = False
        Me.gbInfo.Text = "Pregnancy Information:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnMisscarriage)
        Me.GroupBox1.Controls.Add(Me.rbtnCsection)
        Me.GroupBox1.Controls.Add(Me.rbtnNormal)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(331, 158)
        Me.GroupBox1.TabIndex = 265
        Me.GroupBox1.TabStop = False
        '
        'rbtnMisscarriage
        '
        Me.rbtnMisscarriage.AutoSize = True
        Me.rbtnMisscarriage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnMisscarriage.Location = New System.Drawing.Point(8, 116)
        Me.rbtnMisscarriage.Name = "rbtnMisscarriage"
        Me.rbtnMisscarriage.Size = New System.Drawing.Size(141, 29)
        Me.rbtnMisscarriage.TabIndex = 2
        Me.rbtnMisscarriage.TabStop = True
        Me.rbtnMisscarriage.Text = "Misscarriage"
        Me.rbtnMisscarriage.UseVisualStyleBackColor = True
        '
        'rbtnCsection
        '
        Me.rbtnCsection.AutoSize = True
        Me.rbtnCsection.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCsection.Location = New System.Drawing.Point(8, 76)
        Me.rbtnCsection.Name = "rbtnCsection"
        Me.rbtnCsection.Size = New System.Drawing.Size(123, 29)
        Me.rbtnCsection.TabIndex = 1
        Me.rbtnCsection.TabStop = True
        Me.rbtnCsection.Text = "C- Section"
        Me.rbtnCsection.UseVisualStyleBackColor = True
        '
        'rbtnNormal
        '
        Me.rbtnNormal.AutoSize = True
        Me.rbtnNormal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnNormal.Location = New System.Drawing.Point(8, 36)
        Me.rbtnNormal.Name = "rbtnNormal"
        Me.rbtnNormal.Size = New System.Drawing.Size(167, 29)
        Me.rbtnNormal.TabIndex = 0
        Me.rbtnNormal.TabStop = True
        Me.rbtnNormal.Text = "Normal Delivery"
        Me.rbtnNormal.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.CalendarMonthBackground = System.Drawing.Color.Honeydew
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(204, 45)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(175, 26)
        Me.dtpDate.TabIndex = 264
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(22, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 22)
        Me.Label3.TabIndex = 262
        Me.Label3.Text = "Pregnancy Date:"
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
        Me.ibtnSave.Location = New System.Drawing.Point(411, 228)
        Me.ibtnSave.Name = "ibtnSave"
        Me.ibtnSave.Size = New System.Drawing.Size(139, 42)
        Me.ibtnSave.TabIndex = 85
        Me.ibtnSave.Text = "Save"
        Me.ibtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ibtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSave.UseVisualStyleBackColor = False
        '
        'Frm_Pregnancy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(576, 295)
        Me.Controls.Add(Me.gbInfo)
        Me.Name = "Frm_Pregnancy"
        Me.Text = "Frm_Pregnancy"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbInfo As GroupBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents ibtnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbtnMisscarriage As RadioButton
    Friend WithEvents rbtnCsection As RadioButton
    Friend WithEvents rbtnNormal As RadioButton
End Class

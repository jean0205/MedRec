<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sams
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sams))
        Me.gbInfo = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.ibtnSave = New FontAwesome.Sharp.IconButton()
        Me.txtCost = New System.Windows.Forms.TextBox()
        Me.txtService = New System.Windows.Forms.TextBox()
        Me.txtPatientName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.IconButton8 = New FontAwesome.Sharp.IconButton()
        Me.dtpPeriod2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpPeriod1 = New System.Windows.Forms.DateTimePicker()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblServices = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gbInfo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbInfo
        '
        Me.gbInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbInfo.Controls.Add(Me.Label3)
        Me.gbInfo.Controls.Add(Me.dtpDate)
        Me.gbInfo.Controls.Add(Me.ibtnSave)
        Me.gbInfo.Controls.Add(Me.txtCost)
        Me.gbInfo.Controls.Add(Me.txtService)
        Me.gbInfo.Controls.Add(Me.txtPatientName)
        Me.gbInfo.Controls.Add(Me.Label2)
        Me.gbInfo.Controls.Add(Me.Label1)
        Me.gbInfo.Controls.Add(Me.Label4)
        Me.gbInfo.ForeColor = System.Drawing.Color.Gainsboro
        Me.gbInfo.Location = New System.Drawing.Point(12, 12)
        Me.gbInfo.Name = "gbInfo"
        Me.gbInfo.Size = New System.Drawing.Size(551, 200)
        Me.gbInfo.TabIndex = 82
        Me.gbInfo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(73, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Date:"
        '
        'dtpDate
        '
        Me.dtpDate.CalendarMonthBackground = System.Drawing.Color.Honeydew
        Me.dtpDate.CustomFormat = "dd-MMM-yyyy"
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(126, 113)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(152, 26)
        Me.dtpDate.TabIndex = 255
        '
        'ibtnSave
        '
        Me.ibtnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ibtnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.ibtnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ibtnSave.FlatAppearance.BorderSize = 2
        Me.ibtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnSave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnSave.IconChar = FontAwesome.Sharp.IconChar.Hdd
        Me.ibtnSave.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnSave.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnSave.IconSize = 30
        Me.ibtnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ibtnSave.Location = New System.Drawing.Point(431, 143)
        Me.ibtnSave.Name = "ibtnSave"
        Me.ibtnSave.Size = New System.Drawing.Size(114, 49)
        Me.ibtnSave.TabIndex = 61
        Me.ibtnSave.Text = "Save"
        Me.ibtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSave.UseVisualStyleBackColor = False
        '
        'txtCost
        '
        Me.txtCost.Location = New System.Drawing.Point(126, 155)
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(107, 26)
        Me.txtCost.TabIndex = 246
        '
        'txtService
        '
        Me.txtService.Location = New System.Drawing.Point(126, 71)
        Me.txtService.Name = "txtService"
        Me.txtService.Size = New System.Drawing.Size(274, 26)
        Me.txtService.TabIndex = 245
        '
        'txtPatientName
        '
        Me.txtPatientName.Location = New System.Drawing.Point(126, 32)
        Me.txtPatientName.Name = "txtPatientName"
        Me.txtPatientName.Size = New System.Drawing.Size(274, 26)
        Me.txtPatientName.TabIndex = 244
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(75, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 20)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Cost:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(56, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Service:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(12, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 20)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Patient Name:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.dgv1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(7, 223)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(1009, 584)
        Me.GroupBox2.TabIndex = 81
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Patient List:"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(5, 29)
        Me.dgv1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv1.RowTemplate.Height = 32
        Me.dgv1.Size = New System.Drawing.Size(1000, 543)
        Me.dgv1.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.IconButton8)
        Me.GroupBox1.Controls.Add(Me.dtpPeriod2)
        Me.GroupBox1.Controls.Add(Me.dtpPeriod1)
        Me.GroupBox1.Controls.Add(Me.lblTotal)
        Me.GroupBox1.Controls.Add(Me.lblServices)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(569, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 200)
        Me.GroupBox1.TabIndex = 257
        Me.GroupBox1.TabStop = False
        '
        'IconButton8
        '
        Me.IconButton8.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.IconButton8.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.IconButton8.FlatAppearance.BorderSize = 2
        Me.IconButton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.IconButton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.IconButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.IconButton8.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkSquareAlt
        Me.IconButton8.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.IconButton8.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton8.IconSize = 30
        Me.IconButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton8.Location = New System.Drawing.Point(312, 16)
        Me.IconButton8.Name = "IconButton8"
        Me.IconButton8.Size = New System.Drawing.Size(129, 39)
        Me.IconButton8.TabIndex = 262
        Me.IconButton8.Text = "Export"
        Me.IconButton8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton8.UseVisualStyleBackColor = False
        '
        'dtpPeriod2
        '
        Me.dtpPeriod2.CalendarMonthBackground = System.Drawing.Color.Honeydew
        Me.dtpPeriod2.CustomFormat = "  dd-MMM-yyyy"
        Me.dtpPeriod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPeriod2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriod2.Location = New System.Drawing.Point(283, 116)
        Me.dtpPeriod2.Name = "dtpPeriod2"
        Me.dtpPeriod2.Size = New System.Drawing.Size(157, 29)
        Me.dtpPeriod2.TabIndex = 260
        '
        'dtpPeriod1
        '
        Me.dtpPeriod1.CalendarMonthBackground = System.Drawing.Color.Honeydew
        Me.dtpPeriod1.CustomFormat = "  dd-MMM-yyyy"
        Me.dtpPeriod1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPeriod1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriod1.Location = New System.Drawing.Point(101, 116)
        Me.dtpPeriod1.Name = "dtpPeriod1"
        Me.dtpPeriod1.Size = New System.Drawing.Size(157, 29)
        Me.dtpPeriod1.TabIndex = 259
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTotal.Location = New System.Drawing.Point(103, 59)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(70, 24)
        Me.lblTotal.TabIndex = 258
        Me.lblTotal.Text = "______"
        '
        'lblServices
        '
        Me.lblServices.AutoSize = True
        Me.lblServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServices.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblServices.Location = New System.Drawing.Point(103, 19)
        Me.lblServices.Name = "lblServices"
        Me.lblServices.Size = New System.Drawing.Size(70, 24)
        Me.lblServices.TabIndex = 257
        Me.lblServices.Text = "______"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(40, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 24)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Total:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label7.Location = New System.Drawing.Point(9, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 24)
        Me.Label7.TabIndex = 237
        Me.Label7.Text = "Services:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label8.Location = New System.Drawing.Point(26, 118)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 24)
        Me.Label8.TabIndex = 236
        Me.Label8.Text = "Period:"
        '
        'Frm_Sams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1021, 813)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbInfo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_Sams"
        Me.Text = "Sams"
        Me.gbInfo.ResumeLayout(False)
        Me.gbInfo.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbInfo As GroupBox
    Friend WithEvents ibtnSave As FontAwesome.Sharp.IconButton
    Friend WithEvents txtCost As TextBox
    Friend WithEvents txtService As TextBox
    Friend WithEvents txtPatientName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpPeriod1 As DateTimePicker
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblServices As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpPeriod2 As DateTimePicker
    Friend WithEvents IconButton8 As FontAwesome.Sharp.IconButton
End Class

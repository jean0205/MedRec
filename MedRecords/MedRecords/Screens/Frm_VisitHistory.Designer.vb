<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_VisitHistory
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.gb1 = New System.Windows.Forms.GroupBox()
        Me.gbId = New System.Windows.Forms.GroupBox()
        Me.chkName = New System.Windows.Forms.CheckBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.cmbServices = New System.Windows.Forms.ComboBox()
        Me.chkServices = New System.Windows.Forms.CheckBox()
        Me.gbRange = New System.Windows.Forms.GroupBox()
        Me.chkRange = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpRangFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpRangeTo = New System.Windows.Forms.DateTimePicker()
        Me.gbDate = New System.Windows.Forms.GroupBox()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.gbPeriod = New System.Windows.Forms.GroupBox()
        Me.chkPeriod = New System.Windows.Forms.CheckBox()
        Me.dtpPeriod = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPatients = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.lblOustanding = New System.Windows.Forms.Label()
        Me.lblVisits = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.IconButton3 = New FontAwesome.Sharp.IconButton()
        Me.IconButton4 = New FontAwesome.Sharp.IconButton()
        Me.gb1.SuspendLayout()
        Me.gbId.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.gbRange.SuspendLayout()
        Me.gbDate.SuspendLayout()
        Me.gbPeriod.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gb1
        '
        Me.gb1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gb1.Controls.Add(Me.lblVisits)
        Me.gb1.Controls.Add(Me.Label7)
        Me.gb1.Controls.Add(Me.lblOustanding)
        Me.gb1.Controls.Add(Me.lblPaid)
        Me.gb1.Controls.Add(Me.lblPatients)
        Me.gb1.Controls.Add(Me.Label5)
        Me.gb1.Controls.Add(Me.Label4)
        Me.gb1.Controls.Add(Me.Label3)
        Me.gb1.Controls.Add(Me.gbId)
        Me.gb1.Controls.Add(Me.gbStatus)
        Me.gb1.Controls.Add(Me.gbRange)
        Me.gb1.Controls.Add(Me.gbDate)
        Me.gb1.Controls.Add(Me.gbPeriod)
        Me.gb1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gb1.ForeColor = System.Drawing.Color.Gainsboro
        Me.gb1.Location = New System.Drawing.Point(3, -1)
        Me.gb1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gb1.Name = "gb1"
        Me.gb1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gb1.Size = New System.Drawing.Size(1418, 138)
        Me.gb1.TabIndex = 62
        Me.gb1.TabStop = False
        '
        'gbId
        '
        Me.gbId.Controls.Add(Me.chkName)
        Me.gbId.Controls.Add(Me.txtId)
        Me.gbId.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbId.ForeColor = System.Drawing.Color.White
        Me.gbId.Location = New System.Drawing.Point(4, 13)
        Me.gbId.Name = "gbId"
        Me.gbId.Size = New System.Drawing.Size(179, 119)
        Me.gbId.TabIndex = 69
        Me.gbId.TabStop = False
        Me.gbId.Text = "Filter By Patient Name:"
        '
        'chkName
        '
        Me.chkName.AutoSize = True
        Me.chkName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkName.Location = New System.Drawing.Point(6, 23)
        Me.chkName.Name = "chkName"
        Me.chkName.Size = New System.Drawing.Size(65, 24)
        Me.chkName.TabIndex = 18
        Me.chkName.Text = "Clear"
        Me.chkName.UseVisualStyleBackColor = True
        Me.chkName.Visible = False
        '
        'txtId
        '
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(9, 67)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(164, 26)
        Me.txtId.TabIndex = 19
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.cmbServices)
        Me.gbStatus.Controls.Add(Me.chkServices)
        Me.gbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStatus.ForeColor = System.Drawing.Color.White
        Me.gbStatus.Location = New System.Drawing.Point(187, 13)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(185, 119)
        Me.gbStatus.TabIndex = 68
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Filter By Services:"
        '
        'cmbServices
        '
        Me.cmbServices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServices.FormattingEnabled = True
        Me.cmbServices.Items.AddRange(New Object() {"All", "PAID", "REJECTED"})
        Me.cmbServices.Location = New System.Drawing.Point(9, 67)
        Me.cmbServices.Name = "cmbServices"
        Me.cmbServices.Size = New System.Drawing.Size(160, 26)
        Me.cmbServices.TabIndex = 19
        '
        'chkServices
        '
        Me.chkServices.AutoSize = True
        Me.chkServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkServices.Location = New System.Drawing.Point(9, 23)
        Me.chkServices.Name = "chkServices"
        Me.chkServices.Size = New System.Drawing.Size(65, 24)
        Me.chkServices.TabIndex = 18
        Me.chkServices.Text = "Clear"
        Me.chkServices.UseVisualStyleBackColor = True
        Me.chkServices.Visible = False
        '
        'gbRange
        '
        Me.gbRange.Controls.Add(Me.chkRange)
        Me.gbRange.Controls.Add(Me.Label2)
        Me.gbRange.Controls.Add(Me.Label1)
        Me.gbRange.Controls.Add(Me.dtpRangFrom)
        Me.gbRange.Controls.Add(Me.dtpRangeTo)
        Me.gbRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRange.ForeColor = System.Drawing.Color.Gainsboro
        Me.gbRange.Location = New System.Drawing.Point(777, 13)
        Me.gbRange.Name = "gbRange"
        Me.gbRange.Size = New System.Drawing.Size(180, 119)
        Me.gbRange.TabIndex = 67
        Me.gbRange.TabStop = False
        Me.gbRange.Text = "Filter By Range:"
        '
        'chkRange
        '
        Me.chkRange.AutoSize = True
        Me.chkRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRange.Location = New System.Drawing.Point(28, 23)
        Me.chkRange.Name = "chkRange"
        Me.chkRange.Size = New System.Drawing.Size(65, 24)
        Me.chkRange.TabIndex = 19
        Me.chkRange.Text = "Clear"
        Me.chkRange.UseVisualStyleBackColor = True
        Me.chkRange.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 20)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "To:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "From:"
        '
        'dtpRangFrom
        '
        Me.dtpRangFrom.CustomFormat = ""
        Me.dtpRangFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRangFrom.Location = New System.Drawing.Point(56, 50)
        Me.dtpRangFrom.Name = "dtpRangFrom"
        Me.dtpRangFrom.Size = New System.Drawing.Size(117, 26)
        Me.dtpRangFrom.TabIndex = 20
        '
        'dtpRangeTo
        '
        Me.dtpRangeTo.CustomFormat = ""
        Me.dtpRangeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRangeTo.Location = New System.Drawing.Point(56, 86)
        Me.dtpRangeTo.Name = "dtpRangeTo"
        Me.dtpRangeTo.Size = New System.Drawing.Size(117, 26)
        Me.dtpRangeTo.TabIndex = 17
        '
        'gbDate
        '
        Me.gbDate.Controls.Add(Me.chkDate)
        Me.gbDate.Controls.Add(Me.dtpDate)
        Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDate.ForeColor = System.Drawing.Color.Gainsboro
        Me.gbDate.Location = New System.Drawing.Point(376, 13)
        Me.gbDate.Name = "gbDate"
        Me.gbDate.Size = New System.Drawing.Size(168, 119)
        Me.gbDate.TabIndex = 65
        Me.gbDate.TabStop = False
        Me.gbDate.Text = "Visit Date:"
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDate.Location = New System.Drawing.Point(9, 23)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(65, 24)
        Me.chkDate.TabIndex = 19
        Me.chkDate.Text = "Clear"
        Me.chkDate.UseVisualStyleBackColor = True
        Me.chkDate.Visible = False
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = ""
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(21, 67)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(129, 26)
        Me.dtpDate.TabIndex = 17
        '
        'gbPeriod
        '
        Me.gbPeriod.Controls.Add(Me.chkPeriod)
        Me.gbPeriod.Controls.Add(Me.IconButton3)
        Me.gbPeriod.Controls.Add(Me.IconButton4)
        Me.gbPeriod.Controls.Add(Me.dtpPeriod)
        Me.gbPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPeriod.ForeColor = System.Drawing.Color.Gainsboro
        Me.gbPeriod.Location = New System.Drawing.Point(548, 13)
        Me.gbPeriod.Name = "gbPeriod"
        Me.gbPeriod.Size = New System.Drawing.Size(225, 119)
        Me.gbPeriod.TabIndex = 64
        Me.gbPeriod.TabStop = False
        Me.gbPeriod.Text = "Filter by Period:"
        '
        'chkPeriod
        '
        Me.chkPeriod.AutoSize = True
        Me.chkPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPeriod.Location = New System.Drawing.Point(9, 23)
        Me.chkPeriod.Name = "chkPeriod"
        Me.chkPeriod.Size = New System.Drawing.Size(65, 24)
        Me.chkPeriod.TabIndex = 19
        Me.chkPeriod.Text = "Clear"
        Me.chkPeriod.UseVisualStyleBackColor = True
        Me.chkPeriod.Visible = False
        '
        'dtpPeriod
        '
        Me.dtpPeriod.CustomFormat = "  MMM-yyyy"
        Me.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriod.Location = New System.Drawing.Point(54, 67)
        Me.dtpPeriod.Name = "dtpPeriod"
        Me.dtpPeriod.Size = New System.Drawing.Size(124, 26)
        Me.dtpPeriod.TabIndex = 17
        '
        'GroupBox10
        '
        Me.GroupBox10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox10.Controls.Add(Me.dgv1)
        Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(6, 136)
        Me.GroupBox10.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox10.Size = New System.Drawing.Size(1418, 673)
        Me.GroupBox10.TabIndex = 63
        Me.GroupBox10.TabStop = False
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(6, 15)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv1.RowTemplate.Height = 32
        Me.dgv1.Size = New System.Drawing.Size(1404, 650)
        Me.dgv1.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1004, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 22)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Patients:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(987, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 22)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Total Paid:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(977, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 22)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "Oustanding:"
        '
        'lblPatients
        '
        Me.lblPatients.AutoSize = True
        Me.lblPatients.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatients.Location = New System.Drawing.Point(1088, 55)
        Me.lblPatients.Name = "lblPatients"
        Me.lblPatients.Size = New System.Drawing.Size(70, 22)
        Me.lblPatients.TabIndex = 73
        Me.lblPatients.Text = "______"
        '
        'lblPaid
        '
        Me.lblPaid.AutoSize = True
        Me.lblPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPaid.Location = New System.Drawing.Point(1088, 83)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(70, 22)
        Me.lblPaid.TabIndex = 74
        Me.lblPaid.Text = "______"
        '
        'lblOustanding
        '
        Me.lblOustanding.AutoSize = True
        Me.lblOustanding.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOustanding.Location = New System.Drawing.Point(1088, 108)
        Me.lblOustanding.Name = "lblOustanding"
        Me.lblOustanding.Size = New System.Drawing.Size(70, 22)
        Me.lblOustanding.TabIndex = 75
        Me.lblOustanding.Text = "______"
        '
        'lblVisits
        '
        Me.lblVisits.AutoSize = True
        Me.lblVisits.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVisits.Location = New System.Drawing.Point(1088, 25)
        Me.lblVisits.Name = "lblVisits"
        Me.lblVisits.Size = New System.Drawing.Size(70, 22)
        Me.lblVisits.TabIndex = 77
        Me.lblVisits.Text = "______"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1026, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 22)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Visits:"
        '
        'IconButton3
        '
        Me.IconButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.IconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        Me.IconButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton3.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconButton3.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.IconButton3.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButton3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton3.IconSize = 25
        Me.IconButton3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.IconButton3.Location = New System.Drawing.Point(8, 64)
        Me.IconButton3.Name = "IconButton3"
        Me.IconButton3.Size = New System.Drawing.Size(35, 35)
        Me.IconButton3.TabIndex = 5
        Me.IconButton3.UseVisualStyleBackColor = False
        '
        'IconButton4
        '
        Me.IconButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.IconButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton4.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconButton4.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.IconButton4.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButton4.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton4.IconSize = 25
        Me.IconButton4.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.IconButton4.Location = New System.Drawing.Point(184, 64)
        Me.IconButton4.Name = "IconButton4"
        Me.IconButton4.Size = New System.Drawing.Size(35, 35)
        Me.IconButton4.TabIndex = 4
        Me.IconButton4.UseVisualStyleBackColor = False
        '
        'Frm_VisitHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1429, 814)
        Me.Controls.Add(Me.gb1)
        Me.Controls.Add(Me.GroupBox10)
        Me.Name = "Frm_VisitHistory"
        Me.Text = "Frm_VisitHistory"
        Me.gb1.ResumeLayout(False)
        Me.gb1.PerformLayout()
        Me.gbId.ResumeLayout(False)
        Me.gbId.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.gbRange.ResumeLayout(False)
        Me.gbRange.PerformLayout()
        Me.gbDate.ResumeLayout(False)
        Me.gbDate.PerformLayout()
        Me.gbPeriod.ResumeLayout(False)
        Me.gbPeriod.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gb1 As GroupBox
    Friend WithEvents gbId As GroupBox
    Friend WithEvents chkName As CheckBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents gbStatus As GroupBox
    Friend WithEvents cmbServices As ComboBox
    Friend WithEvents chkServices As CheckBox
    Friend WithEvents gbRange As GroupBox
    Friend WithEvents chkRange As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpRangFrom As DateTimePicker
    Friend WithEvents dtpRangeTo As DateTimePicker
    Friend WithEvents gbDate As GroupBox
    Friend WithEvents chkDate As CheckBox
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents gbPeriod As GroupBox
    Friend WithEvents chkPeriod As CheckBox
    Friend WithEvents IconButton3 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton4 As FontAwesome.Sharp.IconButton
    Friend WithEvents dtpPeriod As DateTimePicker
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents lblOustanding As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents lblPatients As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblVisits As Label
    Friend WithEvents Label7 As Label
End Class

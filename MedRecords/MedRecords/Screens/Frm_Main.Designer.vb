<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Main
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.panelAddAppointment = New System.Windows.Forms.Panel()
        Me.ibtnClosePanel = New FontAwesome.Sharp.IconButton()
        Me.gbNewAppointment = New System.Windows.Forms.GroupBox()
        Me.ibtnNewPatient = New FontAwesome.Sharp.IconButton()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalPaid = New System.Windows.Forms.Label()
        Me.lblTotaltoPaid = New System.Windows.Forms.Label()
        Me.lblTotalPatients = New System.Windows.Forms.Label()
        Me.chkPaperRecord = New System.Windows.Forms.CheckBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.ibtnVisits = New FontAwesome.Sharp.IconButton()
        Me.ibtnRestore = New FontAwesome.Sharp.IconButton()
        Me.ibtnBackup = New FontAwesome.Sharp.IconButton()
        Me.ibtnSams = New FontAwesome.Sharp.IconButton()
        Me.ibtnReports = New FontAwesome.Sharp.IconButton()
        Me.ibtnExpenses = New FontAwesome.Sharp.IconButton()
        Me.ibtnSurgeries = New FontAwesome.Sharp.IconButton()
        Me.ibtnServices = New FontAwesome.Sharp.IconButton()
        Me.ibtnPatients = New FontAwesome.Sharp.IconButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ibtnNewAppointment = New FontAwesome.Sharp.IconButton()
        Me.GroupBox2.SuspendLayout()
        Me.panelAddAppointment.SuspendLayout()
        Me.gbNewAppointment.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.panelAddAppointment)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.dgv1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(207, 136)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1197, 644)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Today Walk In/Appointment:"
        '
        'panelAddAppointment
        '
        Me.panelAddAppointment.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.panelAddAppointment.Controls.Add(Me.ibtnClosePanel)
        Me.panelAddAppointment.Controls.Add(Me.gbNewAppointment)
        Me.panelAddAppointment.Location = New System.Drawing.Point(59, 45)
        Me.panelAddAppointment.Name = "panelAddAppointment"
        Me.panelAddAppointment.Size = New System.Drawing.Size(957, 494)
        Me.panelAddAppointment.TabIndex = 81
        Me.panelAddAppointment.Visible = False
        '
        'ibtnClosePanel
        '
        Me.ibtnClosePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ibtnClosePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnClosePanel.FlatAppearance.BorderSize = 0
        Me.ibtnClosePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnClosePanel.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.ibtnClosePanel.IconColor = System.Drawing.Color.White
        Me.ibtnClosePanel.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnClosePanel.IconSize = 30
        Me.ibtnClosePanel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ibtnClosePanel.Location = New System.Drawing.Point(925, 2)
        Me.ibtnClosePanel.Name = "ibtnClosePanel"
        Me.ibtnClosePanel.Size = New System.Drawing.Size(30, 30)
        Me.ibtnClosePanel.TabIndex = 97
        Me.ibtnClosePanel.UseVisualStyleBackColor = False
        '
        'gbNewAppointment
        '
        Me.gbNewAppointment.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.gbNewAppointment.Controls.Add(Me.ibtnNewPatient)
        Me.gbNewAppointment.Controls.Add(Me.dgv2)
        Me.gbNewAppointment.Controls.Add(Me.txtLastName)
        Me.gbNewAppointment.Controls.Add(Me.txtFirstName)
        Me.gbNewAppointment.Controls.Add(Me.Label7)
        Me.gbNewAppointment.Controls.Add(Me.Label8)
        Me.gbNewAppointment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbNewAppointment.ForeColor = System.Drawing.Color.Black
        Me.gbNewAppointment.Location = New System.Drawing.Point(11, 28)
        Me.gbNewAppointment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbNewAppointment.Name = "gbNewAppointment"
        Me.gbNewAppointment.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbNewAppointment.Size = New System.Drawing.Size(942, 454)
        Me.gbNewAppointment.TabIndex = 80
        Me.gbNewAppointment.TabStop = False
        Me.gbNewAppointment.Text = "Search Patient:"
        '
        'ibtnNewPatient
        '
        Me.ibtnNewPatient.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.ibtnNewPatient.FlatAppearance.BorderSize = 2
        Me.ibtnNewPatient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnNewPatient.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnNewPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnNewPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnNewPatient.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNewPatient.IconChar = FontAwesome.Sharp.IconChar.HospitalUser
        Me.ibtnNewPatient.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNewPatient.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnNewPatient.IconSize = 55
        Me.ibtnNewPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnNewPatient.Location = New System.Drawing.Point(773, 27)
        Me.ibtnNewPatient.Name = "ibtnNewPatient"
        Me.ibtnNewPatient.Size = New System.Drawing.Size(162, 94)
        Me.ibtnNewPatient.TabIndex = 85
        Me.ibtnNewPatient.Text = "New Patient"
        Me.ibtnNewPatient.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnNewPatient.UseVisualStyleBackColor = False
        '
        'dgv2
        '
        Me.dgv2.AllowUserToAddRows = False
        Me.dgv2.AllowUserToDeleteRows = False
        Me.dgv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.Location = New System.Drawing.Point(7, 129)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.ReadOnly = True
        Me.dgv2.RowHeadersVisible = False
        Me.dgv2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgv2.RowTemplate.Height = 32
        Me.dgv2.Size = New System.Drawing.Size(928, 317)
        Me.dgv2.TabIndex = 81
        '
        'txtLastName
        '
        Me.txtLastName.ForeColor = System.Drawing.Color.Black
        Me.txtLastName.Location = New System.Drawing.Point(112, 77)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(274, 26)
        Me.txtLastName.TabIndex = 249
        '
        'txtFirstName
        '
        Me.txtFirstName.ForeColor = System.Drawing.Color.Black
        Me.txtFirstName.Location = New System.Drawing.Point(112, 40)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(274, 26)
        Me.txtFirstName.TabIndex = 248
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 20)
        Me.Label7.TabIndex = 247
        Me.Label7.Text = "Last Name:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 43)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 20)
        Me.Label8.TabIndex = 246
        Me.Label8.Text = "First Name:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label9.Location = New System.Drawing.Point(911, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(501, 20)
        Me.Label9.TabIndex = 239
        Me.Label9.Text = "poner boton paralos detalles del paciente y otropara crear nueva visita"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label11.Location = New System.Drawing.Point(701, 551)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(427, 60)
        Me.Label11.TabIndex = 241
        Me.Label11.Text = "si elpacientetiene historia elpapel marcar la fila de otro color" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "poner leyenda e" &
    "n laparte baja deldata grid" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label10.Location = New System.Drawing.Point(247, 576)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(418, 20)
        Me.Label10.TabIndex = 240
        Me.Label10.Text = "si elpaciente no tiene historia clinica marcar lafilde un color" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
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
        Me.dgv1.Location = New System.Drawing.Point(6, 27)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowTemplate.Height = 32
        Me.dgv1.Size = New System.Drawing.Size(1183, 605)
        Me.dgv1.TabIndex = 59
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Lavender
        Me.lblDate.Location = New System.Drawing.Point(293, 66)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(104, 46)
        Me.lblDate.TabIndex = 82
        Me.lblDate.Text = "Date"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 42.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblTime.Location = New System.Drawing.Point(382, 3)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(146, 64)
        Me.lblTime.TabIndex = 81
        Me.lblTime.Text = "Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblTotalPaid)
        Me.GroupBox1.Controls.Add(Me.lblTotaltoPaid)
        Me.GroupBox1.Controls.Add(Me.lblTotalPatients)
        Me.GroupBox1.Controls.Add(Me.chkPaperRecord)
        Me.GroupBox1.Controls.Add(Me.lblAge)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(1025, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 138)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Doctor Statistics:"
        '
        'lblTotalPaid
        '
        Me.lblTotalPaid.AutoSize = True
        Me.lblTotalPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPaid.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPaid.Location = New System.Drawing.Point(159, 102)
        Me.lblTotalPaid.Name = "lblTotalPaid"
        Me.lblTotalPaid.Size = New System.Drawing.Size(108, 20)
        Me.lblTotalPaid.TabIndex = 261
        Me.lblTotalPaid.Text = "___________"
        '
        'lblTotaltoPaid
        '
        Me.lblTotaltoPaid.AutoSize = True
        Me.lblTotaltoPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotaltoPaid.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTotaltoPaid.Location = New System.Drawing.Point(159, 67)
        Me.lblTotaltoPaid.Name = "lblTotaltoPaid"
        Me.lblTotaltoPaid.Size = New System.Drawing.Size(108, 20)
        Me.lblTotaltoPaid.TabIndex = 260
        Me.lblTotaltoPaid.Text = "___________"
        '
        'lblTotalPatients
        '
        Me.lblTotalPatients.AutoSize = True
        Me.lblTotalPatients.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPatients.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPatients.Location = New System.Drawing.Point(159, 32)
        Me.lblTotalPatients.Name = "lblTotalPatients"
        Me.lblTotalPatients.Size = New System.Drawing.Size(108, 20)
        Me.lblTotalPatients.TabIndex = 259
        Me.lblTotalPatients.Text = "___________"
        '
        'chkPaperRecord
        '
        Me.chkPaperRecord.AutoSize = True
        Me.chkPaperRecord.Location = New System.Drawing.Point(860, 11)
        Me.chkPaperRecord.Name = "chkPaperRecord"
        Me.chkPaperRecord.Size = New System.Drawing.Size(126, 24)
        Me.chkPaperRecord.TabIndex = 258
        Me.chkPaperRecord.Text = "Paper Record"
        Me.chkPaperRecord.UseVisualStyleBackColor = True
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblAge.Location = New System.Drawing.Point(706, 80)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(36, 20)
        Me.lblAge.TabIndex = 256
        Me.lblAge.Text = "___"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(31, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Today Total Paid:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(9, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 20)
        Me.Label1.TabIndex = 237
        Me.Label1.Text = "Today Total To Paid:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(43, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 20)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "Today Patients:"
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(202, 120)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.panel2.Controls.Add(Me.ibtnVisits)
        Me.panel2.Controls.Add(Me.ibtnRestore)
        Me.panel2.Controls.Add(Me.ibtnBackup)
        Me.panel2.Controls.Add(Me.ibtnSams)
        Me.panel2.Controls.Add(Me.ibtnReports)
        Me.panel2.Controls.Add(Me.ibtnExpenses)
        Me.panel2.Controls.Add(Me.ibtnSurgeries)
        Me.panel2.Controls.Add(Me.ibtnServices)
        Me.panel2.Controls.Add(Me.ibtnPatients)
        Me.panel2.Controls.Add(Me.pictureBox1)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(202, 780)
        Me.panel2.TabIndex = 41
        '
        'ibtnVisits
        '
        Me.ibtnVisits.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnVisits.FlatAppearance.BorderSize = 0
        Me.ibtnVisits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnVisits.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnVisits.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnVisits.IconChar = FontAwesome.Sharp.IconChar.VoteYea
        Me.ibtnVisits.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnVisits.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnVisits.IconSize = 40
        Me.ibtnVisits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnVisits.Location = New System.Drawing.Point(3, 327)
        Me.ibtnVisits.Name = "ibtnVisits"
        Me.ibtnVisits.Size = New System.Drawing.Size(202, 53)
        Me.ibtnVisits.TabIndex = 240
        Me.ibtnVisits.Text = "Visits"
        Me.ibtnVisits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnVisits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnVisits.UseVisualStyleBackColor = True
        '
        'ibtnRestore
        '
        Me.ibtnRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ibtnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnRestore.FlatAppearance.BorderSize = 0
        Me.ibtnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnRestore.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnRestore.IconChar = FontAwesome.Sharp.IconChar.Server
        Me.ibtnRestore.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnRestore.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnRestore.IconSize = 30
        Me.ibtnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnRestore.Location = New System.Drawing.Point(0, 732)
        Me.ibtnRestore.Name = "ibtnRestore"
        Me.ibtnRestore.Size = New System.Drawing.Size(199, 45)
        Me.ibtnRestore.TabIndex = 239
        Me.ibtnRestore.Text = "Restore"
        Me.ibtnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnRestore.UseVisualStyleBackColor = False
        '
        'ibtnBackup
        '
        Me.ibtnBackup.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ibtnBackup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnBackup.FlatAppearance.BorderSize = 0
        Me.ibtnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnBackup.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnBackup.IconChar = FontAwesome.Sharp.IconChar.Database
        Me.ibtnBackup.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnBackup.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnBackup.IconSize = 30
        Me.ibtnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnBackup.Location = New System.Drawing.Point(0, 687)
        Me.ibtnBackup.Name = "ibtnBackup"
        Me.ibtnBackup.Size = New System.Drawing.Size(199, 45)
        Me.ibtnBackup.TabIndex = 238
        Me.ibtnBackup.Text = "Backup"
        Me.ibtnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnBackup.UseVisualStyleBackColor = False
        '
        'ibtnSams
        '
        Me.ibtnSams.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnSams.FlatAppearance.BorderSize = 0
        Me.ibtnSams.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnSams.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSams.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnSams.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnSams.IconChar = FontAwesome.Sharp.IconChar.HospitalAlt
        Me.ibtnSams.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnSams.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnSams.IconSize = 40
        Me.ibtnSams.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnSams.Location = New System.Drawing.Point(0, 622)
        Me.ibtnSams.Name = "ibtnSams"
        Me.ibtnSams.Size = New System.Drawing.Size(202, 53)
        Me.ibtnSams.TabIndex = 237
        Me.ibtnSams.Text = "SAMS"
        Me.ibtnSams.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnSams.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSams.UseVisualStyleBackColor = True
        '
        'ibtnReports
        '
        Me.ibtnReports.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnReports.FlatAppearance.BorderSize = 0
        Me.ibtnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnReports.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnReports.IconChar = FontAwesome.Sharp.IconChar.CalendarDay
        Me.ibtnReports.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnReports.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnReports.IconSize = 40
        Me.ibtnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnReports.Location = New System.Drawing.Point(0, 563)
        Me.ibtnReports.Name = "ibtnReports"
        Me.ibtnReports.Size = New System.Drawing.Size(202, 53)
        Me.ibtnReports.TabIndex = 236
        Me.ibtnReports.Text = "Reports"
        Me.ibtnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnReports.UseVisualStyleBackColor = True
        '
        'ibtnExpenses
        '
        Me.ibtnExpenses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnExpenses.FlatAppearance.BorderSize = 0
        Me.ibtnExpenses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnExpenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnExpenses.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnExpenses.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt
        Me.ibtnExpenses.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnExpenses.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnExpenses.IconSize = 40
        Me.ibtnExpenses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnExpenses.Location = New System.Drawing.Point(0, 504)
        Me.ibtnExpenses.Name = "ibtnExpenses"
        Me.ibtnExpenses.Size = New System.Drawing.Size(202, 53)
        Me.ibtnExpenses.TabIndex = 235
        Me.ibtnExpenses.Text = "Expenses"
        Me.ibtnExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnExpenses.UseVisualStyleBackColor = True
        '
        'ibtnSurgeries
        '
        Me.ibtnSurgeries.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnSurgeries.FlatAppearance.BorderSize = 0
        Me.ibtnSurgeries.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnSurgeries.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnSurgeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnSurgeries.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnSurgeries.IconChar = FontAwesome.Sharp.IconChar.UserNurse
        Me.ibtnSurgeries.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnSurgeries.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnSurgeries.IconSize = 40
        Me.ibtnSurgeries.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnSurgeries.Location = New System.Drawing.Point(0, 445)
        Me.ibtnSurgeries.Name = "ibtnSurgeries"
        Me.ibtnSurgeries.Size = New System.Drawing.Size(202, 53)
        Me.ibtnSurgeries.TabIndex = 234
        Me.ibtnSurgeries.Text = "Surgeries"
        Me.ibtnSurgeries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnSurgeries.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnSurgeries.UseVisualStyleBackColor = True
        '
        'ibtnServices
        '
        Me.ibtnServices.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnServices.FlatAppearance.BorderSize = 0
        Me.ibtnServices.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnServices.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnServices.IconChar = FontAwesome.Sharp.IconChar.ListAlt
        Me.ibtnServices.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnServices.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnServices.IconSize = 40
        Me.ibtnServices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnServices.Location = New System.Drawing.Point(0, 386)
        Me.ibtnServices.Name = "ibtnServices"
        Me.ibtnServices.Size = New System.Drawing.Size(202, 53)
        Me.ibtnServices.TabIndex = 233
        Me.ibtnServices.Text = "Services"
        Me.ibtnServices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnServices.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnServices.UseVisualStyleBackColor = True
        '
        'ibtnPatients
        '
        Me.ibtnPatients.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnPatients.FlatAppearance.BorderSize = 0
        Me.ibtnPatients.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnPatients.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnPatients.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnPatients.IconChar = FontAwesome.Sharp.IconChar.UserFriends
        Me.ibtnPatients.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnPatients.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnPatients.IconSize = 40
        Me.ibtnPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnPatients.Location = New System.Drawing.Point(3, 268)
        Me.ibtnPatients.Name = "ibtnPatients"
        Me.ibtnPatients.Size = New System.Drawing.Size(202, 53)
        Me.ibtnPatients.TabIndex = 232
        Me.ibtnPatients.Text = "Patients"
        Me.ibtnPatients.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnPatients.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnPatients.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ibtnNewAppointment
        '
        Me.ibtnNewAppointment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ibtnNewAppointment.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.ibtnNewAppointment.FlatAppearance.BorderSize = 2
        Me.ibtnNewAppointment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnNewAppointment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnNewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnNewAppointment.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnNewAppointment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNewAppointment.IconChar = FontAwesome.Sharp.IconChar.HospitalUser
        Me.ibtnNewAppointment.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNewAppointment.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnNewAppointment.IconSize = 55
        Me.ibtnNewAppointment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnNewAppointment.Location = New System.Drawing.Point(768, 44)
        Me.ibtnNewAppointment.Name = "ibtnNewAppointment"
        Me.ibtnNewAppointment.Size = New System.Drawing.Size(251, 94)
        Me.ibtnNewAppointment.TabIndex = 84
        Me.ibtnNewAppointment.Text = "New Walk In Appointment"
        Me.ibtnNewAppointment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnNewAppointment.UseVisualStyleBackColor = False
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1408, 780)
        Me.Controls.Add(Me.ibtnNewAppointment)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.panel2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_Main"
        Me.Text = "Frm_Main"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.panelAddAppointment.ResumeLayout(False)
        Me.gbNewAppointment.ResumeLayout(False)
        Me.gbNewAppointment.PerformLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgv1 As DataGridView
    Private WithEvents lblDate As Label
    Private WithEvents lblTime As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTotalPaid As Label
    Friend WithEvents lblTotaltoPaid As Label
    Friend WithEvents lblTotalPatients As Label
    Friend WithEvents chkPaperRecord As CheckBox
    Friend WithEvents lblAge As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents panel2 As Panel
    Friend WithEvents ibtnRestore As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnBackup As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnSams As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnReports As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnExpenses As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnSurgeries As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnServices As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnPatients As FontAwesome.Sharp.IconButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ibtnNewAppointment As FontAwesome.Sharp.IconButton
    Friend WithEvents gbNewAppointment As GroupBox
    Friend WithEvents ibtnNewPatient As FontAwesome.Sharp.IconButton
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents panelAddAppointment As Panel
    Friend WithEvents ibtnClosePanel As FontAwesome.Sharp.IconButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ibtnVisits As FontAwesome.Sharp.IconButton
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkPaperRecord = New System.Windows.Forms.CheckBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.ibtnRestore = New FontAwesome.Sharp.IconButton()
        Me.ibtnBackup = New FontAwesome.Sharp.IconButton()
        Me.ibtnSams = New FontAwesome.Sharp.IconButton()
        Me.ibtnReports = New FontAwesome.Sharp.IconButton()
        Me.ibtnExpenses = New FontAwesome.Sharp.IconButton()
        Me.ibtnSurgeries = New FontAwesome.Sharp.IconButton()
        Me.ibtnServices = New FontAwesome.Sharp.IconButton()
        Me.ibtnPatients = New FontAwesome.Sharp.IconButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ibtnNew = New FontAwesome.Sharp.IconButton()
        Me.GroupBox2.SuspendLayout()
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
        Me.lblTime.ForeColor = System.Drawing.SystemColors.Highlight
        Me.lblTime.Location = New System.Drawing.Point(382, 3)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(146, 64)
        Me.lblTime.TabIndex = 81
        Me.lblTime.Text = "Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label6.Location = New System.Drawing.Point(159, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 20)
        Me.Label6.TabIndex = 261
        Me.Label6.Text = "___________"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(159, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 20)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "___________"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label3.Location = New System.Drawing.Point(159, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 20)
        Me.Label3.TabIndex = 259
        Me.Label3.Text = "___________"
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
        'ibtnRestore
        '
        Me.ibtnRestore.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.ibtnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.ibtnRestore.FlatAppearance.BorderSize = 0
        Me.ibtnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnSams.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnExpenses.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnSurgeries.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnServices.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ibtnPatients.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnPatients.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnPatients.IconChar = FontAwesome.Sharp.IconChar.UserFriends
        Me.ibtnPatients.IconColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ibtnPatients.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnPatients.IconSize = 40
        Me.ibtnPatients.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnPatients.Location = New System.Drawing.Point(0, 327)
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
        '
        'ibtnNew
        '
        Me.ibtnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.ibtnNew.FlatAppearance.BorderSize = 2
        Me.ibtnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnNew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNew.IconChar = FontAwesome.Sharp.IconChar.HospitalUser
        Me.ibtnNew.IconColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnNew.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnNew.IconSize = 55
        Me.ibtnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnNew.Location = New System.Drawing.Point(768, 44)
        Me.ibtnNew.Name = "ibtnNew"
        Me.ibtnNew.Size = New System.Drawing.Size(251, 94)
        Me.ibtnNew.TabIndex = 84
        Me.ibtnNew.Text = "New Walk In Appointment"
        Me.ibtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnNew.UseVisualStyleBackColor = False
        '
        'Frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1408, 780)
        Me.Controls.Add(Me.ibtnNew)
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
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
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
    Friend WithEvents ibtnNew As FontAwesome.Sharp.IconButton
End Class

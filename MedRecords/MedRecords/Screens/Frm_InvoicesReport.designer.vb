<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_InvoicesReport
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_InvoicesReport))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbtnProccAuth = New System.Windows.Forms.RadioButton()
        Me.rbtnApprovedProcessed = New System.Windows.Forms.RadioButton()
        Me.rbtnUploadApproved = New System.Windows.Forms.RadioButton()
        Me.rbtnIssuUpload = New System.Windows.Forms.RadioButton()
        Me.ChartBreakDown = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ChartTotals = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtp1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ibtnBack = New FontAwesome.Sharp.IconButton()
        Me.ibtnFow = New FontAwesome.Sharp.IconButton()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.IconButton2 = New FontAwesome.Sharp.IconButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ChartBreakDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ChartTotals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Chart1)
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1411, 841)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(1257, 819)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 325
        Me.Label4.Text = "Services"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel1.BackColor = System.Drawing.Color.SeaGreen
        Me.Panel1.Location = New System.Drawing.Point(1217, 817)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(34, 17)
        Me.Panel1.TabIndex = 324
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label14.Location = New System.Drawing.Point(1164, 819)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 323
        Me.Label14.Text = "Patients"
        '
        'Panel6
        '
        Me.Panel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(1124, 817)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(34, 17)
        Me.Panel6.TabIndex = 322
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.rbtnProccAuth)
        Me.GroupBox4.Controls.Add(Me.rbtnApprovedProcessed)
        Me.GroupBox4.Controls.Add(Me.rbtnUploadApproved)
        Me.GroupBox4.Controls.Add(Me.rbtnIssuUpload)
        Me.GroupBox4.Controls.Add(Me.ChartBreakDown)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(3, 233)
        Me.GroupBox4.MaximumSize = New System.Drawing.Size(750, 385)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(568, 346)
        Me.GroupBox4.TabIndex = 321
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Same Patient Visits:"
        '
        'rbtnProccAuth
        '
        Me.rbtnProccAuth.AutoSize = True
        Me.rbtnProccAuth.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.rbtnProccAuth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnProccAuth.ForeColor = System.Drawing.Color.Black
        Me.rbtnProccAuth.Location = New System.Drawing.Point(390, 28)
        Me.rbtnProccAuth.Name = "rbtnProccAuth"
        Me.rbtnProccAuth.Size = New System.Drawing.Size(105, 24)
        Me.rbtnProccAuth.TabIndex = 325
        Me.rbtnProccAuth.Text = "Proc./Auth."
        Me.rbtnProccAuth.UseVisualStyleBackColor = False
        '
        'rbtnApprovedProcessed
        '
        Me.rbtnApprovedProcessed.AutoSize = True
        Me.rbtnApprovedProcessed.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.rbtnApprovedProcessed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnApprovedProcessed.ForeColor = System.Drawing.Color.Black
        Me.rbtnApprovedProcessed.Location = New System.Drawing.Point(279, 28)
        Me.rbtnApprovedProcessed.Name = "rbtnApprovedProcessed"
        Me.rbtnApprovedProcessed.Size = New System.Drawing.Size(105, 24)
        Me.rbtnApprovedProcessed.TabIndex = 324
        Me.rbtnApprovedProcessed.Text = "Appr./Proc."
        Me.rbtnApprovedProcessed.UseVisualStyleBackColor = False
        '
        'rbtnUploadApproved
        '
        Me.rbtnUploadApproved.AutoSize = True
        Me.rbtnUploadApproved.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.rbtnUploadApproved.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnUploadApproved.ForeColor = System.Drawing.Color.Black
        Me.rbtnUploadApproved.Location = New System.Drawing.Point(133, 28)
        Me.rbtnUploadApproved.Name = "rbtnUploadApproved"
        Me.rbtnUploadApproved.Size = New System.Drawing.Size(141, 24)
        Me.rbtnUploadApproved.TabIndex = 323
        Me.rbtnUploadApproved.Text = "Upload/Approve"
        Me.rbtnUploadApproved.UseVisualStyleBackColor = False
        '
        'rbtnIssuUpload
        '
        Me.rbtnIssuUpload.AutoSize = True
        Me.rbtnIssuUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.rbtnIssuUpload.Checked = True
        Me.rbtnIssuUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnIssuUpload.ForeColor = System.Drawing.Color.Black
        Me.rbtnIssuUpload.Location = New System.Drawing.Point(6, 28)
        Me.rbtnIssuUpload.Name = "rbtnIssuUpload"
        Me.rbtnIssuUpload.Size = New System.Drawing.Size(121, 24)
        Me.rbtnIssuUpload.TabIndex = 322
        Me.rbtnIssuUpload.TabStop = True
        Me.rbtnIssuUpload.Text = "Issue/Upload"
        Me.rbtnIssuUpload.UseVisualStyleBackColor = False
        '
        'ChartBreakDown
        '
        Me.ChartBreakDown.BackColor = System.Drawing.Color.Transparent
        Me.ChartBreakDown.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea1.Area3DStyle.Enable3D = True
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.IsLogarithmic = True
        ChartArea1.AxisY.LogarithmBase = 3.0R
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.Name = "ChartArea1"
        Me.ChartBreakDown.ChartAreas.Add(ChartArea1)
        Me.ChartBreakDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend1.AutoFitMinFontSize = 12
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Legend1.ForeColor = System.Drawing.Color.Gainsboro
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Legend1"
        Me.ChartBreakDown.Legends.Add(Legend1)
        Me.ChartBreakDown.Location = New System.Drawing.Point(3, 123)
        Me.ChartBreakDown.Name = "ChartBreakDown"
        Me.ChartBreakDown.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.BorderColor = System.Drawing.Color.White
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Series1.IsValueShownAsLabel = True
        Series1.LabelForeColor = System.Drawing.Color.White
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.ShadowColor = System.Drawing.Color.White
        Series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Black
        Series1.YValuesPerPoint = 2
        Me.ChartBreakDown.Series.Add(Series1)
        Me.ChartBreakDown.Size = New System.Drawing.Size(562, 220)
        Me.ChartBreakDown.TabIndex = 321
        Me.ChartBreakDown.Text = "Chart5"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChartTotals)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 10)
        Me.GroupBox3.MaximumSize = New System.Drawing.Size(750, 385)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(497, 223)
        Me.GroupBox3.TabIndex = 318
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Services:"
        '
        'ChartTotals
        '
        Me.ChartTotals.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ChartTotals.BorderlineColor = System.Drawing.Color.Transparent
        Me.ChartTotals.BorderSkin.BackColor = System.Drawing.Color.Transparent
        Me.ChartTotals.BorderSkin.BorderColor = System.Drawing.Color.Transparent
        Me.ChartTotals.BorderSkin.PageColor = System.Drawing.Color.Transparent
        ChartArea2.Area3DStyle.Enable3D = True
        ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 12
        ChartArea2.AxisX.LabelAutoFitMinFontSize = 10
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
        ChartArea2.AxisX.LineColor = System.Drawing.Color.Transparent
        ChartArea2.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisY.IsLogarithmic = True
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
        ChartArea2.AxisY.LineColor = System.Drawing.Color.Gainsboro
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "ChartArea1"
        Me.ChartTotals.ChartAreas.Add(ChartArea2)
        Me.ChartTotals.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartTotals.Location = New System.Drawing.Point(3, 25)
        Me.ChartTotals.MaximumSize = New System.Drawing.Size(730, 360)
        Me.ChartTotals.Name = "ChartTotals"
        Me.ChartTotals.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate
        Series2.BorderColor = System.Drawing.Color.Transparent
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar
        Series2.EmptyPointStyle.Color = System.Drawing.Color.Transparent
        Series2.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Gainsboro
        Series2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Series2.IsValueShownAsLabel = True
        Series2.IsVisibleInLegend = False
        Series2.Label = "#VAL{N0}"
        Series2.LabelForeColor = System.Drawing.Color.Gainsboro
        Series2.MarkerBorderColor = System.Drawing.Color.Transparent
        Series2.Name = "Series1"
        Series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones
        Series2.ShadowColor = System.Drawing.Color.Silver
        Me.ChartTotals.Series.Add(Series2)
        Me.ChartTotals.Size = New System.Drawing.Size(491, 195)
        Me.ChartTotals.TabIndex = 17
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.dtp1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.ibtnBack)
        Me.GroupBox2.Controls.Add(Me.ibtnFow)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(932, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(470, 88)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Period"
        '
        'dtp1
        '
        Me.dtp1.CustomFormat = "   MMM-yyyy"
        Me.dtp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp1.Location = New System.Drawing.Point(78, 54)
        Me.dtp1.Name = "dtp1"
        Me.dtp1.Size = New System.Drawing.Size(141, 30)
        Me.dtp1.TabIndex = 319
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(49, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 24)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Label3"
        '
        'ibtnBack
        '
        Me.ibtnBack.FlatAppearance.BorderSize = 0
        Me.ibtnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.ibtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnBack.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        Me.ibtnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnBack.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnBack.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.ibtnBack.IconColor = System.Drawing.Color.Gainsboro
        Me.ibtnBack.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnBack.IconSize = 30
        Me.ibtnBack.Location = New System.Drawing.Point(3, 20)
        Me.ibtnBack.Name = "ibtnBack"
        Me.ibtnBack.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ibtnBack.Size = New System.Drawing.Size(45, 35)
        Me.ibtnBack.TabIndex = 7
        Me.ibtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnBack.UseMnemonic = False
        Me.ibtnBack.UseVisualStyleBackColor = True
        '
        'ibtnFow
        '
        Me.ibtnFow.FlatAppearance.BorderSize = 0
        Me.ibtnFow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.ibtnFow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnFow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnFow.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnFow.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.ibtnFow.IconColor = System.Drawing.Color.Gainsboro
        Me.ibtnFow.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.ibtnFow.IconSize = 30
        Me.ibtnFow.Location = New System.Drawing.Point(419, 13)
        Me.ibtnFow.Name = "ibtnFow"
        Me.ibtnFow.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.ibtnFow.Size = New System.Drawing.Size(45, 35)
        Me.ibtnFow.TabIndex = 6
        Me.ibtnFow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnFow.UseVisualStyleBackColor = True
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chart1.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderlineColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderSkin.BorderColor = System.Drawing.Color.Transparent
        Me.Chart1.BorderSkin.PageColor = System.Drawing.Color.Transparent
        ChartArea3.Area3DStyle.Inclination = 10
        ChartArea3.Area3DStyle.Rotation = 100
        ChartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
        ChartArea3.AxisX.LineColor = System.Drawing.Color.Transparent
        ChartArea3.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea3.AxisY.IsLogarithmic = True
        ChartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gainsboro
        ChartArea3.AxisY.LineColor = System.Drawing.Color.Gainsboro
        ChartArea3.BackColor = System.Drawing.Color.Transparent
        ChartArea3.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea3.BorderColor = System.Drawing.Color.White
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Me.Chart1.Location = New System.Drawing.Point(-66, 572)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series3.BorderColor = System.Drawing.Color.Transparent
        Series3.ChartArea = "ChartArea1"
        Series3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Series3.EmptyPointStyle.Color = System.Drawing.Color.Transparent
        Series3.EmptyPointStyle.LabelForeColor = System.Drawing.Color.Gainsboro
        Series3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.IsValueShownAsLabel = True
        Series3.IsVisibleInLegend = False
        Series3.LabelForeColor = System.Drawing.Color.White
        Series3.MarkerBorderColor = System.Drawing.Color.Transparent
        Series3.Name = "Series1"
        Series3.ShadowColor = System.Drawing.Color.Silver
        Series4.ChartArea = "ChartArea1"
        Series4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series4.IsValueShownAsLabel = True
        Series4.LabelForeColor = System.Drawing.Color.White
        Series4.Name = "Series2"
        Series5.ChartArea = "ChartArea1"
        Series5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series5.IsValueShownAsLabel = True
        Series5.LabelForeColor = System.Drawing.Color.White
        Series5.Name = "Series3"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Series.Add(Series4)
        Me.Chart1.Series.Add(Series5)
        Me.Chart1.Size = New System.Drawing.Size(1517, 252)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Chart1"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.Chart3)
        Me.Panel4.Location = New System.Drawing.Point(733, 124)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(676, 378)
        Me.Panel4.TabIndex = 331
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 3)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(179, 24)
        Me.Label7.TabIndex = 321
        Me.Label7.Text = "Services and Profits:"
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.Color.Transparent
        Me.Chart3.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea4.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea4.AxisY.IsLabelAutoFit = False
        ChartArea4.AxisY.IsLogarithmic = True
        ChartArea4.AxisY.LogarithmBase = 3.0R
        ChartArea4.BackColor = System.Drawing.Color.Transparent
        ChartArea4.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea4)
        Me.Chart3.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend2.AutoFitMinFontSize = 10
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend2.ForeColor = System.Drawing.Color.Gainsboro
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend2)
        Me.Chart3.Location = New System.Drawing.Point(0, 16)
        Me.Chart3.Name = "Chart3"
        Me.Chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen
        Series6.BorderColor = System.Drawing.Color.White
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Series6.IsValueShownAsLabel = True
        Series6.LabelForeColor = System.Drawing.Color.White
        Series6.Legend = "Legend1"
        Series6.Name = "Series1"
        Series6.ShadowColor = System.Drawing.Color.White
        Series6.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Black
        Series6.YValuesPerPoint = 2
        Me.Chart3.Series.Add(Series6)
        Me.Chart3.Size = New System.Drawing.Size(676, 362)
        Me.Chart3.TabIndex = 330
        Me.Chart3.Text = "top te vendors"
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Panel2.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Panel2.Location = New System.Drawing.Point(1319, 817)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(34, 17)
        Me.Panel2.TabIndex = 326
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label5.Location = New System.Drawing.Point(1355, 819)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 327
        Me.Label5.Text = "Money"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "   MMM-yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(270, 54)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(141, 30)
        Me.DateTimePicker1.TabIndex = 320
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.IconButton1)
        Me.GroupBox5.Controls.Add(Me.IconButton2)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox5.Location = New System.Drawing.Point(1148, 511)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(251, 78)
        Me.GroupBox5.TabIndex = 332
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Month:"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "   MMM-yyyy"
        Me.DateTimePicker3.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(87, 48)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(127, 27)
        Me.DateTimePicker3.TabIndex = 319
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 24)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderSize = 0
        Me.IconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal
        Me.IconButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.IconButton1.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButton1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton1.IconSize = 30
        Me.IconButton1.Location = New System.Drawing.Point(4, 19)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.IconButton1.Size = New System.Drawing.Size(45, 35)
        Me.IconButton1.TabIndex = 7
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton1.UseMnemonic = False
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'IconButton2
        '
        Me.IconButton2.FlatAppearance.BorderSize = 0
        Me.IconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.IconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton2.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconButton2.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight
        Me.IconButton2.IconColor = System.Drawing.Color.Gainsboro
        Me.IconButton2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconButton2.IconSize = 30
        Me.IconButton2.Location = New System.Drawing.Point(200, 19)
        Me.IconButton2.Name = "IconButton2"
        Me.IconButton2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.IconButton2.Size = New System.Drawing.Size(45, 35)
        Me.IconButton2.TabIndex = 6
        Me.IconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.IconButton2.UseVisualStyleBackColor = True
        '
        'Frm_InvoicesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1411, 841)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Frm_InvoicesReport"
        Me.Text = "Invoice Report and Dash-Board"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ChartBreakDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ChartTotals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents IconButton2 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rbtnProccAuth As RadioButton
    Friend WithEvents rbtnApprovedProcessed As RadioButton
    Friend WithEvents rbtnUploadApproved As RadioButton
    Friend WithEvents rbtnIssuUpload As RadioButton
    Friend WithEvents ChartBreakDown As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ChartTotals As DataVisualization.Charting.Chart
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents dtp1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents ibtnBack As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnFow As FontAwesome.Sharp.IconButton
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Chart3 As DataVisualization.Charting.Chart
End Class

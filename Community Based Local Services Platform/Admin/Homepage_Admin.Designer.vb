<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Homepage_Admin
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        LinkLabel1 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        LinkLabel3 = New LinkLabel()
        QueryType = New DataGridViewTextBoxColumn()
        QueryBy = New DataGridViewTextBoxColumn()
        AppointmentID = New DataGridViewTextBoxColumn()
        QueryDate = New DataGridViewTextBoxColumn()
        Description = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridView1.BackgroundColor = Color.White
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.Tomato
        DataGridViewCellStyle1.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.NullValue = "Hello"
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {QueryType, QueryBy, AppointmentID, QueryDate, Description, Status})
        DataGridView1.Cursor = Cursors.Hand
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.HighlightText
        DataGridView1.Location = New Point(115, 127)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.ScrollBars = ScrollBars.None
        DataGridView1.Size = New Size(1103, 174)
        DataGridView1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(115, 91)
        Label1.Name = "Label1"
        Label1.Size = New Size(60, 18)
        Label1.TabIndex = 1
        Label1.Text = "Queries"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(115, 357)
        Label2.Name = "Label2"
        Label2.Size = New Size(157, 18)
        Label2.TabIndex = 2
        Label2.Text = "Registration Requests"
        Label2.TextAlign = ContentAlignment.TopCenter
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(768, 357)
        Label3.Name = "Label3"
        Label3.Size = New Size(149, 18)
        Label3.TabIndex = 3
        Label3.Text = "All Service Providers"
        Label3.TextAlign = ContentAlignment.TopCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(115, 419)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(200, 180)
        PictureBox1.TabIndex = 4
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Location = New Point(365, 419)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(200, 180)
        PictureBox2.TabIndex = 5
        PictureBox2.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(414, 616)
        Label4.Name = "Label4"
        Label4.Size = New Size(119, 18)
        Label4.TabIndex = 6
        Label4.Text = "Service Provider"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(154, 616)
        Label5.Name = "Label5"
        Label5.Size = New Size(119, 18)
        Label5.TabIndex = 7
        Label5.Text = "Service Provider"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(807, 616)
        Label6.Name = "Label6"
        Label6.Size = New Size(119, 18)
        Label6.TabIndex = 11
        Label6.Text = "Service Provider"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(1067, 616)
        Label7.Name = "Label7"
        Label7.Size = New Size(119, 18)
        Label7.TabIndex = 10
        Label7.Text = "Service Provider"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Location = New Point(1018, 419)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(200, 180)
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Location = New Point(768, 419)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(200, 180)
        PictureBox4.TabIndex = 8
        PictureBox4.TabStop = False
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.LinkColor = Color.Red
        LinkLabel1.Location = New Point(1163, 91)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(55, 18)
        LinkLabel1.TabIndex = 12
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "See All"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.LinkColor = Color.Red
        LinkLabel2.Location = New Point(510, 357)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(55, 18)
        LinkLabel2.TabIndex = 13
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "See All"
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.LinkColor = Color.Red
        LinkLabel3.Location = New Point(1163, 357)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(55, 18)
        LinkLabel3.TabIndex = 14
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "See All"
        ' 
        ' QueryType
        ' 
        QueryType.HeaderText = "Query Type"
        QueryType.MinimumWidth = 6
        QueryType.Name = "QueryType"
        QueryType.ReadOnly = True
        ' 
        ' QueryBy
        ' 
        QueryBy.HeaderText = "Query By"
        QueryBy.MinimumWidth = 6
        QueryBy.Name = "QueryBy"
        QueryBy.ReadOnly = True
        ' 
        ' AppointmentID
        ' 
        AppointmentID.HeaderText = "Appointment ID"
        AppointmentID.MinimumWidth = 6
        AppointmentID.Name = "AppointmentID"
        AppointmentID.ReadOnly = True
        ' 
        ' QueryDate
        ' 
        QueryDate.HeaderText = "Query Date"
        QueryDate.MinimumWidth = 6
        QueryDate.Name = "QueryDate"
        QueryDate.ReadOnly = True
        ' 
        ' Description
        ' 
        Description.HeaderText = "Description"
        Description.MinimumWidth = 6
        Description.Name = "Description"
        Description.ReadOnly = True
        ' 
        ' Status
        ' 
        Status.HeaderText = "Status"
        Status.MinimumWidth = 6
        Status.Name = "Status"
        Status.ReadOnly = True
        ' 
        ' View
        ' 

        ' 
        ' Homepage_Admin
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1353, 793)
        Controls.Add(LinkLabel3)
        Controls.Add(LinkLabel2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label6)
        Controls.Add(Label7)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox4)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(DataGridView1)
        Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Name = "Homepage_Admin"
        RightToLeftLayout = True
        Text = "Homepage_Admin"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents QueryType As DataGridViewTextBoxColumn
    Friend WithEvents QueryBy As DataGridViewTextBoxColumn
    Friend WithEvents AppointmentID As DataGridViewTextBoxColumn
    Friend WithEvents QueryDate As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn

End Class

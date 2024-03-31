<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class All_Queries
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        QueryType = New DataGridViewTextBoxColumn()
        QueryBy = New DataGridViewTextBoxColumn()
        AppointmentID = New DataGridViewTextBoxColumn()
        QueryDate = New DataGridViewTextBoxColumn()
        Description = New DataGridViewTextBoxColumn()
        Status = New DataGridViewTextBoxColumn()
        View = New DataGridViewButtonColumn()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.BackgroundColor = Color.White
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = Color.Tomato
        DataGridViewCellStyle4.Font = New Font("Bahnschrift", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.NullValue = "Hello"
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {QueryType, QueryBy, AppointmentID, QueryDate, Description, Status, View})
        DataGridView1.Cursor = Cursors.Hand
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.White
        DataGridViewCellStyle6.Font = New Font("Bahnschrift", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ActiveCaptionText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle6
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.HighlightText
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.ScrollBars = ScrollBars.Vertical
        DataGridView1.Size = New Size(1353, 881)
        DataGridView1.TabIndex = 0
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
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.FromArgb(CByte(0), CByte(64), CByte(64))
        DataGridViewCellStyle5.ForeColor = Color.White
        View.DefaultCellStyle = DataGridViewCellStyle5
        View.FlatStyle = FlatStyle.Popup
        View.HeaderText = ""
        View.MinimumWidth = 6
        View.Name = "View"
        View.ReadOnly = True
        View.Resizable = DataGridViewTriState.False
        View.Text = "View"
        View.UseColumnTextForButtonValue = True
        ' 
        ' All_Queries
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1353, 881)
        Controls.Add(DataGridView1)
        Name = "All_Queries"
        RightToLeftLayout = True
        Text = "All_Queries"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents QueryType As DataGridViewTextBoxColumn
    Friend WithEvents QueryBy As DataGridViewTextBoxColumn
    Friend WithEvents AppointmentID As DataGridViewTextBoxColumn
    Friend WithEvents QueryDate As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents View As DataGridViewButtonColumn

End Class

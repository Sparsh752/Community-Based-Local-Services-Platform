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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        QueryID = New DataGridViewTextBoxColumn()
        Type = New DataGridViewTextBoxColumn()
        UserID = New DataGridViewTextBoxColumn()
        AppointmentID = New DataGridViewTextBoxColumn()
        QueryDate = New DataGridViewTextBoxColumn()
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
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {QueryID, Type, UserID, AppointmentID, QueryDate, Status, View})
        DataGridView1.Cursor = Cursors.Hand
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.Dock = DockStyle.Bottom
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.HighlightText
        DataGridView1.Location = New Point(0, 113)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.ScrollBars = ScrollBars.Vertical
        DataGridView1.Size = New Size(1353, 768)
        DataGridView1.TabIndex = 0
        ' 
        ' QueryID
        ' 
        QueryID.HeaderText = "Query ID"
        QueryID.MinimumWidth = 6
        QueryID.Name = "QueryID"
        QueryID.ReadOnly = True
        ' 
        ' Type
        ' 
        Type.HeaderText = "Type"
        Type.MinimumWidth = 6
        Type.Name = "Type"
        Type.ReadOnly = True
        ' 
        ' UserID
        ' 
        UserID.HeaderText = "User ID"
        UserID.MinimumWidth = 6
        UserID.Name = "UserID"
        UserID.ReadOnly = True
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
        ' Status
        ' 
        Status.HeaderText = "Status"
        Status.MinimumWidth = 6
        Status.Name = "Status"
        Status.ReadOnly = True
        ' 
        ' View
        ' 
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(15), CByte(42), CByte(55))
        DataGridViewCellStyle2.ForeColor = Color.White
        View.DefaultCellStyle = DataGridViewCellStyle2
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
        AutoScaleDimensions = New SizeF(8F, 20F)
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
    Friend WithEvents QueryID As DataGridViewTextBoxColumn
    Friend WithEvents Type As DataGridViewTextBoxColumn
    Friend WithEvents UserID As DataGridViewTextBoxColumn
    Friend WithEvents AppointmentID As DataGridViewTextBoxColumn
    Friend WithEvents QueryDate As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents View As DataGridViewButtonColumn

End Class

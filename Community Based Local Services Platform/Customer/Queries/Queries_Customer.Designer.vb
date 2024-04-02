<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Queries_Customer
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        DataGridView1 = New DataGridView()
        QueryType = New DataGridViewTextBoxColumn()
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
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridView1.BackgroundColor = Color.White
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.Tomato
        DataGridViewCellStyle1.Font = New Font("Bahnschrift", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.NullValue = "Hello"
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {QueryType, AppointmentID, QueryDate, Description, Status, View})
        DataGridView1.Cursor = Cursors.Hand
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Bahnschrift", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        DataGridView1.EnableHeadersVisualStyles = False
        DataGridView1.GridColor = SystemColors.HighlightText
        DataGridView1.Location = New Point(254, 236)
        DataGridView1.MultiSelect = False
        DataGridView1.Name = "DataGridView1"
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 51
        DataGridView1.ScrollBars = ScrollBars.None
        DataGridView1.Size = New Size(1103, 174)
        DataGridView1.TabIndex = 2
        ' 
        ' QueryType
        ' 
        QueryType.HeaderText = "Query Type"
        QueryType.MinimumWidth = 6
        QueryType.Name = "QueryType"
        QueryType.ReadOnly = True
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
        ' Queries_Customer
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1706, 1100)
        ControlBox = False
        Controls.Add(DataGridView1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4, 3, 4, 3)
        Name = "Queries_Customer"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents QueryType As DataGridViewTextBoxColumn
    Friend WithEvents AppointmentID As DataGridViewTextBoxColumn
    Friend WithEvents QueryDate As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents View As DataGridViewButtonColumn
End Class

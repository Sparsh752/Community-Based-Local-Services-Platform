<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Homepage_Customer
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
        Panel1 = New Panel()
        SearchBtn = New Button()
        TrackBar1 = New TrackBar()
        Label4 = New Label()
        ComboBox1 = New ComboBox()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        MaxCostBox = New TextBox()
        MinCostBox = New TextBox()
        priceLabel = New Label()
        searchBox = New TextBox()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        CType(TrackBar1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(SearchBtn)
        Panel1.Controls.Add(TrackBar1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(MaxCostBox)
        Panel1.Controls.Add(MinCostBox)
        Panel1.Controls.Add(priceLabel)
        Panel1.Controls.Add(searchBox)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(362, 813)
        Panel1.TabIndex = 0
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.Tomato
        SearchBtn.FlatStyle = FlatStyle.Popup
        SearchBtn.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        SearchBtn.ForeColor = Color.White
        SearchBtn.Location = New Point(102, 653)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(117, 53)
        SearchBtn.TabIndex = 12
        SearchBtn.Text = "Search"
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' TrackBar1
        ' 
        TrackBar1.LargeChange = 1
        TrackBar1.Location = New Point(42, 547)
        TrackBar1.Maximum = 5
        TrackBar1.Name = "TrackBar1"
        TrackBar1.Size = New Size(249, 56)
        TrackBar1.TabIndex = 0
        TrackBar1.TickStyle = TickStyle.TopLeft
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 16F)
        Label4.Location = New Point(30, 485)
        Label4.Name = "Label4"
        Label4.Size = New Size(94, 37)
        Label4.TabIndex = 11
        Label4.Text = "Rating"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 10.8F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(42, 404)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(281, 33)
        ComboBox1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16F)
        Label3.Location = New Point(30, 364)
        Label3.Name = "Label3"
        Label3.Size = New Size(119, 37)
        Label3.TabIndex = 10
        Label3.Text = "Location"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(185, 257)
        Label2.Name = "Label2"
        Label2.Size = New Size(42, 23)
        Label2.TabIndex = 9
        Label2.Text = "Max"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(42, 257)
        Label1.Name = "Label1"
        Label1.Size = New Size(39, 23)
        Label1.TabIndex = 8
        Label1.Text = "Min"
        ' 
        ' MaxCostBox
        ' 
        MaxCostBox.BorderStyle = BorderStyle.FixedSingle
        MaxCostBox.Font = New Font("Segoe UI", 10.8F)
        MaxCostBox.Location = New Point(185, 283)
        MaxCostBox.Name = "MaxCostBox"
        MaxCostBox.Size = New Size(106, 31)
        MaxCostBox.TabIndex = 7
        ' 
        ' MinCostBox
        ' 
        MinCostBox.BorderStyle = BorderStyle.FixedSingle
        MinCostBox.Font = New Font("Segoe UI", 10.8F)
        MinCostBox.Location = New Point(42, 283)
        MinCostBox.Name = "MinCostBox"
        MinCostBox.Size = New Size(106, 31)
        MinCostBox.TabIndex = 6
        ' 
        ' priceLabel
        ' 
        priceLabel.AutoSize = True
        priceLabel.Font = New Font("Segoe UI", 16F)
        priceLabel.Location = New Point(30, 220)
        priceLabel.Name = "priceLabel"
        priceLabel.Size = New Size(74, 37)
        priceLabel.TabIndex = 0
        priceLabel.Text = "Price"
        ' 
        ' searchBox
        ' 
        searchBox.BorderStyle = BorderStyle.FixedSingle
        searchBox.Font = New Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        searchBox.Location = New Point(30, 101)
        searchBox.Name = "searchBox"
        searchBox.Size = New Size(293, 47)
        searchBox.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(362, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1003, 813)
        Panel2.TabIndex = 1
        ' 
        ' Homepage_Customer
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.WhiteSmoke
        ClientSize = New Size(1365, 813)
        ControlBox = False
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Name = "Homepage_Customer"
        StartPosition = FormStartPosition.CenterParent
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(TrackBar1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents searchBox As TextBox
    Friend WithEvents priceLabel As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MaxCostBox As TextBox
    Friend WithEvents MinCostBox As TextBox
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents SearchBtn As Button
End Class
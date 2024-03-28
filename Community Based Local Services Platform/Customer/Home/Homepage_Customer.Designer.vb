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
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        priceLabel = New Label()
        Button4 = New Button()
        Button5 = New Button()
        Button6 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        searchBox = New TextBox()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        CType(TrackBar1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(Button5)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(SearchBtn)
        Panel1.Controls.Add(TrackBar1)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(priceLabel)
        Panel1.Controls.Add(searchBox)
        Panel1.Location = New Point(-4, -2)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(326, 698)
        Panel1.TabIndex = 0
        ' 
        ' SearchBtn
        ' 
        SearchBtn.BackColor = Color.Tomato
        SearchBtn.FlatStyle = FlatStyle.Popup
        SearchBtn.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        SearchBtn.ForeColor = Color.White
        SearchBtn.Location = New Point(95, 556)
        SearchBtn.Margin = New Padding(3, 2, 3, 2)
        SearchBtn.Name = "SearchBtn"
        SearchBtn.Size = New Size(102, 40)
        SearchBtn.TabIndex = 12
        SearchBtn.Text = "Search"
        SearchBtn.UseVisualStyleBackColor = False
        ' 
        ' TrackBar1
        ' 
        TrackBar1.Location = New Point(43, 476)
        TrackBar1.Margin = New Padding(3, 2, 3, 2)
        TrackBar1.Name = "TrackBar1"
        TrackBar1.Size = New Size(218, 45)
        TrackBar1.TabIndex = 0
        TrackBar1.TickFrequency = 2
        TrackBar1.TickStyle = TickStyle.TopLeft
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 16F)
        Label4.Location = New Point(32, 430)
        Label4.Name = "Label4"
        Label4.Size = New Size(74, 30)
        Label4.TabIndex = 11
        Label4.Text = "Rating"
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Segoe UI", 10.8F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(43, 369)
        ComboBox1.Margin = New Padding(3, 2, 3, 2)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(218, 27)
        ComboBox1.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 16F)
        Label3.Location = New Point(32, 339)
        Label3.Name = "Label3"
        Label3.Size = New Size(94, 30)
        Label3.TabIndex = 10
        Label3.Text = "Location"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10F)
        Label2.Location = New Point(168, 259)
        Label2.Name = "Label2"
        Label2.Size = New Size(35, 19)
        Label2.TabIndex = 9
        Label2.Text = "Max"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10F)
        Label1.Location = New Point(43, 259)
        Label1.Name = "Label1"
        Label1.Size = New Size(33, 19)
        Label1.TabIndex = 8
        Label1.Text = "Min"
        ' 
        ' TextBox2
        ' 
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Font = New Font("Segoe UI", 10.8F)
        TextBox2.Location = New Point(168, 278)
        TextBox2.Margin = New Padding(3, 2, 3, 2)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(93, 27)
        TextBox2.TabIndex = 7
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Segoe UI", 10.8F)
        TextBox1.Location = New Point(43, 278)
        TextBox1.Margin = New Padding(3, 2, 3, 2)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(93, 27)
        TextBox1.TabIndex = 6
        ' 
        ' priceLabel
        ' 
        priceLabel.AutoSize = True
        priceLabel.Font = New Font("Segoe UI", 16F)
        priceLabel.Location = New Point(32, 231)
        priceLabel.Name = "priceLabel"
        priceLabel.Size = New Size(60, 30)
        priceLabel.TabIndex = 0
        priceLabel.Text = "Price"
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(32, 179)
        Button4.Margin = New Padding(3, 2, 3, 2)
        Button4.Name = "Button4"
        Button4.Size = New Size(75, 22)
        Button4.TabIndex = 5
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = True
        Button4.Visible = False
        ' 
        ' Button5
        ' 
        Button5.Location = New Point(113, 179)
        Button5.Margin = New Padding(3, 2, 3, 2)
        Button5.Name = "Button5"
        Button5.Size = New Size(75, 22)
        Button5.TabIndex = 4
        Button5.Text = "Button5"
        Button5.UseVisualStyleBackColor = True
        Button5.Visible = False
        ' 
        ' Button6
        ' 
        Button6.Location = New Point(193, 179)
        Button6.Margin = New Padding(3, 2, 3, 2)
        Button6.Name = "Button6"
        Button6.Size = New Size(75, 22)
        Button6.TabIndex = 3
        Button6.Text = "Button6"
        Button6.UseVisualStyleBackColor = True
        Button6.Visible = False
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(193, 153)
        Button3.Margin = New Padding(3, 2, 3, 2)
        Button3.Name = "Button3"
        Button3.Size = New Size(75, 22)
        Button3.TabIndex = 2
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = True
        Button3.Visible = False
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(113, 153)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 22)
        Button2.TabIndex = 1
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = True
        Button2.Visible = False
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(32, 153)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 22)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        Button1.Visible = False
        ' 
        ' searchBox
        ' 
        searchBox.BorderStyle = BorderStyle.FixedSingle
        searchBox.Font = New Font("Segoe UI", 11.5F)
        searchBox.Location = New Point(32, 98)
        searchBox.Margin = New Padding(3, 2, 3, 2)
        searchBox.Name = "searchBox"
        searchBox.Size = New Size(257, 28)
        searchBox.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.Location = New Point(328, -2)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(869, 698)
        Panel2.TabIndex = 1
        ' 
        ' Homepage_Customer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1194, 610)
        ControlBox = False
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(3, 2, 3, 2)
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
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents SearchBtn As Button
End Class
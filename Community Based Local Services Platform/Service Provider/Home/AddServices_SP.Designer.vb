<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddServices_SP
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Service_Name = New TextBox()
        Service_type = New ComboBox()
        Description = New TextBox()
        PictureBox1 = New PictureBox()
        Submit_add = New Button()
        Price = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        Service_area = New ComboBox()
        Panel1 = New Panel()
        Location_list = New ListView()
        BackButton = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift SemiBold", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(55, 48)
        Label1.Name = "Label1"
        Label1.Size = New Size(276, 41)
        Label1.TabIndex = 0
        Label1.Text = "Add New Service"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label2.Location = New Point(55, 97)
        Label2.Name = "Label2"
        Label2.Size = New Size(231, 41)
        Label2.TabIndex = 1
        Label2.Text = "Service Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Bahnschrift Light", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(55, 406)
        Label3.Name = "Label3"
        Label3.Size = New Size(149, 41)
        Label3.TabIndex = 2
        Label3.Text = "Location"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label4.Location = New Point(57, 276)
        Label4.Name = "Label4"
        Label4.Size = New Size(202, 41)
        Label4.TabIndex = 3
        Label4.Text = "Description "
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label5.Location = New Point(55, 176)
        Label5.Name = "Label5"
        Label5.Size = New Size(209, 41)
        Label5.TabIndex = 4
        Label5.Text = "Service Type"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Bahnschrift Light", 19.8000011F)
        Label6.Location = New Point(716, 299)
        Label6.Name = "Label6"
        Label6.Size = New Size(97, 41)
        Label6.TabIndex = 5
        Label6.Text = "Price"
        ' 
        ' Service_Name
        ' 
        Service_Name.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Service_Name.BorderStyle = BorderStyle.FixedSingle
        Service_Name.Location = New Point(57, 120)
        Service_Name.Name = "Service_Name"
        Service_Name.Size = New Size(278, 27)
        Service_Name.TabIndex = 0
        ' 
        ' Service_type
        ' 
        Service_type.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Service_type.DropDownStyle = ComboBoxStyle.DropDownList
        Service_type.FlatStyle = FlatStyle.System
        Service_type.FormattingEnabled = True
        Service_type.Location = New Point(55, 199)
        Service_type.Name = "Service_type"
        Service_type.Size = New Size(280, 28)
        Service_type.TabIndex = 3
        ' 
        ' Description
        ' 
        Description.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Description.BorderStyle = BorderStyle.FixedSingle
        Description.Location = New Point(55, 299)
        Description.Multiline = True
        Description.Name = "Description"
        Description.Size = New Size(118, 37)
        Description.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resource1.Upload_img
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(716, 48)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(327, 152)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Submit_add
        ' 
        Submit_add.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Submit_add.BackgroundImageLayout = ImageLayout.None
        Submit_add.FlatStyle = FlatStyle.Popup
        Submit_add.Font = New Font("Bahnschrift Light", 12F)
        Submit_add.ForeColor = Color.White
        Submit_add.Location = New Point(716, 453)
        Submit_add.Name = "Submit_add"
        Submit_add.Size = New Size(94, 29)
        Submit_add.TabIndex = 9
        Submit_add.Text = "Submit"
        Submit_add.UseVisualStyleBackColor = False
        ' 
        ' Price
        ' 
        Price.BackColor = Color.FromArgb(CByte(249), CByte(249), CByte(249))
        Price.BorderStyle = BorderStyle.FixedSingle
        Price.Location = New Point(716, 322)
        Price.Name = "Price"
        Price.Size = New Size(118, 27)
        Price.TabIndex = 10
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button1.BackgroundImageLayout = ImageLayout.None
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Font = New Font("Bahnschrift Light", 12F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(279, 550)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 12
        Button1.Text = "Clear"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(249), CByte(117), CByte(75))
        Button2.BackgroundImageLayout = ImageLayout.None
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Font = New Font("Bahnschrift Light", 12F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(57, 550)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 13
        Button2.Text = "Add"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Service_area
        ' 
        Service_area.DropDownStyle = ComboBoxStyle.DropDownList
        Service_area.FlatStyle = FlatStyle.System
        Service_area.FormattingEnabled = True
        Service_area.Location = New Point(55, 469)
        Service_area.Name = "Service_area"
        Service_area.Size = New Size(226, 28)
        Service_area.TabIndex = 15
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Location = New Point(695, 427)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(424, 14)
        Panel1.TabIndex = 18
        ' 
        ' Location_list
        ' 
        Location_list.LabelWrap = False
        Location_list.Location = New Point(716, 387)
        Location_list.Name = "Location_list"
        Location_list.Size = New Size(357, 51)
        Location_list.TabIndex = 17
        Location_list.UseCompatibleStateImageBehavior = False
        Location_list.View = View.List
        ' 
        ' BackButton
        ' 
        BackButton.FlatStyle = FlatStyle.Flat
        BackButton.Location = New Point(540, 62)
        BackButton.Margin = New Padding(3, 2, 3, 2)
        BackButton.Name = "BackButton"
        BackButton.Size = New Size(150, 40)
        BackButton.TabIndex = 88
        BackButton.Text = "Back"
        BackButton.UseVisualStyleBackColor = True
        ' 
        ' AddServices_SP
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1182, 653)
        ControlBox = False
        Controls.Add(BackButton)
        Controls.Add(Panel1)
        Controls.Add(Location_list)
        Controls.Add(Service_area)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Price)
        Controls.Add(Submit_add)
        Controls.Add(PictureBox1)
        Controls.Add(Description)
        Controls.Add(Service_type)
        Controls.Add(Service_Name)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "AddServices_SP"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Service_Name As TextBox
    Friend WithEvents Service_type As ComboBox
    Friend WithEvents Description As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Submit_add As Button
    Friend WithEvents Price As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Service_area As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Location_list As ListView
    Friend WithEvents BackButton As Button

End Class
